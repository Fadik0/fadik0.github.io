using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using WebSocketSharp;
using System.Diagnostics;
using tag = TagLib;
using System.Threading;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Xml;
using System.Threading.Tasks;

namespace AssistantBroadcasts
{
    public partial class Form_main : Form
    {
        private ProgramData program_data = new ProgramData();
        private UserData user_data = new UserData();
        private SessionData session_data = new SessionData() {
            gg_users = new List<GoodGameUsers>(),
            twitch_users = new List<string>(),
            vidi_users = new List<GoodGameUsers>() 
        };
        private СacheData cache_data = new СacheData() {
            donations = new List<Donation>(),
            gg_followers = new List<Follower>(),
            gg_subscribers = new List<Subscribers>(),
            t_followers = new List<Follower>(),
            t_subscribers = new List<Subscribers>()
        };
        private WebSocket WebSocket_GoodGame;
        private WebSocket WebSocket_VIDI;
        private WebSocket WebSocket_Twitch;
        private WebSocket WebSocket_TwitchPrivate;
        private static comboBoxItem[] cBoxItems;
        static string path_my_doc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static string directory_app = "\\Assistant Broadcasts";
        bool key_now = false;
        System.Windows.Forms.Timer timer_task = new System.Windows.Forms.Timer();    
        Random rnd = new Random();

        System.Windows.Forms.Timer timer_vote_media = new System.Windows.Forms.Timer();
        string[] media_files;
        string location_media = string.Empty;
   
        string vk_status = string.Empty;
        string vk_token = string.Empty;
        string vk_id = string.Empty;
                    
        List<string> system_log = new List<string>();
        Form_Logs log = new Form_Logs();
        List<string> gg_favourites_streamer = null;
        List<string> twitch_favourites_streamer = null;
        string push_url = string.Empty;

        public Form_main()
        {
            load_settings();

            if (program_data.language.IsNullOrEmpty())
            {
                DialogResult res = MessageBox.Show(Properties.Resources.question_ru_lang, Properties.Resources.name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
                    program_data.language = "ru-RU";
                }
                else
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    program_data.language = "en-US";
                }
            }
            else
            {
                try
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(program_data.language);
                }
                catch (Exception e)
                {
                    sys_log("new CultureInfo " + e.Message);
                }
            }
            sys_log("Current language: " + program_data.language);
            cBoxItems = new comboBoxItem[] {
                new comboBoxItem(Properties.Resources.ed_commands, "COMMANDS"),
                new comboBoxItem(Properties.Resources.ed_labels, "LABELS"),          
                /*new comboBoxItem(Properties.Resources.ed_spells, "SPELLS"),
                new comboBoxItem(Properties.Resources.ed_alerts, "ALERTS"),*/
                new comboBoxItem("Notification", "NOTIFICATIONS"),
                new comboBoxItem(Properties.Resources.ed_quests, "QUESTS")
            };

            Notification n = new Notification();
            n.name = "donat";
            n.description = "донат на гг";
            program_data.notifications.Add(n); 

            InitializeComponent();
            this.lb_ver.Text = System.Windows.Forms.Application.ProductVersion;
            this.menuToolStripMenuItem.Text = Properties.Resources.menu;
            this.accountsToolStripMenuItem.Text = Properties.Resources.accounts;

            cBox_editable_data.Items.AddRange(cBoxItems);
            cBox_editable_data.ComboBox.DisplayMember = "name";
            cBox_editable_data.SelectedIndex = 0;
            listB_Object.DisplayMember = "name";

            session_data.vidi_bot_id = "982";
            session_data.vidi_bot_token = "DwvgPLc9hn4up6Mr";

            session_data.gg_bot_id = "363283";
            if (program_data.isGGBot)                
                session_data.gg_bot_token = "b27eea10e68e152010a191d7a48cfff1";

            session_data.twitch_bot_id = "wonderfulbot";
            if (program_data.isTwitchBot)                
                session_data.twitch_bot_token = "1kpldqj75kxvtaj29ih5hd792hzv0q";


            timer_task.Interval = 60000;
            timer_task.Tick += (sender1, e1) =>
            {
                if (!string.IsNullOrEmpty(user_data.lastfm_user))
               { 
                    new Task(getLastFM).Start();
                }
                if (vKToolStripMenuItem.Checked)
                {
                    new Thread(getStatusVK).Start();
                }               
                if (!string.IsNullOrEmpty(user_data.twitch_channel_id))
                {
                    new Task(getStatusTwitch).Start();
                    new Task(getTwitchUsers).Start();
                }
                if (!string.IsNullOrEmpty(user_data.gg_channel_id))
                {
                    new Task(getStatusGG).Start();
                }
                if (program_data.labels.Count > 0 && !string.IsNullOrEmpty(user_data.twitch_channel_id) && !string.IsNullOrEmpty(user_data.twitch_user_token))
                {
                    new Task(getGoodGameDonations).Start();
                    new Task(getGoodGameFollowers).Start();
                    new Task(getGoodGamePremiums).Start();
                }
                if (program_data.labels.Count > 0 && !string.IsNullOrEmpty(user_data.gg_channel_id) && !string.IsNullOrEmpty(user_data.gg_user_token))
                {
                    new Task(getTwitchFollowers).Start();
                    new Task(getTwitchSubscribers).Start();
                }
                if (program_data.wn_notify)
                {
                    pushNotify();
                }
                if (WebSocket_VIDI.IsAlive)
                    WebSocket_VIDI.Send("{\"type\":\"get_users_list2\",\"data\":{\"channel_id\":\"" + user_data.vidi_channel_id + "\"}}");
                if (!WebSocket_VIDI.IsAlive && program_data.vidi_chat)
                {
                    VidiChat();
                    sys_log("Vidi Chat, Reconnect");
                }
                if (!WebSocket_TwitchPrivate.IsAlive && program_data.twitch_private_chat)
                {
                    TwitchPrivateChat();
                    sys_log("Twitch Private Chat, Reconnect");
                }
                if (!WebSocket_Twitch.IsAlive && program_data.twitch_chat)
                {
                    TwitchChat();
                    sys_log("Twitch Chat, Reconnect");
                }
                if (!WebSocket_GoodGame.IsAlive && program_data.gg_chat)
                {
                    GoodGameChat();
                    sys_log("GoodGame Chat, Reconnect");
                }
                new Task(updateLabels).Start();
                new Task(SendPeriodicMessage).Start();
                log.tB_Log.Lines = system_log.ToArray();
                log.tB_Log.Select(log.tB_Log.Text.Length, 0);
                log.tB_Log.ScrollToCaret();
            };

            WebSocket_GoodGame = new WebSocket("ws://chat.goodgame.ru:8081/chat/websocket", new string[0]);
            WebSocket_GoodGame.OnMessage += (sender, e) => WebSocket_GoodGame_OnMessege(sender, e);
            WebSocket_GoodGame.OnError += (sender, e) => WebSocket_GoodGame_OnError(sender, e);
            WebSocket_GoodGame.OnClose += (sender, e) => WebSocket_GoodGame_OnClose(sender, e);
            WebSocket_GoodGame.OnOpen += (sender, e) => WebSocket_GoodGame_OnOpen(sender, e);
            WebSocket_GoodGame.Origin = "http://goodgame.ru";

            WebSocket_VIDI = new WebSocket("ws://chat.ottnow.ru:443/chat/websocket", new string[0]);
            WebSocket_VIDI.OnMessage += (sender, e) => WebSocket_VIDI_OnMessege(sender, e);
            WebSocket_VIDI.OnError += (sender, e) => WebSocket_VIDI_OnError(sender, e);
            WebSocket_VIDI.OnClose += (sender, e) => WebSocket_VIDI_OnClose(sender, e);
            WebSocket_VIDI.OnOpen += (sender, e) => WebSocket_VIDI_OnOpen(sender, e);

            WebSocket_Twitch = new WebSocket("ws://irc-ws.chat.twitch.tv:80", new string[0]);
            WebSocket_Twitch.OnMessage += (sender, e) => WebSocket_Twitch_OnMessege(sender, e);
            WebSocket_Twitch.OnError += (sender, e) => WebSocket_Twitch_OnError(sender, e);
            WebSocket_Twitch.OnClose += (sender, e) => WebSocket_Twitch_OnClose(sender, e);
            WebSocket_Twitch.OnOpen += (sender, e) => WebSocket_Twitch_OnOpen(sender, e);

            WebSocket_TwitchPrivate = new WebSocket("ws://199.9.253.119:80", new string[0]);
            WebSocket_TwitchPrivate.OnMessage += (sender, e) => WebSocket_TwitchPrivate_OnMessege(sender, e);
            WebSocket_TwitchPrivate.OnError += (sender, e) => WebSocket_TwitchPrivate_OnError(sender, e);
            WebSocket_TwitchPrivate.OnClose += (sender, e) => WebSocket_TwitchPrivate_OnClose(sender, e);
            WebSocket_TwitchPrivate.OnOpen += (sender, e) => WebSocket_TwitchPrivate_OnOpen(sender, e);

            if (!string.IsNullOrEmpty(user_data.gg_user_id) && !string.IsNullOrEmpty(user_data.gg_user_token) && !string.IsNullOrEmpty(user_data.gg_user_refresh_token))
            {
                ggToolStripMenuItem.Checked = true;
            }
            if (!string.IsNullOrEmpty(user_data.gg_bot_id) && !string.IsNullOrEmpty(user_data.gg_bot_token) && !string.IsNullOrEmpty(user_data.gg_bot_refresh_token))
            {
                ggBotToolStripMenuItem.Checked = true;
            }
            if (!string.IsNullOrEmpty(user_data.twitch_user_id) && !string.IsNullOrEmpty(user_data.twitch_user_token) && !string.IsNullOrEmpty(user_data.twitch_user_refresh_token) && !string.IsNullOrEmpty(user_data.twitch_channel_id))
            {
                twitchToolStripMenuItem.Checked = true;
            }
            if (!string.IsNullOrEmpty(user_data.twitch_bot_id) && !string.IsNullOrEmpty(user_data.twitch_bot_token) && !string.IsNullOrEmpty(user_data.twitch_bot_refresh_token))
            {
                twitchBotToolStripMenuItem.Checked = true;                
            }
            if (!string.IsNullOrEmpty(user_data.lastfm_user))
                lastfmToolStripMenuItem.Checked = true;           
            if (!string.IsNullOrEmpty(user_data.vidi_channel_id))
            {
                VidiChat();
                vidiToolStripMenuItem.Checked = true;
                vidiChatToolStripMenuItem.Checked = true;

            }
            bool check_user = !string.IsNullOrEmpty(user_data.gg_user_id) && !string.IsNullOrEmpty(user_data.gg_user_token) && !string.IsNullOrEmpty(user_data.gg_channel_id);
            if (check_user && program_data.gg_chat)
            {
                GoodGameChat();
                goodGameToolStripMenuItem.Checked = true;
                goodgameChatToolStripMenuItem.Checked = true;
            }

            check_user = !string.IsNullOrEmpty(user_data.twitch_user_id) && !string.IsNullOrEmpty(user_data.twitch_user_token) && !string.IsNullOrEmpty(user_data.twitch_channel_id);
            if (check_user && program_data.twitch_chat)
            {
                TwitchChat();
                chatTwitchToolStripMenuItem.Checked = true;
                twitchChatToolStripMenuItem.Checked = true;
            }
            if (check_user && program_data.twitch_private_chat)
            {
                TwitchPrivateChat();
                twitchPrivateToolStripMenuItem.Checked = true;
                twitchPrivateChatToolStripMenuItem.Checked = true;
            }

            DataAccess data = null;
            if (!string.IsNullOrEmpty(user_data.gg_user_refresh_token))
            {
                data = refreshGoodGameToken(user_data.gg_user_refresh_token);
                if (data != null)
                {
                    user_data.gg_user_token = data.access_token;
                    user_data.gg_user_refresh_token = data.refresh_token;
                    sys_log(string.Format("GG User Update Access Token: {0}", user_data.gg_user_token));
                    sys_log(string.Format("GG User Update Refresh Token: {0}", user_data.gg_user_refresh_token));
                }
                else
                    sys_log(string.Format("GG User Update Access Token: {0}", "Нужно перезайти на аккаунт пользователя GoodGame"));
            }
            data = null;
            if (!string.IsNullOrEmpty(user_data.gg_bot_refresh_token))
            {
                data = refreshGoodGameToken(user_data.gg_bot_refresh_token);
                if (data != null)
                {
                    user_data.gg_bot_token = data.access_token;
                    user_data.gg_bot_refresh_token = data.refresh_token;
                    sys_log(string.Format("GG Bot Update Access Token: {0}", user_data.gg_bot_token));
                    sys_log(string.Format("GG Bot Update Refresh Token: {0}", user_data.gg_bot_refresh_token));
                }
                else
                    sys_log(string.Format("GG Bot Update Access Token: {0}", "Нужно перезайти на аккаунт бота GoodGame"));
            }

        }

        private void Form_main_Load(object sender, EventArgs e)
        {           
            timer_task.Start();            
        }

        private void getTwitchUsers()
        {
            string channel = user_data.twitch_channel_id;
            if (!string.IsNullOrEmpty(program_data.twitch_custom_channel))
                channel = program_data.twitch_custom_channel;
            string data = GET(string.Format("http://tmi.twitch.tv/group/user/{0}/chatters", channel));
            if (!string.IsNullOrEmpty(data))
            {

                TwitchUsers data_users = JsonConvert.DeserializeObject<TwitchUsers>(data);
                if (data_users.chatter_count != session_data.twitch_users.Count)
                    sys_log(string.Format("Twitch Update Users Count: {0}", data_users.chatter_count.ToString()));
                session_data.twitch_users.Clear();
                session_data.twitch_users.AddRange(data_users.chatters.viewers);
                session_data.twitch_users.AddRange(data_users.chatters.moderators);             
            }
        }

        private void pushNotify()
        {            
            string text = string.Empty;
            if (string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(user_data.gg_user_id))
            {
                string data_gg = GET(string.Format("http://goodgame.ru/api/getggchannels?user={0}", user_data.gg_user_id));
                if (!string.IsNullOrEmpty(data_gg))
                {
                    ApiGGChannels data_channels = JsonConvert.DeserializeObject<ApiGGChannels>(data_gg);
                    if (gg_favourites_streamer == null)
                        gg_favourites_streamer = data_channels.channels.Where(x => string.Equals(x.favourite, "1")).Select(x => x.streamer).ToList();
                    else
                        gg_favourites_streamer = data_channels.channels.Where(x => string.Equals(x.favourite, "1")).Where(x => gg_favourites_streamer.Contains(x.streamer)).Select(x => x.streamer).ToList();
                    List<ApiGGChannel> list = data_channels.channels.Where(x => string.Equals(x.favourite, "1")).Where(x => !gg_favourites_streamer.Contains(x.streamer)).ToList();
                    if (list.Count > 0)
                    {
                        text = list[0].streamer + " начал стрим по " + list[0].games.title + " на " + Properties.Resources.goodgame;
                        gg_favourites_streamer.Add(list[0].streamer);
                        push_url = "http://goodgame.ru/" + list[0].key;
                        sys_log(text);
                    }
                }
            }
            if (string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(user_data.twitch_user_token))
            {
                string data_twitch = GET(string.Format("https://api.twitch.tv/kraken/streams/followed?limit=100&oauth_token={0}", user_data.twitch_user_token));
                if (!string.IsNullOrEmpty(data_twitch))
                {
                    ApiTwitchFollowed data_channels = JsonConvert.DeserializeObject<ApiTwitchFollowed>(data_twitch);
                    if (twitch_favourites_streamer == null)
                        twitch_favourites_streamer = data_channels.streams.Select(x => x.channel.name).ToList();
                    else
                        twitch_favourites_streamer = data_channels.streams.Where(x => twitch_favourites_streamer.Contains(x.channel.name)).Select(x => x.channel.name).ToList();
                    List<ApiTwitchStream> list = data_channels.streams.Where(x => !twitch_favourites_streamer.Contains(x.channel.name)).ToList();
                    if (list.Count > 0)
                    {
                        text = list[0].channel.display_name + " начал стрим по " + list[0].game + " на " + Properties.Resources.twitch;
                        twitch_favourites_streamer.Add(list[0].channel.name);
                        push_url = list[0].channel.url;
                        sys_log(text);
                    }
                }
            }
            if (notifyIcon.Visible && !string.IsNullOrEmpty(text))
                notifyIcon.ShowBalloonTip(20000, "Watch Now" , text, ToolTipIcon.Info);
        }

        private void getGoodGameDonations()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();           
            int i = 1;
            int count = 1;
            int old_count = cache_data.donations.Count();
            cache_data.donations.Clear();
            while (i <= count)
            {
                string data = GET(string.Format("http://api2.goodgame.ru/channel/" + user_data.gg_channel_id + "/donations?access_token=" + user_data.gg_user_token + "&page=" + i.ToString()));
                if (!string.IsNullOrEmpty(data))
                {
                    GoodGameApiData data_donations = JsonConvert.DeserializeObject<GoodGameApiData>(data);
                    count = data_donations.page_count;
                    i++;
                    try
                    {
                        cache_data.donations.AddRange(data_donations._embedded.donations.Select(x => new Donation()
                        {
                            username = x.username,
                            id = x.id,
                            comment = x.comment,
                            amount = Double.Parse(x.amount.Replace(".", ",")),
                            date = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(int.Parse(x.paid_date))
                        }).ToList());
                    }
                    catch (Exception e)
                    {
                        sys_log(e.Message);
                    }                              
                }
            }           
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            if (old_count != cache_data.donations.Count)
                sys_log(string.Format("GoodGame Update Donations: {0} - {1}", cache_data.donations.Count.ToString(), ts.TotalMilliseconds));          
        }

        private void getGoodGameFollowers()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int i = 1;
            int count = 1;
            int old_count = cache_data.gg_followers.Count();
            cache_data.gg_followers.Clear();
            while (i <= count)
            {
                string data = GET(string.Format("http://api2.goodgame.ru/channel/" + user_data.gg_channel_id + "/subscribers?access_token=" + user_data.gg_user_token + "&page=" + i.ToString()));
                if (!string.IsNullOrEmpty(data))
                {
                    GoodGameApiData data_followers = JsonConvert.DeserializeObject<GoodGameApiData>(data);
                    count = data_followers.page_count;
                    i++;
                    try
                    {
                        cache_data.gg_followers.AddRange(data_followers._embedded.subscribers.Select(x => new Follower()
                        {
                            username = x.username,
                            id = x.id,
                            date = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(int.Parse(x.created_at))
                        }).ToList());
                    }
                    catch (Exception e)
                    {
                        sys_log(e.Message);
                    }
                }
            }
            updateLabels();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            if (old_count != cache_data.gg_followers.Count)
                sys_log(string.Format("GoodGame Update Followers: {0} - {1}", cache_data.gg_followers.Count.ToString(), ts.TotalMilliseconds));
        }

        private void getGoodGamePremiums()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int i = 1;
            int count = 1;
            int old_count = cache_data.gg_subscribers.Count();
            cache_data.gg_subscribers.Clear();
            while (i <= count)
            {
                string data = GET(string.Format("http://api2.goodgame.ru/channel/" + user_data.gg_channel_id + "/premiums?access_token=" + user_data.gg_user_token + "&page=" + i.ToString()));
                if (!string.IsNullOrEmpty(data))
                {                    
                    GoodGameApiData data_followers = JsonConvert.DeserializeObject<GoodGameApiData>(data);
                    count = data_followers.page_count;
                    i++;
                    try
                    {
                        cache_data.gg_subscribers.AddRange(data_followers._embedded.premiums.Select(x => new Subscribers()
                        {
                            username = x.username,
                            id = x.id,
                            date = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(int.Parse(x.started_at))
                        }).ToList());
                    }
                    catch (Exception e)
                    {
                        sys_log(e.Message);
                    }
                }
            }
            updateLabels();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            if (old_count != cache_data.gg_subscribers.Count)
                sys_log(string.Format("GoodGame Update Subscribers: {0} - {1}", cache_data.gg_subscribers.Count.ToString(), ts.TotalMilliseconds));
        }

        private void getTwitchFollowers()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string i = string.Empty;
            int count = 300;
            int old_count = cache_data.t_followers.Count();
            cache_data.t_followers = new List<Follower>();
            while (1 <= count)
            {
                string data = GET(string.Format("https://api.twitch.tv/kraken/channels/{0}/follows?direction=DESC&limit=100&cursor={1}", user_data.twitch_channel_id, i));
                if (!string.IsNullOrEmpty(data))
                {
                    TwitchApiData data_followers = JsonConvert.DeserializeObject<TwitchApiData>(data);
                    if (string.IsNullOrEmpty(i) && data_followers._total < 300)
                        count = data_followers._total;
                    i = data_followers._cursor;
                    count -= data_followers.follows.Count();
                    try
                    {
                        cache_data.t_followers.AddRange(data_followers.follows.Select(x => new Follower()
                        {
                            username = x.user.name,
                            id = x.user._id.ToString(),
                            date = DateTime.Parse(x.created_at)
                        }).ToList());
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            updateLabels();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            if (old_count != cache_data.t_followers.Count)
                sys_log(string.Format("Twitch Update Followers: {0} - {1}", cache_data.t_followers.Count.ToString(), ts.TotalMilliseconds));
        }

        private void getTwitchSubscribers()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int i = 0;
            int count = 0;
            int old_count = cache_data.t_subscribers.Count();
            cache_data.t_subscribers = new List<Subscribers>();
            while (i <= count)
            {
                string data = GET(string.Format("https://api.twitch.tv/kraken/channels/{0}/subscriptions?direction=DESC&limit=100&offset={1}&oauth_token={2}", user_data.twitch_channel_id, i, user_data.twitch_user_token));
                if (!string.IsNullOrEmpty(data))
                {
                    TwitchApiData data_subscribers = JsonConvert.DeserializeObject<TwitchApiData>(data);
                    if (count == 0)
                        count = data_subscribers._total;
                    i += data_subscribers.subscriptions.Count();
                    try
                    {
                        cache_data.t_subscribers.AddRange(data_subscribers.subscriptions.Select(x => new Subscribers()
                        {
                            username = x.user.name,
                            id = x.user._id.ToString(),
                            date = DateTime.Parse(x.created_at)
                        }).ToList());
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            updateLabels();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            if (old_count != cache_data.t_subscribers.Count)
                sys_log(string.Format("Twitch Update Subscribers: {0} - {1}", cache_data.t_subscribers.Count.ToString(), ts.TotalMilliseconds));
        }

        private string getLabelDonations(DateTime start, DateTime end, int count, string label, string element, bool list, bool top)
        {
            string result = string.Empty;
            double amount = 0;
            var data = cache_data.donations.Where(x => x.date < end).Where(x => x.date > start).Where(x => !String.IsNullOrEmpty(x.username));
            if (top)
                data = data.GroupBy(x => x.username).Select(x => new Donation() {username = x.First().username, amount = x.Sum(y => y.amount)}).OrderByDescending(x => x.amount).Take(count);    
            else
                data = data.OrderByDescending(x => x.date).Take(count);
            foreach (Donation item in data)
            {
                result += (element.Replace("{username}", item.username).Replace("{amount}", item.amount.ToString()));
                if (list) result += Environment.NewLine;
                else result += (" ");
                amount += item.amount;
            }
            result = label.Replace("{elements}", result).Replace("{amount}", amount.ToString());
            return result;
        }

        private string getLabelSubscriders(DateTime start, DateTime end, int count, string label, string element, bool list)
        {
            string result = string.Empty;
            List<Subscribers> data = new List<Subscribers>();
            data.AddRange(cache_data.t_subscribers);
            data.AddRange(cache_data.gg_subscribers);
            data = data.Where(x => x.date < end).Where(x => x.date > start).Where(x => !String.IsNullOrEmpty(x.username)).OrderByDescending(x => x.date).Take(count).ToList();
            foreach (var item in data)
            {
                result += (element.Replace("{username}", item.username));
                if (list) result += Environment.NewLine;
                else result += (" ");
            }
            result = label.Replace("{elements}", result).Replace("{count}", data.ToList().Count.ToString());
            return result;
        }

        private string getLabelFollowers(DateTime start, DateTime end, int count, string label, string element, bool list)
        {
            string result = string.Empty;
            List<Follower> data = new List<Follower>();
            data.AddRange(cache_data.gg_followers);
            data.AddRange(cache_data.t_followers);
            data = data.Where(x => x.date < end).Where(x => x.date > start).Where(x => !String.IsNullOrEmpty(x.username)).OrderByDescending(x => x.date).Take(count).ToList();
            foreach (var item in data)
            {
                result += (element.Replace("{username}", item.username));
                if (list) result += Environment.NewLine;
                else result += (" ");
            }
            result = label.Replace("{elements}", result).Replace("{count}", data.ToList().Count.ToString());
            return result;
        }

        private void updateLabels()
        {
            DateTime date = DateTime.Now;
            DateTime start = date.AddYears(-100);
            DateTime end = date.AddMinutes(5);
            DateTime startweek;
            if ((int)date.DayOfWeek == 0)
                startweek = date.Date.AddDays(1 - 7);
            else
                startweek = date.Date.AddDays(1 - (int)date.DayOfWeek);
            string text = string.Empty;
            foreach (Label item in program_data.labels)
            {               
                switch (item.time)
                {
                    case 1:
                        start = date.Date.AddDays(-30);
                        break;
                    case 2:
                        start = date.Date.AddDays(1 - date.Day);                      
                        break;
                    case 3:
                        start = startweek;
                        break;
                    case 4:
                        start = item.start;
                        end = item.end;
                        break;
                }                
                switch (item.type)
                {
                    case 0:                       
                        text = getLabelDonations(start, end, item.count, item.label, item.element, item.list, false);
                        break;
                    case 1:
                        text = getLabelDonations(start, end, item.count, item.label, item.element, item.list, true);
                        break;
                    case 2:
                        text = getLabelSubscriders(start, end, item.count, item.label, item.element, item.list);
                        break;
                    case 3:
                        text = getLabelFollowers(start, end, item.count, item.label, item.element, item.list);                      
                        break;
                    default:
                        break;
                }
                text = text.Replace("{uptime}", session_data.ggStarted).Replace("{game}", session_data.ggGame);
                text = text.Replace("{lastfm}", session_data.lastfmTrack).Replace("{vk}", vk_status);
                File.WriteAllText(path_my_doc + directory_app + "\\" + item.name + ".txt", text, Encoding.UTF8);
            } 
        }

        private void getStatusGG()
        {
            string channel = user_data.gg_channel_id;
            if (!string.IsNullOrEmpty(program_data.gg_custom_channel))
                channel = program_data.gg_custom_channel;
            string data = GET("http://api2.goodgame.ru/streams/" + channel);
            string old_game = session_data.ggGame;
            string old_time = session_data.ggStarted;
            if (!string.IsNullOrEmpty(data))
            {
                GoodGameStreams data_stream = JsonConvert.DeserializeObject<GoodGameStreams>(data);
                session_data.ggGame = data_stream.channel.games[0].title;
                if (data_stream.is_broadcast)
                    session_data.ggStarted = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(data_stream.broadcast_started).ToShortTimeString();
                if (string.Equals("Dead", data_stream.status))
                    session_data.ggStarted = program_data.text_offline;
                else
                {
                    if (string.IsNullOrEmpty(session_data.ggStarted) && WebSocket_GoodGame.IsAlive)
                    {
                        WebSocket_GoodGame.Send("{\"type\":\"unjoin\",\"data\":{\"channel_id\":\"" + channel + "\",\"hidden\":\"false\"}}");
                        WebSocket_GoodGame.Send("{\"type\":\"join\",\"data\":{\"channel_id\":\"" + channel + "\",\"hidden\":\"false\"}}");
                    }
                }
                if (!string.Equals(session_data.ggGame, old_game) || !string.Equals(session_data.ggStarted, old_time))
                    sys_log(string.Format("GoodGame Update Game: {0}, Uptime: {1}", session_data.ggGame, session_data.ggStarted));
            }
            if (WebSocket_GoodGame.IsAlive)
                WebSocket_GoodGame.Send("{\"type\":\"get_users_list2\",\"data\":{\"channel_id\":\"" + channel + "\"}}");           
        }

        private void getStatusTwitch()
        {
            string channel = user_data.twitch_channel_id;
            if (!string.IsNullOrEmpty(program_data.twitch_custom_channel))
                channel = program_data.twitch_custom_channel;
            string data = GET("https://api.twitch.tv/kraken/streams/" + channel);
            string old_game = session_data.twitchGame;
            string old_time = session_data.twitchStarted;
            if (!string.IsNullOrEmpty(data))
            {
                TwitchStreams data_stream = JsonConvert.DeserializeObject<TwitchStreams>(data);
                if (data_stream.stream != null)
                {
                    session_data.twitchGame = data_stream.stream.game.ToString();
                    session_data.twitchStarted = DateTime.Parse(data_stream.stream.created_at).ToShortTimeString();                                   
                }
                else
                    session_data.twitchStarted = program_data.text_offline;
                if (!string.Equals(session_data.twitchGame, old_game) || !string.Equals(session_data.twitchStarted, old_time))
                    sys_log(string.Format("Twitch Update Game: {0}, Uptime: {1}", session_data.twitchGame, session_data.twitchStarted));
            }
        }

        private void getLastFM()
        {
            string UriString = "http://ws.audioscrobbler.com/2.0/?method=user.getRecentTracks&api_key=bd4e71fb81c3a0bef87caf05be2862d6&limit=1&user=" + user_data.lastfm_user;
            XmlDocument doc = new XmlDocument();
            XmlNodeList nodeList;
            try
            {
                doc.Load(UriString);
                string artist = Properties.Resources.unknown;
                string name = Properties.Resources.unknown;
                nodeList = doc.GetElementsByTagName("artist");
                if (nodeList.Count > 0)
                    artist = nodeList[0].InnerText;
                nodeList = doc.GetElementsByTagName("name");
                if (nodeList.Count > 0)
                    name = nodeList[0].InnerText;
                string track = artist + " - " + name;
                if (!string.Equals(session_data.lastfmTrack, track))
                    sys_log("Last.FM update track: " + track);
                session_data.lastfmTrack = track;               
            }
            catch (Exception e)
            {
                sys_log(string.Format("getLastFM {0}", e.Message));
            }
        }          

        private Response getResponse(Message message, ProgramData data)
        {
            Response response = null;
            string text = string.Empty;
            bool isPrivate = false;
            bool isSleep = false;
            bool isDelete = false;
            bool isBan = false;
            switch (message.text)
            {
                case "!help":
                    {
                        isPrivate = data.auto_help_pm;
                        text = data.text_help + " !help ";
                        foreach (Command cmd in data.commands)
                            if (!cmd.auto_help)
                                text += (" | " + cmd.name);
                        break;
                    }
                case "!bot_sleep":
                    {
                        if (message.isAssistant || message.isStreamer) {
                            isSleep = true;
                            text = data.text_sleep;
                        }
                        break;
                    }
            }
            if (message.text.IndexOf("!quest") > -1 && data.quests.Count > 0)
            {
                isPrivate = true;
                string[] parametrs = message.text.Split(' ');
                if (parametrs.Length == 1)
                    text = data.quests[0].description + " - " + data.quests[0].name;
                if (parametrs.Length == 2)
                    for (int i = 0; i < data.quests.Count; i++)
                        if (String.Equals(data.quests[i].name, parametrs[1]))
                            text = data.quests[i].description + " - " + data.quests[i].name;
                if (parametrs.Length == 3)
                    for (int i = 0; i < data.quests.Count; i++)
                        if (String.Equals(data.quests[i].name, parametrs[1]))
                        {
                            string t = Regex.Replace(parametrs[2], data.quests[i].response, String.Empty);
                            if (!String.Equals(t, parametrs[2]))
                            {
                                if (i == data.quests.Count - 1)
                                {
                                    text = "Сompleted the quest chain - %username%";
                                    isPrivate = false;
                                }
                                else
                                    text = data.quests[i + 1].description + " - " + data.quests[i + 1].name;
                            }
                            else
                            {
                                if (rnd.Next(10000) < data.quests[i].chance * 100)
                                    text = data.quests[i].hint;
                                else
                                    text = "Wrong answer - " + data.quests[i].name;
                            }
                        }
            }
            foreach (Command cmd in program_data.commands)
            {
                bool get_res = false;
                if (string.Equals(cmd.name, message.text))
                    get_res = true;
                if (cmd.ignore_registr)
                    if (string.Equals(cmd.name, message.text))
                        get_res = true;
                if (cmd.regex_net)
                    if (!string.Equals(Regex.Replace(message.text, cmd.name, String.Empty), message.text))
                        get_res = true;
                if (!cmd.regex_net && !cmd.ignore_registr && cmd.response.IndexOf("{parametr}") > -1)
                    if (string.Equals(cmd.name, message.text.Split(' ')[0]))
                        get_res = true;
                if (get_res)
                {
                    text = cmd.response;
                    if (!String.Equals(cmd.file, String.Empty))
                        if (File.Exists(cmd.file))
                            text = File.ReadAllText(cmd.file);
                    string[] value = text.Split('~');
                    text = value[rnd.Next(0, value.Count() - 1)];                 
                    if (cmd.premium || cmd.user || cmd.assistant || cmd.streamer)
                    {
                        
                        bool key_block = true;
                        if (cmd.premium && message.isPremium && key_block)
                            key_block = false;
                        if (cmd.assistant && message.isAssistant && key_block)
                            key_block = false;
                        if (cmd.user && !(message.isStreamer || message.isAssistant) && key_block)
                            key_block = false;
                        if (cmd.streamer && message.isStreamer && key_block)
                            key_block = false;                     
                        if (key_block)
                            text = string.Empty;
                    }
                    if (cmd.ban_command) isBan = true;
                    if (cmd.del_command) isDelete = true;
                    if (cmd.send_pm) isPrivate = true;
                    if (text.IndexOf("{parameter}") > -1)
                    {
                        string[] parametrs = message.text.Split(' ');
                        if (parametrs.Count() > 1)
                            text = text.Replace("{parameter}", parametrs[1]);
                        else
                            text = text.Replace("{parameter}", string.Empty);
                    }
                    break;
                }
            }
            if (program_data.citations && rnd.Next(1, 1000) <= program_data.citations_chance && session_data.citations_list.Count() > 0 && string.IsNullOrEmpty(text))
                text = session_data.citations_list[rnd.Next(0, session_data.citations_list.Count() - 1)];
            if (!string.IsNullOrEmpty(text))
                response = new Response() { text = text, isPrivate = isPrivate, isSleep = isSleep, isBan = isBan, isDelete = isDelete };
            return response;
        }       

        public void refreshDataList()
        {
            comboBoxItem item = (comboBoxItem)cBox_editable_data.SelectedItem;
            switch (item.key)
            {
                case "COMMANDS":
                    {
                        program_data.commands.Clear();
                        program_data.commands.AddRange(listB_Object.Items.Cast<Command>().ToArray());
                        break;
                    }
                case "QUESTS":
                    {
                        program_data.quests.Clear();
                        program_data.quests.AddRange(listB_Object.Items.Cast<Quest>().ToArray());
                        break;
                    }
                case "LABELS":
                    {
                        program_data.labels.Clear();
                        program_data.labels.AddRange(listB_Object.Items.Cast<Label>().ToArray());
                        break;
                    }
                case "NOTIFICATIONS":
                    {
                        program_data.notifications.Clear();
                        program_data.notifications.AddRange(listB_Object.Items.Cast<Notification>().ToArray());
                        break;
                    }
                default:
                    break;
            }
        }

        public void UpdateNotification(object sender, EventArgs e)
        {
            Notification notification = listB_Object.SelectedItem as Notification;
            Form_Notification Dialog = new Form_Notification();
            Dialog.Text = "Update notification"; //text
            Dialog.tB_name.Text = notification.name;
            Dialog.tB_description.Text = notification.description;
            Dialog.tB_text.Text = notification.text;
            Dialog.tB_image.Text = notification.image;
            Dialog.tB_sound.Text = notification.music;
            Dialog.numUD_font_size.Value = notification.font_size;
            Dialog.numUD_height.Value = notification.height;
            Dialog.numUD_width.Value = notification.width;
            Dialog.numUD_volume.Value = notification.volume;
            Dialog.numUD_ssize.Value = notification.size_shadow;
            Dialog.cB_align.SelectedItem = "";
            Dialog.cB_an_in.SelectedItem = "";
            Dialog.cB_an_out.SelectedItem = "";
            Dialog.cB_an_name.SelectedItem = "";
            Dialog.cB_font.SelectedItem = "";
            if (Dialog.ShowDialog() == DialogResult.OK)
            {                
                listB_Object.Items[listB_Object.SelectedIndex] = notification;
            }
        }

        public void AddLabel(object sender, EventArgs e)
        {
            Form_Label Dialog = new Form_Label();
            Dialog.Text = "Add label"; //text
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                Label label = new Label();
                label.name = Dialog.tB_name.Text;
                label.description = Dialog.tB_description.Text;
                label.element = Dialog.tB_element.Text;
                label.label = Dialog.tB_label.Text;
                label.count = Decimal.ToInt32(Dialog.numUD_count.Value);
                label.time = Dialog.comB_time.SelectedIndex;
                label.type = Dialog.comB_type.SelectedIndex;
                label.start = Dialog.dateTimePicker1.Value;
                label.end = Dialog.dateTimePicker2.Value;
                listB_Object.Items.Add(label);
            }
        }

        public void UpdateLabel(object sender, EventArgs e)
        {
            Label label = listB_Object.SelectedItem as Label;
            Form_Label Dialog = new Form_Label();
            Dialog.Text = "Update label"; //text
            Dialog.time = label.time;
            Dialog.type = label.type;
            Dialog.tB_name.Text = label.name;
            Dialog.tB_description.Text = label.description;
            Dialog.tB_element.Text = label.element;
            Dialog.tB_label.Text = label.label;            
            Dialog.numUD_count.Value = label.count;
            Dialog.dateTimePicker1.Value = label.start;
            Dialog.dateTimePicker2.Value = label.end;
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                label.name = Dialog.tB_name.Text;
                label.description = Dialog.tB_description.Text;
                label.element = Dialog.tB_element.Text;
                label.label = Dialog.tB_label.Text;
                label.count = Decimal.ToInt32(Dialog.numUD_count.Value);
                label.time = Dialog.comB_time.SelectedIndex;
                label.type = Dialog.comB_type.SelectedIndex;
                label.start = Dialog.dateTimePicker1.Value;
                label.end = Dialog.dateTimePicker2.Value;
                listB_Object.Items[listB_Object.SelectedIndex] = label;
            }
        }

        public void AddQuest(object sender, EventArgs e)
        {
            Form_Quest Dialog = new Form_Quest();
            Dialog.Text = "Add quest"; //text
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                Quest quest = new Quest();
                quest.name = Dialog.tB_name.Text;
                quest.description = Dialog.tB_description.Text;
                quest.response = Dialog.tB_response.Text.Trim();
                quest.hint = Dialog.tB_hint.Text;
                quest.chance = Decimal.ToByte(Dialog.numUD_chance.Value);
                listB_Object.Items.Add(quest);
            }
        }

        public void UpdateQuest(object sender, EventArgs e)
        {
            Quest quest = listB_Object.SelectedItem as Quest;
            Form_Quest Dialog = new Form_Quest();
            Dialog.Text = "Update quest"; //text
            Dialog.tB_name.Text = quest.name;
            Dialog.tB_response.Text = quest.response;
            Dialog.tB_description.Text = quest.description;
            Dialog.tB_hint.Text = quest.hint;
            Dialog.numUD_chance.Value = quest.chance;
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                quest.name = Dialog.tB_name.Text;
                quest.description = Dialog.tB_description.Text;
                quest.response = Dialog.tB_response.Text.Trim();
                quest.hint = Dialog.tB_hint.Text;
                quest.chance = Decimal.ToByte(Dialog.numUD_chance.Value);
                listB_Object.Items[listB_Object.SelectedIndex] = quest;
            }
        }

        public void AddCommand(object sender, EventArgs e)
        {
            Form_command Dialog = new Form_command();
            Dialog.Text = "Add command"; //text
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                Command cmd = new Command();
                cmd.name = Dialog.tB_command.Text;
                cmd.description = Dialog.tB_description.Text;
                cmd.response = Dialog.tB_response.Text.Replace("\r\n", " ");
                cmd.file = Dialog.tB_file.Text;
                cmd.premium = Dialog.cB_premiums.Checked;
                cmd.assistant = Dialog.cB_assistants.Checked;
                cmd.streamer = Dialog.cB_streamers.Checked;
                cmd.user = Dialog.cB_users.Checked;
                cmd.auto_help = Dialog.cB_auto_help.Checked;
                cmd.send_pm = Dialog.cB_send_pm.Checked;
                cmd.ignore_registr = Dialog.cB_ignore_regitstr.Checked;
                cmd.regex_net = Dialog.cB_regex_net.Checked;
                cmd.del_command = Dialog.cB_del_command.Checked;
                cmd.ban_command = Dialog.cB_ban_command.Checked;
                listB_Object.Items.Add(cmd);
            }
        }

        public void UpdateCommand(object sender, EventArgs e)
        {

            Command cmd = listB_Object.SelectedItem as Command;
            Form_command Dialog = new Form_command();
            Dialog.Text = "Update command"; //text
            Dialog.tB_command.Text = cmd.name;
            Dialog.tB_description.Text = cmd.description;
            Dialog.tB_response.Text = cmd.response;
            Dialog.tB_file.Text = cmd.file;
            Dialog.cB_premiums.Checked = cmd.premium;
            Dialog.cB_assistants.Checked = cmd.assistant;
            Dialog.cB_streamers.Checked = cmd.streamer;
            Dialog.cB_users.Checked = cmd.user;
            Dialog.cB_send_pm.Checked = cmd.send_pm;
            Dialog.cB_auto_help.Checked = cmd.auto_help;
            Dialog.cB_ignore_regitstr.Checked = cmd.ignore_registr;
            Dialog.cB_regex_net.Checked = cmd.regex_net;
            Dialog.cB_del_command.Checked = cmd.del_command;
            Dialog.cB_ban_command.Checked = cmd.ban_command;
            Dialog.numUD_time.Value = cmd.time;
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                cmd.name = Dialog.tB_command.Text;
                cmd.description = Dialog.tB_description.Text;
                cmd.response = Dialog.tB_response.Text.Replace("\r\n", " ");
                cmd.file = Dialog.tB_file.Text;
                cmd.premium = Dialog.cB_premiums.Checked;
                cmd.assistant = Dialog.cB_assistants.Checked;
                cmd.streamer = Dialog.cB_streamers.Checked;
                cmd.user = Dialog.cB_users.Checked;
                cmd.auto_help = Dialog.cB_auto_help.Checked;
                cmd.send_pm = Dialog.cB_send_pm.Checked;
                cmd.ignore_registr = Dialog.cB_ignore_regitstr.Checked;
                cmd.regex_net = Dialog.cB_regex_net.Checked;
                cmd.del_command = Dialog.cB_del_command.Checked;
                cmd.ban_command = Dialog.cB_ban_command.Checked;
                cmd.time = Convert.ToInt32(Dialog.numUD_time.Value);
                listB_Object.Items[listB_Object.SelectedIndex] = cmd;
            }
        }

        public void DeleteObject(object sender, EventArgs e)
        {
            if (listB_Object.SelectedIndex >= 0)
                listB_Object.Items.RemoveAt(listB_Object.SelectedIndex);
        }

        private void save_settings(object sender, EventArgs e)
        {
            if (!Directory.Exists(path_my_doc + directory_app))
            {
                lb_notification.Text = "Catalog app not founded, create catalog"; //text
                Directory.CreateDirectory(path_my_doc + directory_app);
            }
            program_data.app_ver = Application.ProductVersion;
            string save = JsonConvert.SerializeObject(program_data);
            File.WriteAllText(path_my_doc + directory_app + "\\settings.json", save, Encoding.UTF8);
            save = JsonConvert.SerializeObject(user_data);
            File.WriteAllText(path_my_doc + directory_app + "\\user_data.json", save, Encoding.UTF8);
        }

        private void load_settings()
        {
            if (!Directory.Exists(path_my_doc + directory_app))
            {
                Directory.CreateDirectory(path_my_doc + directory_app);
                checkData();
                string save = JsonConvert.SerializeObject(program_data);
                File.WriteAllText(path_my_doc + directory_app + "\\settings.json", save, Encoding.UTF8);
                save = JsonConvert.SerializeObject(user_data);
                File.WriteAllText(path_my_doc + directory_app + "\\user_data.json", save, Encoding.UTF8);
            }
            else
            {
                string load = File.ReadAllText(path_my_doc + directory_app + "\\settings.json", Encoding.UTF8);
                program_data = JsonConvert.DeserializeObject<ProgramData>(load);
                load = File.ReadAllText(path_my_doc + directory_app + "\\user_data.json", Encoding.UTF8);
                user_data = JsonConvert.DeserializeObject<UserData>(load);
                checkData();
            }

            CitationsUpload();

            File.WriteAllText(path_my_doc + directory_app + "\\twitch-now.html", Properties.Resources.twitch_now, Encoding.UTF8);
            File.WriteAllText(path_my_doc + directory_app + "\\twitch-games.html", Properties.Resources.twitch_games, Encoding.UTF8);
            File.WriteAllText(path_my_doc + directory_app + "\\twitch-favorite.html", Properties.Resources.twitch_favorite, Encoding.UTF8);
            File.WriteAllText(path_my_doc + directory_app + "\\goodgame-now.html", Properties.Resources.goodgame_now, Encoding.UTF8);
            File.WriteAllText(path_my_doc + directory_app + "\\goodgame-games.html", Properties.Resources.goodgame_games, Encoding.UTF8);
            File.WriteAllText(path_my_doc + directory_app + "\\goodgame-favorite.html", Properties.Resources.goodgame_favorite, Encoding.UTF8);
        }

        private void CitationsUpload()
        {
            string[] cs;
            if (File.Exists(program_data.citations_file))
                cs = File.ReadAllLines(program_data.citations_file, Encoding.UTF8);
            else
                cs = Properties.Resources.citations_list.Replace("\r\n", "~").Split(new Char[] { '~' });
            session_data.citations_list = new List<string>();
            session_data.citations_list.AddRange(cs);
            sys_log("Citations uploaded: " + cs.Count());
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            comboBoxItem item = (comboBoxItem)cBox_editable_data.SelectedItem;
            switch (item.key)
            {
                case "COMMANDS":
                    {
                        AddCommand(sender, e);
                        break;
                    }
                case "QUESTS":
                    {
                        AddQuest(sender, e);
                        break;
                    }
                case "LABELS":
                    {
                        AddLabel(sender, e);
                        break;
                    }
                default:
                    break;
            }
            refreshDataList();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (listB_Object.SelectedIndex >= 0)
            {
                comboBoxItem item = (comboBoxItem)cBox_editable_data.SelectedItem;
                switch (item.key)
                {
                    case "COMMANDS":
                        {
                            UpdateCommand(sender, e);
                            break;
                        }
                    case "QUESTS":
                        {
                            UpdateQuest(sender, e);
                            break;
                        }
                    case "LABELS":
                        {
                            UpdateLabel(sender, e);
                            break;
                        }
                    case "NOTIFICATIONS":
                        {
                            UpdateNotification(sender, e);
                            break;
                        }
                    default:
                        break;
                }
                refreshDataList();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DeleteObject(sender, e);
            refreshDataList();
        }

        private void Form_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            save_settings(sender, e);
        }

        private string getCupChatID(string cup_id)
        {
            string result = string.Empty;
            WebRequest req = HttpWebRequest.Create(string.Format("http://goodgame.ru/cup/{0}/chat/", cup_id));
            req.Method = "GET";
            string source;
            using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream()))
                source = reader.ReadToEnd();
            int start = source.IndexOf("channelId:") + 10;
            source = source.Remove(0, start);
            start = source.IndexOf(",");
            int end = source.Length;
            result = source.Remove(start, end - start).Replace("'", string.Empty).Trim();
            return result;
        }

        private void Form_main_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void btn_up_cmd_Click(object sender, EventArgs e)
        {
            if (listB_Object.SelectedIndex > 0)
            {
                Object cmd = listB_Object.Items[listB_Object.SelectedIndex] as Object;
                Object cmd1 = listB_Object.Items[listB_Object.SelectedIndex - 1] as Object;
                listB_Object.Items[listB_Object.SelectedIndex] = cmd1;
                listB_Object.Items[listB_Object.SelectedIndex - 1] = cmd;
                listB_Object.SelectedIndex = listB_Object.SelectedIndex - 1;
                refreshDataList();
            }
            else
            {
                lb_notification.Text = Properties.Resources.notifi_list_top;
            }
        }

        private void btn_down_cmd_Click(object sender, EventArgs e)
        {
            if (listB_Object.SelectedIndex < listB_Object.Items.Count - 1)
            {
                Object cmd = listB_Object.Items[listB_Object.SelectedIndex] as Object;
                Object cmd1 = listB_Object.Items[listB_Object.SelectedIndex + 1] as Object;
                listB_Object.Items[listB_Object.SelectedIndex] = cmd1;
                listB_Object.Items[listB_Object.SelectedIndex + 1] = cmd;
                listB_Object.SelectedIndex = listB_Object.SelectedIndex + 1;
                refreshDataList();
            }
            else
            {
                lb_notification.Text = Properties.Resources.notifi_list_bottom;
            }
        }

        private void toolStripTB_search_bar_TextChanged(object sender, EventArgs e)
        {
            if (tstB_search_bar.Text != string.Empty)
            {
                int index = listB_Object.FindString(tstB_search_bar.Text);
                if (index != -1)
                    listB_Object.SetSelected(index, true);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listB_command_DoubleClick(object sender, EventArgs e)
        {
            if (listB_Object.SelectedIndex >= 0)
            {
                btn_update_Click(sender, e);
            }
        }

        private void listB_command_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)43)
                btn_add_Click(sender, e);
            if (e.KeyChar == (char)45)
            {
                DialogResult res = MessageBox.Show(Properties.Resources.question_delete, Properties.Resources.name, MessageBoxButtons.YesNo, MessageBoxIcon.Question); //text
                if (res == DialogResult.Yes)
                    btn_delete_Click(sender, e);
                else
                    return;
            }
        }

        public void vote_media(string catalog, int time)
        {
            media_files = Directory.EnumerateFiles(catalog, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".mp3") || s.EndsWith(".avi")).ToArray();
            int count = media_files.Count();
            if (count > 0)
            {
                if (count > 6)
                    count = 6;
                media_files = media_files.OrderBy(n => Guid.NewGuid()).ToArray();
                string msg = "{\"type\": \"new_poll\", \"data\": {\"channel_id\": \"" + user_data.gg_channel_id + "\", \"title\": \"Что будем слушать/смотреть?\", \"answers\": [";
                for (int i = 0; i < count; i++)
                {
                    if (i < count - 1)
                        msg += "{\"text\": \"" + media_files[i] + "\"},";
                    else
                        msg += "{\"text\": \"" + media_files[i] + "\"}";
                }
                msg += "]}}";
                WebSocket_GoodGame.Send(msg.Replace(catalog + "\\", "").Replace(".mp3", "").Replace(".avi", ""));
                msg = "{\"type\": \"get_poll_results\", \"data\": {\"channel_id\": \"" + user_data.gg_channel_id + "\"}}";
                timer_vote_media.Interval = time;
                timer_vote_media.Tick += (sender, e) => { WebSocket_GoodGame.Send(msg); timer_vote_media.Stop(); timer_vote_media.Enabled = false; };
                timer_vote_media.Enabled = true;
            }
        }

        public void result_vote_media(ChatMessage cm)
        {
            int score = 0;
            int id = 1;
            foreach (Answer a in cm.data.answers)
            {
                if (a.voters >= score)
                {
                    id = a.id;
                    score = a.voters;
                }
            }
            var song = tag.File.Create(media_files[id - 1]);
            Process.Start(media_files[id - 1]);
            vote_media(location_media, Convert.ToInt32(song.Properties.Duration.TotalMilliseconds));
        }

        private void voteForMediaContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!voteForMediaContentToolStripMenuItem.Checked)
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    location_media = dialog.SelectedPath;
                    vote_media(location_media, 300000);
                    voteForMediaContentToolStripMenuItem.Checked = true;
                }
            }
            else
            {
                voteForMediaContentToolStripMenuItem.Checked = false;
                timer_vote_media.Stop();
                timer_vote_media.Enabled = false;
            }
        }

        private void dropListCommandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(Properties.Resources.question_clean, Properties.Resources.name, MessageBoxButtons.YesNo, MessageBoxIcon.Question); //text
            if (res == DialogResult.Yes)
            {
                listB_Object.Items.Clear();
                refreshDataList();
            }
            else
                return;
        }

        private void SendPeriodicMessage()
        {
            string channel_gg = user_data.gg_channel_id;
            if (!string.IsNullOrEmpty(program_data.gg_custom_channel))
                channel_gg = program_data.gg_custom_channel;
            string channel_twitch = user_data.twitch_channel_id;
            if (!string.IsNullOrEmpty(program_data.twitch_custom_channel))
                channel_twitch = program_data.twitch_custom_channel;
            int minute = DateTime.UtcNow.Minute;
            if (minute == 0)
                minute = 60;
            foreach (Command cmd in program_data.commands)
            {
                if (cmd.time > 0)
                    if (minute % cmd.time == 0)
                    {
                        if (WebSocket_VIDI.IsAlive)
                            VidiChat_SendMessage(cmd.response);
                        if (WebSocket_GoodGame.IsAlive)
                            GoodGame_SendMessage(channel_gg, cmd.response);
                        if (WebSocket_Twitch.IsAlive)
                            Twitch_SendMessage(channel_twitch, cmd.response);
                    }
            }
        }

        private void systemLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log.tB_Log.Lines = system_log.ToArray();
            log.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Settings Dialog = new Form_Settings();
            Dialog.key_icon = int.Parse(program_data.message_icon);
            Dialog.start_page = int.Parse(program_data.wn_start_page);
            Dialog.tB_help.Text = program_data.text_help;
            Dialog.tB_offline.Text = program_data.text_offline;
            Dialog.tB_sleep.Text = program_data.text_sleep;
            Dialog.cB_help_in_pm.Checked = program_data.auto_help_pm;
            Dialog.cB_welcome_subscribers.Checked = program_data.hello_premium;
            Dialog.tB_welcome_subscribers.Text = program_data.hello_premium_text;           
            Dialog.cB_random_quotes.Checked = program_data.citations;
            Dialog.tB_file.Text = program_data.citations_file;
            Dialog.numUD_chance.Value = program_data.citations_chance;
            Dialog.cB_GGbot.Checked = program_data.isGGBot;
            Dialog.cB_TwitchBot.Checked = program_data.isTwitchBot;
            Dialog.cB_notify.Checked = program_data.wn_notify;
            Dialog.tB_custom_gg.Text = program_data.gg_custom_channel;
            Dialog.tB_custom_twitch.Text = program_data.twitch_custom_channel;
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                comboBoxItem item = (comboBoxItem)Dialog.cBox_icon.SelectedItem;                
                program_data.message_icon = item.key;
                item = (comboBoxItem)Dialog.cBox_start_page.SelectedItem;
                program_data.wn_start_page = item.key;
                program_data.text_help = Dialog.tB_help.Text;
                program_data.text_offline = Dialog.tB_offline.Text;
                program_data.text_sleep = Dialog.tB_sleep.Text;
                program_data.auto_help_pm = Dialog.cB_help_in_pm.Checked;
                program_data.hello_premium = Dialog.cB_welcome_subscribers.Checked;
                program_data.hello_premium_text = Dialog.tB_welcome_subscribers.Text;
                program_data.citations = Dialog.cB_random_quotes.Checked;
                program_data.citations_chance = Byte.Parse(Dialog.numUD_chance.Value.ToString());
                program_data.citations_file = Dialog.tB_file.Text;
                program_data.isTwitchBot = Dialog.cB_TwitchBot.Checked;
                program_data.isGGBot = Dialog.cB_GGbot.Checked;
                program_data.wn_notify = Dialog.cB_notify.Checked;
                program_data.twitch_custom_channel = Dialog.tB_custom_twitch.Text;
                program_data.gg_custom_channel = Dialog.tB_custom_gg.Text;
                if (!string.IsNullOrEmpty(program_data.gg_custom_channel))
                {
                    string data = GET("http://api2.goodgame.ru/streams/" + program_data.gg_custom_channel);
                    if (data != null)
                        program_data.gg_custom_channel = JsonConvert.DeserializeObject<GoodGameStreams>(data).id.ToString();
                }
                if (!string.IsNullOrEmpty(program_data.twitch_custom_channel))
                {
                    program_data.twitch_custom_channel = program_data.twitch_custom_channel.ToLower();
                }
                CitationsUpload();
                if (!program_data.isGGBot)
                    session_data.gg_bot_token = string.Empty;
                else
                    session_data.gg_bot_token = "b27eea10e68e152010a191d7a48cfff1";
                if (!program_data.isTwitchBot)
                    session_data.twitch_bot_token = string.Empty;
                else
                    session_data.twitch_bot_token = "1kpldqj75kxvtaj29ih5hd792hzv0q";
            }
        }

        private void sys_log(string text)
        {
            system_log.Add(DateTime.Now.ToLongTimeString() + " " + text);
        }

        private void resetLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            program_data.language = string.Empty;
            lb_notification.Text = Properties.Resources.reset_lang_help;
        }

        private void checkData()
        {
            if (program_data == null)
                program_data = new ProgramData();
            if (program_data.commands == null)
                program_data.commands = new List<Command>();
            if (program_data.quests == null)
                program_data.quests = new List<Quest>();
            if (program_data.labels == null)
                program_data.labels = new List<Label>();
            if (program_data.notifications == null)
                program_data.notifications = new List<Notification>();
            if (program_data.app_ver == null)
                program_data.app_ver = Application.ProductVersion;
            if (program_data.message_icon == null)
                program_data.message_icon = Properties.Resources.default_icon;
            if (program_data.message_icon == null)
                program_data.message_icon = "1";
            if (program_data.text_help == null)
                program_data.text_help = Properties.Resources.default_help;
            if (program_data.text_offline == null)
                program_data.text_offline = Properties.Resources.default_offline;
            if (program_data.text_sleep == null)
                program_data.text_sleep = Properties.Resources.default_sleep;
            if (program_data.hello_premium_text == null)
                program_data.hello_premium_text = Properties.Resources.default_welcome_subscribers_text;
            if (program_data.citations_chance < 1 || program_data.citations_chance > 250)
                program_data.citations_chance = 50;
            if (program_data.citations_file == null)
                program_data.citations_file = string.Empty;
            if (program_data.wn_start_page == null)
                program_data.wn_start_page = "2";
        }

        private void patchesLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Logs Dialog = new Form_Logs();
            Dialog.Text = Properties.Resources.name;
            Dialog.btn_save.Visible = false;
            Dialog.tB_Log.Text += Properties.Resources.patches;
            Dialog.ShowDialog();
        }

        private void vKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getTokenVK();
        }

        private void getTokenVK_implicit()
        {
            string url = "https://oauth.vk.com/authorize?client_id=5078958&display=popup&redirect_uri=http://api.vk.com/blank.html&scope=status&response_type=token&v=5.37";
            WebBrowser webBrowser = new WebBrowser();
            if (!vKToolStripMenuItem.Checked)
            {
                webBrowser = new WebBrowser();

                webBrowser.DocumentCompleted += (sender1, e1) =>
                {
                    if (!string.Equals(e1.Url.AbsoluteUri, url))
                    {
                        string data = e1.Url.AbsoluteUri.Replace("http://api.vk.com/blank.html#access_token=", string.Empty).Replace("&expires_in=86400&user_id", string.Empty);
                        vk_token = data.Split('=')[0];
                        vk_id = data.Split('=')[1];
                        getStatusVK();
                    }
                };
                webBrowser.Navigate(new Uri(url));
            }
        }

        //Getting token on VKontakte
        private void getTokenVK()
        {
            string url = "https://oauth.vk.com/authorize?client_id=5078958&display=popup&redirect_uri=http://api.vk.com/blank.html&scope=status&response_type=token&v=5.37";

            Form_Browser Dialog = new Form_Browser();
            Dialog.Text = Properties.Resources.vkontakte;
            Dialog.url = url;
            if (!vKToolStripMenuItem.Checked)
            {
                Dialog.authorization = true;
                if (Dialog.ShowDialog() == DialogResult.Yes)
                {
                    if (!string.Equals(Dialog.webBrowser.Url.AbsoluteUri, url))
                    {
                        string data = Dialog.webBrowser.Url.AbsoluteUri.Replace("http://api.vk.com/blank.html#access_token=", string.Empty).Replace("&expires_in=86400&user_id", string.Empty);
                        vk_token = data.Split('=')[0];
                        vk_id = data.Split('=')[1];
                        getStatusVK();
                    }
                }
            }
            else
            {
                Dialog.authorization = false;
                if (Dialog.ShowDialog() == DialogResult.No)
                {                  
                    vKToolStripMenuItem.Checked = false;
                }
            }
        }

        //Getting the status on VKontakte
        private void getStatusVK()
        {
            string UriString = "https://api.vk.com/method/status.get.xml?user_id=" + vk_id + "&v=5.37&access_token=" + vk_token;
            XmlDocument doc = new XmlDocument();
            XmlNodeList nodeList;
            try
            {
                doc.Load(UriString);
                nodeList = doc.GetElementsByTagName("text");
                if (nodeList.Count > 0)
                {
                    if (!string.Equals(vk_status, nodeList[0].InnerText))
                        sys_log("update status vk - " + nodeList[0].InnerText);
                    vk_status = nodeList[0].InnerText;
                    vKToolStripMenuItem.Checked = true;
                }
                else
                {
                    nodeList = doc.GetElementsByTagName("error");
                    if (nodeList.Count > 0)
                        sys_log(doc.GetElementsByTagName("error_code")[0].InnerText + "-" + doc.GetElementsByTagName("error_msg")[0].InnerText);
                    vKToolStripMenuItem.Checked = false;
                }
            }
            catch (Exception e)
            {
                sys_log("getStatusVK " + e.Message);
            }
        }      

        private void chatTwitchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!chatTwitchToolStripMenuItem.Checked)
            {
                TwitchChat();
                program_data.twitch_chat = true;
                chatTwitchToolStripMenuItem.Checked = true;
                twitchChatToolStripMenuItem.Checked = true;
            }
            else
            {
                TwitchChat_Dissconect();
                program_data.twitch_chat = false;
                chatTwitchToolStripMenuItem.Checked = false;
                twitchChatToolStripMenuItem.Checked = false;
            }
        }

        private void twitchPrivateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!twitchPrivateToolStripMenuItem.Checked)
            {
                TwitchPrivateChat();
                program_data.twitch_private_chat = true;
                twitchPrivateToolStripMenuItem.Checked = true;
                twitchPrivateChatToolStripMenuItem.Checked = true;
            }
            else
            {
                TwitchPrivateChat_Dissconect();
                program_data.twitch_private_chat = false;
                twitchPrivateToolStripMenuItem.Checked = false;
                twitchPrivateChatToolStripMenuItem.Checked = false;
            }
        }

        //----------------------------------------------------------------------------------------------------------------------

        private void TwitchPrivateChat()
        {
            WebSocket_TwitchPrivate.Connect();
        }

        private void TwitchPrivateChat_Dissconect()
        {
            WebSocket_TwitchPrivate.Close();
        }

        private void WebSocket_TwitchPrivate_OnOpen(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(session_data.twitch_bot_token))
            {
                WebSocket_TwitchPrivate.Send("PASS oauth:" + session_data.twitch_bot_token);
                WebSocket_TwitchPrivate.Send("NICK " + session_data.twitch_bot_id);
            }
            else
            {
                if (string.IsNullOrEmpty(user_data.twitch_bot_id) || string.IsNullOrEmpty(user_data.twitch_bot_token))
                {
                    WebSocket_TwitchPrivate.Send("PASS oauth:" + user_data.twitch_user_token);
                    WebSocket_TwitchPrivate.Send("NICK " + user_data.twitch_user_id);
                }
                else
                {
                    WebSocket_TwitchPrivate.Send("PASS oauth:" + user_data.twitch_bot_token);
                    WebSocket_TwitchPrivate.Send("NICK " + user_data.twitch_bot_id);
                }
            }
        }

        private void WebSocket_TwitchPrivate_OnError(object sender, WebSocketSharp.ErrorEventArgs e)
        {
            sys_log("WebSocket TwitchPrivate OnError - " + e.Message);
        }

        private void WebSocket_TwitchPrivate_OnClose(object sender, WebSocketSharp.CloseEventArgs e)
        {
            sys_log("WebSocket TwitchPrivate OnClosed wasClean - " + e.WasClean.ToString());
        }

        private void WebSocket_TwitchPrivate_OnMessege(object sender, MessageEventArgs e)
        {
            if (string.Equals("PING :tmi.twitch.tv", e.Data))
                WebSocket_TwitchPrivate.Send("PONG :tmi.twitch.tv");
            if (e.Data.IndexOf(":tmi.twitch.tv 001") > -1)
                sys_log("Twitch Private Chat: Welcome, GLHF!");
        }

        private void TwitchPrivate_SendMessage(string username, string text)
        {
            if (WebSocket_TwitchPrivate.IsAlive)
                WebSocket_TwitchPrivate.Send("PRIVMSG #" + user_data.twitch_channel_id.ToLower() + " :/w " + username.ToLower() + " " + text);
        }

        //-----------------------------------------------------------------------------------------------------------------------------

        private void TwitchChat()
        {
            WebSocket_Twitch.Connect();
        }

        private void TwitchChat_Dissconect()
        {
            WebSocket_Twitch.Close();
        }

        private void WebSocket_Twitch_OnOpen(object sender, EventArgs e)
        {
            WebSocket_Twitch.Send("CAP REQ :twitch.tv/tags");         
            if (!string.IsNullOrEmpty(session_data.twitch_bot_token))
            {
                WebSocket_Twitch.Send("PASS oauth:" + session_data.twitch_bot_token);
                WebSocket_Twitch.Send("NICK " + session_data.twitch_bot_id);
            }
            else
            {
                if (string.IsNullOrEmpty(user_data.twitch_bot_id) || string.IsNullOrEmpty(user_data.twitch_bot_token))
                {                    
                    WebSocket_Twitch.Send("PASS oauth:" + user_data.twitch_user_token);
                    WebSocket_Twitch.Send("NICK " + user_data.twitch_user_id);
                }
                else
                {
                    WebSocket_Twitch.Send("PASS oauth:" + user_data.twitch_bot_token);
                    WebSocket_Twitch.Send("NICK " + user_data.twitch_bot_id);
                }
            }    
            if (string.IsNullOrEmpty(program_data.twitch_custom_channel))    
                WebSocket_Twitch.Send("JOIN #" + user_data.twitch_channel_id);
            else
                WebSocket_Twitch.Send("JOIN #" + program_data.twitch_custom_channel);
        }

        private void WebSocket_Twitch_OnError(object sender, WebSocketSharp.ErrorEventArgs e)
        {
            sys_log("WebSocket Twitch OnError - " + e.Message);
        }

        private void WebSocket_Twitch_OnClose(object sender, WebSocketSharp.CloseEventArgs e)
        {
            sys_log("WebSocket Twitch OnClosed wasClean - " + e.WasClean.ToString());
        }

        private void WebSocket_Twitch_OnMessege(object sender, MessageEventArgs e)
        {
            //Parsing chat message
            string pattern_msg = @"@(?<tags>[^ ]+?) :(?<nick>[^ ]+?)\!(?<user>[^ ]+?)@(?<host>[^ ]+?) (?<command>[^ ]+?) (?<target>[^ ]+?) :(?<message>.*)";
            string pattern_tags = @"subscriber=(?<sub>[^ ]+?);turbo=(?<turbo>[^ ]+?);user-id=(?<id>[^ ]+?);user-type=(?<type>[^ ]+?)$";
            string input = e.Data;
            Match msg = Regex.Match(input, pattern_msg);
            Match tags = Regex.Match(msg.Groups["tags"].Value, pattern_tags);
            //Generate new message
            Message message = new Message();
            message.text = msg.Groups["message"].Value.Trim();
            if (string.Equals(tags.Groups["sub"].Value, "1"))
                message.isPremium = true;
            if (string.Equals(tags.Groups["type"].Value, "mod"))
                message.isAssistant = true;
            if (string.Equals(msg.Groups["nick"].Value, user_data.twitch_user_id.ToLower()))
                message.isStreamer = true;
            //Geting response and send message
            if (!string.IsNullOrEmpty(message.text))
            {
                Response response = getResponse(message, program_data);
                if (response != null)
                {
                    string channel = user_data.twitch_channel_id;
                    if (!string.IsNullOrEmpty(program_data.twitch_custom_channel))
                        channel = program_data.twitch_custom_channel;

                    if (response.isSleep)
                    {
                        session_data.isSleepTwitch = !session_data.isSleepTwitch;
                        Twitch_SendMessage(channel, response.text);
                        return;
                    }
                    if (session_data.isSleepTwitch)
                        return;
                    string random_username = Properties.Resources.unknown;
                    if (session_data.twitch_users != null)
                        if (session_data.twitch_users.Count > 0)
                        {
                            random_username = session_data.twitch_users[rnd.Next(session_data.twitch_users.Count)];
                            if (string.Equals(msg.Groups["nick"].Value, random_username))
                                random_username = Properties.Resources.unknown;
                        }
                    response.text = response.text.Replace("{username}", msg.Groups["nick"].Value).Replace("{random_username}", random_username).Replace("{uptime}", session_data.twitchStarted);
                    response.text = response.text.Replace("{game}", session_data.twitchGame).Replace("{lastfm}", session_data.lastfmTrack).Replace("{vk}", vk_status);
                   
                    if (response.isPrivate)
                        TwitchPrivate_SendMessage(msg.Groups["nick"].Value, response.text);
                    else
                        Twitch_SendMessage(channel, response.text);
                    if (response.isBan)
                        Twitch_Ban(channel, msg.Groups["nick"].Value);
                    if (response.isDelete)
                        Twitch_RemoveMessage(channel, msg.Groups["nick"].Value);
                }
            }
            //default message and response
            if (string.Equals("PING :tmi.twitch.tv", e.Data))
                WebSocket_Twitch.Send("PONG :tmi.twitch.tv");
            if (e.Data.IndexOf(":tmi.twitch.tv 001") > -1)
                sys_log("Twitch Chat: Welcome, GLHF!");
        }

        private void Twitch_SendMessage(string channel, string text)
        {
            if (WebSocket_Twitch.IsAlive)
                WebSocket_Twitch.Send("PRIVMSG #" + channel.ToLower() + " :" + text);
        }

        private void Twitch_Ban(string channel, string username)
        {
            if (WebSocket_Twitch.IsAlive)
                WebSocket_Twitch.Send("PRIVMSG #" + channel.ToLower() + " :/timeout " + username + " 3600");
        }

        private void Twitch_RemoveMessage(string channel, string username)
        {
            if (WebSocket_Twitch.IsAlive)
                WebSocket_Twitch.Send("PRIVMSG #" + channel.ToLower() + " :/timeout " + username + " ");
        }

        //----------------------------------------------------------------------------------------------------------------------

        private void showDescriptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!btn_showDescriptions.Checked)
            {
                listB_Object.DisplayMember = "description";
                btn_showDescriptions.Checked = true;
            }
            else
            {
                listB_Object.DisplayMember = "name";
                btn_showDescriptions.Checked = false;
            }
        }

        private void toolStripStatusLabel_notification_TextChanged(object sender, EventArgs e)
        {
            sys_log(lb_notification.Text);
        }


        //Выбор изменяемых данных
        private void cBox_editable_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxItem item = (comboBoxItem)cBox_editable_data.SelectedItem;
            switch (item.key)
            {
                case "COMMANDS":
                    {
                        listB_Object.Items.Clear();
                        listB_Object.Items.AddRange(program_data.commands.ToArray());
                        break;
                    }
                case "QUESTS":
                    {
                        listB_Object.Items.Clear();
                        listB_Object.Items.AddRange(program_data.quests.ToArray());
                        break;
                    }
                case "LABELS":
                    {
                        listB_Object.Items.Clear();
                        listB_Object.Items.AddRange(program_data.labels.ToArray());
                        break;
                    }
                case "NOTIFICATIONS":
                    {
                        listB_Object.Items.Clear();
                        listB_Object.Items.AddRange(program_data.notifications.ToArray());
                        break;
                    }
                default:
                    break;
            }
            listB_Object.DisplayMember = "name";
            if (btn_showDescriptions.Checked)
                listB_Object.DisplayMember = "description";
        }

        private void nowToolStripMenuItem_Click(object sender, MouseEventArgs e)
        {
            
        }

        //-------------------------------------------------------------------------------------------------------

        private void VidiChat()
        {            
            WebSocket_VIDI.Connect();
        }

        private void VidiChat_Dissconect()
        {
            WebSocket_VIDI.Close();            
        }

        private void WebSocket_VIDI_OnMessege(object sender, MessageEventArgs e)
        {
            ChatMessage chat_message = JsonConvert.DeserializeObject<ChatMessage>(e.Data);
            switch (chat_message.type)
            {
                case "welcome":
                    //sys_log("VIDI Chat Connect");
                    break;
                case "success_auth":
                    sys_log("VIDI Chat, Authorization User: " + chat_message.data.user_name);
                    WebSocket_VIDI.Send("{\"type\":\"join\",\"data\":{\"channel_id\":\"" + user_data.vidi_channel_id + "\",\"hidden\":\"false\"}}");
                    WebSocket_VIDI.Send("{\"type\":\"get_users_list2\",\"data\":{\"channel_id\":\"" + user_data.vidi_channel_id + "\"}}");
                    break;
                case "success_join":
                    sys_log("VIDI Chat, Join Channel: " + chat_message.data.channel_name);
                    session_data.vidi_user_id = chat_message.data.user_id;
                    session_data.vidi_access_rights = chat_message.data.access_rights;
                    break;
                case "success_unjoin":
                    break;
                case "pong":
                    break;
                case "error":
                    sys_log(chat_message.type + " - " + chat_message.data.errorMsg);
                    break;
                case "message":
                    if (int.Parse(session_data.vidi_access_rights) >= 0)
                    {
                        Message message = new Message() { text = chat_message.data.text, isPremium = chat_message.data.premium };
                        if (chat_message.data.user_rights == 10)
                            message.isAssistant = true;
                        if (chat_message.data.user_rights == 20)
                            message.isStreamer = true;
                        if (!String.Equals(chat_message.data.user_id, session_data.vidi_user_id))
                        {
                            Response response = getResponse(message, program_data);                                                    
                            if (response != null)
                            {
                                if (response.isSleep)
                                {
                                    session_data.isSleepVidi = !session_data.isSleepVidi;
                                    VidiChat_SendMessage(response.text);
                                    return;
                                }
                                if (session_data.isSleepVidi)
                                    return;
                                string random_username = Properties.Resources.unknown;
                                if (session_data.vidi_users != null)
                                    if (session_data.vidi_users.Count > 0)
                                    {
                                        random_username = session_data.vidi_users[rnd.Next(session_data.vidi_users.Count)].name;
                                        if (string.Equals(chat_message.data.user_name, random_username))
                                            random_username = Properties.Resources.unknown;
                                    }
                                response.text = response.text.Replace("{username}", chat_message.data.user_name).Replace("{random_username}", random_username).Replace("{uptime}", session_data.ggStarted);
                                response.text = response.text.Replace("{game}", session_data.ggGame).Replace("{lastfm}", session_data.lastfmTrack).Replace("{vk}", vk_status);
                                if (response.isPrivate)
                                    VidiChat_SendPrivateMessage(chat_message.data.user_id, response.text);
                                else
                                    VidiChat_SendMessage(response.text);
                            }
                                                        
                        }
                    }
                    break;
                case "private_message":                  
                    break;
                case "premium":
                    sys_log(chat_message.type + " - " + chat_message.data.userName);
                    if (program_data.hello_premium)
                        VidiChat_SendMessage(program_data.hello_premium_text + " " + chat_message.data.userName);
                    break;
                case "users_list":
                    if (session_data.vidi_users.Count != chat_message.data.users.Count)
                        sys_log(string.Format("VIDI Update Users Count: {0}", session_data.vidi_users.Count.ToString()));
                    session_data.vidi_users = chat_message.data.users;                   
                    break;
            }
        }

        private void WebSocket_VIDI_OnError(object sender, WebSocketSharp.ErrorEventArgs e)
        {
            sys_log("WebSocket VIDI OnError - " + e.Message);
        }

        private void WebSocket_VIDI_OnClose(object sender, WebSocketSharp.CloseEventArgs e)
        {
            sys_log("WebSocket VIDI OnClose WasClean - " + e.WasClean);
        }

        private void WebSocket_VIDI_OnOpen(object sender, EventArgs e)
        {
            WebSocket_VIDI.Send("{\"type\":\"auth\",\"data\":{\"site_id\": 2, \"user_id\":\"" + session_data.vidi_bot_id + "\",\"token\":\"" + session_data.vidi_bot_token + "\"}}");           
        }

        private void VidiChat_SendMessage(string text)
        {
            if (WebSocket_VIDI.IsAlive)
                WebSocket_VIDI.Send("{\"type\":\"send_message\",\"data\":{\"channel_id\":\"" + user_data.vidi_channel_id + "\",\"text\":\"" + text + "\",\"hideIcon\":\"false\"}}");
        }

        private void VidiChat_SendPrivateMessage(string user_id, string text)
        {
            if (WebSocket_VIDI.IsAlive)
                WebSocket_VIDI.Send("{\"type\":\"send_private_message\",\"data\":{\"channel_id\":\"" + user_data.vidi_channel_id + "\",\"user_id\":\"" + user_id + "\",\"text\":\"" + text + "\",\"hideIcon\":\"false\"}}");
        }

        private void vidiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!vidiToolStripMenuItem.Checked)
            {
                Form_Key dialog = new Form_Key();
                dialog.lb_key.Text = "ID Channel";
                dialog.pictureBox.Image = Properties.Resources.id_channel_vidi;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    user_data.vidi_channel_id = dialog.tB_key.Text;
                    VidiChat();
                    vidiToolStripMenuItem.Checked = true;
                }
            }
            else
            {
                VidiChat_Dissconect();
                vidiToolStripMenuItem.Checked = false;
                user_data.vidi_channel_id = string.Empty;
            }
        }

        //---------------------------------------------------------------------------------------------------------------

        private void goodGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!goodGameToolStripMenuItem.Checked)
            {
                GoodGameChat();
                program_data.gg_chat = true;
                goodGameToolStripMenuItem.Checked = true;
                goodgameChatToolStripMenuItem.Checked = true;
            }
            else
            {
                GoodGameChat_Dissconect();
                program_data.gg_chat = false;
                goodGameToolStripMenuItem.Checked = false;
                goodgameChatToolStripMenuItem.Checked = false;
            }
        }

        private void GoodGameChat()
        {           
            WebSocket_GoodGame.Connect();
        }

        private void GoodGameChat_Dissconect()
        {
            WebSocket_GoodGame.Close();
        }

        private void WebSocket_GoodGame_OnOpen(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(session_data.gg_bot_id) && !string.IsNullOrEmpty(session_data.gg_bot_token))
            {
                WebSocket_GoodGame.Send("{\"type\":\"auth\",\"data\":{\"user_id\":\"" + session_data.gg_bot_id + "\",\"token\":\"" + session_data.gg_bot_token + "\"}}");
                return;
            }
            if (string.IsNullOrEmpty(user_data.gg_bot_id) && string.IsNullOrEmpty(user_data.gg_bot_chat_token))
                WebSocket_GoodGame.Send("{\"type\":\"auth\",\"data\":{\"user_id\":\"" + user_data.gg_user_id + "\",\"token\":\"" + user_data.gg_user_chat_token + "\"}}");
            else
                WebSocket_GoodGame.Send("{\"type\":\"auth\",\"data\":{\"user_id\":\"" + user_data.gg_bot_id + "\",\"token\":\"" + user_data.gg_bot_chat_token + "\"}}");
        }

        private void WebSocket_GoodGame_OnError(object sender, WebSocketSharp.ErrorEventArgs e)
        {
            sys_log("WebSocket GoodGame OnError - " + e.Message); 
        }

        private void WebSocket_GoodGame_OnClose(object sender, WebSocketSharp.CloseEventArgs e)
        {
            sys_log("WebSocket GoodGame OnClosed wasClean - " + e.WasClean.ToString());         
        }

        private void WebSocket_GoodGame_OnMessege(object sender, MessageEventArgs e)
        {
            ChatMessage chat_message = JsonConvert.DeserializeObject<ChatMessage>(e.Data);        
            switch (chat_message.type)
            {
                case "welcome":
                    //sys_log("GoodGame Chat Connect");
                    break;
                case "success_auth":
                    sys_log("GoodGame Chat, Authorization User: " + chat_message.data.user_name);
                    string channel = user_data.gg_channel_id;
                    if (!string.IsNullOrEmpty(program_data.gg_custom_channel))
                        channel = program_data.gg_custom_channel;
                    WebSocket_GoodGame.Send("{\"type\":\"join\",\"data\":{\"channel_id\":\"" + channel + "\",\"hidden\":\"false\"}}");
                    WebSocket_GoodGame.Send("{\"type\":\"get_users_list2\",\"data\":{\"channel_id\":\"" + channel + "\"}}");
                    break;
                case "success_join":
                    sys_log("GoodGame Chat, Join Channel: " + chat_message.data.channel_name);
                    session_data.ggStarted = session_data.ggStarted = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(int.Parse(chat_message.data.started)).ToShortTimeString();
                    sys_log("GoodGame Update Started Stream:" + session_data.ggStarted);
                    session_data.gg_user_id = chat_message.data.user_id;
                    session_data.gg_access_rights = chat_message.data.access_rights;                    
                    break;
                case "success_unjoin":
                    break;
                case "pong":
                    break;
                case "error":
                    sys_log("GoodGame Chat, " + chat_message.data.errorMsg);
                    break;
                case "message":
                    if (int.Parse(session_data.gg_access_rights) >= 0)
                    {
                        Message message = new Message() { text = chat_message.data.text, isPremium = chat_message.data.premium };
                        if (chat_message.data.user_rights == 10)
                            message.isAssistant = true;
                        if (chat_message.data.user_rights == 20)
                            message.isStreamer = true;
                        if (!String.Equals("", session_data.gg_user_id))
                        {
                            Response response = getResponse(message, program_data);
                            if (response != null)
                            {
                                if (response.isSleep)
                                {
                                    session_data.isSleepGG = !session_data.isSleepGG;
                                    GoodGame_SendMessage(chat_message.data.channel_id, response.text);
                                    return;
                                }
                                if (session_data.isSleepGG)
                                    return;
                                string random_username = Properties.Resources.unknown;
                                if (session_data.gg_users != null)
                                    if (session_data.gg_users.Count > 0)
                                    {
                                        random_username = session_data.gg_users[rnd.Next(session_data.gg_users.Count)].name;
                                        if (string.Equals(chat_message.data.user_name, random_username))
                                            random_username = Properties.Resources.unknown;
                                    }
                                response.text = response.text.Replace("{username}", chat_message.data.user_name).Replace("{random_username}", random_username).Replace("{uptime}", session_data.ggStarted);
                                response.text = response.text.Replace("{game}", session_data.ggGame).Replace("{lastfm}", session_data.lastfmTrack).Replace("{vk}", vk_status);                               
                                if (response.isPrivate)
                                    GoodGame_SendPrivateMessage(chat_message.data.channel_id, response.text, chat_message.data.user_id);
                                else
                                    GoodGame_SendMessage(chat_message.data.channel_id, response.text);
                                if (response.isBan)
                                    GoodGame_Ban(chat_message.data.channel_id, chat_message.data.user_id);
                                if (response.isDelete)
                                    GoodGame_RemoveMessage(chat_message.data.channel_id, chat_message.data.message_id);
                            }
                        }
                    }
                    break;
                case "private_message":                   
                    break;
                case "premium":
                    sys_log(chat_message.type + " - " + chat_message.data.userName);
                    if (program_data.hello_premium)
                        GoodGame_SendMessage(chat_message.data.channel_id, program_data.hello_premium_text + " " + chat_message.data.userName);
                    break;
                case "poll_results":
                    if (voteForMediaContentToolStripMenuItem.Checked)
                        result_vote_media(chat_message);
                    break;
                case "users_list":
                    if (session_data.gg_users.Count != chat_message.data.users.Count)
                        sys_log(string.Format("GoodGame Update Users Count: {0}", session_data.gg_users.Count.ToString()));
                    session_data.gg_users = chat_message.data.users;                   
                    break;
            }
        }

        private void GoodGame_SendMessage(string channel, string text)
        {
            if (WebSocket_GoodGame.IsAlive)
                WebSocket_GoodGame.Send("{\"type\":\"send_message\",\"data\":{\"channel_id\":\"" + channel + "\",\"text\":\"" + text + "\",\"hideIcon\":\"false\",\"mobile\":" + int.Parse(program_data.message_icon) + "}}");
        }

        private void GoodGame_SendPrivateMessage(string channel, string text, string user_id)
        {
            if (WebSocket_GoodGame.IsAlive)
                WebSocket_GoodGame.Send("{\"type\":\"send_private_message\",\"data\":{\"channel_id\":\"" + channel + "\",\"user_id\":\"" + user_id + "\",\"text\":\"" + text + "\"}}");
        }

        private void GoodGame_RemoveMessage(string channel, string message_id)
        {
            if (WebSocket_GoodGame.IsAlive)
                WebSocket_GoodGame.Send("{\"type\":\"remove_message\",\"data\":{\"channel_id\":\"" + channel + "\",\"message_id\":\"" + message_id + "\"}}");
        }

        private void GoodGame_Ban(string channel, string user_id)
        {
            if (WebSocket_GoodGame.IsAlive)
                WebSocket_GoodGame.Send("{\"type\": \"ban\", \"data\": { \"channel_id\": \"" + channel + "\", \"ban_channel\": \"" + channel + "\", \"user_id\": \"" + user_id + "\", \"duration\": \"3600\", \"reason\": \"Auto-Ban\", \"comment\": \"Auto-Ban\", \"show_ban\": \"true\"}}");
        }

        private DataAccess refreshGoodGameToken(string refresh_token)
        {
            DataAccess result = null;
            string url = "http://api2.goodgame.ru/oauth";
            string data = "{\"grant_type\": \"refresh_token\", \"refresh_token\": \"" + refresh_token + "\", \"client_id\": \"Assistant Broadcasts\", \"client_secret\": \"c94ivpilc8zei82c87rmfqfwg8waz5mz\"}";
            string res = POST(url, data);
            if (!string.IsNullOrEmpty(res))
            {
                result = JsonConvert.DeserializeObject<DataAccess>(res);
            }
            return result;
        }

        private void ggToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ggToolStripMenuItem.Checked)
            {
                user_data.gg_channel_id = string.Empty;
                user_data.gg_user_id = string.Empty;
                user_data.gg_user_token = string.Empty;
                user_data.gg_user_refresh_token = string.Empty;
                user_data.gg_user_chat_token = string.Empty;
                ggToolStripMenuItem.Checked = false;
                return;
            }
            string state = Guid.NewGuid().ToString();
            Process.Start("http://api2.goodgame.ru/oauth/authorize?response_type=code&client_id=Assistant Broadcasts&redirect_uri=/oauth/receivecode&scope=chat.token channel.donations channel.premiums channel.subscribers&state=" + state);
            Form_Key form_key = new Form_Key();
            form_key.svc = "GOODGAME";
            form_key.state = state;
            form_key.lb_key.Text = "Пройдите авторизация в браузере и введите полученный в конце код";
            if (form_key.ShowDialog() == DialogResult.OK)
            {
                string data = GET("http://api2.goodgame.ru/info?access_token=" + form_key.data_access.access_token);
                string data2 = GET("http://api2.goodgame.ru/chat/token?access_token=" + form_key.data_access.access_token);
                if (!string.IsNullOrEmpty(data) && !string.IsNullOrEmpty(data2))
                {
                    GoodGameInfo goodgame_info = null;
                    try
                    {
                        goodgame_info = JsonConvert.DeserializeObject<GoodGameInfo>(data);
                    }
                    catch (Exception)
                    {

                    }
                    GoodGameChatToken goodgame_chat_token = JsonConvert.DeserializeObject<GoodGameChatToken>(data2);
                    if (goodgame_info != null)
                        user_data.gg_channel_id = goodgame_info.channel.channel_id.ToString();
                    user_data.gg_user_id = goodgame_chat_token.user_id;
                    user_data.gg_user_token = form_key.data_access.access_token;
                    user_data.gg_user_refresh_token = form_key.data_access.refresh_token;
                    user_data.gg_user_chat_token = goodgame_chat_token.chat_token;
                    sys_log("GG User New Access Token: " + form_key.data_access.access_token);
                    sys_log("GG User New Chat Token: " + goodgame_chat_token.chat_token);
                    ggToolStripMenuItem.Checked = true;
                }
            }
        }

        private void ggBotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ggBotToolStripMenuItem.Checked)
            {
                user_data.gg_bot_id = string.Empty;
                user_data.gg_bot_token = string.Empty;
                user_data.gg_bot_refresh_token = string.Empty;
                user_data.gg_bot_chat_token = string.Empty;
                ggBotToolStripMenuItem.Checked = false;
                return;
            }
            string state = Guid.NewGuid().ToString();
            Process.Start("http://api2.goodgame.ru/oauth/authorize?response_type=code&client_id=Assistant Broadcasts&redirect_uri=/oauth/receivecode&scope=chat.token&state=" + state);
            Form_Key form_key = new Form_Key();
            form_key.svc = "GOODGAME";
            form_key.state = state;
            form_key.lb_key.Text = "Пройдите авторизация в браузере и введите полученный в конце код";
            if (form_key.ShowDialog() == DialogResult.OK)
            {                
                string data = GET("http://api2.goodgame.ru/chat/token?access_token=" + form_key.data_access.access_token);
                if (!string.IsNullOrEmpty(data))
                {
                    GoodGameChatToken goodgame_chat_token = JsonConvert.DeserializeObject<GoodGameChatToken>(data);                   
                    user_data.gg_bot_token = form_key.data_access.access_token;
                    user_data.gg_bot_refresh_token = form_key.data_access.refresh_token;
                    user_data.gg_bot_id = goodgame_chat_token.user_id;
                    user_data.gg_bot_chat_token = goodgame_chat_token.chat_token;
                    sys_log("GG Bot New Access Token: " + form_key.data_access.access_token);
                    sys_log("GG Bot New Chat Token:" + goodgame_chat_token.chat_token);
                    ggBotToolStripMenuItem.Checked = true;
                }                
            }
        }

        private void twitchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (twitchToolStripMenuItem.Checked)
            {
                user_data.twitch_channel_id = string.Empty;
                user_data.twitch_user_id = string.Empty;
                user_data.twitch_user_token = string.Empty;
                user_data.twitch_user_refresh_token = string.Empty;
                twitchToolStripMenuItem.Checked = false;
                return;
            }
            string state = Guid.NewGuid().ToString();
            Process.Start("https://api.twitch.tv/kraken/oauth2/authorize?response_type=code&client_id=lez95j7ulvp449k1w47nvi0amsfin94&redirect_uri=https://api.twitch.tv/kraken/base&scope=user_read+chat_login+channel_subscriptions+user_subscriptions&force_verify=true&state=" + state);
            Form_Key form_key = new Form_Key();
            form_key.svc = "TWITCH";
            form_key.state = state;
            form_key.pictureBox.Image = Properties.Resources.twitch_code;
            form_key.lb_key.Text = "Пройдите авторизация в браузере и введите полученный в конце код";
            if (form_key.ShowDialog() == DialogResult.OK)
            {
                string data = GET("https://api.twitch.tv/kraken?oauth_token=" + form_key.data_access.access_token);
                sys_log("Twitch User New Access Token: " + form_key.data_access.access_token);
                if (!string.IsNullOrEmpty(data))
                {
                    TwitchRoot twitch_root = JsonConvert.DeserializeObject<TwitchRoot>(data);
                    if (twitch_root.token.valid)
                    {
                        user_data.twitch_channel_id = twitch_root.token.user_name.ToLower();
                        user_data.twitch_user_id = twitch_root.token.user_name.ToLower();
                        user_data.twitch_user_token = form_key.data_access.access_token;
                        user_data.twitch_user_refresh_token = form_key.data_access.refresh_token;
                        twitchToolStripMenuItem.Checked = true;
                    }
                }
            }
        }

        private void twitchBotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (twitchBotToolStripMenuItem.Checked)
            {
                user_data.twitch_bot_id = string.Empty;
                user_data.twitch_bot_token = string.Empty;
                user_data.twitch_bot_refresh_token = string.Empty;
                twitchBotToolStripMenuItem.Checked = false;
                return;
            }
            string state = Guid.NewGuid().ToString();
            Process.Start("https://api.twitch.tv/kraken/oauth2/authorize?response_type=code&client_id=lez95j7ulvp449k1w47nvi0amsfin94&redirect_uri=https://api.twitch.tv/kraken/base&scope=chat_login" + "&force_verify=true&state=" + state);            
            Form_Key form_key = new Form_Key();
            form_key.svc = "TWITCH";
            form_key.state = state;
            form_key.pictureBox.Image = Properties.Resources.twitch_code;
            form_key.lb_key.Text = "Пройдите авторизация в браузере и введите полученный в конце код";
            if (form_key.ShowDialog() == DialogResult.OK)
            {
                string data = GET("https://api.twitch.tv/kraken?oauth_token=" + form_key.data_access.access_token);
                sys_log("Twitch Bot New Access Token: " + form_key.data_access.access_token);
                if (!string.IsNullOrEmpty(data))
                {
                    TwitchRoot twitch_root = JsonConvert.DeserializeObject<TwitchRoot>(data);
                    if (twitch_root.token.valid)
                    {
                        user_data.twitch_bot_id = twitch_root.token.user_name.ToLower();
                        user_data.twitch_bot_token = form_key.data_access.access_token;
                        user_data.twitch_bot_refresh_token = form_key.data_access.refresh_token;
                        twitchBotToolStripMenuItem.Checked = true;
                    }
                }
            }
        }

        private void lastfmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastfmToolStripMenuItem.Checked)
            {
                user_data.lastfm_user = string.Empty;
                lastfmToolStripMenuItem.Checked = false;
                return;
            }
            Form_Key dialog = new Form_Key();
            dialog.lb_key.Text = "";
            dialog.svc = "LastFM";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                user_data.lastfm_user = dialog.tB_key.Text;
                lastfmToolStripMenuItem.Checked = true;
            }
        }

        private string GET(string url)
        {
            string result = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "application/json";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                result = reader.ReadToEnd();
                response.Close();
            }
            catch (Exception)
            {
            }           
            return result;
        }

        private string POST(string url, string data)
        {
            string result = String.Empty;
            WebRequest request = null;
            try
            {
                request = WebRequest.Create(url);
                request.Method = "POST";
                byte[] byteArray = Encoding.UTF8.GetBytes(data);
                request.ContentType = "application/json";
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                result = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (Exception e)
            {
                sys_log("POST " + url + " Error: " + e.Message);
            }
            return result;
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            Form_Logs dialog = new Form_Logs();
            comboBoxItem item = (comboBoxItem)cBox_editable_data.SelectedItem;
            switch (item.key)
            {
                case "COMMANDS":
                    {
                        dialog.tB_Log.Text = Properties.Resources.help_commands;
                        break;
                    }
                case "QUESTS":
                    {
                        dialog.tB_Log.Text = Properties.Resources.help_quests;
                        break;
                    }
                case "LABELS":
                    {
                        dialog.tB_Log.Text = Properties.Resources.help_labels;
                        break;
                    }
                default:
                    break;
            }           
            dialog.ShowDialog();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(push_url))
                Process.Start(push_url);
        }

        private void watchNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Now form_now = new Form_Now();
            form_now.TopMost = true;
            form_now.gg_user_id = user_data.gg_user_id;
            form_now.start_page = program_data.wn_start_page;
            form_now.twitch_user_token = user_data.twitch_user_token;
            form_now.FormClosed += (_sender, _e) =>
            {
                if (form_now.swap)
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    notifyIcon.Visible = false;
                }
                key_now = false;
                form_now.Dispose();
            };
            if (!key_now)
            {
                form_now.Show();
                key_now = true;
            }
        }

        private void assistantBroadcastsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }
    }
}

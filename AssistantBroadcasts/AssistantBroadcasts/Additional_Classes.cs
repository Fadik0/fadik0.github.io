using System;
using System.Collections.Generic;

namespace AssistantBroadcasts
{
    public class ChatMessage
    {
        public string type { get; set; }
        public ChatData data { get; set; }
    }

    public class ChatData
    {
        public string text { get; set; }
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string started { get; set; }
        public string channel_id { get; set; }
        public string channel_name { get; set; }
        public string userName { get; set; }
        public bool premium { get; set; }
        public int user_rights { get; set; }
        public string access_rights { get; set; }
        public string payments { get; set; }
        public string message_id { get; set; }
        public int voters { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public List<Answer> answers { get; set; }
        public string errorMsg { get; set; }
        public string target_name { get; set; }
        public DateTime arrival_time { get; set; }
        public string clients_in_channel { get; set; }
        public int users_in_channel { get; set; }
        public List<GoodGameUsers> users { get; set; }
    }

    public class Command
    {
        public string name { get; set; }
        public string description { get; set; }
        public string response { get; set; }
        public string file { get; set; }
        public bool premium { get; set; }
        public bool assistant { get; set; }
        public bool streamer { get; set; }
        public bool user { get; set; }
        public bool send_pm { get; set; }
        public bool auto_help { get; set; }
        public bool ignore_registr { get; set; }
        public bool regex_net { get; set; }
        public bool del_command { get; set; }
        public bool ban_command { get; set; }
        public int time { get; set; }
    }

    public class Quest
    {
        public string name { get; set; }
        public string description { get; set; }
        public string response { get; set; }
        public string hint { get; set; }
        public byte chance { get; set; }
    }

    public class ProgramData
    {
        public string app_ver { get; set; }
        public string language { get; set; }
        public string text_offline { get; set; }
        public string message_icon { get; set; }
        public string wn_start_page { get; set; }
        public string text_sleep { get; set; }
        public bool citations { get; set; }
        public byte citations_chance { get; set; }
        public string citations_file { get; set; }
        public bool auto_help_pm { get; set; }
        public string text_help { get; set; }        
        public bool hello_premium { get; set; }
        public string hello_premium_text { get; set; }       
        public bool gg_chat { get; set; }
        public bool vidi_chat { get; set; }
        public bool twitch_chat { get; set; }
        public bool twitch_private_chat { get; set; }
        public bool isGGBot { get; set; }
        public bool isTwitchBot { get; set; }
        public bool wn_notify { get; set; }
        public List<Command> commands { get; set; }
        public List<Quest> quests { get; set; }
        public List<Label> labels { get; set; }
        public List<Notification> notifications { get; set; }
        public string gg_custom_channel { get; set; }
        public string twitch_custom_channel { get; set; }
    }

    public class UserData
    {
        public string gg_channel_id { get; set; }
        public string gg_user_id { get; set; }
        public string gg_user_token { get; set; }
        public string gg_user_refresh_token { get; set; }
        public string gg_user_chat_token { get; set; }

        public string gg_bot_id { get; set; }
        public string gg_bot_token { get; set; }
        public string gg_bot_refresh_token { get; set; }
        public string gg_bot_chat_token { get; set; }

        public string twitch_channel_id { get; set; }
        public string twitch_user_id { get; set; }
        public string twitch_user_token { get; set; }
        public string twitch_user_refresh_token { get; set; }

        public string twitch_bot_id { get; set; }
        public string twitch_bot_token { get; set; }
        public string twitch_bot_refresh_token { get; set; }

        public string vidi_channel_id { get; set; }
        public string vidi_bot_id { get; set; }
        public string vidi_bot_token { get; set; }

        public string lastfm_user { get; set; }

        public bool vkontakte { get; set; }
    }

    public class SessionData
    {
        public string vidi_user_id { get; set; }
        public string vidi_access_rights { get; set; }
        public List<GoodGameUsers> vidi_users { get; set; }

        public string gg_user_id { get; set; }
        public string gg_access_rights { get; set; }
        public List<GoodGameUsers> gg_users { get; set; }
        public string ggStarted { get; set; }
        public string ggGame { get; set; }

        public List<string> twitch_users { get; set; }
        public string twitchStarted { get; set; }
        public string twitchGame { get; set; }

        public string lastfmTrack { get; set; }

        public string vkStatus { get; set; }

        public bool isSleepGG { get; set; }
        public bool isSleepTwitch { get; set; }
        public bool isSleepVidi { get; set; }
        public List<string> citations_list { get; set; }

        public string vidi_bot_id { get; set; }
        public string vidi_bot_token { get; set; }
        public string gg_bot_id { get; set; }
        public string gg_bot_token { get; set; }
        public string twitch_bot_id { get; set; }
        public string twitch_bot_token { get; set; }
    }

    public class СacheData
    {
        public List<Subscribers> gg_subscribers { get; set; }
        public List<Follower> gg_followers { get; set; }
        public List<Subscribers> t_subscribers { get; set; }
        public List<Follower> t_followers { get; set; }
        public List<Donation> donations { get; set; }
    }

    public class Subscribers
    {
        public DateTime date { get; set; }
        public string id { get; set; }
        public string username { get; set; }
    }

    public class Follower
    {
        public DateTime date { get; set; }
        public string id { get; set; }
        public string username { get; set; }
    }

    public class Donation
    {
        public DateTime date { get; set; }
        public string id { get; set; }
        public string username { get; set; }
        public double amount { get; set; }
        public string comment { get; set; }
    }

    public class TwitchRootToken
    {
        public bool valid { get; set; }
        public string user_name { get; set; }
    }

    public class TwitchRoot
    {
        public TwitchRootToken token { get; set; }
    }

    public class GoodGameInfoUser
    {
        public string user_id { get; set; }
        public string username { get; set; }
    }

    public class GoodGameInfoChannel
    {
        public string channel { get; set; }
        public int channel_id { get; set; }
        public string src { get; set; }
    }

    public class GoodGameInfo
    {
        public GoodGameInfoUser user { get; set; }
        public GoodGameInfoChannel channel { get; set; }
    }

    public class Answer
    {
        public int id { get; set; }
        public string text { get; set; }
        public int voters { get; set; }
    }

    public class comboBoxItem
    {
        public string name { get; set; }
        public string key { get; set; }
        public comboBoxItem( string _name, string _key)
        {
            name = _name;
            key = _key; 
        }
    }

    public class GoodGameUsers
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class GoodGameChatToken
    {
        public string user_id { get; set; }
        public string chat_token { get; set; }
    }

    public class Response
    {
        public string text { get; set; }
        public bool isPrivate { get; set; }
        public bool isSleep { get; set; }
        public bool isBan { get; set; }
        public bool isDelete { get; set; }
    }

    public class Message
    {
        public string text { get; set; }
        public bool isPremium { get; set; }
        public bool isStreamer { get; set; }
        public bool isAssistant { get; set; }
    }

    public class TwitchStream
    {
        public string game { get; set; }
        public string created_at { get; set; }
    }

    public class TwitchStreams
    {
        public TwitchStream stream { get; set; }
    }

    public class Game
    {
        public string title { get; set; }
        public string url { get; set; }
    }

    public class GoodGameChannel
    {
        public List<Game> games { get; set; }
    }

    public class GoodGameStreams
    {
        public int broadcast_started { get; set; }
        public int broadcast_end { get; set; }
        public bool is_broadcast { get; set; }
        public string status { get; set; }
        public int id { get; set; }
        public GoodGameChannel channel { get; set; }

    }

    public class Chatters
    {
        public List<string> moderators { get; set; }
        public List<string> staff { get; set; }
        public List<string> admins { get; set; }
        public List<string> global_mods { get; set; }
        public List<string> viewers { get; set; }
    }

    public class TwitchUsers
    {
        public int chatter_count { get; set; }
        public Chatters chatters { get; set; }
    }

    public class Label
    {
        public string name { get; set; }
        public string description { get; set; }
        public string element { get; set; }
        public string label { get; set; }
        public int count { get; set; }
        public bool list { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int type { get; set; }
        public int time { get; set; }
    }

    public class Notification
    {
        public string name { get; set; }
        public string description { get; set; }

        public string text { get; set; }
        public int volume { get; set; }
        public string music { get; set; }
        public string image { get; set; }
        public string animate_nick { get; set; }
        public string animate_in { get; set; }
        public string animate_out { get; set; }

        public int width { get; set; }
        public int height { get; set; }
        public string font { get; set; }
        public int font_size { get; set; }        
        public string color_text { get; set; }
        public string color_shadow { get; set; }
        public int size_shadow { get; set; }
        public string align { get; set; }
    }

    public class GoodGameApiDonation
    {
        public string id { get; set; }
        public string username { get; set; }
        public string amount { get; set; }
        public string paid_date { get; set; }
        public string comment { get; set; }
    }

    public class GoodGameApiSubscriber
    {
        public string id { get; set; }
        public string username { get; set; }
        public string created_at { get; set; }
    }

    public class GoodGameApiPremium
    {
        public string id { get; set; }
        public string username { get; set; }
        public string started_at { get; set; }
    }

    public class GoodGameApiEmbedded
    {
        public List<GoodGameApiDonation> donations { get; set; }
        public List<GoodGameApiSubscriber> subscribers { get; set; }
        public List<GoodGameApiPremium> premiums { get; set; }
    }

    public class GoodGameApiData
    {
        public GoodGameApiEmbedded _embedded { get; set; }
        public int page_count { get; set; }
        public int page_size { get; set; }
        public int total_items { get; set; }
        public int page { get; set; }
    }

    public class TwitchApiUser
    {
        public int _id { get; set; }
        public string name { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string display_name { get; set; }
        public string logo { get; set; }
        public string bio { get; set; }
        public string type { get; set; }
    }

    public class TwitchApiFollow
    {
        public string created_at { get; set; }
        public bool notifications { get; set; }
        public TwitchApiUser user { get; set; }
    }

    public class TwitchApiSubscription
    {
        public string _id { get; set; }
        public TwitchApiUser user { get; set; }
        public string created_at { get; set; }
    }

    public class TwitchApiData
    {
        public List<TwitchApiFollow> follows { get; set; }
        public List<TwitchApiSubscription> subscriptions { get; set; }
        public int _total { get; set; }
        public string _cursor { get; set; }
    }


    /// <summary>
    /// http://goodgame.ru/api/getggchannels?user=
    /// </summary>
    public class ApiGGGames
    {
        public string id { get; set; }
        public string title { get; set; }
        public string poster { get; set; }
    }

    public class ApiGGChannel
    {
        public string stream_id { get; set; }
        public string key { get; set; }
        public ApiGGGames games { get; set; }
        public string title { get; set; }
        public string player_key { get; set; }
        public string viewers { get; set; }
        public string usersinchat { get; set; }
        public string adult { get; set; }
        public string img { get; set; }
        public string thumb { get; set; }
        public string streamer { get; set; }
        public string favourite { get; set; }
    }

    public class ApiGGChannels
    {
        public bool success { get; set; }
        public List<ApiGGChannel> channels { get; set; }
    }

    /// <summary>
    /// https://api.twitch.tv/kraken/streams/followed?limit=100&oauth_token=
    /// </summary>
    public class ApiTwitchChannel
    {
        public bool mature { get; set; }
        public string status { get; set; }
        public string broadcaster_language { get; set; }
        public string display_name { get; set; }
        public string game { get; set; }
        public string language { get; set; }
        public int _id { get; set; }
        public string name { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public object delay { get; set; }
        public string logo { get; set; }
        public object banner { get; set; }
        public string video_banner { get; set; }
        public object background { get; set; }
        public string profile_banner { get; set; }
        public string profile_banner_background_color { get; set; }
        public bool partner { get; set; }
        public string url { get; set; }
        public int views { get; set; }
        public int followers { get; set; }
    }

    public class ApiTwitchStream
    {
        public object _id { get; set; }
        public string game { get; set; }
        public int viewers { get; set; }
        public string created_at { get; set; }
        public int video_height { get; set; }
        public double average_fps { get; set; }
        public int delay { get; set; }
        public bool is_playlist { get; set; }
        public ApiTwitchChannel channel { get; set; }
    }

    public class ApiTwitchFollowed
    {
        public List<ApiTwitchStream> streams { get; set; }
        public int _total { get; set; }
    }
}

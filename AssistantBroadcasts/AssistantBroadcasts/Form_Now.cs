using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssistantBroadcasts
{
    public partial class Form_Now : Form
    {
        public bool swap = false;
        static string path_my_doc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).Replace("\\", "/");
        static string directory_app = "/Assistant Broadcasts";
        static string gg_favorite = "/goodgame-favorite.html?user=";
        static string gg_now = "/goodgame-now.html";
        static string twitch_now = "/twitch-now.html";
        static string twitch_games = "/twitch-games.html";
        static string twitch_favorite = "/twitch-favorite.html?token=";
        public string gg_user_id = "1";       
        public string twitch_user_token = string.Empty;
        public string start_page = string.Empty;
        public Random rnd = new Random();

        public Form_Now()
        {                       
            InitializeComponent();          
        }

        private void Form_Now_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width, Screen.PrimaryScreen.WorkingArea.Height - Height);
            Activate();                      
        }

        private void MenuItem_Close_Click(object sender, EventArgs e)
        {
            swap = false;
            this.Close();
        }

        private void MenuItem_Launch_Click(object sender, EventArgs e)
        {
            swap = true;
            this.Close();
        }

        private void MenuItem_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form_Now_Deactivate(object sender, EventArgs e)
        {
            swap = false;
            this.Close();
        }

        private void MenuItem_GG_Favorite_Click(object sender, EventArgs e)
        {      
            webBrowser.Navigate("file:///" + path_my_doc + directory_app + gg_favorite + gg_user_id);
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
        }

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {           
            if (e.Url.ToString().IndexOf("goodgame.ru") > -1 || e.Url.ToString().IndexOf("twitch.tv") > -1)
            {
                tB_Watch_Now.Text = e.Url.ToString();
                Process.Start(e.Url.ToString());
                e.Cancel = true;
            } 
        }

        private void MenuItem_Refresh_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }

        private void MenuItem_Twitch_Top_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("file:///" + path_my_doc + directory_app + twitch_now);
        }

        private void MenuItem_GG_Top_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("file:///" + path_my_doc + directory_app + gg_now);
        }

        private void MenuItem_Twitch_Games_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("file:///" + path_my_doc + directory_app + twitch_games);
        }

        private void MenuItem_Twitch_Favorite_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(twitch_user_token))
            webBrowser.Navigate("file:///" + path_my_doc + directory_app + twitch_favorite + twitch_user_token);           
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Form_Now_Activated(object sender, EventArgs e)
        {
            switch (start_page)
            {
                case "1":
                    webBrowser.Navigate("file:///" + path_my_doc + directory_app + gg_favorite + gg_user_id);
                    break;
                case "3":
                    webBrowser.Navigate("file:///" + path_my_doc + directory_app + twitch_favorite + twitch_user_token);
                    break;
                case "4":
                    webBrowser.Navigate("file:///" + path_my_doc + directory_app + twitch_now);
                    break;
                case "5":
                    webBrowser.Navigate("file:///" + path_my_doc + directory_app + twitch_games);
                    break;
                default:
                    webBrowser.Navigate("file:///" + path_my_doc + directory_app + gg_now);
                    break;
            }
        }

        private void tB_Watch_Now_Click(object sender, EventArgs e)
        {

        }
    }    
}

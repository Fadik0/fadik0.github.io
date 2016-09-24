using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssistantBroadcasts
{
    public partial class Form_Settings : Form
    {
        public byte access_rights = 250;
        public int key_icon = 3;
        public int start_page = 1;
        static comboBoxItem[] comboBoxItems = new comboBoxItem[] {
            new comboBoxItem("Mobile", "1"),
            new comboBoxItem("Apple", "2"),
            new comboBoxItem("None", "3"),
            new comboBoxItem("Android", "4"),
        };
        static comboBoxItem[] comboBoxPages = new comboBoxItem[] {
            new comboBoxItem("GoodGame Favorites", "1"),
            new comboBoxItem("GoodGame Top", "2"),
            new comboBoxItem("Twitch Favorites", "3"),
            new comboBoxItem("Twitch Top", "4"),
            new comboBoxItem("Twitch Games", "5"),
        };

        public Form_Settings()
        {
            InitializeComponent();
        }

        private void btn_default_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(Properties.Resources.question_default, Properties.Resources.name, MessageBoxButtons.YesNo, MessageBoxIcon.Question); //text
            if (res == DialogResult.Yes)
            {
                cBox_icon.SelectedIndex = 2;
                cBox_start_page.SelectedIndex = 1;
                tB_help.Text = Properties.Resources.default_help;
                tB_offline.Text = Properties.Resources.default_offline;
                tB_sleep.Text = Properties.Resources.default_sleep;
                cB_help_in_pm.Checked = false;
                tB_welcome_subscribers.Text = Properties.Resources.default_welcome_subscribers_text;
                cB_welcome_subscribers.Checked = false;
                cB_random_quotes.Checked = false;
                tB_file.Text = string.Empty;
                numUD_chance.Value = 50;
            }
            else
                return;           
        }

        private void Form_Settings_Load(object sender, EventArgs e)
        {
            this.Text = Properties.Resources.settings;
            btn_ok.Text = Properties.Resources.ok;
            btn_cancel.Text = Properties.Resources.cancel;
            btn_default.Text = Properties.Resources.default_;
            lb_help.Text = Properties.Resources.help_cmd;
            lb_icon.Text = Properties.Resources.icon_cmd;
            lb_sleep.Text = Properties.Resources.sleep_cmd;
            lb_offline.Text = Properties.Resources.offline_cmd;
            cB_help_in_pm.Text = Properties.Resources.help_pm;
            cB_welcome_subscribers.Text = Properties.Resources.welcome_subscribers;
            lb_welcome_subscribers.Text = Properties.Resources.welcome_subscribers_text;
            lb_chance.Text = Properties.Resources.chance_random_quotes;
            lb_file.Text = Properties.Resources.file_random_quotes;
            cB_random_quotes.Text = Properties.Resources.random_quotes;
            cB_GGbot.Text = Properties.Resources.bot_gg;
            cB_TwitchBot.Text = Properties.Resources.bot_twitch;
            lb_start_page.Text = Properties.Resources.start_page;
            groupBox2.Text = Properties.Resources.bot_accounts;
            groupBox6.Text = Properties.Resources.ed_commands;
            groupBox4.Text = Properties.Resources.goodgame;
            cB_notify.Text = Properties.Resources.notify;
            lb_custom_gg.Text = Properties.Resources.goodgame;
            lb_custom_twitch.Text = Properties.Resources.twitch;

            cBox_icon.Items.AddRange(comboBoxItems);
            cBox_icon.DisplayMember = "name";
            cBox_icon.SelectedIndex = key_icon - 1;

            cBox_start_page.Items.AddRange(comboBoxPages);
            cBox_start_page.DisplayMember = "name";
            cBox_start_page.SelectedIndex = start_page - 1;
        }

        private void comboBox_icon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cB_welcome_followers_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_сhoice_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                tB_file.Text = openFileDialog.FileName;
        }
    }
}

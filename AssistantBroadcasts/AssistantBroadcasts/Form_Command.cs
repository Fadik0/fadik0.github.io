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
    public partial class Form_command : Form
    {
        static comboBoxItem[] comboBoxItems = new comboBoxItem[] {
            new comboBoxItem(Properties.Resources.dfi_username, "{username}"),
            new comboBoxItem(Properties.Resources.dfi_game, "{game}"),
            new comboBoxItem(Properties.Resources.dfi_uptime, "{uptime}"),
            new comboBoxItem(Properties.Resources.dfi_random_username, "{random_username}"),
            new comboBoxItem(Properties.Resources.dfi_vk, "{vk}"),
            new comboBoxItem(Properties.Resources.dfi_lastfm, "{lastfm}"),
            new comboBoxItem(Properties.Resources.dfi_separator, "~")
        };

        public Form_command()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

        }

        private void Form_command_Load(object sender, EventArgs e)
        {
            gB_settings.Text = Properties.Resources.settings;
            gB_permissions.Text = Properties.Resources.permissions;
            lb_command.Text = Properties.Resources.command;
            lb_response.Text = Properties.Resources.response;
            lb_description.Text = Properties.Resources.description;
            lb_response_file.Text = Properties.Resources.response_file;
            lb_time.Text = Properties.Resources.time;
            cB_premiums.Text = Properties.Resources.only_premium;
            cB_assistants.Text = Properties.Resources.only_assistant;
            cB_streamers.Text = Properties.Resources.only_streamer;
            cB_users.Text = Properties.Resources.only_users;
            cB_send_pm.Text = Properties.Resources.send_in_pm;
            cB_auto_help.Text = Properties.Resources.hide_in_autohelp;
            cB_ignore_regitstr.Text = Properties.Resources.ignore_registr;
            cB_regex_net.Text = Properties.Resources.regex_net;
            cB_ban_command.Text = Properties.Resources.ban_user;
            cB_del_command.Text = Properties.Resources.del_message;
            btn_ok.Text = Properties.Resources.ok;
            btn_cancel.Text = Properties.Resources.cancel;
            btn_insert.Text = Properties.Resources.insert;
            toolTip.SetToolTip(cB_regex_net, Properties.Resources.help_regex_net);
            lb_required_fields.Text = Properties.Resources.required_fields;
            cBox_data_for_insert.Items.AddRange(comboBoxItems);
            cBox_data_for_insert.DisplayMember = "name";
            cBox_data_for_insert.SelectedIndex = 0;
        }

        private void cB_ignore_regitstr_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_ignore_regitstr.Checked)
                cB_regex_net.Checked = !cB_ignore_regitstr.Checked;
        }

        private void cB_regex_net_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_regex_net.Checked)
                cB_ignore_regitstr.Checked = !cB_regex_net.Checked;
        }

        private void btn_сhoice_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                tB_file.Text = openFileDialog.FileName;
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            comboBoxItem item = cBox_data_for_insert.SelectedItem as comboBoxItem;
            tB_response.SelectedText = item.key;
        }

        private void tB_response_Click(object sender, EventArgs e)
        {
            
        }

        private void cBox_data_for_insert_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form_command_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (this.DialogResult == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(tB_command.Text))
                {
                    MessageBox.Show(Properties.Resources.notifi_required_fields);
                    e.Cancel = true;
                }
            }
        }
    }
}

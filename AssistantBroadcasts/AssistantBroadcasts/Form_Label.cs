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
    public partial class Form_Label : Form
    {
        private static comboBoxItem[] cBoxType = new comboBoxItem[] {
            new comboBoxItem(Properties.Resources.type_donate, ""),
            new comboBoxItem(Properties.Resources.type_donate_top, ""),
            new comboBoxItem(Properties.Resources.type_subscride, ""),
            new comboBoxItem(Properties.Resources.type_followers, "")          
        };

        private static comboBoxItem[] cBoxTime = new comboBoxItem[] {
            new comboBoxItem(Properties.Resources.time_all, ""),
            new comboBoxItem(Properties.Resources.time_30day, ""),
            new comboBoxItem(Properties.Resources.time_monthly, ""),
            new comboBoxItem(Properties.Resources.time_weekly, ""),           
            new comboBoxItem(Properties.Resources.time_custom, "")
        };

        private static comboBoxItem[] cBoxLabel = new comboBoxItem[] {
            new comboBoxItem(Properties.Resources.elements, "{elements}"),
            new comboBoxItem(Properties.Resources.label_count, "{count}"),
            new comboBoxItem(Properties.Resources.dfi_uptime, "{uptime}"),
            new comboBoxItem(Properties.Resources.dfi_game, "{game}"),
            new comboBoxItem(Properties.Resources.dfi_vk, "{vk}"),
            new comboBoxItem(Properties.Resources.dfi_lastfm, "{lastfm}")            
        };

        bool tb_label_active = false;

        public int type = 0;
        public int time = 0;

        public Form_Label()
        {
            InitializeComponent();
            lb_name.Text = Properties.Resources.label_name;
            lb_description.Text = Properties.Resources.label_description;
            gB_type.Text = Properties.Resources.label_type;
            lb_count.Text = Properties.Resources.label_count;
            lb_element.Text = Properties.Resources.label_element;
            lb_label.Text = Properties.Resources.label_label;
            gB_time.Text = Properties.Resources.label_time;
            btn_ok.Text = Properties.Resources.ok;
            btn_cancel.Text = Properties.Resources.cancel;
            btn_insert.Text = Properties.Resources.insert;
            lb_required_fields.Text = Properties.Resources.required_fields;
            cB_list.Text = Properties.Resources.label_list;
        }

        private void Form_Label_Load(object sender, EventArgs e)
        {
            comB_time.Items.AddRange(cBoxTime);
            comB_time.DisplayMember = "name";
            comB_time.SelectedIndex = time;
            comB_type.Items.AddRange(cBoxType);
            comB_type.DisplayMember = "name";
            comB_type.SelectedIndex = type;
            tB_element_Click(sender, e);
        }

        private void gB_time_Enter(object sender, EventArgs e)
        {

        }

        private void comB_type_SelectedIndexChanged(object sender, EventArgs e)
        {           
        }

        private void tB_element_Click(object sender, EventArgs e)
        {
            cBox_data_for_insert.Items.Clear();
            cBox_data_for_insert.Items.Add(new comboBoxItem(Properties.Resources.dfi_username, "{username}"));
            if (comB_type.SelectedIndex == 0 || comB_type.SelectedIndex == 1)
                cBox_data_for_insert.Items.Add(new comboBoxItem(Properties.Resources.amount, "{amount}"));
            cBox_data_for_insert.DisplayMember = "name";
            cBox_data_for_insert.SelectedIndex = 0;
            tb_label_active = false;
        }

        private void tB_label_TextChanged(object sender, EventArgs e)
        {

        }

        private void tB_label_Click(object sender, EventArgs e)
        {
            cBox_data_for_insert.Items.Clear();
            cBox_data_for_insert.Items.AddRange(cBoxLabel);
            if (comB_type.SelectedIndex == 0 || comB_type.SelectedIndex == 1)
                cBox_data_for_insert.Items.Add(new comboBoxItem(Properties.Resources.amount, "{amount}"));
            cBox_data_for_insert.DisplayMember = "name";
            cBox_data_for_insert.SelectedIndex = 0;
            tb_label_active = true;
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            comboBoxItem item = cBox_data_for_insert.SelectedItem as comboBoxItem;
            if (tb_label_active)
                tB_label.SelectedText = item.key;
            else
                tB_element.SelectedText = item.key;
        }

        private void lb_from_Click(object sender, EventArgs e)
        {

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            
        }

        private void Form_Label_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if ((comB_type.SelectedIndex == 2 || comB_type.SelectedIndex == 3) && (tB_element.Text.IndexOf("{amount}") > -1 || tB_label.Text.IndexOf("{amount}") > -1))
                {
                    MessageBox.Show("При выбранных настройках элемент {amount} не будет заменен на сумму.");
                    e.Cancel = true;
                }
                if (string.IsNullOrEmpty(tB_name.Text))
                {
                    MessageBox.Show(Properties.Resources.notifi_required_fields);
                    e.Cancel = true;
                }
            }
        }

        private void cBox_data_for_insert_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

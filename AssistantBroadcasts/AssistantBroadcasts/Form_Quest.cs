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
    public partial class Form_Quest : Form
    {
        public Form_Quest()
        {
            InitializeComponent();
            lb_name.Text = Properties.Resources.quest_name;
            lb_chance.Text = Properties.Resources.quest_chance;
            lb_hint.Text = Properties.Resources.quest_hint;
            lb_description.Text = Properties.Resources.quest_description;
            lb_response.Text = Properties.Resources.quest_response;
        }

        private void Form_Quest_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_gen_Click(object sender, EventArgs e)
        {
            tB_name.Text = Guid.NewGuid().ToString().Split('-')[0];
        }

        private void Form_Quest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(tB_name.Text))
                tB_name.Text = Guid.NewGuid().ToString().Split('-')[0];

            if (string.IsNullOrEmpty(tB_description.Text) || string.IsNullOrEmpty(tB_response.Text))
            {
                e.Cancel = false;
            }            
        }
    }
}

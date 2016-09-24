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
    public partial class Form_Notification : Form
    {
        public Form_Notification()
        {
            InitializeComponent();
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = btn_color.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                btn_color.BackColor = cd.Color;
            }
        }

        private void btn_scolor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = btn_scolor.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                btn_scolor.BackColor = cd.Color;
            }
        }

        private void Form_Notification_Load(object sender, EventArgs e)
        {
            System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
            foreach (FontFamily font in fonts.Families)
                cB_font.Items.Add(font.Name);
            cB_font.SelectedItem = "Open Sans";
            cB_font.SelectedIndex = 0;

            cB_an_name.Items.AddRange(new object[] {
            "",
            "bounce",
            "flash",
            "pulse",
            "rubberBand",
            "shake",
            "headShake",
            "swing",
            "tada",
            "wobble",
            "jello"});
            cB_an_in.Items.AddRange(new object[] {
            "bounceIn",
            "bounceInDown",
            "bounceInLeft",
            "bounceInRight",
            "bounceInUp",
            "fadeIn",
            "fadeInDown",
            "fadeInDownBig",
            "fadeInLeft",
            "fadeInLeftBig",
            "fadeInRight",
            "fadeInRightBig",
            "fadeInUp",
            "fadeInUpBig",
            "flipInX",
            "flipInY",
            "lightSpeedIn",
            "rotateIn",
            "rotateInDownLeft",
            "rotateInDownRight",
            "rotateInUpLeft",
            "rotateInUpRight",
            "hinge",
            "rollIn",
            "zoomIn",
            "zoomInDown",
            "zoomInLeft",
            "zoomInRight",
            "zoomInUp",
            "slideInDown",
            "slideInLeft",
            "slideInRight",
            "slideInUp"});
            cB_an_out.Items.AddRange(new object[] {
            "bounceOut",
            "bounceOutDown",
            "bounceOutLeft",
            "bounceOutRight",
            "bounceOutUp",
            "fadeOut",
            "fadeOutDown",
            "fadeOutDownBig",
            "fadeOutLeft",
            "fadeOutLeftBig",
            "fadeOutRight",
            "fadeOutRightBig",
            "fadeOutUp",
            "fadeOutUpBig",
            "flipOutX",
            "flipOutY",
            "lightSpeedOut",
            "rotateOut",
            "rotateOutDownLeft",
            "rotateOutDownRight",
            "rotateOutUpLeft",
            "rotateOutUpRight",
            "hinge",
            "rollOut",
            "zoomOut",
            "zoomOutDown",
            "zoomOutLeft",
            "zoomOutRight",
            "zoomOutUp",
            "slideOutDown",
            "slideOutLeft",
            "slideOutRight",
            "slideOutUp"});
            cB_an_name.SelectedItem = "flash";
            cB_an_in.SelectedItem = "fadeInDown";
            cB_an_out.SelectedItem = "fadeOutUp";

            cB_align.Items.AddRange(new object[] {
            "center",
            "justify",
            "left",
            "right"});
            cB_align.SelectedItem = "center";            
        }
    }
}

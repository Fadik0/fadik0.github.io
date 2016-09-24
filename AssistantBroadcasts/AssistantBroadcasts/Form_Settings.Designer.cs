namespace AssistantBroadcasts
{
    partial class Form_Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Settings));
            this.lb_icon = new System.Windows.Forms.Label();
            this.cBox_icon = new System.Windows.Forms.ComboBox();
            this.lb_help = new System.Windows.Forms.Label();
            this.tB_help = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.tB_offline = new System.Windows.Forms.TextBox();
            this.lb_offline = new System.Windows.Forms.Label();
            this.btn_default = new System.Windows.Forms.Button();
            this.cB_help_in_pm = new System.Windows.Forms.CheckBox();
            this.cB_welcome_subscribers = new System.Windows.Forms.CheckBox();
            this.lb_welcome_subscribers = new System.Windows.Forms.Label();
            this.tB_welcome_subscribers = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cB_random_quotes = new System.Windows.Forms.CheckBox();
            this.btn_сhoice = new System.Windows.Forms.Button();
            this.tB_file = new System.Windows.Forms.TextBox();
            this.lb_file = new System.Windows.Forms.Label();
            this.numUD_chance = new System.Windows.Forms.NumericUpDown();
            this.lb_chance = new System.Windows.Forms.Label();
            this.tB_sleep = new System.Windows.Forms.TextBox();
            this.lb_sleep = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cB_notify = new System.Windows.Forms.CheckBox();
            this.cBox_start_page = new System.Windows.Forms.ComboBox();
            this.lb_start_page = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cB_TwitchBot = new System.Windows.Forms.CheckBox();
            this.cB_GGbot = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lb_custom_gg = new System.Windows.Forms.Label();
            this.tB_custom_gg = new System.Windows.Forms.TextBox();
            this.lb_custom_twitch = new System.Windows.Forms.Label();
            this.tB_custom_twitch = new System.Windows.Forms.TextBox();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_chance)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_icon
            // 
            this.lb_icon.AutoSize = true;
            this.lb_icon.Location = new System.Drawing.Point(3, 54);
            this.lb_icon.Name = "lb_icon";
            this.lb_icon.Size = new System.Drawing.Size(41, 13);
            this.lb_icon.TabIndex = 0;
            this.lb_icon.Text = "lb_icon";
            // 
            // cBox_icon
            // 
            this.cBox_icon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBox_icon.FormattingEnabled = true;
            this.cBox_icon.Location = new System.Drawing.Point(6, 70);
            this.cBox_icon.Name = "cBox_icon";
            this.cBox_icon.Size = new System.Drawing.Size(202, 21);
            this.cBox_icon.TabIndex = 1;
            this.cBox_icon.SelectedIndexChanged += new System.EventHandler(this.comboBox_icon_SelectedIndexChanged);
            // 
            // lb_help
            // 
            this.lb_help.AutoSize = true;
            this.lb_help.Location = new System.Drawing.Point(6, 16);
            this.lb_help.Name = "lb_help";
            this.lb_help.Size = new System.Drawing.Size(41, 13);
            this.lb_help.TabIndex = 2;
            this.lb_help.Text = "lb_help";
            // 
            // tB_help
            // 
            this.tB_help.Location = new System.Drawing.Point(6, 32);
            this.tB_help.Name = "tB_help";
            this.tB_help.Size = new System.Drawing.Size(202, 20);
            this.tB_help.TabIndex = 3;
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(340, 496);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(95, 23);
            this.btn_cancel.TabIndex = 9;
            this.btn_cancel.Text = "btn_cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_ok
            // 
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Location = new System.Drawing.Point(239, 496);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(95, 23);
            this.btn_ok.TabIndex = 10;
            this.btn_ok.Text = "btn_ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            // 
            // tB_offline
            // 
            this.tB_offline.Location = new System.Drawing.Point(214, 71);
            this.tB_offline.Name = "tB_offline";
            this.tB_offline.Size = new System.Drawing.Size(202, 20);
            this.tB_offline.TabIndex = 14;
            // 
            // lb_offline
            // 
            this.lb_offline.AutoSize = true;
            this.lb_offline.Location = new System.Drawing.Point(211, 55);
            this.lb_offline.Name = "lb_offline";
            this.lb_offline.Size = new System.Drawing.Size(49, 13);
            this.lb_offline.TabIndex = 13;
            this.lb_offline.Text = "lb_offline";
            // 
            // btn_default
            // 
            this.btn_default.Location = new System.Drawing.Point(138, 496);
            this.btn_default.Name = "btn_default";
            this.btn_default.Size = new System.Drawing.Size(95, 23);
            this.btn_default.TabIndex = 15;
            this.btn_default.Text = "btn_default";
            this.btn_default.UseVisualStyleBackColor = true;
            this.btn_default.Click += new System.EventHandler(this.btn_default_Click);
            // 
            // cB_help_in_pm
            // 
            this.cB_help_in_pm.AutoSize = true;
            this.cB_help_in_pm.Location = new System.Drawing.Point(214, 34);
            this.cB_help_in_pm.Name = "cB_help_in_pm";
            this.cB_help_in_pm.Size = new System.Drawing.Size(99, 17);
            this.cB_help_in_pm.TabIndex = 16;
            this.cB_help_in_pm.Text = "cB_help_in_pm";
            this.cB_help_in_pm.UseVisualStyleBackColor = true;
            // 
            // cB_welcome_subscribers
            // 
            this.cB_welcome_subscribers.AutoSize = true;
            this.cB_welcome_subscribers.Location = new System.Drawing.Point(214, 34);
            this.cB_welcome_subscribers.Name = "cB_welcome_subscribers";
            this.cB_welcome_subscribers.Size = new System.Drawing.Size(146, 17);
            this.cB_welcome_subscribers.TabIndex = 21;
            this.cB_welcome_subscribers.Text = "cB_welcome_subscribers";
            this.cB_welcome_subscribers.UseVisualStyleBackColor = true;
            // 
            // lb_welcome_subscribers
            // 
            this.lb_welcome_subscribers.AutoSize = true;
            this.lb_welcome_subscribers.Location = new System.Drawing.Point(3, 16);
            this.lb_welcome_subscribers.Name = "lb_welcome_subscribers";
            this.lb_welcome_subscribers.Size = new System.Drawing.Size(122, 13);
            this.lb_welcome_subscribers.TabIndex = 22;
            this.lb_welcome_subscribers.Text = "lb_welcome_subscribers";
            // 
            // tB_welcome_subscribers
            // 
            this.tB_welcome_subscribers.Location = new System.Drawing.Point(6, 32);
            this.tB_welcome_subscribers.Name = "tB_welcome_subscribers";
            this.tB_welcome_subscribers.Size = new System.Drawing.Size(202, 20);
            this.tB_welcome_subscribers.TabIndex = 23;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lb_icon);
            this.groupBox4.Controls.Add(this.tB_welcome_subscribers);
            this.groupBox4.Controls.Add(this.cBox_icon);
            this.groupBox4.Controls.Add(this.cB_welcome_subscribers);
            this.groupBox4.Controls.Add(this.lb_welcome_subscribers);
            this.groupBox4.Location = new System.Drawing.Point(12, 204);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(423, 101);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "GoodGame";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cB_random_quotes);
            this.groupBox6.Controls.Add(this.btn_сhoice);
            this.groupBox6.Controls.Add(this.tB_file);
            this.groupBox6.Controls.Add(this.lb_file);
            this.groupBox6.Controls.Add(this.numUD_chance);
            this.groupBox6.Controls.Add(this.lb_chance);
            this.groupBox6.Controls.Add(this.tB_offline);
            this.groupBox6.Controls.Add(this.tB_sleep);
            this.groupBox6.Controls.Add(this.lb_sleep);
            this.groupBox6.Controls.Add(this.lb_offline);
            this.groupBox6.Controls.Add(this.tB_help);
            this.groupBox6.Controls.Add(this.lb_help);
            this.groupBox6.Controls.Add(this.cB_help_in_pm);
            this.groupBox6.Location = new System.Drawing.Point(12, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(422, 186);
            this.groupBox6.TabIndex = 32;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Command";
            // 
            // cB_random_quotes
            // 
            this.cB_random_quotes.AutoSize = true;
            this.cB_random_quotes.Location = new System.Drawing.Point(214, 110);
            this.cB_random_quotes.Name = "cB_random_quotes";
            this.cB_random_quotes.Size = new System.Drawing.Size(118, 17);
            this.cB_random_quotes.TabIndex = 24;
            this.cB_random_quotes.Text = "cB_random_quotes";
            this.cB_random_quotes.UseVisualStyleBackColor = true;
            // 
            // btn_сhoice
            // 
            this.btn_сhoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_сhoice.Image = ((System.Drawing.Image)(resources.GetObject("btn_сhoice.Image")));
            this.btn_сhoice.Location = new System.Drawing.Point(395, 149);
            this.btn_сhoice.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btn_сhoice.Name = "btn_сhoice";
            this.btn_сhoice.Size = new System.Drawing.Size(21, 20);
            this.btn_сhoice.TabIndex = 23;
            this.btn_сhoice.UseVisualStyleBackColor = true;
            // 
            // tB_file
            // 
            this.tB_file.Location = new System.Drawing.Point(6, 149);
            this.tB_file.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.tB_file.Name = "tB_file";
            this.tB_file.Size = new System.Drawing.Size(389, 20);
            this.tB_file.TabIndex = 22;
            // 
            // lb_file
            // 
            this.lb_file.AutoSize = true;
            this.lb_file.Location = new System.Drawing.Point(6, 133);
            this.lb_file.Name = "lb_file";
            this.lb_file.Size = new System.Drawing.Size(34, 13);
            this.lb_file.TabIndex = 21;
            this.lb_file.Text = "lb_file";
            // 
            // numUD_chance
            // 
            this.numUD_chance.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numUD_chance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.numUD_chance.Location = new System.Drawing.Point(6, 110);
            this.numUD_chance.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numUD_chance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUD_chance.Name = "numUD_chance";
            this.numUD_chance.Size = new System.Drawing.Size(202, 20);
            this.numUD_chance.TabIndex = 20;
            this.numUD_chance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUD_chance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lb_chance
            // 
            this.lb_chance.AutoSize = true;
            this.lb_chance.Location = new System.Drawing.Point(6, 94);
            this.lb_chance.Name = "lb_chance";
            this.lb_chance.Size = new System.Drawing.Size(57, 13);
            this.lb_chance.TabIndex = 19;
            this.lb_chance.Text = "lb_chance";
            // 
            // tB_sleep
            // 
            this.tB_sleep.Location = new System.Drawing.Point(6, 71);
            this.tB_sleep.Name = "tB_sleep";
            this.tB_sleep.Size = new System.Drawing.Size(202, 20);
            this.tB_sleep.TabIndex = 18;
            // 
            // lb_sleep
            // 
            this.lb_sleep.AutoSize = true;
            this.lb_sleep.Location = new System.Drawing.Point(6, 55);
            this.lb_sleep.Name = "lb_sleep";
            this.lb_sleep.Size = new System.Drawing.Size(46, 13);
            this.lb_sleep.TabIndex = 17;
            this.lb_sleep.Text = "lb_sleep";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cB_notify);
            this.groupBox1.Controls.Add(this.cBox_start_page);
            this.groupBox1.Controls.Add(this.lb_start_page);
            this.groupBox1.Location = new System.Drawing.Point(12, 311);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 62);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Watch Now";
            // 
            // cB_notify
            // 
            this.cB_notify.AutoSize = true;
            this.cB_notify.Location = new System.Drawing.Point(214, 34);
            this.cB_notify.Name = "cB_notify";
            this.cB_notify.Size = new System.Drawing.Size(70, 17);
            this.cB_notify.TabIndex = 2;
            this.cB_notify.Text = "cB_notify";
            this.cB_notify.UseVisualStyleBackColor = true;
            // 
            // cBox_start_page
            // 
            this.cBox_start_page.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBox_start_page.FormattingEnabled = true;
            this.cBox_start_page.Location = new System.Drawing.Point(6, 32);
            this.cBox_start_page.Name = "cBox_start_page";
            this.cBox_start_page.Size = new System.Drawing.Size(202, 21);
            this.cBox_start_page.TabIndex = 1;
            // 
            // lb_start_page
            // 
            this.lb_start_page.AutoSize = true;
            this.lb_start_page.Location = new System.Drawing.Point(6, 16);
            this.lb_start_page.Name = "lb_start_page";
            this.lb_start_page.Size = new System.Drawing.Size(71, 13);
            this.lb_start_page.TabIndex = 0;
            this.lb_start_page.Text = "lb_start_page";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cB_TwitchBot);
            this.groupBox2.Controls.Add(this.cB_GGbot);
            this.groupBox2.Location = new System.Drawing.Point(12, 379);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 45);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Embedded bot accounts";
            // 
            // cB_TwitchBot
            // 
            this.cB_TwitchBot.AutoSize = true;
            this.cB_TwitchBot.Location = new System.Drawing.Point(214, 19);
            this.cB_TwitchBot.Name = "cB_TwitchBot";
            this.cB_TwitchBot.Size = new System.Drawing.Size(93, 17);
            this.cB_TwitchBot.TabIndex = 1;
            this.cB_TwitchBot.Text = "cB_TwitchBot";
            this.cB_TwitchBot.UseVisualStyleBackColor = true;
            // 
            // cB_GGbot
            // 
            this.cB_GGbot.AutoSize = true;
            this.cB_GGbot.Location = new System.Drawing.Point(6, 19);
            this.cB_GGbot.Name = "cB_GGbot";
            this.cB_GGbot.Size = new System.Drawing.Size(76, 17);
            this.cB_GGbot.TabIndex = 0;
            this.cB_GGbot.Text = "cB_GGbot";
            this.cB_GGbot.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tB_custom_twitch);
            this.groupBox3.Controls.Add(this.lb_custom_twitch);
            this.groupBox3.Controls.Add(this.tB_custom_gg);
            this.groupBox3.Controls.Add(this.lb_custom_gg);
            this.groupBox3.Location = new System.Drawing.Point(12, 430);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(423, 60);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Custom Channel";
            // 
            // lb_custom_gg
            // 
            this.lb_custom_gg.AutoSize = true;
            this.lb_custom_gg.Location = new System.Drawing.Point(6, 16);
            this.lb_custom_gg.Name = "lb_custom_gg";
            this.lb_custom_gg.Size = new System.Drawing.Size(73, 13);
            this.lb_custom_gg.TabIndex = 0;
            this.lb_custom_gg.Text = "lb_custom_gg";
            // 
            // tB_custom_gg
            // 
            this.tB_custom_gg.Location = new System.Drawing.Point(6, 32);
            this.tB_custom_gg.Name = "tB_custom_gg";
            this.tB_custom_gg.Size = new System.Drawing.Size(202, 20);
            this.tB_custom_gg.TabIndex = 1;
            // 
            // lb_custom_twitch
            // 
            this.lb_custom_twitch.AutoSize = true;
            this.lb_custom_twitch.Location = new System.Drawing.Point(211, 16);
            this.lb_custom_twitch.Name = "lb_custom_twitch";
            this.lb_custom_twitch.Size = new System.Drawing.Size(89, 13);
            this.lb_custom_twitch.TabIndex = 2;
            this.lb_custom_twitch.Text = "lb_custom_twitch";
            // 
            // tB_custom_twitch
            // 
            this.tB_custom_twitch.Location = new System.Drawing.Point(214, 32);
            this.tB_custom_twitch.Name = "tB_custom_twitch";
            this.tB_custom_twitch.Size = new System.Drawing.Size(202, 20);
            this.tB_custom_twitch.TabIndex = 3;
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 531);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btn_default);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Settings";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_Settings";
            this.Load += new System.EventHandler(this.Form_Settings_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_chance)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_icon;
        private System.Windows.Forms.Label lb_help;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label lb_offline;
        public System.Windows.Forms.ComboBox cBox_icon;
        public System.Windows.Forms.TextBox tB_help;
        public System.Windows.Forms.TextBox tB_offline;
        private System.Windows.Forms.Button btn_default;
        public System.Windows.Forms.CheckBox cB_help_in_pm;
        private System.Windows.Forms.Label lb_welcome_subscribers;
        public System.Windows.Forms.CheckBox cB_welcome_subscribers;
        public System.Windows.Forms.TextBox tB_welcome_subscribers;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.CheckBox cB_random_quotes;
        private System.Windows.Forms.Button btn_сhoice;
        public System.Windows.Forms.TextBox tB_file;
        private System.Windows.Forms.Label lb_file;
        public System.Windows.Forms.NumericUpDown numUD_chance;
        private System.Windows.Forms.Label lb_chance;
        public System.Windows.Forms.TextBox tB_sleep;
        private System.Windows.Forms.Label lb_sleep;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_start_page;
        public System.Windows.Forms.ComboBox cBox_start_page;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.CheckBox cB_TwitchBot;
        public System.Windows.Forms.CheckBox cB_GGbot;
        public System.Windows.Forms.CheckBox cB_notify;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lb_custom_twitch;
        private System.Windows.Forms.Label lb_custom_gg;
        public System.Windows.Forms.TextBox tB_custom_twitch;
        public System.Windows.Forms.TextBox tB_custom_gg;
    }
}
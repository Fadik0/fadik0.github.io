namespace AssistantBroadcasts
{
    partial class Form_command
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_command));
            this.lb_command = new System.Windows.Forms.Label();
            this.tB_command = new System.Windows.Forms.TextBox();
            this.lb_response = new System.Windows.Forms.Label();
            this.tB_response = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.cB_send_pm = new System.Windows.Forms.CheckBox();
            this.cB_auto_help = new System.Windows.Forms.CheckBox();
            this.gB_settings = new System.Windows.Forms.GroupBox();
            this.cB_ban_command = new System.Windows.Forms.CheckBox();
            this.cB_del_command = new System.Windows.Forms.CheckBox();
            this.numUD_time = new System.Windows.Forms.NumericUpDown();
            this.lb_time = new System.Windows.Forms.Label();
            this.cB_regex_net = new System.Windows.Forms.CheckBox();
            this.cB_ignore_regitstr = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tB_file = new System.Windows.Forms.TextBox();
            this.btn_сhoice = new System.Windows.Forms.Button();
            this.lb_response_file = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.lb_description = new System.Windows.Forms.Label();
            this.tB_description = new System.Windows.Forms.TextBox();
            this.gB_permissions = new System.Windows.Forms.GroupBox();
            this.cB_users = new System.Windows.Forms.CheckBox();
            this.cB_premiums = new System.Windows.Forms.CheckBox();
            this.cB_assistants = new System.Windows.Forms.CheckBox();
            this.cB_streamers = new System.Windows.Forms.CheckBox();
            this.cBox_data_for_insert = new System.Windows.Forms.ComboBox();
            this.btn_insert = new System.Windows.Forms.Button();
            this.lb_required_fields = new System.Windows.Forms.Label();
            this.gB_settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_time)).BeginInit();
            this.gB_permissions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_command
            // 
            this.lb_command.AutoSize = true;
            this.lb_command.Location = new System.Drawing.Point(9, 9);
            this.lb_command.Name = "lb_command";
            this.lb_command.Size = new System.Drawing.Size(54, 13);
            this.lb_command.TabIndex = 0;
            this.lb_command.Text = "Command";
            // 
            // tB_command
            // 
            this.tB_command.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_command.Location = new System.Drawing.Point(12, 25);
            this.tB_command.Name = "tB_command";
            this.tB_command.Size = new System.Drawing.Size(460, 22);
            this.tB_command.TabIndex = 1;
            // 
            // lb_response
            // 
            this.lb_response.AutoSize = true;
            this.lb_response.Location = new System.Drawing.Point(9, 92);
            this.lb_response.Name = "lb_response";
            this.lb_response.Size = new System.Drawing.Size(55, 13);
            this.lb_response.TabIndex = 2;
            this.lb_response.Text = "Response";
            // 
            // tB_response
            // 
            this.tB_response.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_response.Location = new System.Drawing.Point(12, 108);
            this.tB_response.Multiline = true;
            this.tB_response.Name = "tB_response";
            this.tB_response.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tB_response.Size = new System.Drawing.Size(294, 153);
            this.tB_response.TabIndex = 3;
            this.tB_response.Click += new System.EventHandler(this.tB_response_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Location = new System.Drawing.Point(150, 343);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "btn_ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(231, 343);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "btn_cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // cB_send_pm
            // 
            this.cB_send_pm.AutoSize = true;
            this.cB_send_pm.Location = new System.Drawing.Point(6, 19);
            this.cB_send_pm.Name = "cB_send_pm";
            this.cB_send_pm.Size = new System.Drawing.Size(88, 17);
            this.cB_send_pm.TabIndex = 9;
            this.cB_send_pm.Text = "cB_send_pm";
            this.cB_send_pm.UseVisualStyleBackColor = true;
            // 
            // cB_auto_help
            // 
            this.cB_auto_help.AutoSize = true;
            this.cB_auto_help.Location = new System.Drawing.Point(6, 39);
            this.cB_auto_help.Name = "cB_auto_help";
            this.cB_auto_help.Size = new System.Drawing.Size(92, 17);
            this.cB_auto_help.TabIndex = 10;
            this.cB_auto_help.Text = "cB_auto_help";
            this.cB_auto_help.UseVisualStyleBackColor = true;
            // 
            // gB_settings
            // 
            this.gB_settings.Controls.Add(this.cB_ban_command);
            this.gB_settings.Controls.Add(this.cB_del_command);
            this.gB_settings.Controls.Add(this.numUD_time);
            this.gB_settings.Controls.Add(this.lb_time);
            this.gB_settings.Controls.Add(this.cB_regex_net);
            this.gB_settings.Controls.Add(this.cB_ignore_regitstr);
            this.gB_settings.Controls.Add(this.cB_auto_help);
            this.gB_settings.Controls.Add(this.cB_send_pm);
            this.gB_settings.Location = new System.Drawing.Point(312, 174);
            this.gB_settings.Name = "gB_settings";
            this.gB_settings.Size = new System.Drawing.Size(160, 195);
            this.gB_settings.TabIndex = 11;
            this.gB_settings.TabStop = false;
            this.gB_settings.Text = "gB_settings";
            // 
            // cB_ban_command
            // 
            this.cB_ban_command.AutoSize = true;
            this.cB_ban_command.Location = new System.Drawing.Point(6, 131);
            this.cB_ban_command.Name = "cB_ban_command";
            this.cB_ban_command.Size = new System.Drawing.Size(115, 17);
            this.cB_ban_command.TabIndex = 16;
            this.cB_ban_command.Text = "cB_ban_command";
            this.cB_ban_command.UseVisualStyleBackColor = true;
            // 
            // cB_del_command
            // 
            this.cB_del_command.AutoSize = true;
            this.cB_del_command.Location = new System.Drawing.Point(6, 108);
            this.cB_del_command.Name = "cB_del_command";
            this.cB_del_command.Size = new System.Drawing.Size(111, 17);
            this.cB_del_command.TabIndex = 15;
            this.cB_del_command.Text = "cB_del_command";
            this.cB_del_command.UseVisualStyleBackColor = true;
            // 
            // numUD_time
            // 
            this.numUD_time.Location = new System.Drawing.Point(7, 167);
            this.numUD_time.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numUD_time.Name = "numUD_time";
            this.numUD_time.Size = new System.Drawing.Size(125, 20);
            this.numUD_time.TabIndex = 14;
            // 
            // lb_time
            // 
            this.lb_time.AutoSize = true;
            this.lb_time.Location = new System.Drawing.Point(6, 151);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(30, 13);
            this.lb_time.TabIndex = 13;
            this.lb_time.Text = "Time";
            // 
            // cB_regex_net
            // 
            this.cB_regex_net.AutoSize = true;
            this.cB_regex_net.Location = new System.Drawing.Point(6, 85);
            this.cB_regex_net.Name = "cB_regex_net";
            this.cB_regex_net.Size = new System.Drawing.Size(92, 17);
            this.cB_regex_net.TabIndex = 12;
            this.cB_regex_net.Text = "cB_regex_net";
            this.cB_regex_net.UseVisualStyleBackColor = true;
            this.cB_regex_net.CheckedChanged += new System.EventHandler(this.cB_regex_net_CheckedChanged);
            // 
            // cB_ignore_regitstr
            // 
            this.cB_ignore_regitstr.AutoSize = true;
            this.cB_ignore_regitstr.Location = new System.Drawing.Point(6, 62);
            this.cB_ignore_regitstr.Name = "cB_ignore_regitstr";
            this.cB_ignore_regitstr.Size = new System.Drawing.Size(111, 17);
            this.cB_ignore_regitstr.TabIndex = 11;
            this.cB_ignore_regitstr.Text = "cB_ignore_regitstr";
            this.cB_ignore_regitstr.UseVisualStyleBackColor = true;
            this.cB_ignore_regitstr.CheckedChanged += new System.EventHandler(this.cB_ignore_regitstr_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 14);
            this.label1.TabIndex = 12;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 300;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 50;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Help!";
            // 
            // tB_file
            // 
            this.tB_file.Location = new System.Drawing.Point(12, 311);
            this.tB_file.Name = "tB_file";
            this.tB_file.Size = new System.Drawing.Size(279, 20);
            this.tB_file.TabIndex = 13;
            // 
            // btn_сhoice
            // 
            this.btn_сhoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_сhoice.Image = ((System.Drawing.Image)(resources.GetObject("btn_сhoice.Image")));
            this.btn_сhoice.Location = new System.Drawing.Point(285, 311);
            this.btn_сhoice.Name = "btn_сhoice";
            this.btn_сhoice.Size = new System.Drawing.Size(21, 20);
            this.btn_сhoice.TabIndex = 14;
            this.btn_сhoice.UseVisualStyleBackColor = true;
            this.btn_сhoice.Click += new System.EventHandler(this.btn_сhoice_Click);
            // 
            // lb_response_file
            // 
            this.lb_response_file.AutoSize = true;
            this.lb_response_file.Location = new System.Drawing.Point(9, 295);
            this.lb_response_file.Name = "lb_response_file";
            this.lb_response_file.Size = new System.Drawing.Size(94, 13);
            this.lb_response_file.TabIndex = 15;
            this.lb_response_file.Text = "Response from file";
            // 
            // lb_description
            // 
            this.lb_description.AutoSize = true;
            this.lb_description.Location = new System.Drawing.Point(9, 52);
            this.lb_description.Name = "lb_description";
            this.lb_description.Size = new System.Drawing.Size(60, 13);
            this.lb_description.TabIndex = 16;
            this.lb_description.Text = "Description";
            // 
            // tB_description
            // 
            this.tB_description.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_description.Location = new System.Drawing.Point(12, 68);
            this.tB_description.Name = "tB_description";
            this.tB_description.Size = new System.Drawing.Size(294, 22);
            this.tB_description.TabIndex = 17;
            // 
            // gB_permissions
            // 
            this.gB_permissions.Controls.Add(this.cB_users);
            this.gB_permissions.Controls.Add(this.cB_premiums);
            this.gB_permissions.Controls.Add(this.cB_assistants);
            this.gB_permissions.Controls.Add(this.cB_streamers);
            this.gB_permissions.Location = new System.Drawing.Point(312, 56);
            this.gB_permissions.Name = "gB_permissions";
            this.gB_permissions.Size = new System.Drawing.Size(160, 112);
            this.gB_permissions.TabIndex = 18;
            this.gB_permissions.TabStop = false;
            this.gB_permissions.Text = "gB_permissions";
            // 
            // cB_users
            // 
            this.cB_users.AutoSize = true;
            this.cB_users.Location = new System.Drawing.Point(6, 88);
            this.cB_users.Name = "cB_users";
            this.cB_users.Size = new System.Drawing.Size(70, 17);
            this.cB_users.TabIndex = 12;
            this.cB_users.Text = "cB_users";
            this.cB_users.UseVisualStyleBackColor = true;
            // 
            // cB_premiums
            // 
            this.cB_premiums.AutoSize = true;
            this.cB_premiums.Location = new System.Drawing.Point(6, 19);
            this.cB_premiums.Name = "cB_premiums";
            this.cB_premiums.Size = new System.Drawing.Size(89, 17);
            this.cB_premiums.TabIndex = 9;
            this.cB_premiums.Text = "cB_premiums";
            this.cB_premiums.UseVisualStyleBackColor = true;
            // 
            // cB_assistants
            // 
            this.cB_assistants.AutoSize = true;
            this.cB_assistants.Location = new System.Drawing.Point(6, 65);
            this.cB_assistants.Name = "cB_assistants";
            this.cB_assistants.Size = new System.Drawing.Size(91, 17);
            this.cB_assistants.TabIndex = 10;
            this.cB_assistants.Text = "cB_assistants";
            this.cB_assistants.UseVisualStyleBackColor = true;
            // 
            // cB_streamers
            // 
            this.cB_streamers.AutoSize = true;
            this.cB_streamers.Location = new System.Drawing.Point(6, 42);
            this.cB_streamers.Name = "cB_streamers";
            this.cB_streamers.Size = new System.Drawing.Size(90, 17);
            this.cB_streamers.TabIndex = 11;
            this.cB_streamers.Text = "cB_streamers";
            this.cB_streamers.UseVisualStyleBackColor = true;
            // 
            // cBox_data_for_insert
            // 
            this.cBox_data_for_insert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBox_data_for_insert.FormattingEnabled = true;
            this.cBox_data_for_insert.Location = new System.Drawing.Point(12, 267);
            this.cBox_data_for_insert.Name = "cBox_data_for_insert";
            this.cBox_data_for_insert.Size = new System.Drawing.Size(213, 21);
            this.cBox_data_for_insert.TabIndex = 20;
            this.cBox_data_for_insert.SelectedIndexChanged += new System.EventHandler(this.cBox_data_for_insert_SelectedIndexChanged);
            // 
            // btn_insert
            // 
            this.btn_insert.Location = new System.Drawing.Point(231, 266);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(75, 22);
            this.btn_insert.TabIndex = 21;
            this.btn_insert.Text = "btn_insert";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // lb_required_fields
            // 
            this.lb_required_fields.AutoSize = true;
            this.lb_required_fields.Location = new System.Drawing.Point(12, 348);
            this.lb_required_fields.Name = "lb_required_fields";
            this.lb_required_fields.Size = new System.Drawing.Size(89, 13);
            this.lb_required_fields.TabIndex = 27;
            this.lb_required_fields.Text = "lb_required_fields";
            // 
            // Form_command
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 381);
            this.Controls.Add(this.lb_required_fields);
            this.Controls.Add(this.btn_insert);
            this.Controls.Add(this.cBox_data_for_insert);
            this.Controls.Add(this.gB_permissions);
            this.Controls.Add(this.tB_description);
            this.Controls.Add(this.lb_description);
            this.Controls.Add(this.lb_response_file);
            this.Controls.Add(this.btn_сhoice);
            this.Controls.Add(this.tB_file);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gB_settings);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.tB_response);
            this.Controls.Add(this.lb_response);
            this.Controls.Add(this.tB_command);
            this.Controls.Add(this.lb_command);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_command";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_Command";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_command_FormClosing);
            this.Load += new System.EventHandler(this.Form_command_Load);
            this.gB_settings.ResumeLayout(false);
            this.gB_settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_time)).EndInit();
            this.gB_permissions.ResumeLayout(false);
            this.gB_permissions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_command;
        private System.Windows.Forms.Label lb_response;
        public System.Windows.Forms.TextBox tB_command;
        public System.Windows.Forms.TextBox tB_response;
        public System.Windows.Forms.Button btn_ok;
        public System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.GroupBox gB_settings;
        public System.Windows.Forms.CheckBox cB_send_pm;
        public System.Windows.Forms.CheckBox cB_auto_help;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip;
        public System.Windows.Forms.CheckBox cB_ignore_regitstr;
        public System.Windows.Forms.CheckBox cB_regex_net;
        private System.Windows.Forms.Label lb_time;
        public System.Windows.Forms.NumericUpDown numUD_time;
        private System.Windows.Forms.Button btn_сhoice;
        private System.Windows.Forms.Label lb_response_file;
        public System.Windows.Forms.CheckBox cB_ban_command;
        public System.Windows.Forms.CheckBox cB_del_command;
        public System.Windows.Forms.TextBox tB_file;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Label lb_description;
        public System.Windows.Forms.TextBox tB_description;
        private System.Windows.Forms.GroupBox gB_permissions;
        public System.Windows.Forms.CheckBox cB_premiums;
        public System.Windows.Forms.CheckBox cB_assistants;
        public System.Windows.Forms.CheckBox cB_streamers;
        private System.Windows.Forms.ComboBox cBox_data_for_insert;
        public System.Windows.Forms.Button btn_insert;
        public System.Windows.Forms.CheckBox cB_users;
        private System.Windows.Forms.Label lb_required_fields;
    }
}
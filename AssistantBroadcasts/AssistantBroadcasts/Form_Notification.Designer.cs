namespace AssistantBroadcasts
{
    partial class Form_Notification
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
            this.lb_name = new System.Windows.Forms.Label();
            this.tB_name = new System.Windows.Forms.TextBox();
            this.lb_description = new System.Windows.Forms.Label();
            this.tB_description = new System.Windows.Forms.TextBox();
            this.gB_settings = new System.Windows.Forms.GroupBox();
            this.tB_sound = new System.Windows.Forms.TextBox();
            this.lb_sound = new System.Windows.Forms.Label();
            this.numUD_volume = new System.Windows.Forms.NumericUpDown();
            this.lb_volume = new System.Windows.Forms.Label();
            this.tB_image = new System.Windows.Forms.TextBox();
            this.lb_image = new System.Windows.Forms.Label();
            this.btn_insert = new System.Windows.Forms.Button();
            this.cB_insert = new System.Windows.Forms.ComboBox();
            this.lb_insert = new System.Windows.Forms.Label();
            this.cB_an_out = new System.Windows.Forms.ComboBox();
            this.lb_an_out = new System.Windows.Forms.Label();
            this.cB_an_in = new System.Windows.Forms.ComboBox();
            this.lb_an_in = new System.Windows.Forms.Label();
            this.cB_an_name = new System.Windows.Forms.ComboBox();
            this.lb_an_name = new System.Windows.Forms.Label();
            this.tB_text = new System.Windows.Forms.TextBox();
            this.lb_text = new System.Windows.Forms.Label();
            this.gB_style = new System.Windows.Forms.GroupBox();
            this.numUD_ssize = new System.Windows.Forms.NumericUpDown();
            this.lb_scolor = new System.Windows.Forms.Label();
            this.lb_ssize = new System.Windows.Forms.Label();
            this.btn_scolor = new System.Windows.Forms.Button();
            this.lb_color = new System.Windows.Forms.Label();
            this.cB_align = new System.Windows.Forms.ComboBox();
            this.lb_align = new System.Windows.Forms.Label();
            this.btn_color = new System.Windows.Forms.Button();
            this.cB_font = new System.Windows.Forms.ComboBox();
            this.numUD_font_size = new System.Windows.Forms.NumericUpDown();
            this.lb_font_size = new System.Windows.Forms.Label();
            this.lb_font = new System.Windows.Forms.Label();
            this.numUD_width = new System.Windows.Forms.NumericUpDown();
            this.lb_width = new System.Windows.Forms.Label();
            this.numUD_height = new System.Windows.Forms.NumericUpDown();
            this.lb_height = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.gB_settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_volume)).BeginInit();
            this.gB_style.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_ssize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_font_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_height)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Location = new System.Drawing.Point(12, 9);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(47, 13);
            this.lb_name.TabIndex = 0;
            this.lb_name.Text = "lb_name";
            // 
            // tB_name
            // 
            this.tB_name.Location = new System.Drawing.Point(12, 25);
            this.tB_name.Name = "tB_name";
            this.tB_name.ReadOnly = true;
            this.tB_name.Size = new System.Drawing.Size(360, 20);
            this.tB_name.TabIndex = 1;
            // 
            // lb_description
            // 
            this.lb_description.AutoSize = true;
            this.lb_description.Location = new System.Drawing.Point(12, 48);
            this.lb_description.Name = "lb_description";
            this.lb_description.Size = new System.Drawing.Size(72, 13);
            this.lb_description.TabIndex = 2;
            this.lb_description.Text = "lb_description";
            // 
            // tB_description
            // 
            this.tB_description.Location = new System.Drawing.Point(12, 64);
            this.tB_description.Name = "tB_description";
            this.tB_description.ReadOnly = true;
            this.tB_description.Size = new System.Drawing.Size(360, 20);
            this.tB_description.TabIndex = 3;
            // 
            // gB_settings
            // 
            this.gB_settings.Controls.Add(this.tB_sound);
            this.gB_settings.Controls.Add(this.lb_sound);
            this.gB_settings.Controls.Add(this.numUD_volume);
            this.gB_settings.Controls.Add(this.lb_volume);
            this.gB_settings.Controls.Add(this.tB_image);
            this.gB_settings.Controls.Add(this.lb_image);
            this.gB_settings.Controls.Add(this.btn_insert);
            this.gB_settings.Controls.Add(this.cB_insert);
            this.gB_settings.Controls.Add(this.lb_insert);
            this.gB_settings.Controls.Add(this.cB_an_out);
            this.gB_settings.Controls.Add(this.lb_an_out);
            this.gB_settings.Controls.Add(this.cB_an_in);
            this.gB_settings.Controls.Add(this.lb_an_in);
            this.gB_settings.Controls.Add(this.cB_an_name);
            this.gB_settings.Controls.Add(this.lb_an_name);
            this.gB_settings.Controls.Add(this.tB_text);
            this.gB_settings.Controls.Add(this.lb_text);
            this.gB_settings.Location = new System.Drawing.Point(12, 90);
            this.gB_settings.Name = "gB_settings";
            this.gB_settings.Size = new System.Drawing.Size(360, 224);
            this.gB_settings.TabIndex = 4;
            this.gB_settings.TabStop = false;
            this.gB_settings.Text = "gB_settings";
            // 
            // tB_sound
            // 
            this.tB_sound.Location = new System.Drawing.Point(100, 192);
            this.tB_sound.Name = "tB_sound";
            this.tB_sound.Size = new System.Drawing.Size(254, 20);
            this.tB_sound.TabIndex = 16;
            // 
            // lb_sound
            // 
            this.lb_sound.AutoSize = true;
            this.lb_sound.Location = new System.Drawing.Point(97, 175);
            this.lb_sound.Name = "lb_sound";
            this.lb_sound.Size = new System.Drawing.Size(50, 13);
            this.lb_sound.TabIndex = 15;
            this.lb_sound.Text = "lb_sound";
            // 
            // numUD_volume
            // 
            this.numUD_volume.Location = new System.Drawing.Point(9, 192);
            this.numUD_volume.Name = "numUD_volume";
            this.numUD_volume.Size = new System.Drawing.Size(85, 20);
            this.numUD_volume.TabIndex = 14;
            // 
            // lb_volume
            // 
            this.lb_volume.AutoSize = true;
            this.lb_volume.Location = new System.Drawing.Point(6, 175);
            this.lb_volume.Name = "lb_volume";
            this.lb_volume.Size = new System.Drawing.Size(55, 13);
            this.lb_volume.TabIndex = 13;
            this.lb_volume.Text = "lb_volume";
            // 
            // tB_image
            // 
            this.tB_image.Location = new System.Drawing.Point(9, 152);
            this.tB_image.Name = "tB_image";
            this.tB_image.Size = new System.Drawing.Size(345, 20);
            this.tB_image.TabIndex = 12;
            // 
            // lb_image
            // 
            this.lb_image.AutoSize = true;
            this.lb_image.Location = new System.Drawing.Point(6, 136);
            this.lb_image.Name = "lb_image";
            this.lb_image.Size = new System.Drawing.Size(49, 13);
            this.lb_image.TabIndex = 11;
            this.lb_image.Text = "lb_image";
            // 
            // btn_insert
            // 
            this.btn_insert.Location = new System.Drawing.Point(141, 110);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(80, 23);
            this.btn_insert.TabIndex = 10;
            this.btn_insert.Text = "btn_insert";
            this.btn_insert.UseVisualStyleBackColor = true;
            // 
            // cB_insert
            // 
            this.cB_insert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_insert.FormattingEnabled = true;
            this.cB_insert.Location = new System.Drawing.Point(9, 112);
            this.cB_insert.Name = "cB_insert";
            this.cB_insert.Size = new System.Drawing.Size(129, 21);
            this.cB_insert.TabIndex = 9;
            // 
            // lb_insert
            // 
            this.lb_insert.AutoSize = true;
            this.lb_insert.Location = new System.Drawing.Point(6, 96);
            this.lb_insert.Name = "lb_insert";
            this.lb_insert.Size = new System.Drawing.Size(46, 13);
            this.lb_insert.TabIndex = 8;
            this.lb_insert.Text = "lb_insert";
            // 
            // cB_an_out
            // 
            this.cB_an_out.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_an_out.FormattingEnabled = true;
            this.cB_an_out.Location = new System.Drawing.Point(227, 112);
            this.cB_an_out.Name = "cB_an_out";
            this.cB_an_out.Size = new System.Drawing.Size(127, 21);
            this.cB_an_out.TabIndex = 7;
            // 
            // lb_an_out
            // 
            this.lb_an_out.AutoSize = true;
            this.lb_an_out.Location = new System.Drawing.Point(227, 96);
            this.lb_an_out.Name = "lb_an_out";
            this.lb_an_out.Size = new System.Drawing.Size(54, 13);
            this.lb_an_out.TabIndex = 6;
            this.lb_an_out.Text = "lb_an_out";
            // 
            // cB_an_in
            // 
            this.cB_an_in.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_an_in.FormattingEnabled = true;
            this.cB_an_in.Location = new System.Drawing.Point(227, 72);
            this.cB_an_in.Name = "cB_an_in";
            this.cB_an_in.Size = new System.Drawing.Size(127, 21);
            this.cB_an_in.TabIndex = 5;
            // 
            // lb_an_in
            // 
            this.lb_an_in.AutoSize = true;
            this.lb_an_in.Location = new System.Drawing.Point(227, 56);
            this.lb_an_in.Name = "lb_an_in";
            this.lb_an_in.Size = new System.Drawing.Size(47, 13);
            this.lb_an_in.TabIndex = 4;
            this.lb_an_in.Text = "lb_an_in";
            // 
            // cB_an_name
            // 
            this.cB_an_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_an_name.FormattingEnabled = true;
            this.cB_an_name.Location = new System.Drawing.Point(227, 32);
            this.cB_an_name.Name = "cB_an_name";
            this.cB_an_name.Size = new System.Drawing.Size(127, 21);
            this.cB_an_name.TabIndex = 3;
            // 
            // lb_an_name
            // 
            this.lb_an_name.AutoSize = true;
            this.lb_an_name.Location = new System.Drawing.Point(227, 16);
            this.lb_an_name.Name = "lb_an_name";
            this.lb_an_name.Size = new System.Drawing.Size(65, 13);
            this.lb_an_name.TabIndex = 2;
            this.lb_an_name.Text = "lb_an_name";
            // 
            // tB_text
            // 
            this.tB_text.Location = new System.Drawing.Point(9, 32);
            this.tB_text.Multiline = true;
            this.tB_text.Name = "tB_text";
            this.tB_text.Size = new System.Drawing.Size(212, 61);
            this.tB_text.TabIndex = 1;
            // 
            // lb_text
            // 
            this.lb_text.AutoSize = true;
            this.lb_text.Location = new System.Drawing.Point(6, 16);
            this.lb_text.Name = "lb_text";
            this.lb_text.Size = new System.Drawing.Size(38, 13);
            this.lb_text.TabIndex = 0;
            this.lb_text.Text = "lb_text";
            // 
            // gB_style
            // 
            this.gB_style.Controls.Add(this.numUD_ssize);
            this.gB_style.Controls.Add(this.lb_scolor);
            this.gB_style.Controls.Add(this.lb_ssize);
            this.gB_style.Controls.Add(this.btn_scolor);
            this.gB_style.Controls.Add(this.lb_color);
            this.gB_style.Controls.Add(this.cB_align);
            this.gB_style.Controls.Add(this.lb_align);
            this.gB_style.Controls.Add(this.btn_color);
            this.gB_style.Controls.Add(this.cB_font);
            this.gB_style.Controls.Add(this.numUD_font_size);
            this.gB_style.Controls.Add(this.lb_font_size);
            this.gB_style.Controls.Add(this.lb_font);
            this.gB_style.Controls.Add(this.numUD_width);
            this.gB_style.Controls.Add(this.lb_width);
            this.gB_style.Controls.Add(this.numUD_height);
            this.gB_style.Controls.Add(this.lb_height);
            this.gB_style.Location = new System.Drawing.Point(12, 321);
            this.gB_style.Name = "gB_style";
            this.gB_style.Size = new System.Drawing.Size(360, 103);
            this.gB_style.TabIndex = 5;
            this.gB_style.TabStop = false;
            this.gB_style.Text = "gB_style";
            // 
            // numUD_ssize
            // 
            this.numUD_ssize.Location = new System.Drawing.Point(267, 72);
            this.numUD_ssize.Name = "numUD_ssize";
            this.numUD_ssize.Size = new System.Drawing.Size(85, 20);
            this.numUD_ssize.TabIndex = 17;
            // 
            // lb_scolor
            // 
            this.lb_scolor.AutoSize = true;
            this.lb_scolor.Location = new System.Drawing.Point(181, 56);
            this.lb_scolor.Name = "lb_scolor";
            this.lb_scolor.Size = new System.Drawing.Size(49, 13);
            this.lb_scolor.TabIndex = 16;
            this.lb_scolor.Text = "lb_scolor";
            // 
            // lb_ssize
            // 
            this.lb_ssize.AutoSize = true;
            this.lb_ssize.Location = new System.Drawing.Point(267, 56);
            this.lb_ssize.Name = "lb_ssize";
            this.lb_ssize.Size = new System.Drawing.Size(44, 13);
            this.lb_ssize.TabIndex = 14;
            this.lb_ssize.Text = "lb_ssize";
            // 
            // btn_scolor
            // 
            this.btn_scolor.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_scolor.Location = new System.Drawing.Point(181, 70);
            this.btn_scolor.Name = "btn_scolor";
            this.btn_scolor.Size = new System.Drawing.Size(80, 23);
            this.btn_scolor.TabIndex = 13;
            this.btn_scolor.UseVisualStyleBackColor = false;
            this.btn_scolor.Click += new System.EventHandler(this.btn_scolor_Click);
            // 
            // lb_color
            // 
            this.lb_color.AutoSize = true;
            this.lb_color.Location = new System.Drawing.Point(6, 56);
            this.lb_color.Name = "lb_color";
            this.lb_color.Size = new System.Drawing.Size(44, 13);
            this.lb_color.TabIndex = 12;
            this.lb_color.Text = "lb_color";
            // 
            // cB_align
            // 
            this.cB_align.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_align.FormattingEnabled = true;
            this.cB_align.Location = new System.Drawing.Point(95, 72);
            this.cB_align.Name = "cB_align";
            this.cB_align.Size = new System.Drawing.Size(80, 21);
            this.cB_align.TabIndex = 11;
            // 
            // lb_align
            // 
            this.lb_align.AutoSize = true;
            this.lb_align.Location = new System.Drawing.Point(92, 56);
            this.lb_align.Name = "lb_align";
            this.lb_align.Size = new System.Drawing.Size(43, 13);
            this.lb_align.TabIndex = 10;
            this.lb_align.Text = "lb_align";
            // 
            // btn_color
            // 
            this.btn_color.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_color.Location = new System.Drawing.Point(9, 72);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(80, 21);
            this.btn_color.TabIndex = 9;
            this.btn_color.UseVisualStyleBackColor = false;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // cB_font
            // 
            this.cB_font.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_font.FormattingEnabled = true;
            this.cB_font.Location = new System.Drawing.Point(181, 32);
            this.cB_font.Name = "cB_font";
            this.cB_font.Size = new System.Drawing.Size(80, 21);
            this.cB_font.TabIndex = 8;
            // 
            // numUD_font_size
            // 
            this.numUD_font_size.Location = new System.Drawing.Point(267, 33);
            this.numUD_font_size.Name = "numUD_font_size";
            this.numUD_font_size.Size = new System.Drawing.Size(85, 20);
            this.numUD_font_size.TabIndex = 7;
            // 
            // lb_font_size
            // 
            this.lb_font_size.AutoSize = true;
            this.lb_font_size.Location = new System.Drawing.Point(264, 17);
            this.lb_font_size.Name = "lb_font_size";
            this.lb_font_size.Size = new System.Drawing.Size(63, 13);
            this.lb_font_size.TabIndex = 6;
            this.lb_font_size.Text = "lb_font_size";
            // 
            // lb_font
            // 
            this.lb_font.AutoSize = true;
            this.lb_font.Location = new System.Drawing.Point(178, 17);
            this.lb_font.Name = "lb_font";
            this.lb_font.Size = new System.Drawing.Size(39, 13);
            this.lb_font.TabIndex = 4;
            this.lb_font.Text = "lb_font";
            // 
            // numUD_width
            // 
            this.numUD_width.Location = new System.Drawing.Point(95, 33);
            this.numUD_width.Name = "numUD_width";
            this.numUD_width.Size = new System.Drawing.Size(80, 20);
            this.numUD_width.TabIndex = 3;
            // 
            // lb_width
            // 
            this.lb_width.AutoSize = true;
            this.lb_width.Location = new System.Drawing.Point(92, 16);
            this.lb_width.Name = "lb_width";
            this.lb_width.Size = new System.Drawing.Size(46, 13);
            this.lb_width.TabIndex = 2;
            this.lb_width.Text = "lb_width";
            // 
            // numUD_height
            // 
            this.numUD_height.Location = new System.Drawing.Point(9, 33);
            this.numUD_height.Name = "numUD_height";
            this.numUD_height.Size = new System.Drawing.Size(80, 20);
            this.numUD_height.TabIndex = 1;
            // 
            // lb_height
            // 
            this.lb_height.AutoSize = true;
            this.lb_height.Location = new System.Drawing.Point(6, 17);
            this.lb_height.Name = "lb_height";
            this.lb_height.Size = new System.Drawing.Size(50, 13);
            this.lb_height.TabIndex = 0;
            this.lb_height.Text = "lb_height";
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(279, 430);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(93, 23);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "btn_cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_ok
            // 
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Location = new System.Drawing.Point(181, 430);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(93, 23);
            this.btn_ok.TabIndex = 7;
            this.btn_ok.Text = "btn_ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            // 
            // Form_Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.gB_style);
            this.Controls.Add(this.gB_settings);
            this.Controls.Add(this.tB_description);
            this.Controls.Add(this.lb_description);
            this.Controls.Add(this.tB_name);
            this.Controls.Add(this.lb_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_Notification";
            this.Text = "Form_Notification";
            this.Load += new System.EventHandler(this.Form_Notification_Load);
            this.gB_settings.ResumeLayout(false);
            this.gB_settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_volume)).EndInit();
            this.gB_style.ResumeLayout(false);
            this.gB_style.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_ssize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_font_size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_height)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Label lb_description;
        private System.Windows.Forms.GroupBox gB_settings;
        private System.Windows.Forms.Label lb_sound;
        private System.Windows.Forms.Label lb_volume;
        private System.Windows.Forms.Label lb_image;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.ComboBox cB_insert;
        private System.Windows.Forms.Label lb_insert;
        private System.Windows.Forms.Label lb_an_out;
        private System.Windows.Forms.Label lb_an_in;
        private System.Windows.Forms.Label lb_an_name;
        private System.Windows.Forms.Label lb_text;
        private System.Windows.Forms.GroupBox gB_style;
        private System.Windows.Forms.Label lb_scolor;
        private System.Windows.Forms.Label lb_ssize;
        private System.Windows.Forms.Label lb_color;
        private System.Windows.Forms.Label lb_align;
        private System.Windows.Forms.Label lb_font_size;
        private System.Windows.Forms.Label lb_font;
        private System.Windows.Forms.Label lb_width;
        private System.Windows.Forms.Label lb_height;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        public System.Windows.Forms.TextBox tB_name;
        public System.Windows.Forms.TextBox tB_description;
        public System.Windows.Forms.TextBox tB_sound;
        public System.Windows.Forms.NumericUpDown numUD_volume;
        public System.Windows.Forms.TextBox tB_image;
        public System.Windows.Forms.ComboBox cB_an_out;
        public System.Windows.Forms.ComboBox cB_an_in;
        public System.Windows.Forms.ComboBox cB_an_name;
        public System.Windows.Forms.Button btn_scolor;
        public System.Windows.Forms.ComboBox cB_align;
        public System.Windows.Forms.Button btn_color;
        public System.Windows.Forms.ComboBox cB_font;
        public System.Windows.Forms.NumericUpDown numUD_font_size;
        public System.Windows.Forms.NumericUpDown numUD_width;
        public System.Windows.Forms.NumericUpDown numUD_height;
        public System.Windows.Forms.NumericUpDown numUD_ssize;
        public System.Windows.Forms.TextBox tB_text;
    }
}
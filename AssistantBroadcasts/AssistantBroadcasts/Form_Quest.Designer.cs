namespace AssistantBroadcasts
{
    partial class Form_Quest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Quest));
            this.lb_name = new System.Windows.Forms.Label();
            this.lb_description = new System.Windows.Forms.Label();
            this.tB_name = new System.Windows.Forms.TextBox();
            this.tB_description = new System.Windows.Forms.TextBox();
            this.lb_response = new System.Windows.Forms.Label();
            this.tB_response = new System.Windows.Forms.TextBox();
            this.lb_chance = new System.Windows.Forms.Label();
            this.numUD_chance = new System.Windows.Forms.NumericUpDown();
            this.lb_hint = new System.Windows.Forms.Label();
            this.tB_hint = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_gen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_chance)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Location = new System.Drawing.Point(12, 9);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(67, 13);
            this.lb_name.TabIndex = 0;
            this.lb_name.Text = "Secret name";
            // 
            // lb_description
            // 
            this.lb_description.AutoSize = true;
            this.lb_description.Location = new System.Drawing.Point(12, 48);
            this.lb_description.Name = "lb_description";
            this.lb_description.Size = new System.Drawing.Size(89, 13);
            this.lb_description.TabIndex = 1;
            this.lb_description.Text = "Quest description";
            // 
            // tB_name
            // 
            this.tB_name.Location = new System.Drawing.Point(12, 25);
            this.tB_name.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.tB_name.Name = "tB_name";
            this.tB_name.Size = new System.Drawing.Size(405, 20);
            this.tB_name.TabIndex = 2;
            // 
            // tB_description
            // 
            this.tB_description.Location = new System.Drawing.Point(12, 64);
            this.tB_description.Multiline = true;
            this.tB_description.Name = "tB_description";
            this.tB_description.Size = new System.Drawing.Size(426, 67);
            this.tB_description.TabIndex = 3;
            // 
            // lb_response
            // 
            this.lb_response.AutoSize = true;
            this.lb_response.Location = new System.Drawing.Point(11, 135);
            this.lb_response.Name = "lb_response";
            this.lb_response.Size = new System.Drawing.Size(81, 13);
            this.lb_response.TabIndex = 4;
            this.lb_response.Text = "Quest response";
            // 
            // tB_response
            // 
            this.tB_response.Location = new System.Drawing.Point(12, 151);
            this.tB_response.Name = "tB_response";
            this.tB_response.Size = new System.Drawing.Size(425, 20);
            this.tB_response.TabIndex = 5;
            // 
            // lb_chance
            // 
            this.lb_chance.AutoSize = true;
            this.lb_chance.Location = new System.Drawing.Point(11, 174);
            this.lb_chance.Name = "lb_chance";
            this.lb_chance.Size = new System.Drawing.Size(64, 13);
            this.lb_chance.TabIndex = 6;
            this.lb_chance.Text = "Chance hint";
            // 
            // numUD_chance
            // 
            this.numUD_chance.Location = new System.Drawing.Point(12, 190);
            this.numUD_chance.Name = "numUD_chance";
            this.numUD_chance.Size = new System.Drawing.Size(66, 20);
            this.numUD_chance.TabIndex = 7;
            // 
            // lb_hint
            // 
            this.lb_hint.AutoSize = true;
            this.lb_hint.Location = new System.Drawing.Point(81, 174);
            this.lb_hint.Name = "lb_hint";
            this.lb_hint.Size = new System.Drawing.Size(151, 13);
            this.lb_hint.TabIndex = 8;
            this.lb_hint.Text = "Hint when the wrong response";
            // 
            // tB_hint
            // 
            this.tB_hint.Location = new System.Drawing.Point(84, 190);
            this.tB_hint.Name = "tB_hint";
            this.tB_hint.Size = new System.Drawing.Size(352, 20);
            this.tB_hint.TabIndex = 9;
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(362, 216);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 10;
            this.btn_cancel.Text = global::AssistantBroadcasts.Properties.Resources.cancel;
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(281, 216);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = global::AssistantBroadcasts.Properties.Resources.ok;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_gen
            // 
            this.btn_gen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_gen.Image = global::AssistantBroadcasts.Properties.Resources.ic_casino_black_18dp;
            this.btn_gen.Location = new System.Drawing.Point(417, 25);
            this.btn_gen.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btn_gen.Name = "btn_gen";
            this.btn_gen.Size = new System.Drawing.Size(21, 20);
            this.btn_gen.TabIndex = 15;
            this.btn_gen.UseVisualStyleBackColor = true;
            this.btn_gen.Click += new System.EventHandler(this.btn_gen_Click);
            // 
            // Form_Quest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 251);
            this.Controls.Add(this.btn_gen);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.tB_hint);
            this.Controls.Add(this.lb_hint);
            this.Controls.Add(this.numUD_chance);
            this.Controls.Add(this.lb_chance);
            this.Controls.Add(this.tB_response);
            this.Controls.Add(this.lb_response);
            this.Controls.Add(this.tB_description);
            this.Controls.Add(this.tB_name);
            this.Controls.Add(this.lb_description);
            this.Controls.Add(this.lb_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Quest";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_Quest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Quest_FormClosing);
            this.Load += new System.EventHandler(this.Form_Quest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUD_chance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Label lb_description;
        private System.Windows.Forms.Label lb_response;
        private System.Windows.Forms.Label lb_chance;
        private System.Windows.Forms.Label lb_hint;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox tB_name;
        public System.Windows.Forms.TextBox tB_description;
        public System.Windows.Forms.TextBox tB_response;
        public System.Windows.Forms.NumericUpDown numUD_chance;
        public System.Windows.Forms.TextBox tB_hint;
        private System.Windows.Forms.Button btn_gen;
    }
}
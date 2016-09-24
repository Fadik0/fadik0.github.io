namespace AssistantBroadcasts
{
    partial class Form_Logs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Logs));
            this.btn_save = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tB_Log = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_save.Location = new System.Drawing.Point(0, 238);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(384, 23);
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "btn_save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tB_Log
            // 
            this.tB_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tB_Log.Location = new System.Drawing.Point(0, 0);
            this.tB_Log.Multiline = true;
            this.tB_Log.Name = "tB_Log";
            this.tB_Log.ReadOnly = true;
            this.tB_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tB_Log.Size = new System.Drawing.Size(384, 238);
            this.tB_Log.TabIndex = 4;
            // 
            // Form_Logs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.tB_Log);
            this.Controls.Add(this.btn_save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "Form_Logs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_Logs";
            this.Load += new System.EventHandler(this.Form_Logs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        public System.Windows.Forms.TextBox tB_Log;
    }
}
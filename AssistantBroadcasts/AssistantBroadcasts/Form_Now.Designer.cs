namespace AssistantBroadcasts
{
    partial class Form_Now
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Now));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip_left = new System.Windows.Forms.MenuStrip();
            this.MenuItem_GG_Favorite = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_GG_Top = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Twitch_Favorite = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Twitch_Top = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Twitch_Games = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_top = new System.Windows.Forms.MenuStrip();
            this.MenuItem_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Launch = new System.Windows.Forms.ToolStripMenuItem();
            this.tB_Watch_Now = new System.Windows.Forms.ToolStripTextBox();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip_left.SuspendLayout();
            this.menuStrip_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // menuStrip_left
            // 
            this.menuStrip_left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(48)))), ((int)(((byte)(86)))));
            this.menuStrip_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip_left.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip_left.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip_left.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_GG_Favorite,
            this.MenuItem_Exit,
            this.MenuItem_GG_Top,
            this.MenuItem_Twitch_Favorite,
            this.MenuItem_Twitch_Top,
            this.MenuItem_Twitch_Games,
            this.MenuItem_Refresh});
            this.menuStrip_left.Location = new System.Drawing.Point(0, 26);
            this.menuStrip_left.Name = "menuStrip_left";
            this.menuStrip_left.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip_left.ShowItemToolTips = true;
            this.menuStrip_left.Size = new System.Drawing.Size(36, 544);
            this.menuStrip_left.TabIndex = 1;
            this.menuStrip_left.Text = "menuStrip2";
            // 
            // MenuItem_GG_Favorite
            // 
            this.MenuItem_GG_Favorite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuItem_GG_Favorite.Image = global::AssistantBroadcasts.Properties.Resources.ic_favorite_goodgame_48dp;
            this.MenuItem_GG_Favorite.Name = "MenuItem_GG_Favorite";
            this.MenuItem_GG_Favorite.Padding = new System.Windows.Forms.Padding(0);
            this.MenuItem_GG_Favorite.Size = new System.Drawing.Size(35, 36);
            this.MenuItem_GG_Favorite.ToolTipText = global::AssistantBroadcasts.Properties.Resources.now_favorites_goodgame;
            this.MenuItem_GG_Favorite.Click += new System.EventHandler(this.MenuItem_GG_Favorite_Click);
            // 
            // MenuItem_Exit
            // 
            this.MenuItem_Exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MenuItem_Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuItem_Exit.Image = ((System.Drawing.Image)(resources.GetObject("MenuItem_Exit.Image")));
            this.MenuItem_Exit.Name = "MenuItem_Exit";
            this.MenuItem_Exit.Padding = new System.Windows.Forms.Padding(0);
            this.MenuItem_Exit.Size = new System.Drawing.Size(35, 36);
            this.MenuItem_Exit.Text = "MenuItem_Exit";
            this.MenuItem_Exit.ToolTipText = global::AssistantBroadcasts.Properties.Resources.now_exit_app;
            this.MenuItem_Exit.Click += new System.EventHandler(this.MenuItem_Exit_Click);
            // 
            // MenuItem_GG_Top
            // 
            this.MenuItem_GG_Top.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuItem_GG_Top.Image = global::AssistantBroadcasts.Properties.Resources.ic_star_goodgame_48dp;
            this.MenuItem_GG_Top.Name = "MenuItem_GG_Top";
            this.MenuItem_GG_Top.Padding = new System.Windows.Forms.Padding(0);
            this.MenuItem_GG_Top.Size = new System.Drawing.Size(35, 36);
            this.MenuItem_GG_Top.ToolTipText = global::AssistantBroadcasts.Properties.Resources.now_top_goodgame;
            this.MenuItem_GG_Top.Click += new System.EventHandler(this.MenuItem_GG_Top_Click);
            // 
            // MenuItem_Twitch_Favorite
            // 
            this.MenuItem_Twitch_Favorite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuItem_Twitch_Favorite.Image = global::AssistantBroadcasts.Properties.Resources.ic_favorite_twitch_48dp;
            this.MenuItem_Twitch_Favorite.Name = "MenuItem_Twitch_Favorite";
            this.MenuItem_Twitch_Favorite.Padding = new System.Windows.Forms.Padding(0);
            this.MenuItem_Twitch_Favorite.Size = new System.Drawing.Size(35, 36);
            this.MenuItem_Twitch_Favorite.Click += new System.EventHandler(this.MenuItem_Twitch_Favorite_Click);
            // 
            // MenuItem_Twitch_Top
            // 
            this.MenuItem_Twitch_Top.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuItem_Twitch_Top.Image = global::AssistantBroadcasts.Properties.Resources.ic_star_twitch_48dp;
            this.MenuItem_Twitch_Top.Name = "MenuItem_Twitch_Top";
            this.MenuItem_Twitch_Top.Padding = new System.Windows.Forms.Padding(0);
            this.MenuItem_Twitch_Top.Size = new System.Drawing.Size(35, 36);
            this.MenuItem_Twitch_Top.ToolTipText = global::AssistantBroadcasts.Properties.Resources.now_top_twitch;
            this.MenuItem_Twitch_Top.Click += new System.EventHandler(this.MenuItem_Twitch_Top_Click);
            // 
            // MenuItem_Twitch_Games
            // 
            this.MenuItem_Twitch_Games.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuItem_Twitch_Games.Image = global::AssistantBroadcasts.Properties.Resources.ic_videogame_asset_twitch_48dp;
            this.MenuItem_Twitch_Games.Name = "MenuItem_Twitch_Games";
            this.MenuItem_Twitch_Games.Padding = new System.Windows.Forms.Padding(0);
            this.MenuItem_Twitch_Games.Size = new System.Drawing.Size(35, 36);
            this.MenuItem_Twitch_Games.ToolTipText = global::AssistantBroadcasts.Properties.Resources.now_games_twitch;
            this.MenuItem_Twitch_Games.Click += new System.EventHandler(this.MenuItem_Twitch_Games_Click);
            // 
            // MenuItem_Refresh
            // 
            this.MenuItem_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuItem_Refresh.Image = global::AssistantBroadcasts.Properties.Resources.ic_refresh_white_36dp;
            this.MenuItem_Refresh.Name = "MenuItem_Refresh";
            this.MenuItem_Refresh.Padding = new System.Windows.Forms.Padding(0);
            this.MenuItem_Refresh.Size = new System.Drawing.Size(35, 36);
            this.MenuItem_Refresh.ToolTipText = global::AssistantBroadcasts.Properties.Resources.now_refresh_page;
            this.MenuItem_Refresh.Click += new System.EventHandler(this.MenuItem_Refresh_Click);
            // 
            // menuStrip_top
            // 
            this.menuStrip_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(48)))), ((int)(((byte)(86)))));
            this.menuStrip_top.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Close,
            this.MenuItem_Launch,
            this.tB_Watch_Now});
            this.menuStrip_top.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_top.Name = "menuStrip_top";
            this.menuStrip_top.ShowItemToolTips = true;
            this.menuStrip_top.Size = new System.Drawing.Size(406, 26);
            this.menuStrip_top.TabIndex = 2;
            this.menuStrip_top.Text = "menuStrip1";
            // 
            // MenuItem_Close
            // 
            this.MenuItem_Close.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MenuItem_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuItem_Close.Image = ((System.Drawing.Image)(resources.GetObject("MenuItem_Close.Image")));
            this.MenuItem_Close.Name = "MenuItem_Close";
            this.MenuItem_Close.Size = new System.Drawing.Size(28, 22);
            this.MenuItem_Close.Text = "MenuItem_Close";
            this.MenuItem_Close.ToolTipText = global::AssistantBroadcasts.Properties.Resources.now_close_window;
            this.MenuItem_Close.Click += new System.EventHandler(this.MenuItem_Close_Click);
            // 
            // MenuItem_Launch
            // 
            this.MenuItem_Launch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MenuItem_Launch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuItem_Launch.Image = ((System.Drawing.Image)(resources.GetObject("MenuItem_Launch.Image")));
            this.MenuItem_Launch.Name = "MenuItem_Launch";
            this.MenuItem_Launch.Size = new System.Drawing.Size(28, 22);
            this.MenuItem_Launch.Text = "MenuItem_Launch";
            this.MenuItem_Launch.ToolTipText = global::AssistantBroadcasts.Properties.Resources.now_swap_to_main;
            this.MenuItem_Launch.Click += new System.EventHandler(this.MenuItem_Launch_Click);
            // 
            // tB_Watch_Now
            // 
            this.tB_Watch_Now.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(48)))), ((int)(((byte)(89)))));
            this.tB_Watch_Now.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tB_Watch_Now.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_Watch_Now.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.tB_Watch_Now.Name = "tB_Watch_Now";
            this.tB_Watch_Now.ReadOnly = true;
            this.tB_Watch_Now.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tB_Watch_Now.Size = new System.Drawing.Size(330, 22);
            this.tB_Watch_Now.Text = "Watch Now";
            this.tB_Watch_Now.Click += new System.EventHandler(this.tB_Watch_Now_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser.Location = new System.Drawing.Point(36, 26);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(370, 544);
            this.webBrowser.TabIndex = 3;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser_Navigated);
            this.webBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser_Navigating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form_Now
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(406, 570);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.menuStrip_left);
            this.Controls.Add(this.menuStrip_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Now";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form_Now";
            this.Activated += new System.EventHandler(this.Form_Now_Activated);
            this.Deactivate += new System.EventHandler(this.Form_Now_Deactivate);
            this.Load += new System.EventHandler(this.Form_Now_Load);
            this.menuStrip_left.ResumeLayout(false);
            this.menuStrip_left.PerformLayout();
            this.menuStrip_top.ResumeLayout(false);
            this.menuStrip_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.MenuStrip menuStrip_left;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_GG_Favorite;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Exit;
        private System.Windows.Forms.MenuStrip menuStrip_top;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Close;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Launch;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Refresh;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Twitch_Top;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_GG_Top;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Twitch_Games;
        private System.Windows.Forms.ToolStripTextBox tB_Watch_Now;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Twitch_Favorite;
    }
}
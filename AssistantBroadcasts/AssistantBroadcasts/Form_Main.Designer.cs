namespace AssistantBroadcasts
{
    partial class Form_main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_main));
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.goodgameChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vidiChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twitchChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twitchPrivateChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.assistantBroadcastsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watchNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lb_ver = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_notification = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watchNowToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.voteForMediaContentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ggToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ggBotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twitchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twitchBotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastfmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goodGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vidiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatTwitchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twitchPrivateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_bottom = new System.Windows.Forms.ToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_upd = new System.Windows.Forms.ToolStripButton();
            this.btn_del = new System.Windows.Forms.ToolStripButton();
            this.btn_help = new System.Windows.Forms.ToolStripButton();
            this.btn_down = new System.Windows.Forms.ToolStripButton();
            this.btn_up = new System.Windows.Forms.ToolStripButton();
            this.btn_showDescriptions = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_top = new System.Windows.Forms.ToolStrip();
            this.cBox_editable_data = new System.Windows.Forms.ToolStripComboBox();
            this.tstB_search_bar = new System.Windows.Forms.ToolStripTextBox();
            this.lb_search = new System.Windows.Forms.ToolStripLabel();
            this.listB_Object = new System.Windows.Forms.ListBox();
            this.contextMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.toolStrip_bottom.SuspendLayout();
            this.toolStrip_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            resources.ApplyResources(this.saveAllToolStripMenuItem, "saveAllToolStripMenuItem");
            this.saveAllToolStripMenuItem.Text = global::AssistantBroadcasts.Properties.Resources.save_all;
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.save_settings);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            this.notifyIcon.Click += new System.EventHandler(this.assistantBroadcastsToolStripMenuItem_Click);
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nowToolStripMenuItem_Click);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goodgameChatToolStripMenuItem,
            this.vidiChatToolStripMenuItem,
            this.twitchChatToolStripMenuItem,
            this.twitchPrivateChatToolStripMenuItem,
            this.toolStripSeparator4,
            this.assistantBroadcastsToolStripMenuItem,
            this.watchNowToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem1});
            this.contextMenuStrip.Name = "contextMenuStrip";
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            // 
            // goodgameChatToolStripMenuItem
            // 
            this.goodgameChatToolStripMenuItem.Name = "goodgameChatToolStripMenuItem";
            resources.ApplyResources(this.goodgameChatToolStripMenuItem, "goodgameChatToolStripMenuItem");
            this.goodgameChatToolStripMenuItem.Click += new System.EventHandler(this.goodGameToolStripMenuItem_Click);
            // 
            // vidiChatToolStripMenuItem
            // 
            this.vidiChatToolStripMenuItem.Name = "vidiChatToolStripMenuItem";
            resources.ApplyResources(this.vidiChatToolStripMenuItem, "vidiChatToolStripMenuItem");
            this.vidiChatToolStripMenuItem.Click += new System.EventHandler(this.vidiToolStripMenuItem_Click);
            // 
            // twitchChatToolStripMenuItem
            // 
            this.twitchChatToolStripMenuItem.Name = "twitchChatToolStripMenuItem";
            resources.ApplyResources(this.twitchChatToolStripMenuItem, "twitchChatToolStripMenuItem");
            this.twitchChatToolStripMenuItem.Click += new System.EventHandler(this.chatTwitchToolStripMenuItem_Click);
            // 
            // twitchPrivateChatToolStripMenuItem
            // 
            this.twitchPrivateChatToolStripMenuItem.Name = "twitchPrivateChatToolStripMenuItem";
            resources.ApplyResources(this.twitchPrivateChatToolStripMenuItem, "twitchPrivateChatToolStripMenuItem");
            this.twitchPrivateChatToolStripMenuItem.Click += new System.EventHandler(this.twitchPrivateToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // assistantBroadcastsToolStripMenuItem
            // 
            this.assistantBroadcastsToolStripMenuItem.Name = "assistantBroadcastsToolStripMenuItem";
            resources.ApplyResources(this.assistantBroadcastsToolStripMenuItem, "assistantBroadcastsToolStripMenuItem");
            this.assistantBroadcastsToolStripMenuItem.Click += new System.EventHandler(this.assistantBroadcastsToolStripMenuItem_Click);
            // 
            // watchNowToolStripMenuItem
            // 
            this.watchNowToolStripMenuItem.Name = "watchNowToolStripMenuItem";
            resources.ApplyResources(this.watchNowToolStripMenuItem, "watchNowToolStripMenuItem");
            this.watchNowToolStripMenuItem.Click += new System.EventHandler(this.watchNowToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            resources.ApplyResources(this.exitToolStripMenuItem1, "exitToolStripMenuItem1");
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_ver,
            this.lb_notification});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.SizingGrip = false;
            // 
            // lb_ver
            // 
            this.lb_ver.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lb_ver.Name = "lb_ver";
            resources.ApplyResources(this.lb_ver, "lb_ver");
            this.lb_ver.Click += new System.EventHandler(this.patchesLogsToolStripMenuItem_Click);
            // 
            // lb_notification
            // 
            this.lb_notification.Name = "lb_notification";
            resources.ApplyResources(this.lb_notification, "lb_notification");
            this.lb_notification.Spring = true;
            this.lb_notification.Click += new System.EventHandler(this.systemLogsToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.accountsToolStripMenuItem,
            this.chatsStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.watchNowToolStripMenuItem1,
            this.voteForMediaContentToolStripMenuItem,
            this.saveAllToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.systemLogsToolStripMenuItem,
            this.resetLanguageToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            resources.ApplyResources(this.menuToolStripMenuItem, "menuToolStripMenuItem");
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // watchNowToolStripMenuItem1
            // 
            this.watchNowToolStripMenuItem1.Name = "watchNowToolStripMenuItem1";
            resources.ApplyResources(this.watchNowToolStripMenuItem1, "watchNowToolStripMenuItem1");
            this.watchNowToolStripMenuItem1.Click += new System.EventHandler(this.watchNowToolStripMenuItem_Click);
            // 
            // voteForMediaContentToolStripMenuItem
            // 
            this.voteForMediaContentToolStripMenuItem.Name = "voteForMediaContentToolStripMenuItem";
            resources.ApplyResources(this.voteForMediaContentToolStripMenuItem, "voteForMediaContentToolStripMenuItem");
            this.voteForMediaContentToolStripMenuItem.Text = global::AssistantBroadcasts.Properties.Resources.vote_media;
            this.voteForMediaContentToolStripMenuItem.Click += new System.EventHandler(this.voteForMediaContentToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Text = global::AssistantBroadcasts.Properties.Resources.settings;
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // systemLogsToolStripMenuItem
            // 
            this.systemLogsToolStripMenuItem.Name = "systemLogsToolStripMenuItem";
            resources.ApplyResources(this.systemLogsToolStripMenuItem, "systemLogsToolStripMenuItem");
            this.systemLogsToolStripMenuItem.Text = global::AssistantBroadcasts.Properties.Resources.sys_logs;
            this.systemLogsToolStripMenuItem.Click += new System.EventHandler(this.systemLogsToolStripMenuItem_Click);
            // 
            // resetLanguageToolStripMenuItem
            // 
            this.resetLanguageToolStripMenuItem.Name = "resetLanguageToolStripMenuItem";
            resources.ApplyResources(this.resetLanguageToolStripMenuItem, "resetLanguageToolStripMenuItem");
            this.resetLanguageToolStripMenuItem.Text = global::AssistantBroadcasts.Properties.Resources.reset_lang;
            this.resetLanguageToolStripMenuItem.Click += new System.EventHandler(this.resetLanguageToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Text = global::AssistantBroadcasts.Properties.Resources.exit;
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ggToolStripMenuItem,
            this.ggBotToolStripMenuItem,
            this.twitchToolStripMenuItem,
            this.twitchBotToolStripMenuItem,
            this.lastfmToolStripMenuItem,
            this.vKToolStripMenuItem});
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            resources.ApplyResources(this.accountsToolStripMenuItem, "accountsToolStripMenuItem");
            this.accountsToolStripMenuItem.Click += new System.EventHandler(this.accountsToolStripMenuItem_Click);
            // 
            // ggToolStripMenuItem
            // 
            this.ggToolStripMenuItem.Name = "ggToolStripMenuItem";
            resources.ApplyResources(this.ggToolStripMenuItem, "ggToolStripMenuItem");
            this.ggToolStripMenuItem.Text = global::AssistantBroadcasts.Properties.Resources.goodgame;
            this.ggToolStripMenuItem.Click += new System.EventHandler(this.ggToolStripMenuItem_Click);
            // 
            // ggBotToolStripMenuItem
            // 
            this.ggBotToolStripMenuItem.Name = "ggBotToolStripMenuItem";
            resources.ApplyResources(this.ggBotToolStripMenuItem, "ggBotToolStripMenuItem");
            this.ggBotToolStripMenuItem.Text = global::AssistantBroadcasts.Properties.Resources.goodgame_bot;
            this.ggBotToolStripMenuItem.Click += new System.EventHandler(this.ggBotToolStripMenuItem_Click);
            // 
            // twitchToolStripMenuItem
            // 
            this.twitchToolStripMenuItem.Name = "twitchToolStripMenuItem";
            resources.ApplyResources(this.twitchToolStripMenuItem, "twitchToolStripMenuItem");
            this.twitchToolStripMenuItem.Click += new System.EventHandler(this.twitchToolStripMenuItem_Click);
            // 
            // twitchBotToolStripMenuItem
            // 
            this.twitchBotToolStripMenuItem.Name = "twitchBotToolStripMenuItem";
            resources.ApplyResources(this.twitchBotToolStripMenuItem, "twitchBotToolStripMenuItem");
            this.twitchBotToolStripMenuItem.Click += new System.EventHandler(this.twitchBotToolStripMenuItem_Click);
            // 
            // lastfmToolStripMenuItem
            // 
            this.lastfmToolStripMenuItem.Name = "lastfmToolStripMenuItem";
            resources.ApplyResources(this.lastfmToolStripMenuItem, "lastfmToolStripMenuItem");
            this.lastfmToolStripMenuItem.Text = global::AssistantBroadcasts.Properties.Resources.lastfm;
            this.lastfmToolStripMenuItem.Click += new System.EventHandler(this.lastfmToolStripMenuItem_Click);
            // 
            // vKToolStripMenuItem
            // 
            this.vKToolStripMenuItem.Name = "vKToolStripMenuItem";
            resources.ApplyResources(this.vKToolStripMenuItem, "vKToolStripMenuItem");
            this.vKToolStripMenuItem.Text = global::AssistantBroadcasts.Properties.Resources.vkontakte;
            this.vKToolStripMenuItem.Click += new System.EventHandler(this.vKToolStripMenuItem_Click);
            // 
            // chatsStripMenuItem
            // 
            this.chatsStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goodGameToolStripMenuItem,
            this.vidiToolStripMenuItem,
            this.chatTwitchToolStripMenuItem,
            this.twitchPrivateToolStripMenuItem});
            this.chatsStripMenuItem.Name = "chatsStripMenuItem";
            resources.ApplyResources(this.chatsStripMenuItem, "chatsStripMenuItem");
            this.chatsStripMenuItem.Text = global::AssistantBroadcasts.Properties.Resources.chats;
            // 
            // goodGameToolStripMenuItem
            // 
            this.goodGameToolStripMenuItem.Name = "goodGameToolStripMenuItem";
            resources.ApplyResources(this.goodGameToolStripMenuItem, "goodGameToolStripMenuItem");
            this.goodGameToolStripMenuItem.Click += new System.EventHandler(this.goodGameToolStripMenuItem_Click);
            // 
            // vidiToolStripMenuItem
            // 
            this.vidiToolStripMenuItem.Name = "vidiToolStripMenuItem";
            resources.ApplyResources(this.vidiToolStripMenuItem, "vidiToolStripMenuItem");
            this.vidiToolStripMenuItem.Text = global::AssistantBroadcasts.Properties.Resources.vidi;
            this.vidiToolStripMenuItem.Click += new System.EventHandler(this.vidiToolStripMenuItem_Click);
            // 
            // chatTwitchToolStripMenuItem
            // 
            this.chatTwitchToolStripMenuItem.Name = "chatTwitchToolStripMenuItem";
            resources.ApplyResources(this.chatTwitchToolStripMenuItem, "chatTwitchToolStripMenuItem");
            this.chatTwitchToolStripMenuItem.Click += new System.EventHandler(this.chatTwitchToolStripMenuItem_Click);
            // 
            // twitchPrivateToolStripMenuItem
            // 
            this.twitchPrivateToolStripMenuItem.Name = "twitchPrivateToolStripMenuItem";
            resources.ApplyResources(this.twitchPrivateToolStripMenuItem, "twitchPrivateToolStripMenuItem");
            this.twitchPrivateToolStripMenuItem.Click += new System.EventHandler(this.twitchPrivateToolStripMenuItem_Click);
            // 
            // toolStrip_bottom
            // 
            resources.ApplyResources(this.toolStrip_bottom, "toolStrip_bottom");
            this.toolStrip_bottom.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_bottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_upd,
            this.btn_del,
            this.btn_help,
            this.btn_down,
            this.btn_up,
            this.btn_showDescriptions});
            this.toolStrip_bottom.Name = "toolStrip_bottom";
            // 
            // btn_add
            // 
            this.btn_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btn_add, "btn_add");
            this.btn_add.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.btn_add.Name = "btn_add";
            this.btn_add.Text = global::AssistantBroadcasts.Properties.Resources.add;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_upd
            // 
            this.btn_upd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btn_upd, "btn_upd");
            this.btn_upd.Name = "btn_upd";
            this.btn_upd.Text = global::AssistantBroadcasts.Properties.Resources.update;
            this.btn_upd.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_del
            // 
            this.btn_del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btn_del, "btn_del");
            this.btn_del.Name = "btn_del";
            this.btn_del.Text = global::AssistantBroadcasts.Properties.Resources.delete;
            this.btn_del.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_help
            // 
            this.btn_help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btn_help, "btn_help");
            this.btn_help.Name = "btn_help";
            this.btn_help.Text = global::AssistantBroadcasts.Properties.Resources.help;
            this.btn_help.Click += new System.EventHandler(this.btn_help_Click);
            // 
            // btn_down
            // 
            this.btn_down.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_down.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_down.Image = global::AssistantBroadcasts.Properties.Resources.ic_arrow_downward_black_36dp;
            resources.ApplyResources(this.btn_down, "btn_down");
            this.btn_down.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.btn_down.Name = "btn_down";
            this.btn_down.Click += new System.EventHandler(this.btn_down_cmd_Click);
            // 
            // btn_up
            // 
            this.btn_up.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_up.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_up.Image = global::AssistantBroadcasts.Properties.Resources.ic_arrow_upward_black_36dp;
            resources.ApplyResources(this.btn_up, "btn_up");
            this.btn_up.Name = "btn_up";
            this.btn_up.Click += new System.EventHandler(this.btn_up_cmd_Click);
            // 
            // btn_showDescriptions
            // 
            this.btn_showDescriptions.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_showDescriptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_showDescriptions.Image = global::AssistantBroadcasts.Properties.Resources.ic_description_black_36dp;
            resources.ApplyResources(this.btn_showDescriptions, "btn_showDescriptions");
            this.btn_showDescriptions.Name = "btn_showDescriptions";
            this.btn_showDescriptions.Click += new System.EventHandler(this.showDescriptionsToolStripMenuItem_Click);
            // 
            // toolStrip_top
            // 
            this.toolStrip_top.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_top.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cBox_editable_data,
            this.tstB_search_bar,
            this.lb_search});
            resources.ApplyResources(this.toolStrip_top, "toolStrip_top");
            this.toolStrip_top.Name = "toolStrip_top";
            // 
            // cBox_editable_data
            // 
            this.cBox_editable_data.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBox_editable_data.Name = "cBox_editable_data";
            resources.ApplyResources(this.cBox_editable_data, "cBox_editable_data");
            this.cBox_editable_data.SelectedIndexChanged += new System.EventHandler(this.cBox_editable_data_SelectedIndexChanged);
            // 
            // tstB_search_bar
            // 
            this.tstB_search_bar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tstB_search_bar.Margin = new System.Windows.Forms.Padding(1);
            this.tstB_search_bar.Name = "tstB_search_bar";
            resources.ApplyResources(this.tstB_search_bar, "tstB_search_bar");
            this.tstB_search_bar.TextChanged += new System.EventHandler(this.toolStripTB_search_bar_TextChanged);
            // 
            // lb_search
            // 
            this.lb_search.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lb_search.Name = "lb_search";
            resources.ApplyResources(this.lb_search, "lb_search");
            this.lb_search.Text = global::AssistantBroadcasts.Properties.Resources.search;
            // 
            // listB_Object
            // 
            this.listB_Object.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.listB_Object, "listB_Object");
            this.listB_Object.FormattingEnabled = true;
            this.listB_Object.Name = "listB_Object";
            // 
            // Form_main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.listB_Object);
            this.Controls.Add(this.toolStrip_top);
            this.Controls.Add(this.toolStrip_bottom);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.Name = "Form_main";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_main_FormClosing);
            this.Load += new System.EventHandler(this.Form_main_Load);
            this.SizeChanged += new System.EventHandler(this.Form_main_SizeChanged);
            this.contextMenuStrip.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip_bottom.ResumeLayout(false);
            this.toolStrip_bottom.PerformLayout();
            this.toolStrip_top.ResumeLayout(false);
            this.toolStrip_top.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lb_ver;
        private System.Windows.Forms.ToolStripStatusLabel lb_notification;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetLanguageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ggToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ggBotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twitchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twitchBotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voteForMediaContentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goodGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vidiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatTwitchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twitchPrivateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lastfmToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip_bottom;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_upd;
        private System.Windows.Forms.ToolStripButton btn_del;
        private System.Windows.Forms.ToolStripButton btn_help;
        private System.Windows.Forms.ToolStripButton btn_down;
        private System.Windows.Forms.ToolStripButton btn_up;
        private System.Windows.Forms.ToolStrip toolStrip_top;
        private System.Windows.Forms.ToolStripComboBox cBox_editable_data;
        private System.Windows.Forms.ToolStripTextBox tstB_search_bar;
        private System.Windows.Forms.ToolStripLabel lb_search;
        private System.Windows.Forms.ListBox listB_Object;
        private System.Windows.Forms.ToolStripButton btn_showDescriptions;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem watchNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assistantBroadcastsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem watchNowToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem goodgameChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vidiChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twitchChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twitchPrivateChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}


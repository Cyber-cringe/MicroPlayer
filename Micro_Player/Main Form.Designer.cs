namespace Micro_Player
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.playlistsBox = new Micro_Player.SlotBox();
            this.musicBox = new Micro_Player.SlotBox();
            this.songPanel = new System.Windows.Forms.Panel();
            this.speedComboBox = new System.Windows.Forms.ComboBox();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.volumeTrackBar = new System.Windows.Forms.TrackBar();
            this.currentSongName = new System.Windows.Forms.Label();
            this.playSongButton = new System.Windows.Forms.Button();
            this.previousSongButton = new System.Windows.Forms.Button();
            this.nextSongButton = new System.Windows.Forms.Button();
            this.songDuration = new System.Windows.Forms.Label();
            this.currentSongTime = new System.Windows.Forms.Label();
            this.songTimeTrackBar = new System.Windows.Forms.TrackBar();
            this.addSongButton = new System.Windows.Forms.Button();
            this.backToRootDirButton = new System.Windows.Forms.Button();
            this.currentPlaylistName = new System.Windows.Forms.Label();
            this.playerStoppedCheckerTimer = new System.Windows.Forms.Timer(this.components);
            this.playlistsLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.createPlaylistButton = new System.Windows.Forms.Button();
            this.addSongFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.songTimer = new System.Windows.Forms.Timer(this.components);
            this.addPlaylistImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.companyName = new System.Windows.Forms.Label();
            this.holidaySymbolLabel = new System.Windows.Forms.Label();
            this.assistantToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.songPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.songTimeTrackBar)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // playlistsBox
            // 
            this.playlistsBox.ActiveSlot = null;
            this.playlistsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistsBox.AutoScroll = true;
            this.playlistsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.playlistsBox.Horisontal = true;
            this.playlistsBox.Location = new System.Drawing.Point(12, 40);
            this.playlistsBox.Name = "playlistsBox";
            this.playlistsBox.Size = new System.Drawing.Size(790, 210);
            this.playlistsBox.TabIndex = 0;
            this.playlistsBox.XDistance = 10;
            this.playlistsBox.YDistance = 10;
            this.playlistsBox.SlotActivated += new System.EventHandler<Micro_Player.SlotBoxEventArgs>(this.playlistsBox_SlotActivated);
            this.playlistsBox.DeletedSlotSelected += new System.EventHandler<Micro_Player.SlotBoxEventArgs>(this.playlistsBox_DeletedSlotSelected);
            this.playlistsBox.AdditionalActionInvoke += new System.EventHandler<Micro_Player.SlotBoxEventArgs>(this.playlistsBox_AdditionalActionInvoke);
            // 
            // musicBox
            // 
            this.musicBox.ActiveSlot = null;
            this.musicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.musicBox.AutoScroll = true;
            this.musicBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.musicBox.Horisontal = false;
            this.musicBox.Location = new System.Drawing.Point(12, 301);
            this.musicBox.Name = "musicBox";
            this.musicBox.Size = new System.Drawing.Size(832, 446);
            this.musicBox.TabIndex = 1;
            this.musicBox.XDistance = 10;
            this.musicBox.YDistance = 10;
            this.musicBox.SlotActivated += new System.EventHandler<Micro_Player.SlotBoxEventArgs>(this.musicBox_SlotActivated);
            this.musicBox.DeletedSlotSelected += new System.EventHandler<Micro_Player.SlotBoxEventArgs>(this.musicBox_DeletedSlotSelected);
            this.musicBox.AdditionalActionInvoke += new System.EventHandler<Micro_Player.SlotBoxEventArgs>(this.musicBox_AdditionalActionInvoke);
            // 
            // songPanel
            // 
            this.songPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.songPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.songPanel.Controls.Add(this.speedComboBox);
            this.songPanel.Controls.Add(this.volumeLabel);
            this.songPanel.Controls.Add(this.volumeTrackBar);
            this.songPanel.Controls.Add(this.currentSongName);
            this.songPanel.Controls.Add(this.playSongButton);
            this.songPanel.Controls.Add(this.previousSongButton);
            this.songPanel.Controls.Add(this.nextSongButton);
            this.songPanel.Controls.Add(this.songDuration);
            this.songPanel.Controls.Add(this.currentSongTime);
            this.songPanel.Controls.Add(this.songTimeTrackBar);
            this.songPanel.Location = new System.Drawing.Point(12, 753);
            this.songPanel.Name = "songPanel";
            this.songPanel.Size = new System.Drawing.Size(832, 114);
            this.songPanel.TabIndex = 8;
            // 
            // speedComboBox
            // 
            this.speedComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.speedComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.speedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speedComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.speedComboBox.FormattingEnabled = true;
            this.speedComboBox.Location = new System.Drawing.Point(704, 14);
            this.speedComboBox.Name = "speedComboBox";
            this.speedComboBox.Size = new System.Drawing.Size(115, 28);
            this.speedComboBox.TabIndex = 11;
            this.speedComboBox.SelectedIndexChanged += new System.EventHandler(this.speedComboBox_SelectedIndexChanged);
            // 
            // volumeLabel
            // 
            this.volumeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.volumeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.volumeLabel.Location = new System.Drawing.Point(733, 83);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(74, 25);
            this.volumeLabel.TabIndex = 10;
            this.volumeLabel.Text = "🔈100%";
            this.volumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // volumeTrackBar
            // 
            this.volumeTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeTrackBar.Location = new System.Drawing.Point(695, 55);
            this.volumeTrackBar.Maximum = 100;
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Size = new System.Drawing.Size(133, 56);
            this.volumeTrackBar.TabIndex = 9;
            this.volumeTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeTrackBar.Value = 100;
            this.volumeTrackBar.Scroll += new System.EventHandler(this.volumeTrackBar_Scroll);
            // 
            // currentSongName
            // 
            this.currentSongName.AutoSize = true;
            this.currentSongName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentSongName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentSongName.Location = new System.Drawing.Point(154, 14);
            this.currentSongName.Name = "currentSongName";
            this.currentSongName.Size = new System.Drawing.Size(17, 28);
            this.currentSongName.TabIndex = 0;
            this.currentSongName.Text = " ";
            // 
            // playSongButton
            // 
            this.playSongButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.playSongButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.playSongButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playSongButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.playSongButton.Location = new System.Drawing.Point(57, 11);
            this.playSongButton.Name = "playSongButton";
            this.playSongButton.Size = new System.Drawing.Size(50, 35);
            this.playSongButton.TabIndex = 4;
            this.playSongButton.Text = "▶";
            this.playSongButton.UseVisualStyleBackColor = false;
            this.playSongButton.Click += new System.EventHandler(this.playSongButton_Click);
            // 
            // previousSongButton
            // 
            this.previousSongButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.previousSongButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.previousSongButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.previousSongButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.previousSongButton.Location = new System.Drawing.Point(16, 11);
            this.previousSongButton.Name = "previousSongButton";
            this.previousSongButton.Size = new System.Drawing.Size(35, 35);
            this.previousSongButton.TabIndex = 3;
            this.previousSongButton.Text = "<";
            this.previousSongButton.UseVisualStyleBackColor = false;
            this.previousSongButton.Click += new System.EventHandler(this.previousSongButton_Click);
            // 
            // nextSongButton
            // 
            this.nextSongButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.nextSongButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.nextSongButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nextSongButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nextSongButton.Location = new System.Drawing.Point(113, 11);
            this.nextSongButton.Name = "nextSongButton";
            this.nextSongButton.Size = new System.Drawing.Size(35, 35);
            this.nextSongButton.TabIndex = 2;
            this.nextSongButton.Text = ">";
            this.nextSongButton.UseVisualStyleBackColor = false;
            this.nextSongButton.Click += new System.EventHandler(this.nextSongButton_Click);
            // 
            // songDuration
            // 
            this.songDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.songDuration.AutoSize = true;
            this.songDuration.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.songDuration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.songDuration.Location = new System.Drawing.Point(633, 83);
            this.songDuration.Name = "songDuration";
            this.songDuration.Size = new System.Drawing.Size(56, 25);
            this.songDuration.TabIndex = 2;
            this.songDuration.Text = "00:00";
            // 
            // currentSongTime
            // 
            this.currentSongTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.currentSongTime.AutoSize = true;
            this.currentSongTime.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentSongTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentSongTime.Location = new System.Drawing.Point(5, 83);
            this.currentSongTime.Name = "currentSongTime";
            this.currentSongTime.Size = new System.Drawing.Size(56, 25);
            this.currentSongTime.TabIndex = 0;
            this.currentSongTime.Text = "00:00";
            // 
            // songTimeTrackBar
            // 
            this.songTimeTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.songTimeTrackBar.Location = new System.Drawing.Point(5, 55);
            this.songTimeTrackBar.Maximum = 0;
            this.songTimeTrackBar.Name = "songTimeTrackBar";
            this.songTimeTrackBar.Size = new System.Drawing.Size(684, 56);
            this.songTimeTrackBar.TabIndex = 1;
            this.songTimeTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.songTimeTrackBar.Scroll += new System.EventHandler(this.songTimeTrackBar_Scroll);
            // 
            // addSongButton
            // 
            this.addSongButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.addSongButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addSongButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addSongButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.addSongButton.Location = new System.Drawing.Point(53, 260);
            this.addSongButton.Name = "addSongButton";
            this.addSongButton.Size = new System.Drawing.Size(35, 35);
            this.addSongButton.TabIndex = 1;
            this.addSongButton.Text = "➕";
            this.addSongButton.UseVisualStyleBackColor = false;
            this.addSongButton.Click += new System.EventHandler(this.addSongButton_Click);
            this.addSongButton.MouseEnter += new System.EventHandler(this.addSongButton_MouseEnter);
            // 
            // backToRootDirButton
            // 
            this.backToRootDirButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.backToRootDirButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backToRootDirButton.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.backToRootDirButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.backToRootDirButton.Location = new System.Drawing.Point(12, 260);
            this.backToRootDirButton.Name = "backToRootDirButton";
            this.backToRootDirButton.Size = new System.Drawing.Size(35, 35);
            this.backToRootDirButton.TabIndex = 0;
            this.backToRootDirButton.Text = "<";
            this.backToRootDirButton.UseVisualStyleBackColor = false;
            this.backToRootDirButton.Click += new System.EventHandler(this.backToRootDirButton_Click);
            this.backToRootDirButton.MouseEnter += new System.EventHandler(this.backToRootDirButton_MouseEnter);
            // 
            // currentPlaylistName
            // 
            this.currentPlaylistName.AutoSize = true;
            this.currentPlaylistName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentPlaylistName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentPlaylistName.Location = new System.Drawing.Point(94, 262);
            this.currentPlaylistName.Name = "currentPlaylistName";
            this.currentPlaylistName.Size = new System.Drawing.Size(126, 28);
            this.currentPlaylistName.TabIndex = 4;
            this.currentPlaylistName.Text = "playlistName";
            this.currentPlaylistName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerStoppedCheckerTimer
            // 
            this.playerStoppedCheckerTimer.Interval = 1000;
            this.playerStoppedCheckerTimer.Tick += new System.EventHandler(this.playerStoppedCheckerTimer_Tick);
            // 
            // playlistsLabel
            // 
            this.playlistsLabel.AutoSize = true;
            this.playlistsLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playlistsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.playlistsLabel.Location = new System.Drawing.Point(12, 9);
            this.playlistsLabel.Name = "playlistsLabel";
            this.playlistsLabel.Size = new System.Drawing.Size(113, 28);
            this.playlistsLabel.TabIndex = 6;
            this.playlistsLabel.Text = "Плейлисты";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel2.Controls.Add(this.createPlaylistButton);
            this.panel2.Location = new System.Drawing.Point(808, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(35, 210);
            this.panel2.TabIndex = 0;
            // 
            // createPlaylistButton
            // 
            this.createPlaylistButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.createPlaylistButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createPlaylistButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.createPlaylistButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.createPlaylistButton.Location = new System.Drawing.Point(3, 3);
            this.createPlaylistButton.Name = "createPlaylistButton";
            this.createPlaylistButton.Size = new System.Drawing.Size(29, 29);
            this.createPlaylistButton.TabIndex = 7;
            this.createPlaylistButton.Text = "➕";
            this.createPlaylistButton.UseVisualStyleBackColor = false;
            this.createPlaylistButton.Click += new System.EventHandler(this.createPlaylistButton_Click);
            this.createPlaylistButton.MouseEnter += new System.EventHandler(this.createPlaylistButton_MouseEnter);
            // 
            // addSongFileDialog
            // 
            this.addSongFileDialog.FileName = "openFileDialog1";
            // 
            // songTimer
            // 
            this.songTimer.Interval = 250;
            this.songTimer.Tick += new System.EventHandler(this.songTimer_Tick);
            // 
            // addPlaylistImageFileDialog
            // 
            this.addPlaylistImageFileDialog.FileName = "openFileDialog1";
            // 
            // companyName
            // 
            this.companyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.companyName.AutoSize = true;
            this.companyName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.companyName.ForeColor = System.Drawing.Color.Gray;
            this.companyName.Location = new System.Drawing.Point(670, 6);
            this.companyName.Name = "companyName";
            this.companyName.Size = new System.Drawing.Size(173, 28);
            this.companyName.TabIndex = 10;
            this.companyName.Text = "Total cringe studio";
            // 
            // holidaySymbolLabel
            // 
            this.holidaySymbolLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.holidaySymbolLabel.AutoSize = true;
            this.holidaySymbolLabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.holidaySymbolLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.holidaySymbolLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.holidaySymbolLabel.Location = new System.Drawing.Point(610, 5);
            this.holidaySymbolLabel.Name = "holidaySymbolLabel";
            this.holidaySymbolLabel.Size = new System.Drawing.Size(20, 31);
            this.holidaySymbolLabel.TabIndex = 12;
            this.holidaySymbolLabel.Text = " ";
            this.holidaySymbolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // assistantToolTip
            // 
            this.assistantToolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.assistantToolTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.assistantToolTip.OwnerDraw = true;
            this.assistantToolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.assistantToolTip_Draw);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(857, 878);
            this.Controls.Add(this.holidaySymbolLabel);
            this.Controls.Add(this.companyName);
            this.Controls.Add(this.backToRootDirButton);
            this.Controls.Add(this.addSongButton);
            this.Controls.Add(this.songPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.playlistsLabel);
            this.Controls.Add(this.currentPlaylistName);
            this.Controls.Add(this.musicBox);
            this.Controls.Add(this.playlistsBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(875, 550);
            this.Name = "MainForm";
            this.Opacity = 0.99D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Micro player";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.songPanel.ResumeLayout(false);
            this.songPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.songTimeTrackBar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private SlotBox playlistsBox;
        private SlotBox musicBox;
        private Button backToRootDirButton;
        private Button nextSongButton;
        private Button previousSongButton;
        private Label currentPlaylistName;
        private System.Windows.Forms.Timer playerStoppedCheckerTimer;
        private Label label1;
        private Panel panel2;
        private Button createPlaylistButton;
        private Button addSongButton;
        private OpenFileDialog addSongFileDialog;
        private Label playlistsLabel;
        private Button playSongButton;
        private Panel songPanel;
        private Label songDuration;
        private Label currentSongTime;
        private TrackBar songTimeTrackBar;
        private Label currentSongName;
        private System.Windows.Forms.Timer songTimer;
        private TrackBar volumeTrackBar;
        private Label volumeLabel;
        private ComboBox speedComboBox;
        private OpenFileDialog addPlaylistImageFileDialog;
        private Label label2;
        private Label companyName;
        private Label holidaySymbolLabel;
        private ToolTip assistantToolTip;
    }
}
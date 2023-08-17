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
            components = new System.ComponentModel.Container();
            playlistsBox = new SlotBox();
            musicBox = new SlotBox();
            MusicPanelBox = new SlotBox();
            label4 = new Label();
            PlayPauseButton = new Button();
            label3 = new Label();
            button3 = new Button();
            label2 = new Label();
            button2 = new Button();
            label5 = new Label();
            VolumeTrackBar = new TrackBar();
            MusicTrackBar = new TrackBar();
            button1 = new Button();
            panel1 = new Panel();
            addSongButton = new Button();
            backToRootDirButton = new Button();
            currentPlaylistName = new Label();
            playerStoppedCheckerTimer = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            panel2 = new Panel();
            createPlaylistButton = new Button();
            addSongFileDialog = new OpenFileDialog();
            MusicTimer = new System.Windows.Forms.Timer(components);
            musicBox.SuspendLayout();
            MusicPanelBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)VolumeTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MusicTrackBar).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // playlistsBox
            // 
            playlistsBox.AutoScroll = true;
            playlistsBox.BackColor = Color.FromArgb(27, 27, 27);
            playlistsBox.Location = new Point(10, 40);
            playlistsBox.Name = "playlistsBox";
            playlistsBox.SelectedSlot = null;
            playlistsBox.Size = new Size(733, 210);
            playlistsBox.TabIndex = 0;
            // 
            // musicBox
            // 
            musicBox.AutoScroll = true;
            musicBox.BackColor = Color.FromArgb(27, 27, 27);
            musicBox.Controls.Add(MusicPanelBox);
            musicBox.Location = new Point(10, 298);
            musicBox.Name = "musicBox";
            musicBox.SelectedSlot = null;
            musicBox.Size = new Size(776, 559);
            musicBox.TabIndex = 1;
            // 
            // MusicPanelBox
            // 
            MusicPanelBox.AutoScroll = true;
            MusicPanelBox.BackColor = Color.FromArgb(45, 45, 45);
            MusicPanelBox.BorderStyle = BorderStyle.FixedSingle;
            MusicPanelBox.Controls.Add(label4);
            MusicPanelBox.Controls.Add(PlayPauseButton);
            MusicPanelBox.Controls.Add(label3);
            MusicPanelBox.Controls.Add(button3);
            MusicPanelBox.Controls.Add(label2);
            MusicPanelBox.Controls.Add(button2);
            MusicPanelBox.Controls.Add(label5);
            MusicPanelBox.Controls.Add(VolumeTrackBar);
            MusicPanelBox.Controls.Add(MusicTrackBar);
            MusicPanelBox.Location = new Point(3, 359);
            MusicPanelBox.Name = "MusicPanelBox";
            MusicPanelBox.SelectedSlot = null;
            MusicPanelBox.Size = new Size(768, 200);
            MusicPanelBox.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(725, 174);
            label4.Name = "label4";
            label4.Size = new Size(33, 20);
            label4.TabIndex = 7;
            label4.Text = "100";
            // 
            // PlayPauseButton
            // 
            PlayPauseButton.BackColor = Color.Transparent;
            PlayPauseButton.BackgroundImageLayout = ImageLayout.None;
            PlayPauseButton.FlatAppearance.BorderSize = 0;
            PlayPauseButton.FlatStyle = FlatStyle.Flat;
            PlayPauseButton.Image = Properties.Resources.pausebutton;
            PlayPauseButton.Location = new Point(351, 3);
            PlayPauseButton.Name = "PlayPauseButton";
            PlayPauseButton.Size = new Size(55, 55);
            PlayPauseButton.TabIndex = 0;
            PlayPauseButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            PlayPauseButton.UseVisualStyleBackColor = false;
            PlayPauseButton.Click += PlayPauseButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(507, 174);
            label3.Name = "label3";
            label3.Size = new Size(17, 20);
            label3.TabIndex = 6;
            label3.Text = "0";
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Location = new Point(293, 16);
            button3.Name = "button3";
            button3.Size = new Size(52, 29);
            button3.TabIndex = 3;
            button3.Text = "<";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(722, 102);
            label2.Name = "label2";
            label2.Size = new Size(36, 20);
            label2.TabIndex = 5;
            label2.Text = "0:00";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(412, 16);
            button2.Name = "button2";
            button2.Size = new Size(52, 29);
            button2.TabIndex = 2;
            button2.Text = ">";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 102);
            label5.Name = "label5";
            label5.Size = new Size(36, 20);
            label5.TabIndex = 4;
            label5.Text = "0:00";
            // 
            // VolumeTrackBar
            // 
            VolumeTrackBar.Location = new Point(497, 138);
            VolumeTrackBar.Maximum = 100;
            VolumeTrackBar.Name = "VolumeTrackBar";
            VolumeTrackBar.Size = new Size(261, 56);
            VolumeTrackBar.TabIndex = 3;
            VolumeTrackBar.Value = 100;
            VolumeTrackBar.Scroll += VolumeTrackBar_Scroll;
            // 
            // MusicTrackBar
            // 
            MusicTrackBar.AutoSize = false;
            MusicTrackBar.Location = new Point(3, 64);
            MusicTrackBar.Name = "MusicTrackBar";
            MusicTrackBar.Size = new Size(755, 35);
            MusicTrackBar.TabIndex = 2;
            MusicTrackBar.Scroll += MusicTrackBar_Scroll;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(632, 5);
            button1.Name = "button1";
            button1.Size = new Size(154, 29);
            button1.TabIndex = 0;
            button1.Text = "ТЕСТ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(27, 27, 27);
            panel1.Controls.Add(addSongButton);
            panel1.Controls.Add(backToRootDirButton);
            panel1.Location = new Point(10, 252);
            panel1.Name = "panel1";
            panel1.Size = new Size(94, 49);
            panel1.TabIndex = 0;
            // 
            // addSongButton
            // 
            addSongButton.BackColor = Color.FromArgb(55, 55, 55);
            addSongButton.FlatStyle = FlatStyle.Flat;
            addSongButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            addSongButton.ForeColor = SystemColors.ActiveCaptionText;
            addSongButton.Location = new Point(51, 5);
            addSongButton.Name = "addSongButton";
            addSongButton.Size = new Size(40, 38);
            addSongButton.TabIndex = 1;
            addSongButton.Text = "+";
            addSongButton.UseVisualStyleBackColor = false;
            addSongButton.Click += addSongButton_Click;
            // 
            // backToRootDirButton
            // 
            backToRootDirButton.BackColor = Color.FromArgb(55, 55, 55);
            backToRootDirButton.FlatStyle = FlatStyle.Flat;
            backToRootDirButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            backToRootDirButton.ForeColor = SystemColors.ActiveCaptionText;
            backToRootDirButton.Location = new Point(3, 5);
            backToRootDirButton.Name = "backToRootDirButton";
            backToRootDirButton.Size = new Size(40, 38);
            backToRootDirButton.TabIndex = 0;
            backToRootDirButton.Text = "<";
            backToRootDirButton.UseVisualStyleBackColor = false;
            backToRootDirButton.Click += backToRootDirButton_Click;
            // 
            // currentPlaylistName
            // 
            currentPlaylistName.AutoSize = true;
            currentPlaylistName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            currentPlaylistName.ForeColor = Color.FromArgb(190, 190, 190);
            currentPlaylistName.Location = new Point(110, 261);
            currentPlaylistName.Name = "currentPlaylistName";
            currentPlaylistName.Size = new Size(65, 28);
            currentPlaylistName.TabIndex = 4;
            currentPlaylistName.Text = "label1";
            // 
            // playerStoppedCheckerTimer
            // 
            playerStoppedCheckerTimer.Tick += playerStoppedCheckerTimer_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(40, 40, 40);
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(190, 190, 190);
            label1.Location = new Point(10, 5);
            label1.Name = "label1";
            label1.Size = new Size(113, 28);
            label1.TabIndex = 6;
            label1.Text = "Плейлисты";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(27, 27, 27);
            panel2.Controls.Add(createPlaylistButton);
            panel2.Location = new Point(749, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(35, 210);
            panel2.TabIndex = 0;
            // 
            // createPlaylistButton
            // 
            createPlaylistButton.BackColor = Color.FromArgb(55, 55, 55);
            createPlaylistButton.FlatStyle = FlatStyle.Flat;
            createPlaylistButton.ForeColor = SystemColors.ActiveCaptionText;
            createPlaylistButton.Location = new Point(3, 3);
            createPlaylistButton.Name = "createPlaylistButton";
            createPlaylistButton.Size = new Size(29, 29);
            createPlaylistButton.TabIndex = 7;
            createPlaylistButton.Text = "+";
            createPlaylistButton.UseVisualStyleBackColor = false;
            createPlaylistButton.Click += createPlaylistButton_Click;
            // 
            // addSongFileDialog
            // 
            addSongFileDialog.FileName = "openFileDialog1";
            // 
            // MusicTimer
            // 
            MusicTimer.Tick += MusicTimer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(798, 863);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(currentPlaylistName);
            Controls.Add(musicBox);
            Controls.Add(playlistsBox);
            Controls.Add(panel1);
            Name = "MainForm";
            Opacity = 0.99D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += MainForm_Load;
            musicBox.ResumeLayout(false);
            MusicPanelBox.ResumeLayout(false);
            MusicPanelBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)VolumeTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)MusicTrackBar).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        //private Slot slot1;
        //private Slot slot2;
        private SlotBox playlistsBox;
        private SlotBox musicBox;
        private Button button1;
        private Panel panel1;
        private Button backToRootDirButton;
        private Button button2;
        private Button button3;
        private Label currentPlaylistName;
        private System.Windows.Forms.Timer playerStoppedCheckerTimer;
        private Label label1;
        private Panel panel2;
        private Button createPlaylistButton;
        private Button addSongButton;
        private OpenFileDialog addSongFileDialog;
        private SlotBox MusicPanelBox;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label5;
        private TrackBar VolumeTrackBar;
        private TrackBar MusicTrackBar;
        private Button PlayPauseButton;
        private System.Windows.Forms.Timer MusicTimer;
    }
}
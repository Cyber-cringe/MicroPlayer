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
            button1 = new Button();
            panel1 = new Panel();
            backToRootDirButton = new Button();
            button2 = new Button();
            button3 = new Button();
            currentPlaylistName = new Label();
            MusicPanelBox = new SlotBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            VolumeTrackBar = new TrackBar();
            MusicTrackBar = new TrackBar();
            StopButton = new Button();
            PlayPauseButton = new Button();
            MusicTimer = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            MusicPanelBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)VolumeTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MusicTrackBar).BeginInit();
            SuspendLayout();
            // 
            // playlistsBox
            // 
            playlistsBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            playlistsBox.AutoScroll = true;
            playlistsBox.BackColor = Color.FromArgb(44, 45, 46);
            playlistsBox.Location = new Point(12, 12);
            playlistsBox.Name = "playlistsBox";
            playlistsBox.SelectedSlot = null;
            playlistsBox.Size = new Size(1083, 170);
            playlistsBox.TabIndex = 0;
            // 
            // musicBox
            // 
            musicBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            musicBox.AutoScroll = true;
            musicBox.BackColor = Color.FromArgb(44, 45, 46);
            musicBox.Location = new Point(13, 234);
            musicBox.Name = "musicBox";
            musicBox.SelectedSlot = null;
            musicBox.Size = new Size(1083, 271);
            musicBox.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(251, 511);
            button1.Name = "button1";
            button1.Size = new Size(154, 29);
            button1.TabIndex = 0;
            button1.Text = "ТЕСТ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(44, 45, 46);
            panel1.Controls.Add(backToRootDirButton);
            panel1.Location = new Point(13, 188);
            panel1.Name = "panel1";
            panel1.Size = new Size(94, 49);
            panel1.TabIndex = 0;
            // 
            // backToRootDirButton
            // 
            backToRootDirButton.BackColor = Color.FromArgb(10, 10, 10);
            backToRootDirButton.FlatStyle = FlatStyle.Popup;
            backToRootDirButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            backToRootDirButton.ForeColor = Color.Teal;
            backToRootDirButton.Location = new Point(3, 5);
            backToRootDirButton.Name = "backToRootDirButton";
            backToRootDirButton.Size = new Size(35, 35);
            backToRootDirButton.TabIndex = 0;
            backToRootDirButton.Text = "<";
            backToRootDirButton.UseVisualStyleBackColor = false;
            backToRootDirButton.Click += backToRootDirButton_Click;
            // 
            // button2
            // 
            button2.Location = new Point(110, 511);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = ">";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(10, 511);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 3;
            button3.Text = "<";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // currentPlaylistName
            // 
            currentPlaylistName.AutoSize = true;
            currentPlaylistName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            currentPlaylistName.ForeColor = SystemColors.ControlDark;
            currentPlaylistName.Location = new Point(113, 203);
            currentPlaylistName.Name = "currentPlaylistName";
            currentPlaylistName.Size = new Size(65, 28);
            currentPlaylistName.TabIndex = 4;
            currentPlaylistName.Text = "label1";
            // 
            // MusicPanelBox
            // 
            MusicPanelBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            MusicPanelBox.AutoScroll = true;
            MusicPanelBox.BackColor = Color.FromArgb(64, 64, 64);
            MusicPanelBox.Controls.Add(label4);
            MusicPanelBox.Controls.Add(label3);
            MusicPanelBox.Controls.Add(label2);
            MusicPanelBox.Controls.Add(label1);
            MusicPanelBox.Controls.Add(VolumeTrackBar);
            MusicPanelBox.Controls.Add(MusicTrackBar);
            MusicPanelBox.Controls.Add(StopButton);
            MusicPanelBox.Controls.Add(PlayPauseButton);
            MusicPanelBox.Location = new Point(10, 547);
            MusicPanelBox.Name = "MusicPanelBox";
            MusicPanelBox.SelectedSlot = null;
            MusicPanelBox.Size = new Size(1086, 177);
            MusicPanelBox.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1033, 144);
            label4.Name = "label4";
            label4.Size = new Size(33, 20);
            label4.TabIndex = 7;
            label4.Text = "100";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(815, 144);
            label3.Name = "label3";
            label3.Size = new Size(17, 20);
            label3.TabIndex = 6;
            label3.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1030, 52);
            label2.Name = "label2";
            label2.Size = new Size(36, 20);
            label2.TabIndex = 5;
            label2.Text = "0:00";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(243, 52);
            label1.Name = "label1";
            label1.Size = new Size(36, 20);
            label1.TabIndex = 4;
            label1.Text = "0:00";
            // 
            // VolumeTrackBar
            // 
            VolumeTrackBar.Location = new Point(805, 108);
            VolumeTrackBar.Maximum = 100;
            VolumeTrackBar.Name = "VolumeTrackBar";
            VolumeTrackBar.Size = new Size(261, 56);
            VolumeTrackBar.TabIndex = 3;
            VolumeTrackBar.Value = 100;
            VolumeTrackBar.Scroll += VolumeTrackBar_Scroll;
            // 
            // MusicTrackBar
            // 
            MusicTrackBar.Location = new Point(243, 16);
            MusicTrackBar.Name = "MusicTrackBar";
            MusicTrackBar.Size = new Size(823, 56);
            MusicTrackBar.TabIndex = 2;
            MusicTrackBar.Scroll += MusicTrackBar_Scroll;
            // 
            // StopButton
            // 
            StopButton.Location = new Point(123, 3);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(114, 80);
            StopButton.TabIndex = 1;
            StopButton.Text = "Стоп";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // PlayPauseButton
            // 
            PlayPauseButton.Location = new Point(3, 3);
            PlayPauseButton.Name = "PlayPauseButton";
            PlayPauseButton.Size = new Size(114, 80);
            PlayPauseButton.TabIndex = 0;
            PlayPauseButton.Text = "Играть Пауза";
            PlayPauseButton.UseVisualStyleBackColor = true;
            PlayPauseButton.Click += PlayPauseButton_Click;
            // 
            // MusicTimer
            // 
            MusicTimer.Tick += MusicTimer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 10, 10);
            ClientSize = new Size(1107, 821);
            Controls.Add(MusicPanelBox);
            Controls.Add(currentPlaylistName);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(musicBox);
            Controls.Add(playlistsBox);
            Controls.Add(panel1);
            Name = "MainForm";
            Opacity = 0.99D;
            Text = "Form1";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            MusicPanelBox.ResumeLayout(false);
            MusicPanelBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)VolumeTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)MusicTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Slot slot1;
        private Slot slot2;
        private SlotBox playlistsBox;
        private SlotBox musicBox;
        private Button button1;
        private Panel panel1;
        private Button backToRootDirButton;
        private Button button2;
        private Button button3;
        private Label currentPlaylistName;
        private SlotBox MusicPanelBox;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TrackBar VolumeTrackBar;
        private TrackBar MusicTrackBar;
        private Button StopButton;
        private Button PlayPauseButton;
        private System.Windows.Forms.Timer MusicTimer;
    }
}
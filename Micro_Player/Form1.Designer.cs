namespace Micro_Player
{
    partial class Form1
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
            slotBox1 = new SlotBox();
            slotBox2 = new SlotBox();
            MusicPanel = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            VolumeTracker = new TrackBar();
            MusicTracker = new TrackBar();
            StopButton = new Button();
            PlayPauseButton = new Button();
            MusicTimer = new System.Windows.Forms.Timer(components);
            MusicPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)VolumeTracker).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MusicTracker).BeginInit();
            SuspendLayout();
            // 
            // slotBox1
            // 
            slotBox1.AutoScroll = true;
            slotBox1.BackColor = SystemColors.ButtonFace;
            slotBox1.Location = new Point(12, 12);
            slotBox1.Name = "slotBox1";
            slotBox1.Size = new Size(1079, 107);
            slotBox1.TabIndex = 0;
            // 
            // slotBox2
            // 
            slotBox2.AutoScroll = true;
            slotBox2.BackColor = SystemColors.ButtonFace;
            slotBox2.Location = new Point(12, 125);
            slotBox2.Name = "slotBox2";
            slotBox2.Size = new Size(1079, 288);
            slotBox2.TabIndex = 1;
            // 
            // MusicPanel
            // 
            MusicPanel.Controls.Add(label4);
            MusicPanel.Controls.Add(label3);
            MusicPanel.Controls.Add(label2);
            MusicPanel.Controls.Add(label1);
            MusicPanel.Controls.Add(VolumeTracker);
            MusicPanel.Controls.Add(MusicTracker);
            MusicPanel.Controls.Add(StopButton);
            MusicPanel.Controls.Add(PlayPauseButton);
            MusicPanel.Location = new Point(12, 419);
            MusicPanel.Name = "MusicPanel";
            MusicPanel.Size = new Size(1079, 148);
            MusicPanel.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1034, 108);
            label4.Name = "label4";
            label4.Size = new Size(33, 20);
            label4.TabIndex = 7;
            label4.Text = "100";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(743, 108);
            label3.Name = "label3";
            label3.Size = new Size(17, 20);
            label3.TabIndex = 6;
            label3.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1031, 40);
            label2.Name = "label2";
            label2.Size = new Size(36, 20);
            label2.TabIndex = 5;
            label2.Text = "0:00";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(145, 40);
            label1.Name = "label1";
            label1.Size = new Size(36, 20);
            label1.TabIndex = 4;
            label1.Text = "0:00";
            // 
            // VolumeTracker
            // 
            VolumeTracker.AutoSize = false;
            VolumeTracker.Location = new Point(743, 76);
            VolumeTracker.Maximum = 100;
            VolumeTracker.Name = "VolumeTracker";
            VolumeTracker.Size = new Size(324, 29);
            VolumeTracker.TabIndex = 3;
            VolumeTracker.Scroll += VolumeTracker_Scroll;
            // 
            // MusicTracker
            // 
            MusicTracker.AutoSize = false;
            MusicTracker.Location = new Point(145, 4);
            MusicTracker.Name = "MusicTracker";
            MusicTracker.Size = new Size(931, 30);
            MusicTracker.TabIndex = 2;
            MusicTracker.Scroll += MusicTracker_Scroll;
            // 
            // StopButton
            // 
            StopButton.Location = new Point(74, 3);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(65, 57);
            StopButton.TabIndex = 1;
            StopButton.Text = "Стоп";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // PlayPauseButton
            // 
            PlayPauseButton.Location = new Point(3, 3);
            PlayPauseButton.Name = "PlayPauseButton";
            PlayPauseButton.Size = new Size(65, 57);
            PlayPauseButton.TabIndex = 0;
            PlayPauseButton.Text = "Играть Пауза";
            PlayPauseButton.UseVisualStyleBackColor = true;
            PlayPauseButton.Click += PlayPauseButton_Click;
            // 
            // MusicTimer
            // 
            MusicTimer.Tick += MusicTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1103, 579);
            Controls.Add(MusicPanel);
            Controls.Add(slotBox2);
            Controls.Add(slotBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            MusicPanel.ResumeLayout(false);
            MusicPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)VolumeTracker).EndInit();
            ((System.ComponentModel.ISupportInitialize)MusicTracker).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Slot slot1;
        private Slot slot2;
        private SlotBox slotBox1;
        private SlotBox slotBox2;
        private Panel MusicPanel;
        private TrackBar VolumeTracker;
        private TrackBar MusicTracker;
        private Button StopButton;
        private Button PlayPauseButton;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private System.Windows.Forms.Timer MusicTimer;
    }
}
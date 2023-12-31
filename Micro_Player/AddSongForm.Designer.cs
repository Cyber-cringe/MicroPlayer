﻿namespace Micro_Player
{
    partial class AddSongForm
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
            this.playlistslistBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.confirmAdditionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playlistslistBox
            // 
            this.playlistslistBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistslistBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.playlistslistBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playlistslistBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playlistslistBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.playlistslistBox.FormattingEnabled = true;
            this.playlistslistBox.ItemHeight = 28;
            this.playlistslistBox.Location = new System.Drawing.Point(10, 40);
            this.playlistslistBox.Name = "playlistslistBox";
            this.playlistslistBox.Size = new System.Drawing.Size(335, 198);
            this.playlistslistBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label1.Location = new System.Drawing.Point(82, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите плейлист";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // confirmAdditionButton
            // 
            this.confirmAdditionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmAdditionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.confirmAdditionButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.confirmAdditionButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.confirmAdditionButton.Location = new System.Drawing.Point(10, 252);
            this.confirmAdditionButton.Name = "confirmAdditionButton";
            this.confirmAdditionButton.Size = new System.Drawing.Size(335, 29);
            this.confirmAdditionButton.TabIndex = 2;
            this.confirmAdditionButton.Text = "Добавить в плейлист";
            this.confirmAdditionButton.UseVisualStyleBackColor = false;
            this.confirmAdditionButton.Click += new System.EventHandler(this.confirmAdditionButton_Click);
            // 
            // AddSongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(357, 293);
            this.Controls.Add(this.confirmAdditionButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playlistslistBox);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "AddSongForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить музыку";
            this.Load += new System.EventHandler(this.AddSongForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox playlistslistBox;
        private Label label1;
        private Button confirmAdditionButton;
    }
}
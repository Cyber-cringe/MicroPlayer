using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Micro_Player
{
    public class Slot : Panel, IDisposable
    {
        private Button activateSlotButton;
        private Button deleteSlotButton;
        private Label nameLabel;
        private Button additionalActionButton;
        private ToolTip nameToolTip;
        private IContainer components;
        private Lazy<PictureBox> slotPicture = new Lazy<PictureBox>();
        private FileWorker fileWorker = new FileWorker();
        private DirectoryWorker directoryWorker = new DirectoryWorker();

        public string path { get; set; }
        public string name { get; private set; }
        public Button ActivateSlotButton { get => activateSlotButton; }
        public Button DeleteSlotButton { get => deleteSlotButton; }
        public Button AdditionalActionButton { get => additionalActionButton; }
        public Label NameLabel { get => nameLabel; }
        public PictureBox SlotPicture { get => slotPicture.Value; }
        
        public Slot(string? path)
        {
            InitializeComponent();
            SetStartPosition();
            
            this.path = path ?? "";
            name = GetName(this.path) ?? this.path;
            nameLabel!.Text = name;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.nameLabel = new System.Windows.Forms.Label();
            this.activateSlotButton = new System.Windows.Forms.Button();
            this.deleteSlotButton = new System.Windows.Forms.Button();
            this.additionalActionButton = new System.Windows.Forms.Button();
            this.nameToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 20);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Slot";
            this.nameLabel.MouseEnter += new System.EventHandler(this.nameLabel_MouseEnter);
            // 
            // activateSlotButton
            // 
            this.activateSlotButton.BackColor = System.Drawing.Color.Black;
            this.activateSlotButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.activateSlotButton.Name = "activateSlotButton";
            this.activateSlotButton.Size = new System.Drawing.Size(35, 35);
            this.activateSlotButton.TabIndex = 0;
            this.activateSlotButton.UseVisualStyleBackColor = false;
            // 
            // deleteSlotButton
            // 
            this.deleteSlotButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteSlotButton.BackColor = System.Drawing.Color.Black;
            this.deleteSlotButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.deleteSlotButton.Name = "deleteSlotButton";
            this.deleteSlotButton.Size = new System.Drawing.Size(35, 35);
            this.deleteSlotButton.TabIndex = 0;
            this.deleteSlotButton.UseVisualStyleBackColor = false;
            // 
            // additionalActionButton
            // 
            this.additionalActionButton.Name = "additionalActionButton";
            this.additionalActionButton.Size = new System.Drawing.Size(35, 35);
            this.additionalActionButton.TabIndex = 0;
            this.additionalActionButton.UseVisualStyleBackColor = true;
            // 
            // nameToolTip
            // 
            this.nameToolTip.AutoPopDelay = 5000;
            this.nameToolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(99)))));
            this.nameToolTip.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.nameToolTip.InitialDelay = 500;
            this.nameToolTip.IsBalloon = true;
            this.nameToolTip.ReshowDelay = 100;
            // 
            // Slot
            // 
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.activateSlotButton);
            this.Controls.Add(this.deleteSlotButton);
            this.Controls.Add(this.additionalActionButton);
            this.Size = new System.Drawing.Size(370, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public new void Dispose()
        {
            Controls.Clear();
            nameLabel.Dispose();
            activateSlotButton.Dispose();
            deleteSlotButton.Dispose();
            additionalActionButton.Dispose();
            nameToolTip.Dispose();
            slotPicture?.Value?.Image?.Dispose();
            slotPicture?.Value?.Dispose();
            GC.SuppressFinalize(this);
            base.Dispose();
        }

        //сдвигаем слот
        public void MoveSlot(int distance) => this.Left += distance;

        // получаем имя слота по пазу
        private string? GetName(string path)
        {
            if (File.Exists(path))
            {
                string? fileName = fileWorker.GetFileName(path);
                return fileName;
            }
            else if (Directory.Exists(path))
            {
                string? directoryName = directoryWorker.GetDirName(path);
                return directoryName;
            }
            return null;
        }

        private void SetStartPosition()
        {
            activateSlotButton.Location = new Point(10, 10);
            deleteSlotButton.Location = new Point(350, 10);
            additionalActionButton.Location = new Point(305, 10);
            nameLabel.Location = new Point(70, 10);
        }

        //Всплывающая подсказка при наведении курсора мыши на слот
        //(показывает название слота, если его не видно полностью)
        private void nameLabel_MouseEnter(object sender, EventArgs e)
        {
            if (nameLabel.Width > this.Width )
                nameToolTip.SetToolTip(nameLabel, name);
        }

    }

}

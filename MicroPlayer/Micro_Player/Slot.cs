using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Micro_Player
{
    public class Slot : Panel
    {
        private Button activateSlotButton;
        private Button deleteSlotButton;
        private Label nameLabel;
        private FileWorker fileWorker = new FileWorker();
        private DirectoryWorker directoryWorker = new DirectoryWorker();
        public string? path { get; private set; }
        public string? name { get; private set; }
        public Button ActivateSlotButton { get => activateSlotButton; }
        public Button DeleteSlotButton { get => deleteSlotButton; }
        public Label NameLabel { get => nameLabel; }


        public event EventHandler? slotSwitched;//события нажатия кнопки активации
        public event EventHandler? slotDeleted;//событие нажатия кнопки удаления

        public Slot(string path)
        {
            InitializeComponent();
            SetStartPosition();

            this.path = path;
            name = GetName(path) ?? path;
            nameLabel!.Text = name;
        }
        //~Slot() { MessageBox.Show("уничтожен"); }

        private void InitializeComponent()
        {

            this.nameLabel = new System.Windows.Forms.Label();
            this.activateSlotButton = new System.Windows.Forms.Button();
            this.deleteSlotButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 20);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Slot";
            // 
            // activateSlotButton
            // 
            this.activateSlotButton.BackColor = System.Drawing.Color.Black;
            this.activateSlotButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.activateSlotButton.Name = "activateSlotButton";
            this.activateSlotButton.Size = new System.Drawing.Size(35, 35);
            this.activateSlotButton.TabIndex = 0;
            this.activateSlotButton.UseVisualStyleBackColor = false;
            this.activateSlotButton.Click += new System.EventHandler(this.activateSlotButton_Click);
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
            this.deleteSlotButton.Click += new System.EventHandler(this.deleteSlotButton_Click);
            // 
            // Slot
            // 
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.activateSlotButton);
            this.Controls.Add(this.deleteSlotButton);
            this.Size = new System.Drawing.Size(350, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void activateSlotButton_Click(object sender, EventArgs e) => slotSwitched?.Invoke(this, new EventArgs());

        private void deleteSlotButton_Click(object sender, EventArgs e) => slotDeleted?.Invoke(this, new EventArgs());

        public void MoveSlot(int distance) => this.Left += distance;

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
            deleteSlotButton.Location = new Point(305, 10);
            nameLabel.Location = new Point(70, 10);
        }

    }
}

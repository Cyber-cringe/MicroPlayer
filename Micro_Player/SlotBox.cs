using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Micro_Player
{
    public class SlotBox:Panel, IEnumerable
    {
        //-----Поля-----
        private List<Slot>? slotList;
        private Slot? activeSlot;
        private int xDistance = 10;
        private int yDistance = 10;

        ~SlotBox() => MessageBox.Show($"слотбокс {Name} удален");
        
        //-----Свойства-----

        [Category("Слоты")] [Description("Определяет текущий активный слот. При этом не вызывается соответствующее событие")]
        public Slot? ActiveSlot
        {
            get => activeSlot;
            set
            {
                if(value == null)
                    activeSlot = null;
                else if (slotList != null && slotList.Contains(value))
                    activeSlot = value;
            }
        }

        [Category("Слоты")] [Description("Расстояние между слотами по координате X.")]
        public int XDistance
        {
            get => xDistance;
            set => xDistance = Math.Abs(value);
        }

        [Category("Слоты")] [Description("Расстояние между слотами по координате Y.")]
        public int YDistance
        {
            get => yDistance;
            set => yDistance = Math.Abs(value);
        }

        [Category("Слоты")] [Description("Определяет, будут ли слоты распологаться горизонтально.")]
        public bool Horisontal { get; set; }

        //-----События-----
        [Category("Состояние слотов")] [Description("Событие возникает, когда нажата кнопка активации любого из слотов, а также при вызове методов ActivateNextSlot(bool) и ActivatePreviousSlot(bool)")]
        public event EventHandler<SlotBoxEventArgs>? SlotActivated; //событие активации любого слота из списка

        [Category("Состояние слотов")] [Description("Событие возникает, когда нажата кнопка удаления любого из слотов.")]
        public event EventHandler<SlotBoxEventArgs>? DeletedSlotSelected; //событие удаление любого слота из списка

        [Category("Состояние слотов")] [Description("Событие возникает, когда нажата кнопка дополнительного действия любого из слотов.")]
        public event EventHandler<SlotBoxEventArgs>? AdditionalActionInvoke; //событие удаление любого слота из списка

        public SlotBox()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SlotBox
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Size = new System.Drawing.Size(450, 450);
            this.ResumeLayout(false);
        }

        //-----ОСНОВНЫЕ МЕТОДЫ-----
        //получаем перечислитель слотов слотбокса
        public IEnumerator GetEnumerator() => slotList.GetEnumerator();

        //Добавление в список слотов с соответствующими пазами
        public void SetData(string[] slotBoxElements)
        {
            ClearBox();
            if (slotBoxElements == null) return;
            slotList = new List<Slot>(slotBoxElements.Length);
            foreach (string element in slotBoxElements)
            {
                Slot slot = new Slot(element);
                slotList.Add(slot);
                SubscribeTo(slot);
            }
        }

        //настройка расположения слотов
        public void ShowSlots()
        {
            if (slotList == null) return;
            if (Horisontal)
                ArrangeSlotsHorizontally();
            else
                ArrangeSlotsVertically();
        }

        //Активация следующего слота
        public void ActivateNextSlot(bool closure = false)
        {
            if (slotList == null || activeSlot == null) return;
            int currentSlotIndex = slotList.IndexOf(activeSlot);
            try
            {
                activeSlot = slotList[currentSlotIndex + 1];
                SlotActivated?.Invoke(this, new SlotBoxEventArgs(activeSlot));
            }
            catch (ArgumentOutOfRangeException)
            {
                if (closure)
                {
                    activeSlot = slotList[0];
                    SlotActivated?.Invoke(this, new SlotBoxEventArgs(activeSlot));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        //Активация предыдущего слота
        public void ActivatePreviousSlot(bool closure = false)
        {
            if (slotList == null || activeSlot == null) return;
            int currentSlotIndex = slotList.IndexOf(activeSlot);
            try
            {
                activeSlot = slotList[currentSlotIndex - 1];
                SlotActivated?.Invoke(this, new SlotBoxEventArgs(activeSlot));
            }
            catch(ArgumentOutOfRangeException)
            {
                if (closure)
                {
                    activeSlot = slotList[slotList.Count - 1];
                    SlotActivated?.Invoke(this, new SlotBoxEventArgs(activeSlot));
                }
            }
            catch(Exception ex) {MessageBox.Show(ex.Message);}
        }

        //удаление слота
        public void DeleteSlot(Slot? slot)
        {
            if (slotList == null || slot == null) return;
            if (Controls.Contains(slot))
            {
                int index = Controls.IndexOf(slot);
                Point slotPosition = slot.Location;
                Controls.Remove(slot);
                slot.Dispose();
                MoveSlots(slotPosition, index);
            }
            slotList.Remove(slot);
        }

        //смена активного слота без вызова события
        public void FindAndSetNewActiveSlot(Predicate<Slot> pred)
        {
            Slot? newActiveSlot = slotList?.Find(pred);
            if (newActiveSlot != null)
                activeSlot = newActiveSlot;
        }

        //Количество слотов
        public int GetSlotCount() => Controls.Count;

        //-----ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ-----
        //обработчик события нажатия кнопки "активировать" на любом из слотов
        private void SlotSwitchedHandler(object? sender, EventArgs e)
        {
            if (sender is Button button && button.Parent is Slot activatedSlot) 
            {
                this.activeSlot = activatedSlot;
                SlotActivated?.Invoke(this, new SlotBoxEventArgs(activatedSlot));
            }
        }

        //обработчик события нажатия кнопки "удалить" на любом из слотов
        private void SlotDeletedHandler(object? sender, EventArgs e)
        {
            if (sender is Button button && button.Parent is Slot slotForDeletion)
                DeletedSlotSelected?.Invoke(this, new SlotBoxEventArgs(slotForDeletion));
        }

        //обработчик события нажатия кнопки дополнительного действия на любом из слотов
        private void AdditionalActionInvokeHandler(object? sender, EventArgs e)
        {
            if (sender is Button button && button.Parent is Slot AdditionalActionSlot)
                AdditionalActionInvoke?.Invoke(this, new SlotBoxEventArgs(AdditionalActionSlot));
        }

        //Подписываем методы на соответствующие события слота
        private void SubscribeTo(Slot slot)
        {
            slot.ActivateSlotButton.Click += SlotSwitchedHandler;
            slot.DeleteSlotButton.Click += SlotDeletedHandler;
            slot.AdditionalActionButton.Click += AdditionalActionInvokeHandler;
        }

        //метод для вертикального размещения слотов
        private void ArrangeSlotsVertically()
        {
            if (slotList == null) return;
            for (int i = 0; i < slotList.Count; i++)
            {
                int XPosition = XDistance;
                int YPosition = (slotList[i].Height + YDistance) * i + YDistance;
                slotList[i].Location = new Point(XPosition, YPosition);
            }
            Controls.AddRange(slotList.ToArray());
        }

        //метод для горизонтального размещения слотов
        private void ArrangeSlotsHorizontally()
        {
            if (slotList == null) return;
            for (int i = 0; i < slotList.Count; i++)
            {
                int XPosition = (slotList[i].Width + XDistance) * i + XDistance;
                int YPosition = YDistance;
                slotList[i].Location = new Point(XPosition, YPosition);
            }
            Controls.AddRange(slotList.ToArray());
        }

        //сдвигаем слоты влево или вверх после удаления одного из слотов
        private void MoveSlots(Point startPosition, int startIndex)
        {
            if (Horisontal)
            {
                for (int i = startIndex; i < Controls.Count; i++)
                {
                    (Controls[i].Left, startPosition.X) = (startPosition.X, Controls[i].Left);
                }
            }
            else
            {
                for (int i = startIndex; i < Controls.Count; i++)
                {
                    (Controls[i].Top, startPosition.Y) = (startPosition.Y, Controls[i].Top);
                }
            }
        }

        //очистка панели, удаление слотов
        public void ClearBox()
        {
            if (slotList == null) return;
            activeSlot = null;
            foreach(var slot in slotList)
            {
                this.Controls.Remove(slot);
                slot.Dispose();
            }
            slotList = null;
        }

    }

}

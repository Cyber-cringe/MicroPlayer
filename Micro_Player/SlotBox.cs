using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro_Player
{
    public class SlotBox:Panel
    {
        private System.ComponentModel.IContainer components;

        //Поля
        private List<Slot>? slotList;
        public Slot? selectedSlot { get; private set; }
        public event EventHandler<SlotBoxEventArgs>? SelectedSlotChanged; //событие активации любого слота из списка
        public event EventHandler<SlotBoxEventArgs>? DeletedSlotSelected; //событие удаление любого слота из списка

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

        //Добавление в список слотов с соответствующими пазами
        public void SetData(string[] slotBoxElements)
        {
            if (slotBoxElements == null) return;
            ClearAll();
            slotList = new List<Slot>(slotBoxElements.Length);
            foreach (string element in slotBoxElements)
            {
                Slot slot = new Slot(element);
                slotList.Add(slot);
                Subscribe(slot);
            }
        }

        //настройка расположения слотов
        public void ShowSlots(int XDistance = 10, int YDistance = 10, bool horisontal = false)
        {
            if (slotList == null) return;
            this.Controls.Clear();
            if (horisontal)
                ArrangeSlotsHorizontally(XDistance, YDistance);
            else
                ArrangeSlotsVertically(XDistance, YDistance);
        }

        //Активация следующего слота
        public void ActivateNextSlot()
        {
            if (slotList == null) return;
            int? nextIndex = GetNextIndex(selectedSlot);
            if (nextIndex == null) return;
            selectedSlot = slotList[nextIndex.Value];
            SelectedSlotChanged?.Invoke(this, new SlotBoxEventArgs(selectedSlot));
        }

        //Активация предыдущего слота
        public void ActivatePreviousSlot()
        {
            if (slotList == null) return;
            int? previousIndex = GetPreviousIndex(selectedSlot);
            if (previousIndex == null) return;
            selectedSlot = slotList![previousIndex.Value];
            SelectedSlotChanged?.Invoke(this, new SlotBoxEventArgs(selectedSlot));
        }

        //Передаем в метод делегат, который настраивает слот
        public void GlobalVisualizationSetup(Action<Slot> SlotVisualSetup)
        {
            if (slotList == null) return;
            foreach(Slot slot in slotList)
            {
                SlotVisualSetup(slot);
            }
        }

        //-----ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ-----

        //если нажата кнопка "активировать" на любом из слотов
        private void SlotSwitchedHandler(object? sender, EventArgs e)
        {
            if (sender is Slot selectedSlot) 
            {
                this.selectedSlot = selectedSlot;
                SelectedSlotChanged?.Invoke(this, new SlotBoxEventArgs(selectedSlot));
            }
        }

        //если нажата кнопка "удалить" на любом из слотов
        private void SlotDeletedHandler(object? sender, EventArgs e)
        {
            if (sender is Slot slotForDeletion)
                DeletedSlotSelected?.Invoke(this, new SlotBoxEventArgs(slotForDeletion));
        }

        //Подписываем методы на соответствующие события слота
        private void Subscribe(Slot slot)
        {
            slot.slotSwitched += SlotSwitchedHandler;
            slot.slotDeleted += SlotDeletedHandler;
        }

        //метод для вертикального размещения слотов
        private void ArrangeSlotsVertically(int XDistance = 10, int YDistance = 10)
        {
            if (slotList == null) return;
            for (int i = 0; i < slotList.Count; i++)
            {
                int XPosition = XDistance;
                int YPosition = (slotList[i].Height + YDistance) * i;
                slotList[i].Location = new Point(XPosition, YPosition);
                this.Controls.Add(slotList[i]);
            }
        }

        //метод для горизонтального размещения слотов
        private void ArrangeSlotsHorizontally(int XDistance = 10, int YDistance = 10)
        {
            if (slotList == null) return;
            for (int i = 0; i < slotList.Count; i++)
            {
                int XPosition = (slotList[i].Width + XDistance) * i;
                int YPosition = YDistance;
                slotList[i].Location = new Point(XPosition, YPosition);
                this.Controls.Add(slotList[i]);
            }
        }

        //получаем индекс следущего, после переданнрго в метод слота
        private int? GetNextIndex(Slot currentSlot)
        {
            if (slotList == null) return null;
            int? curentIndex = slotList.IndexOf(currentSlot);
            if (curentIndex == null || curentIndex == slotList.Count - 1) return null;
            return curentIndex.Value + 1;
        }

        //получаем индекс предыдущего, после переданнрго в метод слота
        private int? GetPreviousIndex(Slot currentSlot)
        {
            if (slotList == null) return null;
            int? curentIndex = slotList.IndexOf(currentSlot);
            if (curentIndex == null || curentIndex == 0) return null;
            return curentIndex.Value - 1;
        }

        private void ClearAll()
        {
            this.Controls.Clear();
            selectedSlot= null;
        }

    }


}

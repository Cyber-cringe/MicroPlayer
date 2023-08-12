using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace Micro_Player
{
    public partial class MainForm: Form
    {
        //директории приложения музыки и плейлистов
        private const string rootDir = @"C:\Micro Player";
        private const string musicDir = rootDir + @"\Music";
        private const string playlistsDir = rootDir + @"\Playlists";

        WindowsMediaPlayer player = new WindowsMediaPlayer();

        private Slot? currentSlot = null;
        private Slot? previousSlot = null;
        private Slot? currentPlaylist = null;
        private int SlotMoveDistance = 10;
        private (string play, string pause) playButtonStates = (play: "▍ ▍", pause: "▶");

        //Создаём корневую папку приложения и добавляем в неё остальные папки
        private void CreateDirs()
        {
            TryCreateDir(rootDir);
            TryCreateDir(musicDir);
            TryCreateDir(playlistsDir);
        }

        //-----МУЗЫКА-----
        //получаем список песен
        private void ShowMusic(string path = musicDir)
        {
            string[]? music = Directory.GetFiles(path, "*.mp3");
            if (music == null) return;
            musicBox.SetData(music);
            SetVisualToMusicBox();
            musicBox.ShowSlots();
            TryFindAndSwitchCurrentSlotInPlaylist();
        }

        //обработчик события смены трека
        private void MusicBoxSelectedSlotChangedEventHandler(object? sender, SlotBoxEventArgs e)
        {

            Slot activatedSlot = e.slot;
            string path = e.slot.path!;
            SwitchSound(path);
            TrySwitchSlots(activatedSlot);
            ChangePlayButtonState(activatedSlot.ActivateSlotButton);
            if(previousSlot!= null)
                previousSlot.ActivateSlotButton.Text = playButtonStates.pause;
        }

        //визуальная настройка слотов музыки
        private void SetVisualToMusicBox()
        {
            musicBox.GlobalVisualizationSetup((slot) =>
            {
                //настройки слота
                slot.Size = new Size(650, 50);
                slot.BackColor = Color.Orange;
                //настройки кнопки активации
                slot.ActivateSlotButton.Location = new Point(250, 10);
                slot.ActivateSlotButton.Size = new Size(110, 35);
                slot.ActivateSlotButton.Text = "▶";
                slot.ActivateSlotButton.ForeColor = Color.Orange;
                slot.ActivateSlotButton.FlatStyle = FlatStyle.Popup;
                //настройки кнопки удаления
                slot.DeleteSlotButton.Location = new Point(370, 10);
                slot.DeleteSlotButton.Size = new Size(110, 35);
                slot.DeleteSlotButton.Text = "Удалить";
                slot.DeleteSlotButton.BackColor = Color.Red;
                slot.DeleteSlotButton.ForeColor = Color.Black;
                slot.DeleteSlotButton.FlatStyle = FlatStyle.Popup;
                //настройки label
                slot.NameLabel.Location = new Point(10, 10);
            });
        }

        //-----ПЛЕЙЛИСТЫ-----

        //получаем список плейлистов
        private void ShowPlaylists(string path = playlistsDir)
        {
            string[]? playlists = Directory.GetDirectories(path);
            if (playlists == null) return;
            playlistsBox.SetData(playlists);
            SetVisualToPlaylistsBox();
            playlistsBox.ShowSlots(10, 10, true);
        }
        
        //обработчик события смены плейлиста
        private void PlayListsBoxSelectedSlotChangedEventHandler(object? sender, SlotBoxEventArgs e)
        {
            string path = e.slot.path!;
            currentPlaylist = e.slot;
            ShowMusic(path);
            currentPlaylistName.Text = currentPlaylist.name;
        }

        //визуальная настройка слотов playlistvox
        private void SetVisualToPlaylistsBox()
        {
            playlistsBox.GlobalVisualizationSetup((slot) =>
            {
                //настройки слота
                slot.Size = new Size(130,130);
                slot.BackColor = Color.Orange;
                //настройки кнопки активации
                slot.ActivateSlotButton.Location = new Point(10,45);
                slot.ActivateSlotButton.Size = new Size(110,35);
                slot.ActivateSlotButton.Text = "Открыть";
                slot.ActivateSlotButton.ForeColor= Color.Orange;
                slot.ActivateSlotButton.FlatStyle = FlatStyle.Popup;
                //настройки кнопки удаления
                slot.DeleteSlotButton.Location = new Point(10,90);
                slot.DeleteSlotButton.Size = new Size(110,35);
                slot.DeleteSlotButton.Text = "Удалить";
                slot.DeleteSlotButton.BackColor= Color.Red;
                slot.DeleteSlotButton.ForeColor = Color.Black;
                slot.DeleteSlotButton.FlatStyle = FlatStyle.Popup;
                //настройки label
                slot.NameLabel.Location = new Point(10, 10);
            });
        }

        //-----ПЛЕЕР----
        //включает новый трек, или меняет состояние текущего
        private void SwitchSound(string path)
        {
            if (player.URL == path) {
                ChangePlayerState();
            }
            else player.URL = path;
        }

        //Меняет состояние плеера
        private void ChangePlayerState()
        {
            if (player.playState == WMPPlayState.wmppsPlaying)
                player.controls.pause();
            else if (player.playState == WMPPlayState.wmppsPaused)
                player.controls.play();  
        }

        //-----ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ-----
        //создание директории
        private void TryCreateDir(string path)
        {
            if (!Directory.Exists(path) && !File.Exists(path))
                Directory.CreateDirectory(path);
        }

        //выдвигает/задвигает слоты при переключении треков
        private void TrySwitchSlots(Slot activatedSlot)
        {
            if (activatedSlot == currentSlot) return;
            (previousSlot, currentSlot) = (currentSlot, activatedSlot);
            DeactivateSlot(previousSlot);
            ActivateSlot(currentSlot);
        }

        //проверяем, есть ли текущий слот трека в новом плейлисте,
        //если да, то активируем слот
        private void TryFindAndSwitchCurrentSlotInPlaylist()
        {
            Slot? newSlot = musicBox.FindSlot((slot) => slot.path == currentSlot?.path);
            if (newSlot == null) return;
            newSlot.ActivateSlotButton.Text = currentSlot?.ActivateSlotButton.Text;
            currentSlot = newSlot;
            musicBox.SelectedSlot = newSlot;
            ActivateSlot(currentSlot);
        }

        //делаем слот активным
        private void ActivateSlot(Slot? slot)
        {
            if (slot == null) return;
            slot.MoveSlot(SlotMoveDistance);
            slot.DeleteSlotButton.Enabled = false;
        }

        //делаем слот неактивным
        private void DeactivateSlot(Slot? slot)
        {
            if (slot == null) return;
            slot.MoveSlot(-SlotMoveDistance);
            slot.DeleteSlotButton.Enabled = true;
        }

        //Меняем текст кнопки активации слота с треком
        private void ChangePlayButtonState(Button? button)
        {
            if (button == null) return;
            if (button.Text == playButtonStates.play)
                button.Text = playButtonStates.pause;
            else if (button.Text == playButtonStates.pause)
                button.Text = playButtonStates.play;
        }

    }
}

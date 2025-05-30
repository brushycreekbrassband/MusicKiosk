using MusicKiosk.Interfaces;
using MusicKiosk.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicKiosk
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalPage : ContentPage
    {
        Song _song;
        IAudioPlayer _audioPlayer;
        public ModalPage(Song song, IAudioPlayer audioPlayer)
        {
            _song = song;
            _audioPlayer = audioPlayer;
            InitializeComponent();
            labelSong.Text = $"{song.Number} - {song.Name}";
            labelSongMeta.Text = song.Meta;
        }

        //private void buttonAnnounceSong_Clicked(object sender, EventArgs e)
        //{
        //    _audioPlayer.PlayAudioFile(Path.Combine("Numbers", $"{_song.Number.ToString("D3")}.mp3"));
        //}

        //private void buttonInstructions_Clicked(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(_song.InstructionsFileName))
        //    {
        //        _audioPlayer.PlayAudioFile(Path.Combine("Instructions", _song.InstructionsFileName));
        //    }
        //}

        //private void buttonHereWeGo_Clicked(object sender, EventArgs e)
        //{
        //    _audioPlayer.PlayAudioFile(Path.Combine("Instructions", "HereWeGo.mp3"));
        //}


        private void PlayButton_Clicked(object sender, EventArgs e)
        {
            //buttonAnnounceSong.IsEnabled = false;
            //buttonHereWeGo.IsEnabled = false;
            //buttonInstructions.IsEnabled = false;
            buttonStart.IsEnabled = false;
            buttonStop.IsEnabled = true;
            _audioPlayer.PlayAudioFile(_song.FileName);
        }
        private void StopButton_Clicked(object sender, EventArgs e)
        {
            _audioPlayer.StopAudioFile();
            buttonStart.IsEnabled = true;
            buttonStop.IsEnabled = false;
            //buttonAnnounceSong.IsEnabled = true;
            //buttonHereWeGo.IsEnabled = true;
            //buttonInstructions.IsEnabled = true;
        }

        protected override void OnDisappearing()
        {
            _audioPlayer.StopAudioFile();
        }
        protected override bool OnBackButtonPressed()
        {
            _audioPlayer.StopAudioFile();
            return base.OnBackButtonPressed();
        }
    }
}
using MusicKiosk.Interfaces;
using MusicKiosk.Models;
using System;
using System.Collections.Generic;
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            buttonStart.IsEnabled = false;
            buttonStop.IsEnabled = true;
            _audioPlayer.PlayNoise();
            Thread.Sleep(2000);
            _audioPlayer.PlayAudioFile(_song.FileName);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            buttonStart.IsEnabled = true;
            buttonStop.IsEnabled = false;
            _audioPlayer.StopAudioFile();
            _audioPlayer.StopPlayNoise();
        }

        protected override void OnDisappearing()
        {
            _audioPlayer.StopAudioFile();
            _audioPlayer.StopPlayNoise();
        }
        protected override bool OnBackButtonPressed()
        {
            _audioPlayer.StopAudioFile();
            _audioPlayer.StopPlayNoise();
            return base.OnBackButtonPressed();
        }
    }
}
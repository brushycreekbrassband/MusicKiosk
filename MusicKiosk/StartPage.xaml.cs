using MusicKiosk.Interfaces;
using MusicKiosk.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Xamarin.Forms;

namespace MusicKiosk
{
    public partial class StartPage : ContentPage
    {
        IAudioPlayer _audioPlayer;
        StartPageViewModel _StartPageViewModel;
        public StartPage(ObservableCollection<Song>songs, IAudioPlayer audioPlayer)
        {
            InitializeComponent();
            _audioPlayer = audioPlayer;
            _StartPageViewModel = new StartPageViewModel(this, songs);
            BindingContext = _StartPageViewModel;
        }

        private void FlowListView_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            ObservableCollection<Song> filteredSongs = new ObservableCollection<Song>();
            foreach (var song in _StartPageViewModel.Songs)
            {
                if (song.Set == 0 || song.Set == (e.Item as Song).Set)
                {
                    filteredSongs.Add(song);
                }
            }
            MainPage mainPage = new MainPage(filteredSongs, _audioPlayer);
            Navigation.PushModalAsync(mainPage);
        }
    }
}

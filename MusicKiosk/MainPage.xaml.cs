using MusicKiosk.Interfaces;
using MusicKiosk.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MusicKiosk
{
    public partial class MainPage : ContentPage
    {
        IAudioPlayer _audioPlayer;
        MainPageViewModel _mainPageViewModel;
        public MainPage(ObservableCollection<Song>songs, IAudioPlayer audioPlayer)
        {
            InitializeComponent();
            _audioPlayer = audioPlayer;
            _mainPageViewModel = new MainPageViewModel(this, songs);
            BindingContext = _mainPageViewModel;
        }

        private void FlowListView_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            ModalPage modalPage = new ModalPage(e.Item as Song, _audioPlayer);
            Navigation.PushModalAsync(modalPage);
        }
    }
}

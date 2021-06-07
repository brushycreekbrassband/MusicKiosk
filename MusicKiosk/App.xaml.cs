using DLToolkit.Forms.Controls;
using MusicKiosk.Interfaces;
using MusicKiosk.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicKiosk
{
    public partial class App : Application
    {
        public static object ParentWindow { get; set; }

        public App(ObservableCollection<Song> songs, IAudioPlayer audioPlayer)
        {
            InitializeComponent();
            FlowListView.Init();
            MainPage = new MainPage(songs, audioPlayer);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

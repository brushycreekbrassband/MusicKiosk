using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using MusicKiosk.Models;
using System.IO;

namespace MusicKiosk
{
    public class MainPageViewModel : BindableObject
    {
        private MainPage _mainPage;

        public MainPageViewModel(MainPage mainPage, ObservableCollection<Song> songs)
        {
            _songs = songs;
        }

        private ObservableCollection<Song> _songs;
        public ObservableCollection<Song> Songs
        {
            get
            {
                return _songs;
            }
            set
            {
                if (_songs != value)
                {
                    _songs = value;
                    OnPropertyChanged(nameof(Songs));
                }
            }
        }

    
    }
}

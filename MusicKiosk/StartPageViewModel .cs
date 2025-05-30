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
    public class StartPageViewModel : BindableObject
    {
        private StartPage _startPage;
        private ObservableCollection<Song> _songs;

        public StartPageViewModel(StartPage mainPage, ObservableCollection<Song> songs)
        {
            _songs = songs;
        }


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
        public ObservableCollection<Song> Sets
        {
            get
            {
                ObservableCollection<Song> sets = new ObservableCollection<Song>();
                var setNumbers = _songs.Select(x => x.Set).Distinct().ToList().OrderBy(x => x);
                foreach (var setNumber in setNumbers)
                {
                    if (setNumber != null)
                    {
                        sets.Add(new Song() { Set = setNumber });
                    }
                }
                return sets;
            }
        }


    }
}

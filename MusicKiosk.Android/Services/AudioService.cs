using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MusicKiosk.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MusicKiosk.Droid.Services
{
    class AudioService : IAudioPlayer
    {
        MediaPlayer _mediaPlayer;
        MediaPlayer _noiseMediaPlayerN;
        string _folder;
        public AudioService(string folder)
        {
            _folder = folder;
        }

        public void StopAudioFile()
        {
            if (_mediaPlayer != null)
            {
                _mediaPlayer.Stop();
                _mediaPlayer.Dispose();
                _mediaPlayer = null;
            }
        }

        public void StopPlayNoise()
        {
            if (_noiseMediaPlayerN != null)
            {
                _noiseMediaPlayerN.Stop();
                _noiseMediaPlayerN.Dispose();
                _noiseMediaPlayerN = null;
            }
        }
        public void PlayNoise()
        {
            StopAudioFile();
            _noiseMediaPlayerN = new MediaPlayer();
            _noiseMediaPlayerN.Prepared += (s, e) =>
            {
                _noiseMediaPlayerN.Start();
            };

            //    var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
            string filePath = Path.Combine(_folder, "noise.mp3");
            _noiseMediaPlayerN.SetDataSource(filePath);
            _noiseMediaPlayerN.Prepare();
        }
        public void PlayAudioFile(string fileName)
        {
            StopAudioFile();
            _mediaPlayer = new MediaPlayer();
            _mediaPlayer.Prepared += (s, e) =>
            {
                _mediaPlayer.Start();
            };

            //    var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
            string filePath = Path.Combine(_folder, fileName);
            _mediaPlayer.SetDataSource(filePath);
            _mediaPlayer.Prepare();
        }
    }
}
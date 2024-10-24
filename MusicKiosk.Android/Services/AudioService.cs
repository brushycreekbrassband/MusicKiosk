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
using System.Threading;

namespace MusicKiosk.Droid.Services
{
    class AudioService : IAudioPlayer
    {
        MediaPlayer _audioPlayer;
        MediaPlayer _noisePlayer;

        string _folder;
        public AudioService(string folder)
        {
            _folder = folder;
        }

        public void StopAudioFile()
        {
            if (_audioPlayer != null)
            {
                _audioPlayer.Stop();
                _audioPlayer.Dispose();
                _audioPlayer = null;
            }

            if (_noisePlayer != null)
            {
                _noisePlayer.SetVolume(0, 0);
                _noisePlayer.Stop();
                _noisePlayer.Dispose();
                _noisePlayer = null;
            }
        }

        public void PlayAudioFile(string audioFileRelativePath)
        {
            StopAudioFile();
            _noisePlayer = new MediaPlayer();
            _noisePlayer.Prepared += (s, e) =>
            {
                _noisePlayer.SetVolume(.10f, .10f);
                _noisePlayer.Start();
            };

            string noiseFilePath = Path.Combine(_folder, "noise.mp3");
            _noisePlayer.SetDataSource(noiseFilePath);
            _noisePlayer.Prepare();

            _audioPlayer = new MediaPlayer();
            _audioPlayer.Prepared += (s, e) =>
            {
                Thread.Sleep(1000);
                _audioPlayer.Start();
                Thread.Sleep(1000);
                _noisePlayer.Stop();
            };

            //    var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
            string audioFilePath = Path.Combine(_folder, audioFileRelativePath);
            _audioPlayer.SetDataSource(audioFilePath);
            _audioPlayer.Prepare();
        }
    }
}
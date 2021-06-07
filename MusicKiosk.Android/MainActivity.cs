using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using System.Linq;
using Android.Views;
using Xamarin.Forms;
using MusicKiosk.Droid.Services;
using System.IO;
using System.Collections.Generic;
using AndroidX.Core.Content;
using Android;
using AndroidX.Core.App;
using static System.Environment;
using Newtonsoft.Json;
using MusicKiosk.Models;
using System.Collections.ObjectModel;

namespace MusicKiosk.Droid
{
    [Activity(Label = "MusicKiosk", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            this.Window.AddFlags(WindowManagerFlags.Fullscreen);

            CheckAppPermissions();
            //string[] files = Directory.GetFiles("/", "*.*", SearchOption.TopDirectoryOnly);

            string folder = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryMusic).ToString() + "/BCBB";
           
            ObservableCollection<Song> songs = JsonConvert.DeserializeObject<ObservableCollection<Song>>(File.ReadAllText(Path.Combine(folder, "songs.json")));
           // List<string> files = Directory.GetFiles(folder, "*.mp3", SearchOption.AllDirectories).ToList();

            LoadApplication(new App(songs, new AudioService(folder)));
            App.ParentWindow = this;
        }

        public bool CheckAppPermissions()
        {
            if ((int)Build.VERSION.SdkInt < 23)
            {
                return true;
            }

            if (!(ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) == (int)Permission.Granted) && !(ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) == (int)Permission.Granted))
            {
                var permissions = new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage };
                ActivityCompat.RequestPermissions(this, permissions, 0);
                return false;
            }
            return true;

        }
    }
}
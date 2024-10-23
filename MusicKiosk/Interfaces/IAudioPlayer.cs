using System;
using System.Collections.Generic;
using System.Text;

namespace MusicKiosk.Interfaces
{
    public interface IAudioPlayer
    {
        void PlayAudioFile(string fileName);
        void StopAudioFile();
    }
}

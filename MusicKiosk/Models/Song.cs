using System;
using System.Collections.Generic;
using System.Text;

namespace MusicKiosk.Models
{
    public class Song
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string InstructionsFileName { get; set; }
        public string FileName { get; set; }

        public string Meta { get; set; }
        public int? Set { get; set; }

    }
}

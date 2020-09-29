using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Tractor : ISingable
    {
        public string Name { get; }
        public string Sound { get; }

        public Tractor()
        {
            Name = "Tractor";
            Sound = "Vroom";
        }

        public string MakeSoundOnce()
        {
            return Sound;
        }

        public string MakeSoundTwice()
        {
            return Name + " goes " + Sound;
        }
    }
}

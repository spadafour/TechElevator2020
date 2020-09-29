using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public interface ISingable
    {
        string Name { get; }
        string Sound { get; }

        string MakeSoundOnce();
        string MakeSoundTwice();
    }
}

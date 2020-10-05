using Lecture.Aids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //FileAndDirectories.UsingTheDirectoryClass();
                //FileAndDirectories.UsingTheFileClass();
                //ReadingInFiles.ReadACharacterFile();
                //ReadingCSVFiles.ReadFile();
                SummingUpNumbers.ReadFile();         
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

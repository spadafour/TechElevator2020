using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Lecture.Aids
{
    public static class WritingTextFiles
    {
        /*
        * This method below provides sample code for printing out a message to a text file.
        */
        public static void WritingAFile()
        {

            string directory = Environment.CurrentDirectory;
            string fileName = "output.txt";
            string fullPath = Path.Combine(directory, fileName);
            try
            {
                //create new streamwriter
                using(StreamWriter sw = new StreamWriter(fullPath,true))
                {
                    // Write the current datetime
                    sw.WriteLine(DateTime.UtcNow);

                    // Print out Hello World
                    sw.Write("Hello ");
                    // commits what is in the buffer to the disk
                    sw.Flush();
                    sw.Write("World");
                    sw.WriteLine("");
                }

            } catch (Exception e)
            {

            }
            // After the using statement ends, file has now been written
            // and closed for further writing
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Text;

namespace WorkTimeA2
{
    static class GetTxtLines
    {
        static string txtName = "time-points.txt";

        // Returns all lines of the file named txtName that is on the same directory as the .exe file
        // //Returns null if the file doesn't exist
        // Throws exception if the file doesn't exist
        public static string[] ReadTxtLines()
        {
            string txtFilePath = string.Format("{0}/{1}", new DirectoryInfo(".").FullName, txtName);

            try
            {
                return File.ReadAllLines(txtFilePath);
            }
            catch (FileNotFoundException e)
            {
                throw new ArgumentException(string.Format("File named: {0} needs to exist", txtName));
                //return null;
            }
        }

        public static List<TimeSpan> GetSegments(IEnumerable<string> txtLines)
        {
            TimePoint lastTimePoint = null;
            List<TimeSpan> segments = new List<TimeSpan>();

            bool breakNow = false;

            foreach (string line in txtLines)
            {
                Console.WriteLine(line);
                if (line != "")
                {
                    TimePoint temp = new TimePoint(line);

                    if (lastTimePoint != null)
                    {
                        string tag;

                        if (breakNow)
                            tag = "break";
                        else
                            tag = "work";

                        TimeSpan tempTimeSpan = new TimeSpan(lastTimePoint, temp, tag);
                        segments.Add(tempTimeSpan);
                    }

                    breakNow = false;
                    lastTimePoint = temp;
                }
                else
                    breakNow = true;
            }

            return segments;
        }
    }
}

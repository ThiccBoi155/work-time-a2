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

        public static List<string> totalTags = new List<string>()
        {
            "work",
            "break"
        };

        public static List<TimeSpan> GetSegments(IEnumerable<string> txtLines)
        {
            TimePoint lastTimePoint = null;
            List<TimeSpan> segments = new List<TimeSpan>();

            bool breakNow = false;
            string currentTag = "work";

            foreach (string line in txtLines)
            {
                Console.WriteLine(line);
                if (line != "")
                {
                    //*
                    int sep = line.IndexOf(':');

                    if (sep != 1 && sep != 2)
                        throw new ArgumentException("Incorrenct time input");

                    string subLine;
                    string nextTag = currentTag;

                    // sep + 1 + 4. If there are only 2 or 3 more characters after the seperator, there is no tag.
                    // If there are 4 or more characters after the seperator, there is a tag.
                    if (sep + 5 <= line.Length)
                    {
                        nextTag = line.Substring(sep + 4);

                        if (!totalTags.Contains(nextTag))
                            totalTags.Add(nextTag);

                        subLine = line.Substring(0, 5);
                    }
                    else
                        subLine = line;
                    //*/

                    TimePoint temp = new TimePoint(subLine);

                    if (lastTimePoint != null)
                    {
                        string tag;

                        if (breakNow)
                            tag = "break";
                        else
                            tag = currentTag;

                        TimeSpan tempTimeSpan = new TimeSpan(lastTimePoint, temp, tag);
                        segments.Add(tempTimeSpan);
                    }

                    breakNow = false;
                    lastTimePoint = temp;

                    currentTag = nextTag;
                }
                else
                    breakNow = true;
            }

            Console.WriteLine();

            foreach (string tag in totalTags)
                Console.WriteLine(tag);

            return segments;
        }

        static void temp()
        {

        }
    }
}

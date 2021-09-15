using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimeA2
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> txtLines = GetTxtLines.ReadTxtLines();

            if (txtLines == null)
                Console.WriteLine("File not found");

            List<TimeSpan> segments = getSegments(txtLines);

            Console.WriteLine();

            int totalTime = GetSegmentData.GetTotalTime(segments);
            Console.WriteLine("Total time: {0}", totalTime);

            int workTime = GetSegmentData.GetTotalWithTag(segments, "work");
            Console.WriteLine("Total work time: {0}, {1}", workTime, GetSegmentData.GetPercentage(workTime, totalTime));

            int breakTime = GetSegmentData.GetTotalWithTag(segments, "break");
            Console.WriteLine("Total break time: {0}, {1}", breakTime, GetSegmentData.GetPercentage(breakTime, totalTime));

            Console.WriteLine();

            GetSegmentData.PrintTagAndTimeSpan(segments);

            Console.ReadLine();
        }

        static List<TimeSpan> getSegments(IEnumerable<string> txtLines)
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

        void quickTimePointTesting()
        {
            List<TimePoint> points = new List<TimePoint>()
            {
                new TimePoint(5,4),
                new TimePoint(9,47),
                new TimePoint(10,11),
                new TimePoint(12,3),
                new TimePoint(12,43)
            };

            foreach (TimePoint p in points)
                Console.WriteLine(p);

            Console.WriteLine("\n");

            TimePoint t = new TimePoint();

            try
            {
                t = new TimePoint(23, 59);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.GetType());
                Console.WriteLine("Message: {0}", e.Message);
            }

            Console.WriteLine(t);

            Console.WriteLine("stuf");
        }
    }
}

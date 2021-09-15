using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimeA2
{
    static class GetSegmentData
    {
        public static List<TimeSpan> Segments { set; private get; }

        public static int GetTotalTime()
        {
            return GetTotalTimeInInterval(0, Segments.Count - 1);
        }

        // Returns the total time from s1 to s2
        public static int GetTotalTimeInInterval(int index1, int index2)
        {
            return Segments[index2].start - Segments[index1].start + Segments[index2].timeSpan;
        }

        public static int GetTotalWithTag(string tag)
        {
            int sum = 0;

            foreach (TimeSpan seg in Segments)
            {
                if (seg.tag == tag)
                    sum += seg.timeSpan;
            }

            return sum;
        }

        public static string GetPercentage(int tagTime, int totalTime)
        {
            var v = 100f * tagTime / totalTime;

            return string.Format("{0}%", v);
        }

        public static void PrintTagAndTimeSpan()
        {
            foreach (TimeSpan segment in Segments)
            {
                Console.WriteLine("{0}: {1}", segment.tag, segment.timeSpan);
            }
        }
    }
}

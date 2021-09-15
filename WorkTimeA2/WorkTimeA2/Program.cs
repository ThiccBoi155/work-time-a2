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

            GetSegmentData.Segments = GetTxtLines.GetSegments(txtLines);

            Console.WriteLine();

            int totalTime = GetSegmentData.GetTotalTime();
            Console.WriteLine("Total time: {0}", totalTime);

            foreach (string tag in GetTxtLines.totalTags)
                PrintTagStat(totalTime, tag);

            Console.WriteLine();

            GetSegmentData.PrintTagAndTimeSpan();

            Console.ReadLine();
        }

        static void PrintTagStat(int totalTime, string tag)
        {
            int tagTime = GetSegmentData.GetTotalWithTag(tag);
            Console.WriteLine("Total {0} time: {1}, {2}", tag, tagTime, GetSegmentData.GetPercentage(tagTime, totalTime));

        }
    }
}

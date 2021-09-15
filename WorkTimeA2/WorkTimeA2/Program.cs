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

            int workTime = GetSegmentData.GetTotalWithTag("work");
            Console.WriteLine("Total work time: {0}, {1}", workTime, GetSegmentData.GetPercentage(workTime, totalTime));

            int breakTime = GetSegmentData.GetTotalWithTag("break");
            Console.WriteLine("Total break time: {0}, {1}", breakTime, GetSegmentData.GetPercentage(breakTime, totalTime));

            Console.WriteLine();

            GetSegmentData.PrintTagAndTimeSpan();

            Console.ReadLine();
        }
    }
}

using System;
using System.Diagnostics;

//By Christoph Silge

namespace TipToyGui.Common
{ /// <summary>
  /// PerfMon
  /// </summary>
    public static class PerfMon
    {
        private static Stopwatch sw = new Stopwatch();

        /// <summary>
        /// PerfMon for Quick Method Performance Tests
        /// </summary>
        public static void MeasureMS(Action action, string debugMessage)
        {
            sw.Restart();
            action();
            sw.Stop();
            Console.WriteLine($"{debugMessage} : {sw.ElapsedMilliseconds} ms");
        }
    }
}
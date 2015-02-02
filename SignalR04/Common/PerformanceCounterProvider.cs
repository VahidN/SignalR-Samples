using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SignalR04.Common
{
    public class Counter
    {
        public string Name { set; get; }
        public float Value { set; get; }
    }

    public class PerformanceCounterProvider
    {
        private readonly List<PerformanceCounter> _counters = new List<PerformanceCounter>();

        public PerformanceCounterProvider()
        {
            _counters.Add(new PerformanceCounter("Processor", "% Processor Time", "_Total", readOnly: true));
            _counters.Add(new PerformanceCounter("Memory", "Pages/sec", readOnly: true));
            _counters.Add(new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total", readOnly: true));
        }

        public IList<Counter> GetResults()
        {
            return _counters.Select(c => new Counter
                                        {
                                            Name = c.CategoryName, 
                                            Value = c.NextValue() 
                                        }).ToList();
        }
    }
}
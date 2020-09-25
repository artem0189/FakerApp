using System;
using FakerLib;
using FakerLib.Attribute;
using FakerLib.DefaultGenerators;

namespace DateTimeGenerator
{
    [FakerClass(typeof(DateTime))]
    public class DateTimeGenerator : IGenerator
    {
        private Random _rand;

        public DateTimeGenerator()
        {
            _rand = new Random();
        }

        public object GenerateValue(Type objectType, ObjectFiller objectFiller)
        {
            DateTime start = new DateTime(1995, 1, 1);
            TimeSpan range = DateTime.Today - start;
            TimeSpan randTimeSpan = new TimeSpan((long)(_rand.NextDouble() * range.Ticks));
            return start + randTimeSpan;
        }
    }
}

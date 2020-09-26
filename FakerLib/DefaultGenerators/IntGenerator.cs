using System;

namespace FakerLib.DefaultGenerators
{
    public class IntGenerator : IGenerator
    {
        private Random _rand;

        public IntGenerator()
        {
            _rand = new Random();
        }

        public object GenerateValue(Type objectType, ObjectFiller objectFiller)
        {
            return _rand.Next(1, Int32.MaxValue);
        }
    }
}

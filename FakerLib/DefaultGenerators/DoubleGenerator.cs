using System;

namespace FakerLib.DefaultGenerators
{
    public class DoubleGenerator : IGenerator
    {
        private Random _rand;

        public DoubleGenerator()
        {
            _rand = new Random();
        }

        public object GenerateValue(Type objectType, ObjectFiller objectFiller)
        {
            return _rand.NextDouble();
        }
    }
}

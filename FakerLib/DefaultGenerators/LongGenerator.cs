using System;

namespace FakerLib.DefaultGenerators
{
    public class LongGenerator : IGenerator
    {
        private Random _rand;

        public LongGenerator()
        {
            _rand = new Random();
        }

        public object GenerateValue(Type objectType, ObjectFiller objectFiller)
        {
            long result = _rand.Next() << 32;
            result = result | (long)_rand.Next();
            return result;
        }
    }
}

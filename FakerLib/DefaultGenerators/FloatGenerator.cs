using System;
using System.Collections.Generic;
using System.Text;

namespace FakerLib.DefaultGenerators
{
    public class FloatGenerator : IGenerator
    {
        private Random _rand;

        public FloatGenerator()
        {
            _rand = new Random();
        }

        public object GenerateValue(Type objectType, ObjectFiller objectFiller)
        {
            return _rand.NextDouble();
        }
    }
}

using System;

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
            double mantissa = (_rand.NextDouble() * 2.0) - 1.0;
            double exponent = Math.Pow(2.0, _rand.Next(-126, 128));
            return (float)(mantissa * exponent);
        }
    }
}

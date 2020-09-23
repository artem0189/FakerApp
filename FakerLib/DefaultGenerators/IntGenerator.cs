using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace FakerLib.DefaultGenerators
{
    public class IntGenerator : IGenerator
    {
        private Random _rand;

        public IntGenerator()
        {
            _rand = new Random();
        }

        public object GenerateValue(Type objectType)
        {
            return _rand.Next();
        }
    }
}

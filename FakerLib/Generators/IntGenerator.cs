using System;
using System.Collections.Generic;
using System.Text;

namespace FakerLib.Generators
{
    class IntGenerator : IGenerator
    {
        private Random _rand;

        public IntGenerator()
        {
            _rand = new Random();
        }

        public object GenerateValue()
        {
            return _rand.Next();
        }
    }
}

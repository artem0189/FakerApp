using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace FakerLib.DefaultGenerators
{
    public class IntGenerator : IGenerator
    {
        private Random _rand;

        public MemberInfo MemberType { get; }

        public IntGenerator()
        {
            _rand = new Random();
            MemberType = null;
        }

        public object GenerateValue()
        {
            return _rand.Next();
        }
    }
}

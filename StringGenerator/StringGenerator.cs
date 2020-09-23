using System;
using System.Reflection;
using FakerLib.Attribute;
using FakerLib.DefaultGenerators;

namespace StringGenerator
{
    [FakerClass(typeof(string))]
    public class StringGenerator : IGenerator
    {
        public MemberInfo MemberType { get; }

        public StringGenerator()
        {
            MemberType = null;
        }

        public object GenerateValue()
        {
            return "fegrhtgh";
        }
    }
}

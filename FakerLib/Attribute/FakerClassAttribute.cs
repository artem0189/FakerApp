using System;
using System.Collections.Generic;
using System.Text;

namespace FakerLib.Attribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class FakerClassAttribute : System.Attribute
    {
        public Type ReturningType { get; }

        public FakerClassAttribute(Type returningType)
        {
            ReturningType = returningType;
        }
    }
}

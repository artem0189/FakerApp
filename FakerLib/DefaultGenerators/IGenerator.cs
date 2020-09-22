using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace FakerLib.Generators
{
    public interface IGenerator
    {
        MemberInfo MemberType { get; }
        object GenerateValue();
    }
}

using System;
using System.Reflection;
using FakerLib.Attribute;

namespace FakerLib
{
    public class FakerType
    {
        public Type Type { get; }
        public Type BaseType { get; }
        public string MemberName { get; }
        public bool IsCreateAttribute { get; }

        public FakerType(Type type)
        {
            Type = type;
            IsCreateAttribute = type.IsDefined(typeof(FakerCreateAttribute));
        }

        public FakerType(Type type, Type baseType, string name) : this(type)
        {
            BaseType = baseType;
            MemberName = name;
        }
    }
}

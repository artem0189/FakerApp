using System;
using System.Reflection;
using FakerLib.Attribute;

namespace FakerLib
{
    public class FakerDTOType
    {
        public Type Type { get; }
        public MemberInfo Member { get; }
        public bool IsCreateAttribute { get; }
        public bool IsIgnoreAttribute { get; }

        public FakerDTOType(Type type)
        {
            Type = type;
            Member = null;
            IsCreateAttribute = type.IsDefined(typeof(FakerCreateAttribute));
            IsIgnoreAttribute = false;
        }

        public FakerDTOType(Type type, MemberInfo memberInfo)
        {
            Type = type;
            Member = memberInfo;
            IsCreateAttribute = type.IsDefined(typeof(FakerCreateAttribute));
            IsIgnoreAttribute = memberInfo.IsDefined(typeof(FakerIgnoreAttribute));
        }
    }
}

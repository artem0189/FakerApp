using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace FakerLib
{
    internal class ObjectFiller<T>
    {
        private FakerConfig _config;

        public ObjectFiller(FakerConfig config)
        {
            _config = config;
        }

        public T FillObject(T obj)
        {
            MemberInfo[] tre = GetAllVariables(obj);
            return (T)obj;
        }

        private MemberInfo[] GetAllVariables(T obj)
        {
            Type type = obj.GetType();
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            return type.GetMembers(flags);
        }
    }
}

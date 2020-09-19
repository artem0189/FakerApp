using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace FakerLib
{
    internal class ObjectFiller
    {
        private Generator _generator;
        private const BindingFlags _flags = BindingFlags.Instance | BindingFlags.Public;

        public ObjectFiller(FakerConfig config)
        {
            _generator = new Generator(config);
        }

        public object FillObject(Type type)
        {
            object obj = Activator.CreateInstance(type);
            MemberInfo[] memberInfo = GetAllVariables(type);
            foreach (var value in memberInfo)
            {
                FillObject((value as FieldInfo).FieldType);
            }
            return obj;
        }

        private MemberInfo[] GetAllVariables(Type type)
        {
            MemberInfo[] result = type.GetMembers(_flags).
                Where(member => member is PropertyInfo || member is FieldInfo).
                ToArray();

            return result;
        }
    }
}

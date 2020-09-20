using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using FakerLib.Reflection;

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

        public object FillObject(Type objectType)
        {
            object obj;
            if (!_generator.TryGenerateValue(objectType, out obj))
            {
                if (TryCreateObject(objectType, out obj))
                {
                    MemberInfo[] memberInfo = MetaInfo.GetFieldsAndProperties(objectType, _flags);
                    for (int i = 0; i < memberInfo.Length; i++)
                    {
                        object value = FillObject(MetaInfo.GetMemberType(memberInfo[i]));
                        MetaInfo.SetValue(memberInfo[i], obj, value);
                    }
                }
            }
            return obj;
        }

        private bool TryCreateObject(Type objectType, out object obj)
        {
            ConstructorInfo[] constructors = objectType.GetConstructors(_flags);
            if (constructors.Length == 1 && constructors[0].GetParameters().Length == 0)
            {
                obj = Activator.CreateInstance(objectType);
            }
            else
            {
                ParameterInfo[] parameters = constructors.Last().GetParameters();
                object[] constructorParams = new object[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    constructorParams[i] = FillObject(parameters[i].ParameterType);
                }
                obj = Activator.CreateInstance(objectType, constructorParams);
            }
            return obj != null;
        }
    }
}

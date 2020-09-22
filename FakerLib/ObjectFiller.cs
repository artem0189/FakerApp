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

        public object FillObject(FakerDTOType fakerType)
        {
            object obj = null;
            if (!fakerType.IsIgnoreAttribute)
            {
                if (!_generator.TryGenerateValue(fakerType, out obj) && fakerType.IsCreateAttribute)
                {
                    if (TryCreateObject(fakerType, out obj))
                    {
                        MemberInfo[] members = Metadata.GetFieldsAndProperties(fakerType.Type, _flags);
                        for (int i = 0; i < members.Length; i++)
                        {
                            object value = FillObject(new FakerDTOType(Metadata.GetMemberType(members[i]), members[i]));
                            Metadata.SetValue(members[i], obj, value);
                        }
                    }
                }
            }
            return obj;
        }

        private bool TryCreateObject(FakerDTOType fakerType, out object obj)
        {
            obj = null;
            ConstructorInfo constructor = Metadata.GetConstructor(fakerType.Type);
            if (constructor != null)
            {
                ParameterInfo[] parameters = constructor.GetParameters();
                object[] constructorParams = new object[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    constructorParams[i] = FillObject(new FakerDTOType(parameters[i].ParameterType));
                }
                obj = Activator.CreateInstance(fakerType.Type, constructorParams);
            }
            return obj != null;
        }
    }
}

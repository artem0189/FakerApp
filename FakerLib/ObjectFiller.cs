using System;
using System.Reflection;
using System.Linq;
using FakerLib.Reflection;

namespace FakerLib
{
    public class ObjectFiller
    {
        private Generator _generator;
        private const BindingFlags _flags = BindingFlags.Instance | BindingFlags.Public;

        public ObjectFiller(Generator generator)
        {
            _generator = generator;
        }

        public object FillObject(FakerType fakerType)
        {
            object obj = null;
            if (!_generator.TryGenerateValue(fakerType, this, out obj) && fakerType.IsCreateAttribute)
            {
                if (TryCreateObject(fakerType, out obj))
                {
                    MemberInfo[] members = Metadata.GetFieldsAndProperties(fakerType.Type, _flags);
                    for (int i = 0; i < members.Length; i++)
                    {
                        object value = FillObject(new FakerType(Metadata.GetMemberType(members[i]), fakerType.Type, members[i].Name));
                        Metadata.SetValue(members[i], obj, value);
                    }
                }
            }
            return obj;
        }

        private bool TryCreateObject(FakerType fakerType, out object obj)
        {
            obj = null;
            ConstructorInfo[] constructors = fakerType.Type.GetConstructors();
            constructors = constructors.OrderByDescending(constructor => constructor.GetParameters().Length).ToArray();
            for (int i = 0; i < constructors.Length; i++)
            {
                ParameterInfo[] parameters = constructors[i].GetParameters();
                object[] constructorParams = new object[parameters.Length];
                for (int j = 0; j < parameters.Length; j++)
                {
                    constructorParams[j] = FillObject(new FakerType(parameters[j].ParameterType, fakerType.Type, parameters[j].Name));
                }

                try
                {
                    obj = Activator.CreateInstance(fakerType.Type, constructorParams);
                    break;
                }
                catch { }
            }
            return obj != null;
        }
    }
}

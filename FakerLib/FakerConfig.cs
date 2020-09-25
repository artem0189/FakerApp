using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Reflection;
using FakerLib.DefaultGenerators;

namespace FakerLib
{
    public struct CustomGenerator
    {
        public MemberInfo Member { get; }
        public IGenerator Generator { get; }

        public CustomGenerator(IGenerator generator, MemberInfo member)
        {
            Generator = generator;
            Member = member;
        }
    }

    public class FakerConfig
    {
        private Dictionary<int, List<CustomGenerator>> _classes;

        public FakerConfig()
        {
            _classes = new Dictionary<int, List<CustomGenerator>>();
        }

        public void Add<ClassType, ReturningType, GeneratorType>(Expression<Func<ClassType, ReturningType>> expression)
        {
            IGenerator generator = (IGenerator)Activator.CreateInstance(typeof(GeneratorType)); 
            MemberInfo member = (expression.Body as MemberExpression).Member as MemberInfo;
            CustomGenerator customGenerator = new CustomGenerator(generator, member);
            List<CustomGenerator> generators;
            if (_classes.TryGetValue(typeof(ClassType).MetadataToken, out generators))
            {
                generators.Add(customGenerator);
            }
            else
            {
                generators = new List<CustomGenerator>();
                generators.Add(customGenerator);
                _classes.Add(typeof(ClassType).MetadataToken, generators);
            }
        }

        public bool TryGetGenerator(Type type, string memberName, out IGenerator generator)
        {
            generator = null;
            List<CustomGenerator> generators;
            if (_classes.TryGetValue(type.MetadataToken, out generators))
            {
                for (int i = 0; i < generators.Count; i++)
                {
                    if (string.Compare(memberName, generators[i].Member.Name, StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        generator = generators[i].Generator;
                    }
                }
            }
            return generator != null;
        }
    }
}

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Reflection;
using FakerLib.DefaultGenerators;

namespace FakerLib
{
    public class FakerConfig
    {
        private Dictionary<Type, List<(Expression, IGenerator)>> _classes;

        public FakerConfig()
        {
            _classes = new Dictionary<Type, List<IGenerator>>();
        }

        public void Add<ClassType, ReturningType, GeneratorType>(Expression<Func<ClassType, ReturningType>> expression)
        {
            List<IGenerator> generators;
            if (_classes.TryGetValue(typeof(ClassType), out generators))
            {
                generators.Add(null)
            }
            else
            {
                generators = new List<IGenerator>();
                generators.Add(null);
                _classes.Add(typeof(ClassType), generators);
            }
        }

        public bool TryGetGenerator(Type classType, MemberInfo memberInfo, out IGenerator generator)
        {
            
        }
    }
}

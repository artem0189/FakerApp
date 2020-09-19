using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Reflection;

namespace FakerLib
{
    public struct GeneratorStruct
    {
        public Type ReturnType { get; }
        public Expression ExpressionTree { get; }

        public GeneratorStruct(Type returnType, Expression expressionTree)
        {
            ReturnType = returnType;
            ExpressionTree = expressionTree;
        }
    }

    public class FakerConfig
    {
        private Dictionary<Type, List<GeneratorStruct>> _customGenerator;

        public FakerConfig()
        {
            _customGenerator = new Dictionary<Type, List<GeneratorStruct>>();
        }

        public void Add<ClassType, NameType, GenerateType>(Expression<Func<ClassType, NameType>> expression)
        {
            List<GeneratorStruct> generators;
            GeneratorStruct newGenerator = new GeneratorStruct(typeof(NameType), expression);
            if (_customGenerator.TryGetValue(typeof(ClassType), out generators))
            {
                generators.Add(newGenerator);
            }
            else
            {
                generators = new List<GeneratorStruct>() { newGenerator };
                _customGenerator.Add(typeof(ClassType), generators);
            }
        }

        public List<GeneratorStruct> GetGenerator(Type classType, Type returnType)
        {
            List<GeneratorStruct> generators;
            if (_customGenerator.TryGetValue(classType, out generators))
            {
                generators.Where(generator => generator.ReturnType == returnType);
            }
            return generators;
        }
    }
}

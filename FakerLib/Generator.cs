using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using FakerLib.Generators;
using FakerLib.Attribute;

namespace FakerLib
{
    public class Generator
    {
        private FakerConfig _config;
        private Dictionary<string, IGenerator> _defaultGenerators;

        public Generator(FakerConfig config)
        {
            _config = config;
            _defaultGenerators = new Dictionary<string, IGenerator>()
            {
                { typeof(int).Name, new IntGenerator() }
            };
        }

        public bool TryGenerateValue(FakerDTOType fakerType, out object obj)
        {
            obj = null;
            IGenerator generator;
            if (TryGetGenerator(fakerType, out generator))
            {
                obj = generator.GenerateValue();
            }
            return obj != null;
        }

        private bool TryGetGenerator(FakerDTOType fakerType, out IGenerator generator)
        {
            generator = null;
            if (_defaultGenerators.TryGetValue(fakerType.Type.Name, out generator))
            {

            }
            return generator != null;
        }
    }
}

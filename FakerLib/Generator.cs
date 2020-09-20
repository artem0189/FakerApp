using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
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

        public bool TryGenerateValue(Type objectType, out object obj)
        {
            //Dto attribute check

            bool result = false;
            IGenerator generator;
            if (TryGetDefaultGenerator(objectType, out generator))
            {
                obj = generator.GenerateValue();
                result = true;
            }
            else
            {
                obj = null;
            }
            return result;
        }

        private bool TryGetCustomGenerator(Type objectType, out IGenerator generator)
        {
            generator = null;
            return true;
        }

        private bool TryGetDefaultGenerator(Type objectType, out IGenerator generator)
        {
            return _defaultGenerators.TryGetValue(objectType.Name, out generator);
        }
    }
}

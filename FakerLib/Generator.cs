using System;
using System.Collections.Generic;
using System.Text;
using FakerLib.Generators;

namespace FakerLib
{
    class Generator
    {
        private FakerConfig _config;
        private Dictionary<Type, IGenerator> _defaultGenerators;

        public Generator(FakerConfig config)
        {
            _config = config;
            _defaultGenerators = new Dictionary<Type, IGenerator>()
            {
                { typeof(int), new IntGenerator() }
            };
        }
    }
}

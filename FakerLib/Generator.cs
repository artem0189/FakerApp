using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using FakerLib.DefaultGenerators;
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
            LoadPlugin();
        }

        private void LoadPlugin()
        {
            string pluginDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\Plugins";
            if (Directory.Exists(pluginDirectory))
            {
                string[] plugins = Directory.GetFiles(pluginDirectory, "*.dll");
                for (int i = 0; i < plugins.Length; i++)
                {
                    Assembly assembly = Assembly.LoadFile(plugins[i]);
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (type.GetInterface(typeof(IGenerator).Name) != null && type.IsDefined(typeof(FakerClassAttribute)))
                        {
                            FakerClassAttribute attribute = type.GetCustomAttribute(typeof(FakerClassAttribute)) as FakerClassAttribute;
                            IGenerator generator = Activator.CreateInstance(type) as IGenerator;                 
                            _defaultGenerators.Add(attribute.ReturningType.Name, generator); // ?
                        }
                    }
                }
            }
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

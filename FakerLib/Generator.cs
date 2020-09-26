using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using FakerLib.DefaultGenerators;
using FakerLib.Attribute;

namespace FakerLib
{
    public class Generator
    {
        private static Dictionary<int, IGenerator> _defaultGenerators;
        public FakerConfig Config { get; set; }

        static Generator()
        {
            _defaultGenerators = new Dictionary<int, IGenerator>()
            {
                { typeof(int).MetadataToken, new IntGenerator() },
                { typeof(float).MetadataToken, new FloatGenerator() },
                { typeof(string).MetadataToken, new StringGenerator() },
                { typeof(double).MetadataToken, new DoubleGenerator() },
                { typeof(long).MetadataToken, new LongGenerator() },
                { typeof(char).MetadataToken, new CharGenerator() }
            };
            LoadPlugin();
        }

        private static void LoadPlugin()
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
                            _defaultGenerators.Add(attribute.ReturningType.MetadataToken, (IGenerator)Activator.CreateInstance(type));
                        }
                    }
                }
            }
        }

        public bool TryGenerateValue(FakerType fakerType, ObjectFiller objectFiller, out object obj)
        {
            obj = null;
            IGenerator generator;
            if (TryGetGenerator(fakerType, out generator))
            {
                obj = generator.GenerateValue(fakerType.Type, objectFiller);
            }
            return obj != null;
        }

        private bool TryGetGenerator(FakerType fakerType, out IGenerator generator)
        {
            generator = null;
            if (Config == null || fakerType.BaseType == null)
            {
                _defaultGenerators.TryGetValue(fakerType.Type.MetadataToken, out generator);
            }
            else
            {
                if (!Config.TryGetGenerator(fakerType.BaseType, fakerType.MemberName, out generator))
                {
                    _defaultGenerators.TryGetValue(fakerType.Type.MetadataToken, out generator);
                }
            }
            return generator != null;
        }
    }
}

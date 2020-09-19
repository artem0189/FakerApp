using System;
using System.Reflection;

namespace FakerLib
{
    public class Faker
    {
        private FakerConfig _config;

        public Faker()
        {
            _config = null;
        }

        public Faker(FakerConfig config)
        {
            _config = config;
        }

        public T Create<T>()
        {
            ObjectFiller objectFiller = new ObjectFiller(_config);
            return (T)objectFiller.FillObject(typeof(T));
        }
    }
}

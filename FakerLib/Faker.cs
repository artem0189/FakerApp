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
            ObjectFiller<T> objectFiller = new ObjectFiller<T>(_config);
            return objectFiller.FillObject((T)Activator.CreateInstance(typeof(T)));
        }
    }
}

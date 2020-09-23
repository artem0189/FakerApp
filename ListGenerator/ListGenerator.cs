using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using FakerLib;
using FakerLib.Attribute;
using FakerLib.DefaultGenerators;

namespace ListGenerator
{
    [FakerClass(typeof(List<>))]
    public class ListGenerator : IGenerator
    {
        private Random _rand;
        private ObjectFiller _objectFiller;

        public ListGenerator()
        {
            _rand = new Random();
            _objectFiller = new ObjectFiller(null);
        }

        public object GenerateValue(Type objectType)
        {
            Type createdElement = objectType.GetGenericArguments()[0];
            IList list = (IList)Activator.CreateInstance(objectType);

            int countObject = _rand.Next() % 10;
            for (int i = 0; i < countObject; i++)
            {
                object value = _objectFiller.FillObject(new FakerDTOType(createdElement));
                list.Add(value);
            }
            return list;
        }
    }
}

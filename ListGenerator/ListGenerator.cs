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

        public ListGenerator()
        {
            _rand = new Random();
        }

        public object GenerateValue(Type objectType, ObjectFiller objectFiller)
        {
            Type createdElement = objectType.GetGenericArguments()[0];
            IList list = (IList)Activator.CreateInstance(objectType);

            int countObject = _rand.Next() % 10;
            for (int i = 0; i < countObject; i++)
            {
                object value = objectFiller.FillObject(new FakerType(createdElement));
                list.Add(value);
            }
            return list;
        }
    }
}

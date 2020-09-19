using System;
using System.Collections.Generic;
using FakerLib;
using FakerLib.Generators;

namespace FakerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Faker faker = new Faker();
            Foo foo = faker.Create<Foo>();
        }

         /*
            IGenerator generator = (IGenerator)Activator.CreateInstance(typeof(GenerateType));
            NameType fdg = (NameType)generator.GenerateValue();

            MemberExpression test = expression.Body as MemberExpression;
            PropertyInfo t = test.Member as PropertyInfo;
            t.SetValue(obj, fdg);
        */
    }

    public class Foo
    {
        public int test;
    }
}

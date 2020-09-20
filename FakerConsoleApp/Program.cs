using System;
using System.Collections.Generic;
using FakerLib;
using FakerLib.Attribute;

namespace FakerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Faker faker = new Faker();
            Bar foo = faker.Create<Bar>();
        }

         /*
            IGenerator generator = (IGenerator)Activator.CreateInstance(typeof(GenerateType));
            NameType fdg = (NameType)generator.GenerateValue();

            MemberExpression test = expression.Body as MemberExpression;
            PropertyInfo t = test.Member as PropertyInfo;
            t.SetValue(obj, fdg);
        */
    }

    [FakerDTO]
    public class Foo
    {
        public Bar bar;
    }

    [FakerDTO]
    public class Bar
    {
        private int test;
        public int trh;

        public Bar(int test)
        {
            this.test = test;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using FakerLib;
using FakerLib.Attribute;

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

    [FakerCreate]
    public class Foo
    {
        [FakerIgnore]
        public List<string> test;
        public int t;
    }

    [FakerCreate]
    public class Bar
    {
        private int test;
        public int trh;
        public string resg;

        public Bar(int test)
        {
            this.test = test;
        }
    }
}

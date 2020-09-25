using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using FakerLib;
using FakerLib.Attribute;
using FakerLib.DefaultGenerators;

namespace FakerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FakerConfig config = new FakerConfig();
            config.Add<Bar, int, IntGenerator>(bar => bar.Test);
            Faker faker = new Faker(config);
            Bar foo = faker.Create<Bar>();
        }
    }

    public class IntGenerator : IGenerator
    {
        public object GenerateValue(Type objectType, ObjectFiller objectFiller)
        {
            return -1;
        }
    }

    [FakerCreate]
    public class Foo
    {
        public List<Bar> test;
        public int t;
    }

    [FakerCreate]
    public class Bar
    {
        public int Test { get; }
        public string resg;

        public Bar(int test)
        {
            Test = test;
        }
    }
}

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
    }

    [FakerCreate]
    public class Bar
    {
        public List<int> test;
    }
}

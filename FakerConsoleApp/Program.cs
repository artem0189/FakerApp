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
            faker.Create<Foo>();
        }
    }

    public class Foo
    {
        public int gd;
        private int fgdhfj;
        public int Te { get; set; }
    }
}

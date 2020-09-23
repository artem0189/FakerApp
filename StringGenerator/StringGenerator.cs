using System;
using System.Reflection;
using FakerLib.Attribute;
using FakerLib.DefaultGenerators;

namespace StringGenerator
{
    [FakerClass(typeof(string))]
    public class StringGenerator : IGenerator
    {
        private Random _rand;
        private char[] _letters;

        public StringGenerator()
        {
            _rand = new Random();
            _letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        }

        public object GenerateValue(Type objectType)
        {
            string word = "";
            int wordLength = _rand.Next() % 25;
            for (int i = 0; i < wordLength; i++)
            {
                word += _letters[_rand.Next() % _letters.Length];
            }
            return word;
        }
    }
}

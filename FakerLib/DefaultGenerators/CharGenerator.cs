using System;

namespace FakerLib.DefaultGenerators
{
    public class CharGenerator : IGenerator
    {
        private Random _rand;
        private char[] _letters;

        public CharGenerator()
        {
            _rand = new Random();
            _letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        }

        public object GenerateValue(Type objectType, ObjectFiller objectFiller)
        {
            return _letters[_rand.Next(0, _letters.Length)];
        }
    }
}

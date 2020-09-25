using System;
using System.Reflection;

namespace FakerLib.DefaultGenerators
{
    public interface IGenerator
    {
        object GenerateValue(Type objectType, ObjectFiller objectFiller);
    }
}

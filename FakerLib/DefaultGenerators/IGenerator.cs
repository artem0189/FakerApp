using System;

namespace FakerLib.DefaultGenerators
{
    public interface IGenerator
    {
        object GenerateValue(Type objectType, ObjectFiller objectFiller);
    }
}

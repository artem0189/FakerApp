using System.Reflection;

namespace FakerLib.DefaultGenerators
{
    public interface IGenerator
    {
        MemberInfo MemberType { get; }
        object GenerateValue();
    }
}

using System;

namespace FakerLib.Attribute
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class FakerIgnoreAttribute : System.Attribute
    {
    }
}

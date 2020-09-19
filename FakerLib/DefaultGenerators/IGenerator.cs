using System;
using System.Collections.Generic;
using System.Text;

namespace FakerLib.Generators
{
    public interface IGenerator
    {
        object GenerateValue();
    }
}

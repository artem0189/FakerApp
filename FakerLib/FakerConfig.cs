using System;
using System.Linq.Expressions;
using System.Reflection;

namespace FakerLib
{
    public class FakerConfig
    {
        public void Add<ClassType, NameType, GenerateType>(ClassType obj, Expression<Func<ClassType, NameType>> expression)
        { 
            /*
            IGenerator generator = (IGenerator)Activator.CreateInstance(typeof(GenerateType));
            NameType fdg = (NameType)generator.GenerateValue();

            MemberExpression test = expression.Body as MemberExpression;
            PropertyInfo t = test.Member as PropertyInfo;
            t.SetValue(obj, fdg);
            */
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace FakerLib.Reflection
{
    static class Metadata
    {
        public static ConstructorInfo GetConstructor(Type type)
        {
            ConstructorInfo[] constructors = type.GetConstructors();
            return constructors.Length == 0 ? null : constructors[0];
        }

        public static MemberInfo[] GetFieldsAndProperties(Type objectType, BindingFlags flags)
        {
            MemberInfo[] result = objectType.GetMembers(flags).
                Where(member => member is PropertyInfo || member is FieldInfo).
                ToArray();

            return result;
        }

        public static Type GetMemberType(MemberInfo memberInfo)
        {
            Type result = null;
            switch (memberInfo.MemberType)
            {
                case MemberTypes.Field:
                    result = (memberInfo as FieldInfo).FieldType;
                    break;
                case MemberTypes.Property:
                    result = (memberInfo as PropertyInfo).PropertyType;
                    break;
            }
            return result;
        }

        public static void SetValue(MemberInfo memberInfo, object obj, object value)
        {
            switch (memberInfo.MemberType)
            {
                case MemberTypes.Field:
                    (memberInfo as FieldInfo).SetValue(obj, value);
                    break;
                case MemberTypes.Property:
                    (memberInfo as PropertyInfo).SetValue(obj, value);
                    break;
            }
        }
    }
}

using System;
using System.Linq;
using System.Reflection;

namespace FakerLib.Reflection
{
    static class Metadata
    {
        public static MemberInfo[] GetFieldsAndProperties(Type objectType, BindingFlags flags)
        {
            PropertyInfo[] properties = objectType.GetProperties(flags).Where(prop => prop.CanWrite).ToArray();
            FieldInfo[] fields = objectType.GetFields(flags);
            return fields.Cast<MemberInfo>().Concat(properties.Cast<MemberInfo>()).ToArray();
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

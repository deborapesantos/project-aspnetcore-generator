using System.ComponentModel;
using System.Reflection;

namespace TemplateHexagonal.Core.Infra.Shared
{
    public class EnumHelper
    {
        public static bool TryGetEnumValueFromDescription<T>(string description, out T register)
           where T : struct, IConvertible
        {
            MemberInfo[] fis = typeof(T).GetFields();
            foreach (var fi in fis)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null && attributes.Length > 0 && attributes[0].Description == description)
                {
                    return Enum.TryParse(fi.Name, true, out register);
                }
            }

            register = default;

            return false;
        }

        public static T GetValueFromDescription<T>(string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            return default(T);
        }
    }
}

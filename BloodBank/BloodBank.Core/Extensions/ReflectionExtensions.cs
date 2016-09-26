using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BloodBank.Core.Extensions {
    public static class ReflectionExtensions {

        public static string PropertyList(this object obj, Type customAttributeType, params string[] excluedPropertiesNames) {
            List<PropertyInfo> excludedProps = excluedPropertiesNames.Select(excluedPropertyName => obj.GetType().GetProperty(excluedPropertyName)).ToList();
            return PropertyList(obj, customAttributeType, excludedProps.ToArray());
        }

        public static string PropertyList(this object obj, Type customAttributeType, PropertyInfo[] excluedProperties) {
            IEnumerable<PropertyInfo> props = obj.GetType().GetProperties();
            if (customAttributeType != null)
                props = props.Where(p => Attribute.IsDefined(p, customAttributeType));
            props = props.Except(excluedProperties);

            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo p in props) {
                object value = p.GetValue(obj, null);
                if (value is IEnumerable<object>)
                    sb.AppendLine(((IEnumerable) value).Cast<object>().Aggregate((x, y) => x + ", " + y).ToString());
                else if (value is DateTime)
                    sb.AppendLine("" + ((DateTime)value).ToShortDateString());
                else
                    sb.AppendLine("" + value);
            }
            return sb.ToString();
        }

        public static IEnumerable<string> PropertyNames(this Type obj, Type customAttributeType) {
            IEnumerable<PropertyInfo> props = obj.GetProperties();
            if (customAttributeType != null)
                props = props.Where(p => Attribute.IsDefined(p, customAttributeType));
            return props.Select(p => {
                Type type = p.PropertyType;
                type = Nullable.GetUnderlyingType(type) ?? type;
                IEnumerable values = type.IsEnum ? Enum.GetValues(type) : null;
                values = values ?? (type == typeof(bool) ? new[] {"True", "False"} : null);
                values = values ?? (IEnumerable)type.GetProperty("Values")?.GetValue(null, null);

                string stringValues = values?.Cast<object>().Aggregate((x, y) => x + ", " + y).ToString();
                return stringValues != null ? p.Name.ToSentenceCase() + " (" + stringValues + ")" : p.Name.ToSentenceCase();
            }).OrderBy(name => name);
        }

        public static Dictionary<string, object> ToPropertyDictionary(this object obj) {
            return obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).ToDictionary(prop => prop.Name, prop => prop.GetValue(obj, null));
        }

        public static bool IsDerivedOfGenericType(this Type type, Type genericType) {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == genericType)
                return true;
            if (type.BaseType != null) {
                return IsDerivedOfGenericType(type.BaseType, genericType);
            }
            return false;
        }
    }
}

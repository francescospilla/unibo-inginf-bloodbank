using System;
using System.Collections.Generic;
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
                sb.AppendLine(p.Name + ": " + p.GetValue(obj, null));
            }
            return sb.ToString();
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

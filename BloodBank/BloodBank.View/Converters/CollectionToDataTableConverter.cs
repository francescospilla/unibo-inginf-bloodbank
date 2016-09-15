using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Tests;

namespace BloodBank.View.Converters {

    public class CollectionToDataTableConverter : IValueConverter {

        public IComparer<string> PropertySorter { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            IEnumerable<object> enumerable = value as IEnumerable<object>;
            if (enumerable == null)
                throw new NotSupportedException("Object " + value + " is not an IEnumerable");

            List<Dictionary<string, object>> dictionaries = enumerable.Select(obj => ObjectToDictionaryConverter.Instance.Convert(obj, targetType, parameter, culture)).Cast<Dictionary<string, object>>().ToList();

            DataTable dt = new DataTable();

            SortedSet<string> unionKeys = new SortedSet<string>(PropertySorter);
            foreach (Dictionary<string, object> dictionary in dictionaries)
                unionKeys.UnionWith(dictionary.Keys);

            foreach (string key in unionKeys) {
                dt.Columns.Add(key, key.Equals("Id") ? typeof(int) : typeof(string));
            }

            foreach (Dictionary<string, object> dictionary in dictionaries) {
                dt.Rows.Add(unionKeys.Select(key => {
                    dictionary.TryGetValue(key, out value);
                    return value;
                }).ToArray());
            }

            return dt;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }


    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Data;
using BloodBank.Core.Extensions;

namespace BloodBank.View.Converters {

    public class CollectionToDataTableConverter : IValueConverter {

        public IComparer<string> PropertySorter { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            IEnumerable<object> enumerable = value as IEnumerable<object>;
            if (enumerable == null)
                throw new NotSupportedException("Object " + value + " is not an IEnumerable");

            List<Dictionary<string, object>> dictionaries = enumerable.Select(obj => obj.ToPropertyDictionary()).ToList();

            DataTable dt = new DataTable();

            SortedSet<string> unionKeys = new SortedSet<string>(PropertySorter);
            foreach (Dictionary<string, object> dictionary in dictionaries)
                unionKeys.UnionWith(dictionary.Keys);

            foreach (string key in unionKeys) {
                dt.Columns.Add(key.ToSentenceCase(), typeof(string));
            }

            foreach (Dictionary<string, object> dictionary in dictionaries) {
                object[] values = unionKeys.Select(key => {
                    dictionary.TryGetValue(key, out value);
                    return value;
                }).ToArray();

                var stringValues = values.Select(obj => {
                    if (obj == null) return null;
                    if (obj is string) return obj;
                    if (obj is bool) return (bool) obj ? "Sì" : "No";
                    return obj.ToString().ToSentenceCase();
                });
                dt.Rows.Add(stringValues.ToArray());
            }

            return dt;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }


    }

    public class PriorityPropertyComparer : IComparer<string> {

        private IList<string> _priorityList;
        public IEnumerable<string> PriorityList {
            get { return _priorityList; }
            set { _priorityList = value.ToList(); }
        }

        private int GetPriority(string property) {
            int result = _priorityList.IndexOf(property);
            return result == -1 ? _priorityList.Count + 1 : result;
        }

        public int Compare(string property1, string property2) {
            if (property1.Equals(property2))
                return 0;

            int diff;
            if ((diff = GetPriority(property1) - GetPriority(property2)) != 0)
                return diff;

            return string.Compare(property1, property2, StringComparison.Ordinal);
        }

    }


}

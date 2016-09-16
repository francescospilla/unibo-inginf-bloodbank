using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Tests;

namespace BloodBank.View.Converters {

    public class PriorityPropertyComparer : IComparer<string> {

        private IList<string> _priorityList;
        public IEnumerable<string> PriorityList
        {
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Extensions {
    public static class EnumerableExtensions {

        public static IEnumerable Enumerable(this Type type) {
            switch (Type.GetTypeCode(type)) {
                case TypeCode.Boolean:
                    return new[] { true, false };
                case TypeCode.Int32:
                    return System.Linq.Enumerable.Range(-1000, 2001).ToList();
                case TypeCode.Double:
                    List<double> list = System.Linq.Enumerable.Range(-10000, 20001).Select(i => (double)i / 10).ToList();
                    list.Insert(0, double.NegativeInfinity);
                    list.Add(double.PositiveInfinity);
                    return list;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}

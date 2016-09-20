using System.Collections.Generic;
using System.Linq;

namespace BloodBank.Core.Extensions {

    public static class LINQExtensions {

        public static bool IsSubsetOf<T>(this IEnumerable<T> a, IEnumerable<T> b) {
            return !a.Except(b).Any();
        }

        public static bool IsSubstringWiseSubsetOf(this IEnumerable<string> a, IEnumerable<string> b) {
            return !a.Except(b, new StartsWithSubstringEqualityComparer()).Any();
        }


    }


    public class StartsWithSubstringEqualityComparer : IEqualityComparer<string> {
        #region Implementation of IEqualityComparer<in string>

        public bool Equals(string x, string y) {
            return x.StartsWith(y);
        }

        public int GetHashCode(string obj) {
            return 0;
        }

        #endregion
    }
}

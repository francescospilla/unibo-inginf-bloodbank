using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BloodBank.Core.Extensions {
    public static class StringExtensions {

        public static string ToSentenceCase(this string value) {
            return Regex.Replace(value, "(?!^)([A-Z])", " $1");
        }
    }
}

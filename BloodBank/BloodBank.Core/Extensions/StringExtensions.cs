using System.Text.RegularExpressions;

namespace BloodBank.Core.Extensions {
    public static class StringExtensions {

        public static string ToSentenceCase(this string value) {
            return Regex.Replace(value, "(?!^)([A-Z])", " $1");
        }
    }
}

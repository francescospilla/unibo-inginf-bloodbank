using System.Linq;

namespace BloodBank.Core.Extensions {

    public static class ParsingExtensions {

        public static bool IsPositiveIntegerNumber(this string arg) {
            if (arg == null)
                return false;
            return arg.StartsWith("+") ? arg.Substring(1, arg.Length).All(char.IsDigit) : arg.All(char.IsDigit);
        }
    }
}
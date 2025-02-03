#nullable enable

using System.Text.RegularExpressions;

namespace ConsoleToDoProject.CLI
{
    public class Validator
    {
        /// <summary>
        /// Validator class checks that an input string is a valid. An input string is considered valid if:
        /// 1. It contains only letter characters or underscores
        /// 2. It is not null
        /// </summary>

        public Validator() { }

        private bool IsNullString(string? input)
        {
            return input == null;
        }

        private bool ContainsWhitespace(string input)
        {

            string pattern = @"\s+";
            return Regex.IsMatch(input, pattern);

        }

        private bool ContainsInvalidChars(string input) {

            string pattern = @"[^a-zA-Z_]+";

            return Regex.IsMatch(input, pattern);
        }

        public bool IsValidInput(string? input)
        {
            if (IsNullString(input))
            {
                throw new ArgumentNullException($"{nameof(input)} cannot be null.");
            }
            input = input ?? " "; // to satisfy compiler but probably bad practice

            if (ContainsInvalidChars(input) || ContainsWhitespace(input))
            {
                return false;
            }
            return true;
        }

    }

}

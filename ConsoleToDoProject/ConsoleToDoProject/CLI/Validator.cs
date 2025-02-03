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

        public bool IsNullString(string? input)
        {
            return input == null;
        }

        public bool ContainsWhitespace(string? input)
        {
            if (IsNullString(input))
            {
                throw new ArgumentNullException($"Variable {nameof(input)} cannot be null.");
            }
            else
            {

                string pattern = @"\s+";

                return Regex.IsMatch(input, pattern);
            }

        }

        public bool ContainsInvalidChars(string? input) { 

            if (IsNullString(input))
            {
                throw new ArgumentNullException($"Variable {nameof(input)} cannot be null.");
            }
            else
            {

                string pattern = @"[^a-zA-Z_]+";

                return Regex.IsMatch(input, pattern);
            }
        }

    }

}

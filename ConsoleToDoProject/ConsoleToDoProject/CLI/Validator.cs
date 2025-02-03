#nullable enable

using System.Text.RegularExpressions;
using System.Diagnostics.CodeAnalysis;

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

        private bool IsNullString([NotNullWhen(false)] string? input)
        {
            return input == null;
        }

        private bool ContainsInvalidChars(string input) {

            string pattern = @"[^a-zA-Z_]+";

            return Regex.IsMatch(input, pattern);
        }

        private bool IsEmptyString(string input)
        {
            return input.Length == 0;
        }

        public bool IsValidInput(string? input)
        {
            if (IsNullString(input))
            {
                throw new ArgumentNullException($"{nameof(input)} is invalid: Value cannot be null.");
            }

            if (ContainsInvalidChars(input) )
            {
                throw new ArgumentException($"{nameof(input)} is invalid: Value can only contain a-z, A-Z, and _ chars");
            }else if (IsEmptyString(input))
            {
                throw new ArgumentException($"{nameof(input)} is invalid: Value cannot be an empty string");
            }
            return true;
        }

    }

}

using System;
using System.Text.RegularExpressions;

namespace ConsoleToDoProject.CLI
{
    public class Validator
    {

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

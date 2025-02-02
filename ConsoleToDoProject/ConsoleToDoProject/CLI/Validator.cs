using System;

namespace ConsoleToDoProject.CLI
{
    public class Validator
    {
        public Validator() { }

        public bool IsNullString(string? input)
        {
            return input == null;
        }

    }
}

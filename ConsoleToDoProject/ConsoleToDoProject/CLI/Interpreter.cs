#nullable enable

using System;
using System.Text;

namespace ConsoleToDoProject.CLI
{
    public class Interpreter
    {
        private bool _isRunning { get; set; }
        private Validator _validator;
        public Interpreter()
        {
            _isRunning = false;
            _validator = new Validator();
        }

        public string? GetInput()
        {
            Console.WriteLine(">>>");
            string? input = Console.ReadLine();
            if(_validator.IsValidInput(input))
                return input?.ToLower();
            else return null;
        }

    }
}

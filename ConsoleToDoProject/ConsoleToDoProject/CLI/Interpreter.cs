using System;
using System.Text;

namespace ConsoleToDoProject.CLI
{
    public class Interpreter
    {
        private bool _isRunning { get; set; }
        public Interpreter()
        {
            _isRunning = false;
        }

        public string GetInput()
        {
            Console.WriteLine(">>>");
            string input = CheckNullInput(Console.ReadLine());
            return input;
        }

        private string CheckNullInput(string? input)
        {
            return input ?? string.Empty;
        }
    }
}

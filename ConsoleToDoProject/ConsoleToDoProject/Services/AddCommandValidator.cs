using ConsoleToDoProject.Interfaces;
using ConsoleToDoProject.Models;

namespace ConsoleToDoProject.Services
{
    public class AddCommandValidator:ICommandValidator
    {
        public bool CanValidate(string command)
        {
            return command == "add";
        }
        public bool Validate(Command command, out string errorMessage)
        {
            errorMessage = string.Empty;

            return true;
        }

    }
}

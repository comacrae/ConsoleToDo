using ConsoleToDoProject.Models;

namespace ConsoleToDoProject.Interfaces
{
    public interface ICommandValidator
    {
        public bool CanValidate(string command);
        public bool Validate(Command command, out string errorMessage);
    }
}

using ConsoleToDoProject.Models;

namespace ConsoleToDoProject.Interfaces
{
    public interface ICommandValidator
    {
        public bool IsValid(Command command, out string errorMessage);
    }
}

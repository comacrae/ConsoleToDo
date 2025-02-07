using ConsoleToDoProject.Interfaces;
using ConsoleToDoProject.Models;

namespace ConsoleToDoProject.Services
{
    public class AddCommandValidator: ICommandValidator
    {
        public bool IsValid(Command cmd, out string errorMessage)
        {
            errorMessage = String.Empty;
            return false; 
        }


    }
}

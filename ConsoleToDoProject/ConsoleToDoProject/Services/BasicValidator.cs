using ConsoleToDoProject.Models;

namespace ConsoleToDoProject.Services
{
    public class BasicValidator
    {

        public bool IsSupportedCommand(string command, Commands cmds, out string errorMessage) { 

            errorMessage = string.Empty;

            if(String.IsNullOrEmpty(command))
            {
                errorMessage = $"Command: {command} cannot be empty or null";
                return false;
            }

            if(cmds.GetCommand(command) == null)
            {
                errorMessage = $"{command} is not a supported command";
                return false;
            }

            return true;
        }
    }
}

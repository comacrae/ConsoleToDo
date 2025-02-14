using ConsoleToDoProject.Models;
using ConsoleToDoProject.Interfaces;

namespace ConsoleToDoProject.Services
{
    public class UpdateCommandExecutor:ICommandExecutor
    {
        public ToDoTaskList Execute(Command cmd, ToDoTaskList tList)
        {

            if (cmd.Name != "update")
                throw new ArgumentException("UpdateCommandExecutor cannot execute command of type: ", cmd.Name);
            if (cmd.Arguments?.Count > 1)
                throw new ArgumentException("Update command can only have a single argument");

            //Validate Priority
            Option descriptionOp = cmd.Options.GetOption("description");
            Option indexOp = cmd.Options.GetOption("index");

            if (cmd.Arguments?.Count == 0)
                throw new ArgumentException("UpdateCommandExecutor recieved empty arguments");
            //make sure only one flag is active
            if (descriptionOp.Value != "" && indexOp.Value != "")
                throw new ArgumentException("Only one update option can be used at once.");
            else if (descriptionOp.Value == "" && indexOp.Value == "")
                throw new ArgumentException("An update option must be designated");

            if (cmd.Arguments is null)
                throw new ArgumentNullException("Update Command Executor received null args");

            string updateStr = cmd.Arguments[0] ?? throw new ArgumentNullException("Update argument string is null");
            if (descriptionOp.Value != "")
            {
                tList.UpdateTaskByDescription(descriptionOp.Value ?? throw new ArgumentNullException("Update description option value is null"), updateStr);
            }
            else if (indexOp.Value != "")
            {
                if (int.TryParse(indexOp.Value, out int result))
                {
                    tList.UpdateTaskByIndex(result, updateStr);
                }
                else
                {
                    throw new ArgumentException($"Invalid index value {indexOp.Value}");
                }
            }
            else
            {
                throw new ArgumentException("No option values were instantiated for updateCommand");
            }

            return tList;
        }

    }
}

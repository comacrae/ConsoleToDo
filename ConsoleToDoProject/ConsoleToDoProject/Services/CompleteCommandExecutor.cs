using ConsoleToDoProject.Models;
using ConsoleToDoProject.Interfaces;

namespace ConsoleToDoProject.Services
{
    public class CompleteCommandExecutor:ICommandExecutor
    {
        public ToDoTaskList Execute(Command cmd, ToDoTaskList tList)
        {

            if (cmd.Name != "complete")
                throw new ArgumentException("CompleteCommandExecutor cannot execute command of type: ", cmd.Name);

            //Validate
            Option descriptionOp = cmd.Options.GetOption("description");
            Option indexOp = cmd.Options.GetOption("index");

            //make sure only one flag is active
            if (descriptionOp.Value != "" && indexOp.Value != "")
                throw new ArgumentException("Only one completion option can be used at once.");
            else if (descriptionOp.Value == "" && indexOp.Value == "")
                throw new ArgumentException("A completion option must be designated");

            if (cmd.Arguments is not null)
                throw new ArgumentNullException("Update Command Executor received args");

            if (descriptionOp.Value != "")
            {
                tList.MarkCompleteByDescription(descriptionOp.Value ?? throw new ArgumentNullException("Complete Task description option value is null"));
            }
            else if (indexOp.Value != "")
            {
                if (int.TryParse(indexOp.Value, out int result))
                {
                    tList.MarkCompleteByIndex(result);
                }
                else
                {
                    throw new ArgumentException($"Invalid index value {indexOp.Value}");
                }
            }
            else
            {
                throw new ArgumentException("No option values were instantiated for completeCommand");
            }

            return tList;
        }

    }
}

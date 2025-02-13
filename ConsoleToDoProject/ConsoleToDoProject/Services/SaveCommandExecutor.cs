using ConsoleToDoProject.Models;
using ConsoleToDoProject.Interfaces;
using System.IO;

namespace ConsoleToDoProject.Services
{
    public class SaveCommandExecutor:ICommandExecutor
    {
        public void Execute(Command cmd, ToDoTaskList tList, TaskListFileHandler fileHandler)
        {

            if (cmd.Name != "save")
                throw new ArgumentException("SaveCommandExecutor cannot execute command of type: ", cmd.Name);
            if (cmd.Arguments?.Count > 0)
                throw new ArgumentException("Save command cannot recieve arguments");

            //Validate Priority
            Option pathOp = cmd.Options.GetOption("path");
            Option overwriteOp = cmd.Options.GetOption("overwrite");
            string? savePath = null;
            bool overwrite = overwriteOp.FlagActive;

            //make sure only one flag is active
            if (pathOp.Value != "")
                savePath = pathOp.Value;

            fileHandler.WriteFile(tList, filePath:savePath, overwrite: overwrite);

        }

    }
}

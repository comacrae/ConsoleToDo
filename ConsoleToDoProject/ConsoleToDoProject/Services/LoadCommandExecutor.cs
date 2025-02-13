using ConsoleToDoProject.Models;
using System.IO;

namespace ConsoleToDoProject.Services
{
    public class LoadCommandExecutor
    {
        public ToDoTaskList Execute(Command cmd, TaskListFileHandler fileHandler)
        {

            if (cmd.Name != "load")
                throw new ArgumentException("LoadCommandExecutor cannot execute command of type: ", cmd.Name);
            if (cmd.Arguments?.Count > 0)
                throw new ArgumentException("Load command cannot recieve arguments");

            //Validate Priority
            Option pathOp = cmd.Options.GetOption("path");
            string loadPath = "";

            //make sure only one flag is active
            if (pathOp.Value != "")
                loadPath = pathOp.Value?? throw new ArgumentNullException("Load path is null");

            ToDoTaskList tList = fileHandler.LoadFile(loadPath);
            return tList;


        }

    }
}

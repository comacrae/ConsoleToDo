using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDoProject.Models
{
    public class RemoveCommandExecutor
    {
        public ToDoTaskList Execute(Command cmd, ToDoTaskList tList) {
            
            if(cmd.Name != "remove")
                throw new ArgumentException("RemoveCommandExecutor cannot execute command of type: ", cmd.Name);
            if (cmd.Arguments?.Count == 0) 
                throw new ArgumentException("RemoveCommandExecutor recieved empty arguments");

            //Validate Priority
            Option priorityOp = cmd.Options.GetOption("priority");
            Option descriptionOp = cmd.Options.GetOption("description");
            Option completedOp = cmd.Options.GetOption("completed");
            Option removeAll = cmd.Options.GetOption("all");

            //make sure only one flag is active
            int activeFlags = 0;
            if(removeAll.FlagActive)
                activeFlags++;
            if(completedOp.FlagActive)
                activeFlags++;
            if (priorityOp.Value != String.Empty)
                activeFlags++;
            if (descriptionOp.Value != String.Empty)
                activeFlags++;
            if (activeFlags > 1)
                throw new ArgumentException("Only one remove option can be used at once.");
            else if(activeFlags == 0)
                throw new ArgumentException("A removal option must be designated");

            if (removeAll.FlagActive)
            {
                tList.DeleteAllTasks();
            }
            else if (completedOp.FlagActive)
            {
                tList.DeleteAllCompletedTasks();
            }
            else if (priorityOp.Value != String.Empty)
            {
                int val = int.Parse(priorityOp.Value ?? throw new ArgumentNullException("Priority Value is null"));
                if (val < 1 || val > 3)
                    throw new ArgumentException($"Priority Value is out of bounds: {priorityOp.Value}");
                ToDoTask.PriorityLevel priority = (ToDoTask.PriorityLevel) val;
                tList.DeleteTaskByPriority(priority);
            }else if(descriptionOp.Value != String.Empty)
            {
                tList.DeleteTaskByDescription(descriptionOp.Value ?? throw new ArgumentNullException("Remove Option description value is null"));
            }
            return tList;

        }
    }
}

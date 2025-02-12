using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleToDoProject.Models;

namespace ConsoleToDoProject.Services
{
    public class RemoveCommandExecutor
    {
        public ToDoTaskList Execute(Command cmd, ToDoTaskList tList)
        {

            if (cmd.Name != "remove")
                throw new ArgumentException("RemoveCommandExecutor cannot execute command of type: ", cmd.Name);
            if (cmd.Arguments?.Count == 0)
                throw new ArgumentException("RemoveCommandExecutor recieved empty arguments");

            //Validate Priority
            Option priorityOp = cmd.Options.GetOption("priority");
            Option descriptionOp = cmd.Options.GetOption("description");
            Option completedOp = cmd.Options.GetOption("completed");
            Option removeAll = cmd.Options.GetOption("all");
            Option indexOp = cmd.Options.GetOption("index");

            //make sure only one flag is active
            int activeFlags = 0;
            if (removeAll.FlagActive)
                activeFlags++;
            if (completedOp.FlagActive)
                activeFlags++;
            if (priorityOp.Value != "")
                activeFlags++;
            if (descriptionOp.Value != "")
                activeFlags++;
            if (indexOp.Value != "")
                activeFlags++;
            if (activeFlags > 1)
                throw new ArgumentException("Only one remove option can be used at once.");
            else if (activeFlags == 0)
                throw new ArgumentException("A removal option must be designated");

            if (removeAll.FlagActive)
            {
                tList.DeleteAllTasks();
            }
            else if (completedOp.FlagActive)
            {
                tList.DeleteAllCompletedTasks();
            }
            else if (priorityOp.Value != "")
            {
                if (Enum.IsDefined(typeof(ToDoTask.PriorityLevel), int.Parse(priorityOp.Value)))
                {
                    ToDoTask.PriorityLevel priority = (ToDoTask.PriorityLevel)Enum.Parse(typeof(ToDoTask.PriorityLevel), priorityOp.Value);
                    tList.DeleteTaskByPriority(priority);
                }
                else
                {
                    throw new ArgumentException($"Priority level {priorityOp.Value} not defined");
                }

            }
            else if (descriptionOp.Value != "")
            {
                tList.DeleteTaskByDescription(descriptionOp.Value ?? throw new ArgumentNullException("Remove Option description value is null"));
            }
            else if (indexOp.Value != "")
            {
                if (int.TryParse(indexOp.Value, out int result))
                {
                    tList.DeleteTaskByIndex(result);
                }
                else
                {
                    throw new ArgumentException($"Invalid index value {indexOp.Value}");
                }
            }
            else
            {
                throw new ArgumentException("No option values were instantiated for removeCommand");
            }
            return tList;

        }
    }
}

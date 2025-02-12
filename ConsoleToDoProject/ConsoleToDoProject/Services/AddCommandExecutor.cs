using ConsoleToDoProject.Interfaces;
using ConsoleToDoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDoProject.Services
{
    public class AddCommandExecutor
    {
        public ToDoTaskList Execute(Command cmd, ToDoTaskList tList)
        {

            if (cmd.Name != "add")
                throw new ArgumentException("AddCommandExecutor cannot execute command of type: ", cmd.Name);
            if (cmd.Arguments?.Count == 0)
                throw new ArgumentException("AddCommandExecutor recieved empty arguments");

            //Validate Priority
            Option priorityOp = cmd.Options.GetOption("priority");
            int val = int.Parse(priorityOp.Value ?? throw new ArgumentNullException("Priority Value is null"));
            if (val < 1 || val > 3)
                throw new ArgumentException($"Priority Value is out of bounds: {priorityOp.Value}");
            ToDoTask.PriorityLevel priority = (ToDoTask.PriorityLevel)val;

            //Get task descriptions to add and update ToDoList
            List<string> taskDescriptions = cmd.Arguments ?? throw new ArgumentException("AddCommandExecutor recieved null arguments");
            foreach (string description in taskDescriptions)
            {
                ToDoTask t = new ToDoTask(description, priority);
                tList.AddTask(t);
            }

            return tList;

        }

    }
}

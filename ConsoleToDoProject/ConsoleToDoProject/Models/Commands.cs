using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleToDoProject.Models
{
    public class Commands
    {
        public List<Command> supportedCommands { get; set; } = new List<Command>();

        public Commands() { 
            supportedCommands= new List<Command>();
                }   

        public Commands(List<Command> initCommandsList) { 
            foreach (Command initCmd in initCommandsList)
            {
                if(supportedCommands.Find(cmd => cmd.Name == initCmd.Name) == null) // if the Command isn't already in the list
                {
                    supportedCommands.Add(initCmd);
                }
                else
                {
                    throw new TypeInitializationException("Command", new ArgumentException($"Cannot have duplicate Commands in initCommandsList: {initCmd.Name}"));
                }
            }

        }

        public Command? GetCommand(string name){
            return supportedCommands.Find(cmd => cmd.Name == name);
        }
    }
}

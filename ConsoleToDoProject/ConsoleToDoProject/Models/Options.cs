using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleToDoProject.Models
{
    public class Options
    {
        public List<Option> supportedOptions { get; set; } = new List<Option>();

        public Options(List<Option> initOptionsList) { 
            foreach (Option initCmd in initOptionsList)
            {
                if(supportedOptions.Find(cmd => cmd.Name == initCmd.Name) == null) // if the Option isn't already in the list
                {
                    supportedOptions.Add(initCmd);
                }
                else
                {
                    throw new TypeInitializationException("Option", new ArgumentException($"Cannot have duplicate Options in initOptionsList: {initCmd.Name}"));
                }
            }

        }

        public Option? GetOption(string name){
            return supportedOptions.Find(cmd => cmd.Name == name);
        }
    }
}

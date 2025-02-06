using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleToDoProject.Models
{
    public class Options
    {
        private List<Option> supportedOptions { get; set; } = new List<Option>();

        public Options() { }

        public Options(List<Option> initOptionsList) { 
            foreach (Option initOpt in initOptionsList)
            {
                if(supportedOptions.Find(opt => opt.FullName != initOpt.FullName && opt.AbbreviatedName != initOpt.AbbreviatedName) == null) // if the Option isn't already in the list
                {
                    supportedOptions.Add(initOpt);
                }
                else
                {
                    throw new TypeInitializationException("Option", new ArgumentException($"Cannot have duplicate Options in initOptionsList: {initOpt.FullName}"));
                }
            }

        }

        public Option? GetOptionByFullName(string name){
            return supportedOptions.Find(cmd => cmd.FullName == name);
        }
        public Option? GetOptionByAbbreviatedName(string name){
            return supportedOptions.Find(cmd => cmd.AbbreviatedName == name);
        }

        public List<string> GetSupportedOptionsByFullName()
        {
            List<string> output = new List<string>();
            supportedOptions.ForEach(opt => output.Add($"{opt.FullName}"));
            return output;
        }
        public List<string> GetSupportedOptionsByAbbreviatedName()
        {
            List<string> output = new List<string>();
            supportedOptions.ForEach(opt => output.Add($"{opt.AbbreviatedName}"));
            return output;
        }
    }
}

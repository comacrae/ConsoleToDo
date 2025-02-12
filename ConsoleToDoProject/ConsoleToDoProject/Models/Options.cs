using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleToDoProject.Models
{
    public class Options: IEnumerable<Option>
    {
        private List<Option> supportedOptions { get; set; } = new List<Option>();

        public Options() { }

        public Options(List<Option> initOptionsList)
        {
            foreach (Option initOpt in initOptionsList)
            {
                if (supportedOptions.Find(opt => opt.FullName == initOpt.FullName && opt.AbbreviatedName == initOpt.AbbreviatedName) != null) // if the Option is already in the list
                {
                    throw new TypeInitializationException("Option", new ArgumentException($"Cannot have duplicate Options in initOptionsList: {initOpt.FullName}"));
                }
                else
                {
                    supportedOptions.Add(initOpt);
                }
            }

        }

        public void Add(Option op){
            supportedOptions.Add(op);
        }

        private Option? GetOptionByFullName(string name)
        {
            return supportedOptions.Find(cmd => cmd.FullName == name);
        }
        private Option? GetOptionByAbbreviatedName(string name)
        {
            return supportedOptions.Find(cmd => cmd.AbbreviatedName == name);
        }

        public Option GetOption(string name, bool abbreviated = false)
        {
            Option? opt = null;
            if (abbreviated)
            {
                opt = GetOptionByAbbreviatedName(name);
            }
            else
            {
                opt = GetOptionByFullName(name);
            }

            if (opt == null)
            {
                throw new ArgumentException("Option does not exist: ", name);
            }
            else
            {
                return opt;
            }
        }

        private int GetOptionIndexByAbbreviatedName(string name)
        {
            return supportedOptions.FindIndex(opt => opt.AbbreviatedName == name);
        }
        private int GetOptionIndexByFullName(string name)
        {
            return supportedOptions.FindIndex(opt => opt.FullName == name);
        }

        private int GetOptionIndex(string name, bool abbreviated = false)
        {

            if (abbreviated)
            {
                return GetOptionIndexByAbbreviatedName(name);
            }
            else
            {
                return GetOptionIndexByFullName(name);
            }
        }

        public void UpdateOption(string name, string value, bool abbreviated)
        {
            int index = GetOptionIndex(name, abbreviated);
            if (index == -1)
            {
                throw new Exception($"Option does not exist in supportedOptions: {name}");
            }
            supportedOptions[index].SetValue(value);
            return;
        }

        public void SetFlagOption(string name, bool flagValue, bool abbreviated)
        {
            int index = GetOptionIndex(name, abbreviated);
            if (index == -1)
            {
                throw new Exception($"Option does not exist in supportedOptions: {name}");
            }
            supportedOptions[index].FlagActive = flagValue;
            return;

        }

        public bool OptionExists(string name, bool abbreviated = false)
        {
            return GetOption(name, abbreviated) != null;

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

        public IEnumerator<Option> GetEnumerator()
        {
            return supportedOptions.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)supportedOptions).GetEnumerator();
        }
    }
}

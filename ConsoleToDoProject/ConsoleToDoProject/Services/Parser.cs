using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ConsoleToDoProject.Models;

namespace ConsoleToDoProject.Services
{
    public class Parser
    {
        Commands Commands { get; set; }

        public Parser(Commands initCommandsList) { 
            Commands = initCommandsList;
        }
        public Command Parse(string[] input)
        {
            Command parsedCommand = new Command();
            List<string> optionsEvoked = new List<string>();

            if (input.Length == 0)
                throw new ArgumentException("No commands recieved");

            string commandName = input[0];

            Command cmd = Commands.GetCommand(commandName) ?? throw new Exception("Invalid command");
             
            for(int i = 0; i< input.Length; i++)
            {
                string token = input[i];
                Option? opt = null;
                if (isOption(token))
                {
                    token = Regex.Replace(token, "-", "");
                    if (optionsEvoked.Contains(token))
                    {
                        throw new Exception("Cannot repeat an option");
                    }

                    if(isAbbreviatedOption(token))
                        opt = cmd.Options.GetOptionByAbbreviatedName(token);
                    else
                        opt = cmd.Options.GetOptionByFullName(token);

                    if(opt == null)
                    {
                        throw new Exception("Invalid option");
                    }

                    if(opt.IsFlag)
                        opt.FlagActive = true;
                    else
                    {
                        if(i == input.Length - 1 && opt.IsRequired)
                        {
                            throw new Exception("No value provided for a required option");
                        }
                    }
                     
                }
                else
                {
                    parsedCommand.Arguments.Add(token);
                }
            }
            return parsedCommand;
        }

        private bool isOption(string token)
        {
            return Regex.IsMatch(token, @"^--\w{2,}$|^-\w$");
        }

        private bool isAbbreviatedOption(string option)
        {
            return Regex.IsMatch(option, @"^-\w$");

        }



    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ConsoleToDoProject.Models;

namespace ConsoleToDoProject.Services
{
    public class Parser
    {
        Commands Commands { get; set; } = new Commands();

        public Parser() { 
            Commands = new Commands();
        }
        public Parser(Commands initCommands) { 
            Commands = initCommands;
        }
        public Command Parse(string[] input)
        {
            HashSet<string> optionsEvoked = new HashSet<string>();
            List<string> arguments = new List<string>();

            if (input.Length == 0)
                throw new ArgumentException("No commands recieved");

            string commandName = input[0];

            Command cmd = Commands.GetCommand(commandName) ?? throw new Exception("Invalid command");
             
            for(int i = 1; i< input.Length; i++)
            {
                string token = input[i];

                if (String.IsNullOrEmpty(token))
                {
                    throw new Exception("Empty or null string as token");
                }


                if (isOption(token))
                {

                    bool isAbbreviated = isAbbreviatedOption(token);
                    token = Regex.Replace(token, "-", "").ToLower(); // trim dashes before searching for option


                    if (cmd.Options.OptionExists(token, isAbbreviated))
                    {
                        if (optionsEvoked.Contains(token))
                        {
                            throw new Exception("Cannot repeat an option");
                        }

                        Option opt = cmd.Options.GetOption(token, isAbbreviated);

                        if (opt.IsFlag)
                            opt.FlagActive = true;
                        else
                        {
                            if (i == input.Length - 1 && opt.IsRequired)
                            {
                                throw new Exception("No value provided for a required option");
                            }
                            else
                            {
                                string value = input[i + 1];
                                cmd.Options.UpdateOption(token, value, isAbbreviated);
                                i++;
                            }
                        }
                    }
                     
                }
                else 
                {
                    arguments.Add(token);
                }
            }

            if (!cmd.NoArgs && arguments.Count == 0)
                throw new Exception("No arguments provided");
            else
                cmd.Arguments = arguments;

            return cmd;
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ConsoleToDoProject.Models;

namespace ConsoleToDoProject.Services
{
    public class Parser
    {
        public Command Parse(string[] input)
        {
            Command parsedCommand = new Command();

            if (input.Length == 0)
                throw new ArgumentException("No commands recieved");

            parsedCommand.Name = input[0];
             
            foreach(string token in input)
            {
                if (isFlag(token))
                {
                    
                }
            }
            return parsedCommand;
        }

        private bool isFlag(string token)
        {
            return Regex.IsMatch(token, @"^--\w{2,}$|^-\w$");
        }


    }
}

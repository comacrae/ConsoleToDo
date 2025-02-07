using System;
using ConsoleToDoProject.Models;
using ConsoleToDoProject.Services;
namespace ConsoleToDoProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Option saveFile = new Option(fullName:"save", abbreviatedName:"s", description:"Save file at designated path", isFlag:false, defaultValue:"./");
            Option reminders = new Option(fullName:"reminders", abbreviatedName:"r", description:"Trigger reminders", isFlag:true, defaultValue: "false");
            List<Option> initOptionsList = new List<Option>() { saveFile, reminders };
            Options options = new Options(initOptionsList);
            Command c = new Command(name:"add", options:options);
            List<Command> commandList = new List<Command>() {c};
            Commands commands = new Commands(initCommandsList:commandList);
            Parser p  = new Parser(initCommands:commands);
            Command output = p.Parse(args);
            Console.WriteLine($"Command: {output.Name}");
            Console.WriteLine($"Arguments: {String.Join(",",output.Arguments )}");
            foreach(Option opt in output.Options)
            {
                if(opt.IsFlag)
                    Console.WriteLine($"Option: {opt.FullName} Value:{opt.FlagActive}");
                else
                    Console.WriteLine($"Option: {opt.FullName} Value:{opt.Value}");
            }

        }
    }
}
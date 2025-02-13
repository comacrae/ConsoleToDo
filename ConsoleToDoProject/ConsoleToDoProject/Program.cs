using System;
using ConsoleToDoProject.Models;
using ConsoleToDoProject.Interfaces;
using ConsoleToDoProject.Services;
namespace ConsoleToDoProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Commands commands = new Commands(initCommandsList:new CommandDefinitions().GetCommandList());
            Parser p  = new Parser(initCommands:commands);
            TaskListFileHandler fileHandler = new TaskListFileHandler();
            Tokenizer tokenizer = new Tokenizer();

            SaveCommandExecutor save = new SaveCommandExecutor();
            AddCommandExecutor add = new AddCommandExecutor();
            RemoveCommandExecutor remove = new RemoveCommandExecutor();
            UpdateCommandExecutor update = new UpdateCommandExecutor();
            LoadCommandExecutor load = new LoadCommandExecutor();
            PrintCommandExecutor print = new PrintCommandExecutor();
            HelpCommandExecutor help = new HelpCommandExecutor();

            ToDoTaskList? tList = new ToDoTaskList();
            bool quit = false;

            while (!quit)
            {
                Console.Write(">>");
                string? input = Console.ReadLine();
                try
                {
                    string[] tokens = tokenizer.Tokenize(input ?? throw new ArgumentNullException("Input is null"));
                    Command parsedCmd = p.Parse(tokens);
                    if (parsedCmd.Name == "save")
                    {
                        save.Execute(parsedCmd, tList, fileHandler);
                    }
                    else if (parsedCmd.Name == "load")
                    {
                        tList = load.Execute(parsedCmd, fileHandler);
                    }
                    else if (parsedCmd.Name == "add")
                    {
                        tList = add.Execute(parsedCmd, tList);
                    }
                    else if (parsedCmd.Name == "update")
                    {
                        tList = update.Execute(parsedCmd, tList);
                    }
                    else if (parsedCmd.Name == "remove")
                    {
                        tList = remove.Execute(parsedCmd, tList);
                    }
                    else if(parsedCmd.Name == "print"){
                        print.Execute(tList);
                    }else if(parsedCmd.Name == "help")
                    {
                        help.Execute(commands);
                    }
                    else if (parsedCmd.Name == "quit")
                    {
                        Console.WriteLine("Goodbye");
                        quit = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }

    }
}

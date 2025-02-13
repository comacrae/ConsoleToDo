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

            SaveCommandExecutor save = new SaveCommandExecutor();
            AddCommandExecutor add = new AddCommandExecutor();
            RemoveCommandExecutor remove = new RemoveCommandExecutor();
            UpdateCommandExecutor update = new UpdateCommandExecutor();
            LoadCommandExecutor load = new LoadCommandExecutor();

            ToDoTaskList? tList = new ToDoTaskList();

            try
            {
                Command parsedCmd = p.Parse(args);
                if (parsedCmd.Name == "save")
                {
                    save.Execute(parsedCmd, tList, fileHandler);
                } else if (parsedCmd.Name == "load")
                {
                    tList = load.Execute(parsedCmd, fileHandler);
                } else if (parsedCmd.Name == "add") {
                    tList = add.Execute(parsedCmd, tList);
                }else if (parsedCmd.Name == "update") {
                    tList = update.Execute(parsedCmd, tList);
                }else if(parsedCmd.Name == "remove")
                {
                    tList = remove.Execute(parsedCmd, tList);
                }
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }

        }
    }
}
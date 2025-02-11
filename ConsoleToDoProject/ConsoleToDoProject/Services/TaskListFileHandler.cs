using System;
using System.Text.Json;
using System.IO;
using ConsoleToDoProject.Models;
using System.Runtime.CompilerServices;

namespace ConsoleToDoProject.Services
{
    public class TaskListFileHandler
    {
        private string? Filepath { get; set; } = null;
        private string DefaultFilePath { get; set; }

        public TaskListFileHandler(string defaultFilePath= @"C:\Users\comac\source\repos\comacrae\ConsoleToDo\ConsoleToDoProject\ConsoleToDoProject.Tests\TestFolder\tasks.json")
        {
            if(IsValidPath(defaultFilePath))
                DefaultFilePath = defaultFilePath;

        }

        private bool IsValidPath(string path)
        {
            if(String.IsNullOrEmpty(path))
                throw new ArgumentNullException("Filepath cannot be null or empty");
            return true;
        }

        private ToDoTaskList ReadJson(string fileContents)
        {
               return JsonSerializer.Deserialize<ToDoTaskList>(fileContents)?? throw new ArgumentNullException("File contents are null");
        }
        private string SerializeJson(ToDoTaskList taskList)
        {
            return JsonSerializer.Serialize<ToDoTaskList>(taskList);
        }
        private void WriteContentsToFile(string path,string fileContents)
        {
            File.WriteAllText(path, fileContents);
        }

        public string GetCurrentFilePath()
        {
            if(Filepath == null)
            {
                throw new FileLoadException("No file has been loaded or no default file has been designated in your .tasklic config file");
            }
            return Filepath;
        }

        public ToDoTaskList LoadFile(string filePath)
        {
            ToDoTaskList returnList = new ToDoTaskList();
            if (IsValidPath(filePath))
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"File does not exist with path {filePath}");
                }
                try
                {
                    string fileContents = File.ReadAllText(filePath);
                    returnList = ReadJson(fileContents);
                    Filepath = filePath;
                }catch (Exception ex)
                {

                    throw new FileLoadException($"Unable to load file at path: {filePath}", ex);
                }
            }
            return returnList;
        }

        public void WriteFile(ToDoTaskList writeList, string? filePath=null, bool overwrite=false)
        {
            if (filePath == null)
                filePath = DefaultFilePath;

            if (IsValidPath(filePath)) {
                if(!overwrite && File.Exists(filePath))
                {
                    throw new ArgumentException($"A file already exists at path {filePath}");
                }

                string? serializedList = null;
                try
                {
                    serializedList = SerializeJson(writeList);
                }catch (Exception ex)
                {
                    throw new Exception($"Error serializing task list: ",ex);
                }

                try
                {
                   WriteContentsToFile(filePath, serializedList);
                }catch (Exception ex)
                {
                    throw new Exception($"Error writing tasklist to path {filePath}: ",ex);
                }
            }

        }
    }
}

using ConsoleToDoProject.Models;
using ConsoleToDoProject.Services;
using System.IO;
public class SaveCommandExecutorTests
{
    private CommandDefinitions _commandDefinitions = new CommandDefinitions();
    private string existingFilePath = "C:\\Users\\comac\\source\\repos\\comacrae\\ConsoleToDo\\ConsoleToDoProject\\ConsoleToDoProject.Tests\\TestFolder\\existingFile.json";
    private string newFilePath = "C:\\Users\\comac\\source\\repos\\comacrae\\ConsoleToDo\\ConsoleToDoProject\\ConsoleToDoProject.Tests\\TestFolder\\newTestFile.json";
    private ToDoTaskList GetPopulatedList()
    {
        ToDoTaskList taskList = new ToDoTaskList();
        taskList.AddTask(new ToDoTask("task 1", ToDoTask.PriorityLevel.Low));
        taskList.AddTask(new ToDoTask("task 2", ToDoTask.PriorityLevel.Medium));
        taskList.AddTask(new ToDoTask("task 3", ToDoTask.PriorityLevel.Medium));
        taskList.MarkCompleteByDescription("task 3");
        return taskList;
    }

    [Fact]
    public void Execute_EmptyList_ThrowsError()
    {
        Command cmd = _commandDefinitions.SaveCommand();
        TaskListFileHandler fileHandler = new TaskListFileHandler();
        ToDoTaskList tList = new ToDoTaskList();
        SaveCommandExecutor executor = new SaveCommandExecutor();
        Exception e = Assert.Throws<ArgumentException>(() => executor.Execute(cmd, tList, fileHandler));
        Assert.Contains("Cannot save empty task list", e.Message);
    }

    [Fact]
    public void Execute_ExistingFileWithoutOverwrite_ThrowsError()
    {
        Command cmd = _commandDefinitions.SaveCommand();
        cmd.Options.UpdateOption("path", existingFilePath, false);
        TaskListFileHandler fileHandler = new TaskListFileHandler();
        ToDoTaskList tList = GetPopulatedList();
        SaveCommandExecutor executor = new SaveCommandExecutor();
        Exception e = Assert.Throws<ArgumentException>(() => executor.Execute(cmd, tList, fileHandler));
        Assert.Contains("A file already exists at", e.Message);
    }

    [Fact]
    public void Execute_ExistingFileWithOverwrite_Success()
    {
        Command cmd = _commandDefinitions.SaveCommand();
        cmd.Options.UpdateOption("path", existingFilePath, false);
        cmd.Options.SetFlagOption("o", true, true);
        TaskListFileHandler fileHandler = new TaskListFileHandler();
        ToDoTaskList tList = GetPopulatedList();
        SaveCommandExecutor executor = new SaveCommandExecutor();
        executor.Execute(cmd, tList, fileHandler);
        ToDoTaskList newList = fileHandler.LoadFile(existingFilePath);
        Assert.True(newList.Tasks.Count == 3);
        Assert.NotNull(newList.Tasks.Find(t=>t.Description == "task 1"));
        Assert.NotNull(newList.Tasks.Find(t=>t.Description == "task 2"));
        Assert.NotNull(newList.Tasks.Find(t=>t.Description == "task 3"));
    }

    [Fact]
    public void Execute_NewFileWithOverwrite_Success()
    {
        if(File.Exists(newFilePath)) 
            File.Delete(newFilePath);
        Command cmd = _commandDefinitions.SaveCommand();
        cmd.Options.UpdateOption("path", newFilePath, false);
        cmd.Options.SetFlagOption("o", true, true);
        TaskListFileHandler fileHandler = new TaskListFileHandler();
        ToDoTaskList tList = GetPopulatedList();
        SaveCommandExecutor executor = new SaveCommandExecutor();
        executor.Execute(cmd, tList, fileHandler);
        ToDoTaskList newList = fileHandler.LoadFile(newFilePath);
        Assert.True(newList.Tasks.Count == 3);
        Assert.NotNull(newList.Tasks.Find(t=>t.Description == "task 1"));
        Assert.NotNull(newList.Tasks.Find(t=>t.Description == "task 2"));
        Assert.NotNull(newList.Tasks.Find(t=>t.Description == "task 3"));
    }

    [Fact]
    public void Execute_NewFileWithoutOverwrite_Success()
    {
        if(File.Exists(newFilePath)) 
            File.Delete(newFilePath);
        Command cmd = _commandDefinitions.SaveCommand();
        cmd.Options.UpdateOption("path", newFilePath, false);
        TaskListFileHandler fileHandler = new TaskListFileHandler();
        ToDoTaskList tList = GetPopulatedList();
        SaveCommandExecutor executor = new SaveCommandExecutor();
        executor.Execute(cmd, tList, fileHandler);
        ToDoTaskList newList = fileHandler.LoadFile(newFilePath);
        Assert.True(newList.Tasks.Count == 3);
        Assert.NotNull(newList.Tasks.Find(t=>t.Description == "task 1"));
        Assert.NotNull(newList.Tasks.Find(t=>t.Description == "task 2"));
        Assert.NotNull(newList.Tasks.Find(t=>t.Description == "task 3"));
    }

}

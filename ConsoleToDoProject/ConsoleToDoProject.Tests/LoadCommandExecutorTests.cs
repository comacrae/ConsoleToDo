using ConsoleToDoProject.Models;
using ConsoleToDoProject.Services;
using System.IO;
public class LoadCommandExecutorTests
{
    private CommandDefinitions _commandDefinitions = new CommandDefinitions();
    private string existingFilePath = "C:\\Users\\comac\\source\\repos\\comacrae\\ConsoleToDo\\ConsoleToDoProject\\ConsoleToDoProject.Tests\\TestFolder\\existingFile.json";
    private string nonExistentFilePath = "C:\\Users\\comac\\source\\repos\\comacrae\\ConsoleToDo\\ConsoleToDoProject\\ConsoleToDoProject.Tests\\TestFolder\\IDontExist.json";
    private string brokenFilePath = "C:\\Users\\comac\\source\\repos\\comacrae\\ConsoleToDo\\ConsoleToDoProject\\ConsoleToDoProject.Tests\\TestFolder\\brokenfile.json";

    [Fact]
    public void Execute_NonexistentList_ThrowsError()
    {
        Command cmd = _commandDefinitions.LoadCommand();
        cmd.Options.UpdateOption("p", nonExistentFilePath, true);
        TaskListFileHandler fileHandler = new TaskListFileHandler();
        LoadCommandExecutor executor = new LoadCommandExecutor();
        Exception e = Assert.Throws<FileNotFoundException>(() => executor.Execute(cmd, fileHandler));
        Assert.Contains("File does not exist", e.Message);
    }

    [Fact]
    public void Execute_BrokenFilePath_ThrowsError()
    {
        Command cmd = _commandDefinitions.LoadCommand();
        cmd.Options.UpdateOption("p", brokenFilePath, true);
        TaskListFileHandler fileHandler = new TaskListFileHandler();
        LoadCommandExecutor executor = new LoadCommandExecutor();
        Exception e = Assert.Throws<FileLoadException>(() => executor.Execute(cmd, fileHandler));
        Assert.Contains("Unable to load file at path", e.Message);
    }

    [Fact]
    public void Execute_ExistingFilePath_ThrowsError()
    {
        Command cmd = _commandDefinitions.LoadCommand();
        cmd.Options.UpdateOption("p", existingFilePath, true);
        TaskListFileHandler fileHandler = new TaskListFileHandler();
        LoadCommandExecutor executor = new LoadCommandExecutor();
        ToDoTaskList tList = executor.Execute(cmd, fileHandler);
        Assert.NotNull(tList);
    }


}

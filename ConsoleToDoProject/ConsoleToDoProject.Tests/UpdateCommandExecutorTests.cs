using ConsoleToDoProject.Models;
using ConsoleToDoProject.Services;
public class UpdateCommandExecutorTests
{
    private CommandDefinitions _commandDefinitions = new CommandDefinitions();
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
    public void Execute_NonexistentTask_ThrowsError()
    {
        Command cmd = _commandDefinitions.UpdateCommand();
        cmd.Arguments = ["task update"];
        UpdateCommandExecutor executor = new UpdateCommandExecutor();
        cmd.Options.UpdateOption("d", "task 1", true);
        ToDoTaskList taskList = new ToDoTaskList();
        Exception m = Assert.Throws<InvalidOperationException>(() => executor.Execute(cmd, taskList));
        Assert.Contains("Tasks list is empty", m.Message);
    }

    [Fact]
    public void Execute_MultipleOptions_ThrowsError()
    {
        Command cmd = _commandDefinitions.UpdateCommand();
        cmd.Arguments = ["task update"];
        UpdateCommandExecutor executor = new UpdateCommandExecutor();
        cmd.Options.UpdateOption("d", "task 1", true);
        cmd.Options.UpdateOption("i", "1", true);
        ToDoTaskList taskList = new ToDoTaskList();
        Exception m = Assert.Throws<ArgumentException>(() => executor.Execute(cmd, taskList));
        Assert.Contains("Only one remove option", m.Message);
    }

    [Fact]
    public void Execute_IndexOptionOOB_ThrowsError()
    {
        Command cmd = _commandDefinitions.UpdateCommand();
        cmd.Arguments = ["task update"];
        UpdateCommandExecutor executor = new UpdateCommandExecutor();
        cmd.Options.UpdateOption("i", "4", true);
        ToDoTaskList taskList = GetPopulatedList();
        Exception m = Assert.Throws<IndexOutOfRangeException>(() => executor.Execute(cmd, taskList));
        Assert.Contains("Index", m.Message);
    }

    [Fact]
    public void Execute_IndexOption_UpdatesAppropriateIndex()
    {
        Command cmd = _commandDefinitions.UpdateCommand();
        cmd.Arguments = ["task update"];
        UpdateCommandExecutor executor = new UpdateCommandExecutor();
        cmd.Options.UpdateOption("i", "0", true);
        ToDoTaskList taskList = GetPopulatedList();
        taskList = executor.Execute(cmd, taskList);
        Assert.True(taskList.GetTaskByIndex(0).Description == "task update");
    }

    [Fact]
    public void Execute_DescriptionOption_UpdatesAppropriateTask()
    {
        Command cmd = _commandDefinitions.UpdateCommand();
        cmd.Arguments = ["task update"];
        UpdateCommandExecutor executor = new UpdateCommandExecutor();
        cmd.Options.UpdateOption("d", "task 2", true);
        ToDoTaskList taskList = GetPopulatedList();
        taskList = executor.Execute(cmd, taskList);
        Assert.True(taskList.GetTaskByIndex(1).Description == "task update");
    }

    [Fact]
    public void Execute_DescriptionOptionDuplicate_ThrowsError()
    {
        Command cmd = _commandDefinitions.UpdateCommand();
        cmd.Arguments = ["task 1"];
        UpdateCommandExecutor executor = new UpdateCommandExecutor();
        cmd.Options.UpdateOption("d", "task 2", true);
        ToDoTaskList taskList = GetPopulatedList();
        Exception m = Assert.Throws<ArgumentException>(() => executor.Execute(cmd, taskList));
        Assert.Contains("duplicate", m.Message);

    }

    [Fact]
    public void Execute_IndexOptionDuplicate_ThrowsError()
    {
        Command cmd = _commandDefinitions.UpdateCommand();
        cmd.Arguments = ["task 1"];
        UpdateCommandExecutor executor = new UpdateCommandExecutor();
        cmd.Options.UpdateOption("i", "2", true);
        ToDoTaskList taskList = GetPopulatedList();
        Exception m = Assert.Throws<ArgumentException>(() => executor.Execute(cmd, taskList));
        Assert.Contains("duplicate", m.Message);

    }
}

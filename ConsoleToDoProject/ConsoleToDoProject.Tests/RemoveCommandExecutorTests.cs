using ConsoleToDoProject.Models; 
namespace ConsoleToDoProject.Tests
{
    public class RemoveCommandExecutorTests
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
        public void Execute_EmptyList_ThrowsError()
        {
            Command cmd = _commandDefinitions.RemoveCommand();
            RemoveCommandExecutor executor = new RemoveCommandExecutor();
            cmd.Options.UpdateOption("priority", "1", false);
            ToDoTaskList taskList = new ToDoTaskList(); 
            Exception m = Assert.Throws<InvalidOperationException>(()=>executor.Execute(cmd,taskList));
            Assert.Contains("empty", m.Message);
        }

        [Fact]
        public void Execute_NoMatchingPriority_ThrowsError()
        {
            Command cmd = _commandDefinitions.RemoveCommand();
            cmd.Options.UpdateOption("priority", "1", false);
            RemoveCommandExecutor executor = new RemoveCommandExecutor();
            ToDoTaskList taskList = GetPopulatedList();
            Exception m = Assert.Throws<InvalidOperationException>(()=>executor.Execute(cmd,taskList));
            Assert.Contains("Tasks list has no task with priority", m.Message);
        }
    }
}

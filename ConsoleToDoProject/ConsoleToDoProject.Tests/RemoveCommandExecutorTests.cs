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
            Assert.Contains("Tasks list has no tasks with priority", m.Message);
        }
        [Fact]
        public void Execute_RemoveAllOption_ClearsList()
        {
            Command cmd = _commandDefinitions.RemoveCommand();
            cmd.Options.SetFlagOption("a",true,true);
            RemoveCommandExecutor executor = new RemoveCommandExecutor();
            ToDoTaskList taskList = GetPopulatedList();
            taskList = executor.Execute(cmd,taskList);
            Assert.True(taskList.Tasks.Count == 0);

        }

        [Fact]
        public void Execute_RemovePriorityOption_ClearsPriority()
        {
            Command cmd = _commandDefinitions.RemoveCommand();
            cmd.Options.UpdateOption("p","2",true);
            RemoveCommandExecutor executor = new RemoveCommandExecutor();
            ToDoTaskList taskList = GetPopulatedList();
            taskList = executor.Execute(cmd,taskList);
            Assert.Null(taskList.Tasks.Find(t => t.Description == "task 2"));
            Assert.Null(taskList.Tasks.Find(t => t.Description == "task 3"));
            Assert.True(taskList.Tasks.Count == 1);
        }

        [Fact]
        public void Execute_RemoveDescriptionOption_ClearsAppropriateTask()
        {
            Command cmd = _commandDefinitions.RemoveCommand();
            cmd.Options.UpdateOption("d","task 2",true);
            RemoveCommandExecutor executor = new RemoveCommandExecutor();
            ToDoTaskList taskList = GetPopulatedList();
            taskList = executor.Execute(cmd,taskList);
            Assert.Null(taskList.Tasks.Find(t => t.Description == "task 2"));
            Assert.True(taskList.Tasks.Count == 2);
        }

        [Fact]
        public void Execute_RemoveCompletedOption_ClearsAppropriateTask()
        {
            Command cmd = _commandDefinitions.RemoveCommand();
            cmd.Options.SetFlagOption("c",true,true);
            RemoveCommandExecutor executor = new RemoveCommandExecutor();
            ToDoTaskList taskList = GetPopulatedList();
            taskList = executor.Execute(cmd,taskList);
            Assert.Null(taskList.Tasks.Find(t => t.Description == "task 3"));
            Assert.True(taskList.Tasks.Count == 2);
        }

        [Fact]
        public void Execute_RemoveMultipleOptions_ThrowsError()
        {
            Command cmd = _commandDefinitions.RemoveCommand();
            cmd.Options.SetFlagOption("c",true,true);
            cmd.Options.SetFlagOption("a",true,true);
            RemoveCommandExecutor executor = new RemoveCommandExecutor();
            ToDoTaskList taskList = GetPopulatedList();
            Exception e = Assert.Throws<ArgumentException>(()=> executor.Execute(cmd,taskList));
            Assert.Contains("Only one remove option",e.Message);
        }

        [Fact]
        public void Execute_ValidRemoveIndexOption_ClearsAppropriateTask()
        {
            Command cmd = _commandDefinitions.RemoveCommand();
            cmd.Options.UpdateOption("i","0",true);
            RemoveCommandExecutor executor = new RemoveCommandExecutor();
            ToDoTaskList taskList = GetPopulatedList();
            taskList = executor.Execute(cmd,taskList);
            Assert.Null(taskList.Tasks.Find(t => t.Description == "task 1"));
            Assert.True(taskList.Tasks.Count == 2);
        }

        [Fact]
        public void Execute_InvalidIndexOption_ThrowsError()
        {
            Command cmd = _commandDefinitions.RemoveCommand();
            cmd.Options.UpdateOption("i","x",true); // -i abbreviated index option
            RemoveCommandExecutor executor = new RemoveCommandExecutor();
            ToDoTaskList taskList = GetPopulatedList();
            Exception e = Assert.Throws<ArgumentException>(()=> executor.Execute(cmd,taskList));
            Assert.Contains("Invalid index value",e.Message);
        }

        [Fact]
        public void Execute_OOBIndexOption_ThrowsError()
        {
            Command cmd = _commandDefinitions.RemoveCommand();
            cmd.Options.UpdateOption("i","4",true); // -i index flag
            RemoveCommandExecutor executor = new RemoveCommandExecutor();
            ToDoTaskList taskList = GetPopulatedList();
            Exception e = Assert.Throws<IndexOutOfRangeException>(()=> executor.Execute(cmd,taskList));
            Assert.Contains("Index is out of bounds",e.Message);
        }

    }
}

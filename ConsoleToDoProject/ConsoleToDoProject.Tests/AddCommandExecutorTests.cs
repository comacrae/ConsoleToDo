using ConsoleToDoProject.Services;
using ConsoleToDoProject.Models;
using System.Reflection.Metadata.Ecma335;
namespace ConsoleToDoProject.Tests
{
    public class AddCommandExecutorTests
    {

        CommandDefinitions defs = new CommandDefinitions();

        private Command PopulateValidAddCommand()
        {
            Command addCmd = defs.AddCommand();
            addCmd.Arguments = ["task number one", "task number two"];
            return addCmd;
        }

        [Fact]
        public void Execute_EmptyArgs_ThrowsError()
        {
            Command addCmd = defs.AddCommand();
            ToDoTaskList taskList = new ToDoTaskList();
            AddCommandExecutor executor = new AddCommandExecutor();
            Assert.Throws<ArgumentException>(() => executor.Execute(addCmd,taskList));
        }

        [Fact]
        public void Execute_ValidArgs_RunsSuccessfully()
        {
            Command addCmd = defs.AddCommand();
            addCmd.Arguments = ["task number one", "task number two"];
            ToDoTaskList taskList = new ToDoTaskList();
            AddCommandExecutor executor = new AddCommandExecutor();
            taskList =  executor.Execute(addCmd,taskList);
            Assert.NotNull(taskList.GetUncompletedTasks().Find(t => t.Description == "task number one"));
            Assert.NotNull(taskList.GetUncompletedTasks().Find(t => t.Description == "task number two"));
        }

        [Fact]
        public void Execute_DuplicateArgs_ThrowsError()
        {
            Command addCmd = defs.AddCommand();
            addCmd.Arguments = ["task number one", "task number one"];
            ToDoTaskList taskList = new ToDoTaskList();
            AddCommandExecutor executor = new AddCommandExecutor();
            Exception m = Assert.Throws<ArgumentException>(()=>executor.Execute(addCmd,taskList));
            Assert.Contains("Cannot add duplicate task", m.Message);
        }

        [Fact]
        public void Execute_PreexsistingArgs_ThrowsError()
        {
            Command addCmd = defs.AddCommand();
            addCmd.Arguments = ["task number one"];
            ToDoTaskList taskList = new ToDoTaskList();
            AddCommandExecutor executor = new AddCommandExecutor();
            taskList = executor.Execute(addCmd,taskList);
            Assert.True(taskList.GetUncompletedTasks().Find(t => t.Description == "task number one")!= null);
            Exception m = Assert.Throws<ArgumentException>(()=>executor.Execute(addCmd,taskList));
            Assert.Contains("Cannot add duplicate task", m.Message);
        }

        [Fact]
        public void Execute_PriorityOOB_ThrowsError()
        {
            Command addCmd = defs.AddCommand();
            addCmd.Options.UpdateOption("priority", "0", false);
            addCmd.Arguments = ["task number one", "task number two"];
            ToDoTaskList taskList = new ToDoTaskList();
            AddCommandExecutor executor = new AddCommandExecutor();
            Exception m = Assert.Throws<ArgumentException>(()=>executor.Execute(addCmd,taskList));
            Assert.Contains("Priority Value is out of bounds",m.Message);
        }

        [Fact]
        public void Execute_PriorityNonDefault_Success()
        {
            Command addCmd = defs.AddCommand();
            addCmd.Options.UpdateOption("priority", "1", false);
            addCmd.Arguments = ["task number one", "task number two"];
            ToDoTaskList taskList = new ToDoTaskList();
            AddCommandExecutor executor = new AddCommandExecutor();
            taskList = executor.Execute(addCmd, taskList);
            Assert.All(taskList.Tasks, t => { Assert.True(t.Priority == ToDoTask.PriorityLevel.High); });
        }
    }
}

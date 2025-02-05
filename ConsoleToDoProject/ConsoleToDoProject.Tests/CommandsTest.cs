using ConsoleToDoProject.Models;
namespace ConsoleToDoProject.Tests
{
    public class CommandsTest
    {
        [Fact]
        public void GetCommand_NonExistent_ReturnsNull() {
            List<Command> initList = new List<Command>() { new Command() { Name = "test" } };
            Commands cmds = new Commands(initCommandsList:initList);
            Assert.Null(cmds.GetCommand("nonexistent"));
        }

        [Fact] public void GetCommand_Existing_ReturnsCommand()
        {
            List<Command> initList = new List<Command>() { new Command() { Name = "test" } };
            Commands cmds = new Commands(initCommandsList:initList);
            Assert.Equal("test",cmds.GetCommand("test").Name);
        }

        [Fact]
        public void ClassInit_DuplicateCommands_ThrowsException()
        {
            List<Command> initList = new List<Command>() { new Command() { Name = "test" },new Command() { Name = "test" } };
            Assert.Throws<TypeInitializationException>(()=> new Commands(initCommandsList: initList));
        }
    }
}

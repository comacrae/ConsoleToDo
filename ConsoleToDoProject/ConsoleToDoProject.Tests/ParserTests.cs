using ConsoleToDoProject.Services;
using ConsoleToDoProject.Models;
namespace ConsoleToDoProject.Tests
{
    public class ParserTests
    {
        [Fact]
        public void Parse_EmptyCommand_ThrowsError()
        {
            Parser p  = new Parser();
            ArgumentException exception = Assert.Throws<ArgumentException>(() => p.Parse([]));
            Assert.Contains("No commands recieved", exception.Message);
        }
        [Fact]
        public void Parse_EmptyArguments_ThrowsError()
        {
            Parser p  = new Parser();
            ArgumentException exception = Assert.Throws<ArgumentException>(() => p.Parse(["add"]));
            Assert.Contains("No arguments recieved", exception.Message);
        }

        [Fact]
        public void Parse_UnrecognizedCommand_ThrowsError()
        {
            Parser p = new Parser();
            ArgumentException exception = Assert.Throws<ArgumentException>(() => p.Parse(["nonexistentCommand"]));
            Assert.Contains("Command unrecognized", exception.Message);
        }

        [Fact]
        public void Parse_MultipleArgs_Executes()
        {
            Parser p = new Parser();
            Command c = p.Parse(["add", "Item One", "Item Two"]);
            Assert.Equal("add", c.Name);
            Assert.Equal(["Item One", "Item Two"], c.Arguments);
        }

        [Fact]
        public void Parse_FlagSingleArg_Executes()
        {
            Parser p = new Parser();
            Command c = p.Parse(["add", "Item One", "Item Two"]);
            Assert.Equal("add", c.Name);
            Assert.Equal(["Item One", "Item Two"], c.Arguments);
        }
    }
}

using ConsoleToDoProject.Services;
using ConsoleToDoProject.Models;
using System.Security.Cryptography;
namespace ConsoleToDoProject.Tests
{
    public class ParserTests
    {
        [Fact]
        public void Parse_EmptyCommand_ThrowsError()
        {
            Parser p = new Parser();
            ArgumentException exception = Assert.Throws<ArgumentException>(() => p.Parse([]));
            Assert.Contains("No commands recieved", exception.Message);
        }
        [Fact]
        public void Parse_EmptyString_ThrowsError()
        {
            List<Command> commandList = new List<Command>() { new Command(name: "add") };
            Commands commands = new Commands(initCommandsList: commandList);
            Parser p = new Parser(initCommands: commands);
            Exception exception = Assert.Throws<Exception>(() => p.Parse(["add", ""]));
        }

        [Fact]
        public void Parse_UnrecognizedCommand_ThrowsError()
        {
            List<Command> commandList = new List<Command>() { new Command(name: "add") };
            Commands commands = new Commands(initCommandsList: commandList);
            Parser p = new Parser(initCommands: commands);
            var exception = Assert.Throws<Exception>(() => p.Parse(["nonexistentCommand"]));
            Assert.Contains("Invalid command", exception.Message);
        }

        [Fact]
        public void Parse_MultipleArgs_Executes()
        {
            List<Command> commandList = new List<Command>() { new Command(name: "add") };
            Commands commands = new Commands(initCommandsList: commandList);
            Parser p = new Parser(initCommands: commands);
            Command c = p.Parse(["add", "Item One", "Item Two"]);
            Assert.Equal("add", c.Name);
            Assert.Equal(["Item One", "Item Two"], c.Arguments);
        }

        [Fact]
        public void Parse_AbbreviatedFlagSingleArg_Executes()
        {

            Option o = new Option(fullName: "flag", abbreviatedName: "f", description: "test", isFlag: true, defaultValue: "true");
            List<Option> initOptionsList = new List<Option>() { o };
            Options options = new Options(initOptionsList);
            Command c = new Command(name: "add", options: options);
            List<Command> commandList = new List<Command>() { c }; Commands commands = new Commands(initCommandsList: commandList);
            Parser p = new Parser(initCommands: commands);
            Command output = p.Parse(["add", "Item One", "-f"]);
            Assert.Equal("add", c.Name);
            Assert.Equal(["Item One"], c.Arguments);
            Assert.True(c.Options.GetOption("flag").FlagActive);
        }

        [Fact]
        public void Parse_NoArgCommandGivenArgs_ThrowsError()
        {
            Option o = new Option(fullName: "flag", abbreviatedName: "f", description: "test", isFlag: true, defaultValue: "true");
            List<Option> initOptionsList = new List<Option>() { o };
            Options options = new Options(initOptionsList);
            Command c = new Command(name: "noArgCmd", options: options, noArgs: true);
            List<Command> commandList = new List<Command>() { c };
            Commands commands = new Commands(initCommandsList: commandList);
            Parser p = new Parser(initCommands: commands);
            Assert.Throws<Exception>(() => p.Parse(["noArgCmd", "Item One"]));

        }

        [Fact]
        public void Parse_FlagOrder_DoesNotAffectOutput()
        {
            Option o = new Option(fullName: "flag", abbreviatedName: "f", description: "test", isFlag: true, defaultValue: "true");
            List<Option> initOptionsList = new List<Option>() { o };
            Options options = new Options(initOptionsList);
            Command c = new Command(name: "add", options: options, noArgs: false);
            List<Command> commandList = new List<Command>() { c };
            Commands commands = new Commands(initCommandsList: commandList);
            Parser p = new Parser(initCommands: commands);
            Command cmd1 = p.Parse(["add", "-f", "Item One", "Item Two"]);
            Command cmd2 = p.Parse(["add", "Item One", "Item Two", "-f"]);
            Assert.Equal(cmd1.Arguments, cmd2.Arguments);
        }
    }
}

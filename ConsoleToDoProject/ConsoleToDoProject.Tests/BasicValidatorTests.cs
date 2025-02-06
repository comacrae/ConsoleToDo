using ConsoleToDoProject.Services;
using ConsoleToDoProject.Models;

namespace ConsoleToDoProject.Tests
{
    public class BasicValidatorTests
    {

        [Theory]
        [InlineData("", false)]
        [InlineData(null, false)]
        [InlineData("dne",false)]
        [InlineData("add", true)]
        public void IsSupportedCommand_Unsupported_ReturnsFalse(string? command, bool expected)
        {
            string errMsg = "";
            List<Command> commandsList= new List<Command>() { new Command(name:"add" )};
            Commands cmds = new Commands(initCommandsList:commandsList) ;
            BasicValidator basicValidator = new BasicValidator();
            Assert.Equal(basicValidator.IsSupportedCommand(command,cmds, out errMsg), expected);
        }
    }
}

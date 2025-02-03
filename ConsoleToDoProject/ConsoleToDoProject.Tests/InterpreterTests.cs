namespace ConsoleToDoProject.Tests;

using ConsoleToDoProject.CLI;
using System;
using System.IO;
using Xunit;

//MethodName_Condition_ExpectedResult
public class InterpreterTests
{
    [Theory]
    [InlineData("Test","Test")]
    [InlineData("abc","abc")]
    [InlineData("______________","______________")]
    public void GetInput_EnteredString_IsReturned(string input, string expected)
    {
        var interpreter = new Interpreter();

        using (StringReader stringReader = new StringReader(input))
        {
            Console.SetIn(stringReader);
            string result = interpreter.GetInput();
            Assert.Equal(input, expected);
        }
    }

    [Theory]
    [InlineData("Test",false)]
    [InlineData(" ", true)]
    [InlineData("abc%", true)]
    public void GetInput_InvalidEntries_ThrowInvalidEntryException(string input, bool output)
    {
        Interpreter interpreter = new Interpreter();


        using (StringReader stringReader = new StringReader(input))
        {
            Console.SetIn(stringReader);
            Assert.ThrowsAny<Exception>(() => interpreter.GetInput());
        }

    }
}
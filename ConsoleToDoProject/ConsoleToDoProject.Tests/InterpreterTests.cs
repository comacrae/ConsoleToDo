namespace ConsoleToDoProject.Tests;

using ConsoleToDoProject.CLI;
using Xunit;

//MethodName_Condition_ExpectedResult
public class InterpreterTests
{
    [Fact]
    public void CheckNullInput_NullInput_ReturnsEmptyString()
    {

        Interpreter interpreter = new Interpreter();

        string returnValue = interpreter.CheckNullInput(null);
    }
}
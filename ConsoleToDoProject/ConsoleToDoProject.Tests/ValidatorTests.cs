namespace ConsoleToDoProject.Tests;

using Xunit;
using ConsoleToDoProject.CLI;

//MethodName_Condition_ExpectedResult
public class ValidatorTests
{
    [Fact]
    public void IsNullString_NullStringEntered_ReturnsTrue()
    {
        Validator validator = new Validator();
        bool output = validator.IsNullString(null);
        Assert.True(output);
    }

    [Fact] 
    public void IsNullString_NonNullStringEntered_ReturnsFalse()
    {
        Validator validator = new Validator();
        bool output = validator.IsNullString("test");
        Assert.False(output);
    }

    [Fact] public void IsNullString_EmptyStringEntered_ReturnsTrue()
    {
        Validator validator= new Validator();
        bool output = validator.IsNullString("");
        Assert.False(output);
    }
}

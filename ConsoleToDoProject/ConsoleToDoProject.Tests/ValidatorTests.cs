namespace ConsoleToDoProject.Tests;

using Xunit;
using ConsoleToDoProject.CLI;
using System.Text.RegularExpressions;

//MethodName_Condition_ExpectedResult
public class ValidatorTests
{
    [Theory]
    [InlineData(" ")]
    [InlineData("")]
    [InlineData("test")]
    public void IsValidInput_NonNullStringEntered_DoesNotThrowException(string? input)
    {
        Validator validator = new Validator();
        validator.IsValidInput(input);
        Assert.True(true);
    }

    [Fact]
    public void IsValidInput_NullStringEntered_ThrowsNulLArgumentException()
    {
        Validator validator = new Validator();
        Assert.Throws<ArgumentNullException>(() => validator.IsValidInput(null));
    }

    [Theory]
    [InlineData("ab*(", false)]
    [InlineData("ab c", false)]
    [InlineData(" ", false)]
    [InlineData("abc",true)]
    public void IsValidInput_StringWithInvalidChars_ReturnsTrue(string input, bool expected)
    {
        Validator validator = new Validator();
        bool result = validator.IsValidInput(input);
        Assert.Equal(result,expected);
    }

}

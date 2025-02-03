namespace ConsoleToDoProject.Tests;

using Xunit;
using ConsoleToDoProject.CLI;
using System.Text.RegularExpressions;

//MethodName_Condition_ExpectedResult
public class ValidatorTests
{
    [Fact]
    public void IsNullString_NullStringEntered_ReturnsTrue()
    {
        Validator validator = new Validator();
        string? input = null;
        bool output = validator.IsNullString(input);
        Assert.True(output);
    }

    [Fact] 
    public void IsNullString_NonNullStringEntered_ReturnsFalse()
    {
        Validator validator = new Validator();
        bool output = validator.IsNullString("test");
        Assert.False(output);
    }

    [Theory]
    [InlineData("ab*(", true)]
    [InlineData("ab c", true)]
    [InlineData(" ",true)]
    [InlineData("abc",false)]
    public void ContainsInvalidChars_StringWithInvalidChars_ReturnsTrue(string input, bool expected)
    {
        Validator validator = new Validator();
        bool result = validator.ContainsInvalidChars(input);
        Assert.Equal(result,expected);
    }

    [Fact]
    public void ContainsInvalidChars_NullEntered_ThrowsNullArgumentException()
    {
        Validator validator = new Validator();
        Assert.Throws<ArgumentNullException>(() => validator.ContainsInvalidChars(null));
    }
}

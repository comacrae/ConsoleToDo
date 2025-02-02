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
        string input = null;
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

    [Fact] public void IsNullString_EmptyStringEntered_ReturnsTrue()
    {
        Validator validator= new Validator();
        bool output = validator.IsNullString("");
        Assert.False(output);
    }

    [Fact]
    public void ContainsWhitespace_NullStringEntered_ThrowsNullArgumentException()
    {
        Validator validator = new Validator();
        Assert.Throws<ArgumentNullException>(() => validator.ContainsWhitespace(null));
    }

    [Fact]
    public void ContainsWhitespace_EmptyStringEntered_ReturnsFalse()
    {
        Validator validator = new Validator();
        bool result = validator.ContainsWhitespace("");
        Assert.False(result);
    }

    [Fact]
    public void ContainsWhitespace_NoWhitespaceStringEntered_ReturnsFalse()
    {
        Validator validator = new Validator();
        bool result = validator.ContainsWhitespace("thisisatest");
        Assert.False(result);
    }

    [Fact]
    public void ContainsWhitespace_StringWithWhitespace_ReturnsTrue()
    {
        Validator validator = new Validator();
        bool result = validator.ContainsWhitespace("ab c");
        Assert.True(result);
    }

    [Fact]
    public void ContainsInvalidChars_StringWithInvalidChars_ReturnsTrue()
    {
        Validator validator = new Validator();
        bool result = validator.ContainsInvalidChars("ab*(");
        Assert.True(result);
    }

    [Fact] 
    public void ContainsInvalidChars_StringWithValidChars_ReturnsFalse()
    {
        Validator validator = new Validator();
        bool result = validator.ContainsInvalidChars("Test_");
        Assert.False(result);
    }

    [Fact]
    public void ContainsInvalidChars_NullEntered_ThrowsNullArgumentException()
    {
        Validator validator = new Validator();
        Assert.Throws<ArgumentNullException>(() => validator.ContainsInvalidChars(null));
    }
}

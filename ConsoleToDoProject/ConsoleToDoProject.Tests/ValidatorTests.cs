namespace ConsoleToDoProject.Tests;

using Xunit;
using ConsoleToDoProject.CLI;

//MethodName_Condition_ExpectedResult
public class ValidatorTests
{
    [Fact]
    public void IsValidInput_NonNullStringEntered_DoesNotThrowException()
    {
        Validator validator = new Validator();
        validator.IsValidInput("test");
        Assert.True(true);
    }

    [Fact]
    public void IsValidInput_NullStringEntered_ThrowsNulLArgumentException()
    {
        Validator validator = new Validator();
        Assert.Throws<ArgumentNullException>(() => validator.IsValidInput(null));
    }

    [Theory]
    [InlineData("ab*(")]
    [InlineData("ab c")]
    [InlineData(" ")]
    public void IsValidInput_StringWithInvalidChars_ThrowsArgumentException(string input)
    {
        Validator validator = new Validator();
        Assert.Throws<ArgumentException>(() => validator.IsValidInput(input));
    }

}

namespace ConsoleToDoProject.Tests;

using Xunit;

using ConsoleToDoProject.Services;
//MethodName_Condition_ExpectedResult
public class TokenValidatorTests
{
    [Fact]
    public void IsValidInput_NonNullStringEntered_DoesNotThrowException()
    {
        TokenValidator validator = new TokenValidator();
        validator.IsValidInput("-test");
        Assert.True(true);
    }

    [Fact]
    public void IsValidInput_NullStringEntered_ThrowsNulLArgumentException()
    {
        TokenValidator validator = new TokenValidator();
        Assert.Throws<ArgumentNullException>(() => validator.IsValidInput(null));
    }

    [Theory]
    [InlineData("ab*(")]
    [InlineData("ab c")]
    [InlineData(" ")]
    [InlineData("")]
    public void IsValidInput_StringWithInvalidChars_ThrowsArgumentException(string input)
    {
        TokenValidator validator = new TokenValidator();
        Assert.Throws<ArgumentException>(() => validator.IsValidInput(input));
    }

}

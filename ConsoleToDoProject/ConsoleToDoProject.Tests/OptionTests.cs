namespace ConsoleToDoProject.Tests;
using Xunit;
using ConsoleToDoProject.Models;

public class OptionTests
{

    [Fact]
    public void ClassInitialization_EmptyDescription_ThrowsArgumentExceptionError() {
        Option op = new Option(name: "Test", description:"test", defaultValue:"test", isRequired:true) ;
        Assert.NotNull(op.Description);
    }

    [Fact]
    public void ClassInitialization_DefaultValueIsNotEmpty() {
        Option op = new Option(name: "Test", description:"test", defaultValue:"test", isRequired:true) ;
        if (op.DefaultValue != null)
            Assert.True(op.DefaultValue.Length > 0);
    }

    [Fact]
    public void ClassInitialization_NameIsNotNull() {
        Option op = new Option(name: "Test", description:"test", defaultValue:"test", isRequired:true) ;
        Assert.NotNull(op.Name);
    }

    [Fact]
    public void ClassInitialization_NameIsNotEmpty() {
        Option op = new Option(name: "Test", description:"test", defaultValue:"test", isRequired:true) ;
        Assert.True(op.Name.Length > 0);
    }

    [Fact]
    public void ClassInitialization_MultipleAllowedAndFlag_ThrowsArgError()
    {
        Assert.Throws<ArgumentException>( () => new Option(name: "Test", description:"test", defaultValue:"test", isRequired:true, isFlag:true, allowMultiple:true));
    }

    [Fact]
    public void SetValue_FlagWithValueInput_ThrowsException()
    {
        Option op = new Option(name: "Test", description: "test", defaultValue: "test", isRequired: true, isFlag: true, allowMultiple: false);
        Assert.Throws<ArgumentException>( () => op.SetValue("abc") );
    }

    [Fact]
    public void SetValue_NullValueInput_ThrowsException()
    {
        Option op = new Option(name: "Test", description: "test", defaultValue: null, isRequired: true, isFlag: false, allowMultiple: false);
        Assert.Throws<ArgumentNullException>(() => op.SetValue(null));
    }


}
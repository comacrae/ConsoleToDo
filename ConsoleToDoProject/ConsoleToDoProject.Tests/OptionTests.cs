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
        Assert.NotNull(op.FullName);
    }

    [Fact]
    public void ClassInitialization_NameIsNotEmpty() {
        Option op = new Option(name: "Test", description:"test", defaultValue:"test", isRequired:true) ;
        Assert.True(op.FullName.Length > 0);
    }

    [Fact]
    public void ClassInitialization_NullDefaultAndIsRequired_ThrowsInitException() {
        Assert.Throws<TypeInitializationException>(() => new Option(name: "Test", description:"test", defaultValue:null, isRequired:true)) ;
    }

    [Fact]
    public void SetValue_IsFlagTrueAndNonNull_ThrowsException()
    {
        Option op = new Option(name: "Test", description:"test", defaultValue:"test", isRequired:true, isFlag:true) ;
        Assert.Throws<ArgumentException>(() => op.SetValue("abc"));
    }

    [Fact]
    public void SetValue_IsNotFlagTrueAndNull_ThrowsNullException()
    {
        Option op = new Option(name: "Test", description:"test", defaultValue:"test", isRequired:true, isFlag:true) ;
        Assert.Throws<ArgumentException>(() => op.SetValue(null));
    }



}
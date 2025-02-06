namespace ConsoleToDoProject.Tests;
using Xunit;
using ConsoleToDoProject.Models;

public class OptionTests
{

    [Fact]
    public void ClassInitialization_EmptyDescription_ThrowsArgumentExceptionError() {
        Option op = new Option(fullName: "Test", abbreviatedName:"Test", description:"test", defaultValue:null, isRequired:true) ;
        Assert.NotNull(op.Description);
    }

    [Fact]
    public void ClassInitialization_DefaultValueIsNotEmpty() {
        Option op = new Option(fullName: "Test", abbreviatedName:"Test", description:"test", defaultValue:"test") ;
        if (op.DefaultValue != null)
            Assert.True(op.DefaultValue.Length > 0);
    }

    [Fact]
    public void ClassInitialization_NameIsNotNull() {
        Option op = new Option(fullName: "Test", abbreviatedName:"Test", description:"test", defaultValue:"test") ;
        Assert.NotNull(op.FullName);
    }

    [Fact]
    public void ClassInitialization_NameIsNotEmpty() {
        Option op = new Option(fullName: "Test", abbreviatedName:"Test", description:"test", defaultValue:"test") ;
        Assert.True(op.FullName.Length > 0);
    }

    [Fact]
    public void ClassInitialization_NotNullDefaultAndIsRequired_ThrowsInitException() {
        Assert.Throws<TypeInitializationException>(() => new Option(fullName: "Test", abbreviatedName:"Test", description:"test", defaultValue:"shouldbenull", isRequired:true)) ;
    }



}
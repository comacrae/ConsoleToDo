using ConsoleToDoProject.Models;
namespace ConsoleToDoProject.Tests
{
    public class OptionsTest
    {
        [Fact]
        public void GetOption_NonExistent_ReturnsNull() {
            List<Option> initList = new List<Option>() { new Option(fullName:"Test", abbreviatedName:"Test",description:"Test") { } };
            Options cmds = new Options(initOptionsList:initList);
            Assert.Null(cmds.GetOptionByFullName("nonexistent"));
        }

        [Fact] public void GetOption_Existing_ReturnsOption()
        {
            List<Option> initList = new List<Option>() { new Option(fullName:"Test", abbreviatedName:"Test",description:"Test") { } };
            Options options = new Options(initOptionsList:initList);
            Assert.Equal("Test",options.GetOptionByFullName("Test").FullName);
        }

        [Fact]
        public void ClassInit_DuplicateOptions_ThrowsException()
        {
            List<Option> initList = new List<Option>() { new Option(fullName:"Test", abbreviatedName:"Test",description:"Test"),new Option(fullName:"Test", abbreviatedName:"Test",description:"Test")  };
            Assert.Throws<TypeInitializationException>(()=> new Options(initOptionsList: initList));
        }
    }
}

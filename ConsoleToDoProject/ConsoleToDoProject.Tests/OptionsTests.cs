using ConsoleToDoProject.Models;
namespace ConsoleToDoProject.Tests
{
    public class OptionsTest
    {
        [Fact]
        public void GetOption_NonExistent_ReturnsNull() {
            List<Option> initList = new List<Option>() { new Option(name:"Test",description:"Test") { } };
            Options cmds = new Options(initOptionsList:initList);
            Assert.Null(cmds.GetOption("nonexistent"));
        }

        [Fact] public void GetOption_Existing_ReturnsOption()
        {
            List<Option> initList = new List<Option>() { new Option(name:"Test",description:"Test") { } };
            Options options = new Options(initOptionsList:initList);
            Assert.Equal("Test",options.GetOption("Test").Name);
        }

        [Fact]
        public void ClassInit_DuplicateOptions_ThrowsException()
        {
            List<Option> initList = new List<Option>() { new Option(name:"Test",description:"Test"), new Option(name:"Test",description:"Test")  };
            Assert.Throws<TypeInitializationException>(()=> new Options(initOptionsList: initList));
        }
    }
}

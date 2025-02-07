using ConsoleToDoProject.Models;
namespace ConsoleToDoProject.Tests
{
    public class OptionsTest
    {

        [Fact]
        public void ClassInit_DuplicateOptions_ThrowsException()
        {
            List<Option> initList = new List<Option>() { new Option(fullName: "Test", abbreviatedName: "Test", description: "Test", defaultValue: "Test"), new Option(fullName: "Test", abbreviatedName: "Test", description: "Test", defaultValue: "Test") };
            Assert.Throws<TypeInitializationException>(() => new Options(initOptionsList: initList));
        }

        [Fact]
        public void GetOption_Nonexistent_ThrowsException()
        {
            List<Option> initList = new List<Option>() { new Option(fullName: "Test", abbreviatedName: "Test", description: "Test", defaultValue: "Test") };
            Options opts = new Options(initOptionsList: initList);
            Assert.Throws<ArgumentException>(() => opts.GetOption("nonexsistent"));
            Assert.Throws<ArgumentException>(() => opts.GetOption("nonexsistent", true));
        }

        [Theory]
        [InlineData("notflag", false, "notflag")]
        [InlineData("n", true, "notflag")]
        [InlineData("flag", false, "flag")]
        [InlineData("f", true, "flag")]
        public void GetOption_FlagAndAbbreviated_RetrievesExpectedOption(string input, bool isAbbreviated, string expectedOptionName)
        {
            List<Option> initList = new List<Option>() { new Option(fullName: "notflag", abbreviatedName: "n", description: "Test", defaultValue: "Test", isFlag: false), new Option(fullName: "flag", abbreviatedName: "f", description: "Test", defaultValue: "true", isFlag: true) };
            Options opts = new Options(initOptionsList: initList);
            Option output = opts.GetOption(input, isAbbreviated);
            Assert.Equal(expectedOptionName, output.FullName);
        }

    }
}

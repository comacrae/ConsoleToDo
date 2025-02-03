using Xunit;
using ConsoleToDoProject.CLI;

namespace ConsoleToDoProject.Tests
{
    public class TokenizerTests
    {
        [Theory]
        [InlineData("This is a test", new []{"This","is","a","test"})]
        [InlineData("This is a bigger test", new string[] {"This", "is","a","bigger","test"})]
        [InlineData("This", new string[] {"This"})]
        public void Tokenize_StringWithWords_ReturnsRightSizedStringList(string input, string[] expected)
        {

            Tokenizer t = new Tokenizer();
            string[] output = t.Tokenize(input);
            Assert.Equal(output, expected);
        }
    }
}

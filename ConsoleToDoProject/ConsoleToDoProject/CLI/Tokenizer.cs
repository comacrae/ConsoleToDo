namespace ConsoleToDoProject.CLI
{
    public class Tokenizer
    {
        public Tokenizer() { }

        public string[] Tokenize(string input)
        {
            return input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
    }
}

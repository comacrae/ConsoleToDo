using System.Text.RegularExpressions;
namespace ConsoleToDoProject.Services
{
    public class Tokenizer
    {
        public Tokenizer() { }

        private TokenValidator _validator = new TokenValidator();
        public string[] Tokenize(string input)

        {
            // Extract matches and handle quotes
            string[] tokens = input.Trim().Split(' ');
            List<string> output = new List<string>();

            for(int i = 0; i < tokens.Length; i++)
            {
                string token = tokens[i];
                if (!String.IsNullOrEmpty(token))
                {
                    _validator.IsValidInput(token);

                    int doubleQuoteCount = token.Count(ch => ch == '"');

                    if (doubleQuoteCount == 1)
                    {
                        token = token.Trim('"') + " ";
                        i++;
                        bool foundMatch = false;
                        while (!foundMatch && i < tokens.Length)
                        {
                            if (tokens[i].Contains('"'))
                            {
                                token += tokens[i].Trim('"');
                                foundMatch = true;
                            }
                            else
                            {
                                token += tokens[i];
                                token += " ";
                                i++;
                            }

                        }
                        if (!foundMatch)
                            throw new ArgumentException("Unmatched double quotes");
                    }else if (doubleQuoteCount == 2)
                    {
                        token = token.Trim('"');
                    }
                    output.Add(token);
                }
            }
            return output.ToArray();
        }
    }
}

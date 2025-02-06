
namespace ConsoleToDoProject.Models
{
    public class Command
    {
        public string Name { get; set; } = "Default";
        public List<string> Arguments { get; set; } = new List<string>();

        public Options Options { get; set; } = new Options();

    }
}

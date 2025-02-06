
namespace ConsoleToDoProject.Models
{
    public class Command
    {
        public bool NoArgs { get; set; } = false;
        public string Name { get; set; } = "Default";
        public List<string>? Arguments { get; set; } = null;

        public Options Options { get; set; } = new Options();

        public Command( string name, Options? options = null,bool noArgs=false)
        {
            Name = name;
            Options = options?? new Options();
            NoArgs = noArgs;
        }
    }
}

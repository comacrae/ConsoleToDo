using ConsoleToDoProject.Models;
namespace ConsoleToDoProject.Services
{
    public class HelpCommandExecutor
    {
        public void Execute(Commands cmds)
        {
            foreach (var cmd in cmds.supportedCommands) {
                Console.WriteLine($"Command name: {cmd.Name}");
                Console.WriteLine($"Accepts args: {!cmd.NoArgs}");
                if(cmd.Options is not null)
                {
                Console.WriteLine($"Options:");
                foreach(var option in cmd.Options)
                {
                        var defaultVal = option.DefaultValue;
                        if (defaultVal == "")
                            defaultVal = "\"\"";

                    string outputString = $"--{option.FullName} -{option.AbbreviatedName}\n\tDescription: {option.Description}\n\tDefault: {defaultVal}";
                    Console.WriteLine(outputString);
                }

                }
                Console.WriteLine("");
            }
        }
    }
}

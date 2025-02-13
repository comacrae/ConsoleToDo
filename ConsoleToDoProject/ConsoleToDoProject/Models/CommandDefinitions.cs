using ConsoleToDoProject.Models;
namespace ConsoleToDoProject.Models
{
    public class CommandDefinitions
    {
        public Command AddCommand()
        {
            Option priorityOp = new Option(abbreviatedName: "p", fullName: "priority", description:"Task's priority level (1-3)", defaultValue: "1");
            Options ops = new Options() { priorityOp};
            return new Command("add", options: ops);
        }
        public Command RemoveCommand()
        {
            Option descriptionOp = new Option(abbreviatedName: "d", fullName: "description", description:"Remove tasks matching given description", defaultValue: "");
            Option indexOp = new Option(abbreviatedName: "i", fullName: "index", description:"Remove task matching given index", defaultValue: "");
            Option priorityOp = new Option(abbreviatedName: "p", fullName: "priority", description:"Remove tasks with given priority level", defaultValue: "");
            Option completedOp = new Option(abbreviatedName:"c", fullName: "completed",description:"Remove all completed tasks", isFlag: true, defaultValue:"false");
            Option removeAllOp = new Option(abbreviatedName: "a", fullName: "all", description:"Remove all tasks", isFlag:true, defaultValue:"false");

            Options ops = new Options() { descriptionOp,priorityOp, completedOp, removeAllOp, indexOp};
            return new Command("remove", options: ops, noArgs:true);
        }

        public Command UpdateCommand()
        {
            Option descriptionOp = new Option(abbreviatedName: "d", fullName: "description", description: "Description of task to update", defaultValue: "");
            Option indexOp = new Option(abbreviatedName: "i", fullName: "index", description: "Index of task to update", defaultValue: "");
            Options ops = new Options() { descriptionOp, indexOp};
            return new Command("update", options: ops);
        }

        public Command SaveCommand()
        {
            Option pathOp = new Option(abbreviatedName: "p", fullName: "path", description: "Save file path", defaultValue: "");
            Option overwriteOp = new Option(abbreviatedName: "o", fullName: "overwrite", description: "Overwrite file flag", defaultValue:"false",isFlag:true);
            Options ops = new Options() { pathOp, overwriteOp};
            return new Command("save", options: ops, noArgs:true);
        }

        public Command LoadCommand()
        {
            Option pathOp = new Option(abbreviatedName: "p", fullName: "path", description: "Load file path", defaultValue: "");
            Options ops = new Options() { pathOp};
            return new Command("load", options: ops);
        }

        public List<Command> GetCommandList()
        {
            return new List<Command>() { AddCommand(),RemoveCommand(),UpdateCommand(),SaveCommand(),LoadCommand() };
        }



    }
}

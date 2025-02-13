using ConsoleToDoProject.Models;
namespace ConsoleToDoProject.Services
{
    public class PrintCommandExecutor
    {
        public void Execute(ToDoTaskList tList)
        {
            if(tList.Tasks.Count == 0) {
                Console.WriteLine("List is empty");
            }
            else
            {
                for (int i = 0; i < tList.Tasks.Count; i++)
                {
                    ToDoTask t = tList.Tasks[i];
                    string outString = $"{i}: \"{t.Description}\" Priority: {t.Priority}";
                    if (t.IsComplete)
                        outString ="[x] " + outString;
                    else
                        outString = "[ ] " + outString;
                    Console.WriteLine(outString);

                }

            }
        }
    }
}

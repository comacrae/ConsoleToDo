using System; 
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDoProject.Models
{
    public class ToDoTask
    {
        public enum PriorityLevel
        {
            Low =3, Medium = 2, High = 1
        }
        public string Description { get; set; } = "Default";
        public bool IsComplete { get; set; } = false;
        public DateTime CreationDatetime {  get; set; } = DateTime.Now;
        public DateTime? CompletedDatetime { get; set; } = null;
        

        public PriorityLevel Priority { get; set; }

        public ToDoTask(string description, PriorityLevel priority= PriorityLevel.Low)
        {
            Description = description?? throw new TypeInitializationException("ToDoTask", new ArgumentNullException("ToDoTask description string cannot be null"));
            Priority = priority;
        }
        public string GetDescription()
        {
            return Description;
        }

        public void SetComplete()
        {
            IsComplete = true;
            CompletedDatetime = DateTime.Now;
        }
        public void SetUncomplete()
        {
            IsComplete = false;
            CompletedDatetime = null;
        }


    }
}

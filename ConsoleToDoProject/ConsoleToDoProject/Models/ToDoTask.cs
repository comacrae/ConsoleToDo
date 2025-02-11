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
        public DateTime? DueDate { get; set; } = null;
        

        public PriorityLevel Priority { get; set; }

        public ToDoTask(string description, PriorityLevel priority= PriorityLevel.Low)
        {
            if (String.IsNullOrEmpty(description))
            {
                throw new TypeInitializationException("ToDoTask", new ArgumentNullException("ToDoTask description string cannot be null"));
            }
            Description = description;
            Priority = priority;
        }

        public void SetDescription(string description)
        {
            if(String.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("Description cannot be empty or null");
            }

            Description = description;
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

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType()) {
                return false;
            }

            ToDoTask other = (ToDoTask) obj;
            return Description == other.Description &&
                Priority == other.Priority &&
                IsComplete == other.IsComplete &&
                CreationDatetime == other.CreationDatetime;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Description, Priority, IsComplete, CreationDatetime, CompletedDatetime);
        }


    }
}

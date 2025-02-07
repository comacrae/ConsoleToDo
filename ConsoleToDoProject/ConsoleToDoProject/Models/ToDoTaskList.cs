using ConsoleToDoProject.Models;
namespace ConsoleToDoProject.Models
{
    public class ToDoTaskList
    {
        List<ToDoTask> Tasks { get; set; } = new List<ToDoTask>();

        public ToDoTaskList()
        {

        }
        public ToDoTaskList(List<ToDoTask> tasks)
        {
            Tasks = tasks;
        }

        public List<ToDoTask> GetCompletedTasks()
        {
            return Tasks.FindAll(t => t.IsComplete);
        }
        public List<ToDoTask> GetUncompletedTasks()
        {
            return Tasks.FindAll(t => !t.IsComplete);
        }
        public ToDoTask GetTaskByDescription(string description)
        {
            if (String.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("GetTask argument cannot be null or empty string");
            }
            return Tasks.Find(t => t.Description == description)?? throw new ArgumentException($"Task does not exist in list: {description}");
        }
        public ToDoTask GetTaskByIndex(int index)
        {
            if (index < 0 || index > Tasks.Count - 1)
            {
                throw new IndexOutOfRangeException("Index is out of bounds of task list");
            }
            return Tasks[index];
        }

        private int GetTaskIndex(string description)
        {
            return Tasks.IndexOf(GetTaskByDescription(description));
        }

        public void UpdateTaskByDescription(string description, string update)
        {
            if(String.IsNullOrEmpty(update)) {
                throw new ArgumentNullException("Update task string cannot be null or empty");
            }
            int taskIndex = GetTaskIndex(description);
            if (GetTaskByDescription(update) == null)
                Tasks[taskIndex].SetDescription(update);
            else
                throw new ArgumentException("Cannot add duplicate task: ", update);

        }

        public void UpdateTaskByIndex(int index,string update)
        {
            if (index < 0 || index > Tasks.Count - 1)
            {
                throw new IndexOutOfRangeException("Index is out of bounds of task list");
            }
            if (GetTaskByDescription(update) == null)
                Tasks[index].SetDescription(update);
            else
                throw new ArgumentException("Cannot add duplicate task: ", update);

        }

        public void AddTask(ToDoTask newTask)
        {
            if (Tasks.Find(t => t.Description == newTask.Description) == null)
            {
                Tasks.Add(newTask);
            }
            else// duplicate found
            {
                throw new ArgumentException("Cannot add duplicate task: ", newTask.Description);
            }
        }

        public void DeleteTaskByDescription(string description)
        {
            if (Tasks.Count == 0)
                throw new InvalidOperationException("Tasks list is empty.");
            ToDoTask taskToRemove = GetTaskByDescription(description);
            Tasks.Remove(taskToRemove);
        }
        public void DeleteTaskByIndex(int index)
        {
            if (Tasks.Count == 0)
                throw new InvalidOperationException("Tasks list is empty.");
            ToDoTask taskToRemove = GetTaskByIndex(index);
            Tasks.Remove(taskToRemove);
        }
    }
}

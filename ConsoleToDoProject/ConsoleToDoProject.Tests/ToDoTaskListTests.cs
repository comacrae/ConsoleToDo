using ConsoleToDoProject.Models;
namespace ConsoleToDoProject.Tests
{
    public class ToDoTaskListTests
    {
        [Fact]

        public void GetCompleteTasks_ListWithUncomplete_ReturnsOnlyCompleteTasks()
        {
            ToDoTask complete = new ToDoTask("test1");
            complete.SetComplete();
            ToDoTask uncomplete = new ToDoTask("test");

            List<ToDoTask> initList = new List<ToDoTask>() { complete, uncomplete};
            ToDoTaskList taskList = new ToDoTaskList(initList);
            Assert.All<ToDoTask>(taskList.GetCompletedTasks(), task => Assert.True(task.IsComplete));
        }

        [Fact]
        public void GetUncompleteTasks_ListWithComplete_ReturnsOnlyUncompleteTasks()
        {
            ToDoTask complete = new ToDoTask("test1");
            complete.SetComplete();
            ToDoTask uncomplete = new ToDoTask("test");

            List<ToDoTask> initList = new List<ToDoTask>() { complete, uncomplete};
            ToDoTaskList taskList = new ToDoTaskList(initList);
            Assert.All<ToDoTask>(taskList.GetUncompletedTasks(), task => Assert.False(task.IsComplete));
        }

        [Fact]
        public void GetTaskByDescription_NullAndEmptyString_ThrowsError()
        {
            ToDoTask complete = new ToDoTask("test1");
            complete.SetComplete();
            ToDoTask uncomplete = new ToDoTask("test");

            List<ToDoTask> initList = new List<ToDoTask>() { complete, uncomplete};
            ToDoTaskList taskList = new ToDoTaskList(initList);
            Assert.Throws<ArgumentNullException>(()=>taskList.GetTaskByDescription(null));
            Assert.Throws<ArgumentNullException>(()=>taskList.GetTaskByDescription(""));
        }

        [Fact]
        public void GetTaskByIndex_OutOfBoundsIndex_ThrowsError()
        {
            ToDoTask complete = new ToDoTask("test1");
            complete.SetComplete();
            ToDoTask uncomplete = new ToDoTask("test");

            List<ToDoTask> initList = new List<ToDoTask>() { complete, uncomplete};
            ToDoTaskList taskList = new ToDoTaskList(initList);
            Assert.Throws<IndexOutOfRangeException>(()=>taskList.GetTaskByIndex(-1));
        }

        [Fact]
        public void GetTaskByDescription_NonExistentTask_ThrowsError()
        {
            ToDoTask complete = new ToDoTask("test1");
            complete.SetComplete();
            ToDoTask uncomplete = new ToDoTask("test");

            List<ToDoTask> initList = new List<ToDoTask>() { complete, uncomplete};
            ToDoTaskList taskList = new ToDoTaskList(initList);
            Assert.Throws<ArgumentException>(()=>taskList.GetTaskByDescription("I dont exist"));
        }

        [Fact]
        public void UpdateTaskByDescription_NonexistentTask_ThrowsError() { 

            ToDoTask complete = new ToDoTask("test1");
            complete.SetComplete();
            ToDoTask uncomplete = new ToDoTask("test");

            List<ToDoTask> initList = new List<ToDoTask>() { complete, uncomplete};
            ToDoTaskList taskList = new ToDoTaskList(initList);
            Assert.Throws<ArgumentException>(()=>taskList.UpdateTaskByDescription("I dont exist", "updateString"));
        }

        [Fact]
        public void UpdateTaskByIndex_OutOfBoundsIndex_ThrowsError() { 

            ToDoTask complete = new ToDoTask("test1");
            complete.SetComplete();
            ToDoTask uncomplete = new ToDoTask("test2");

            List<ToDoTask> initList = new List<ToDoTask>() { complete, uncomplete};
            ToDoTaskList taskList = new ToDoTaskList(initList);
            Assert.Throws<IndexOutOfRangeException>(()=>taskList.UpdateTaskByIndex(-1, "update"));
        }


        [Fact]
        public void AddTask_DuplicateTask_ThrowsError()
        {
            ToDoTaskList tasklist = new ToDoTaskList();
            ToDoTask newTask = new ToDoTask("new");
            tasklist.AddTask(newTask);
            ToDoTask dupeTask = new ToDoTask("new");
            Assert.Throws<ArgumentException>(() => tasklist.AddTask(dupeTask));

        }

        [Fact]
        public void UpdateTaskByDescription_DuplicateTask_ThrowsError()
        {
            ToDoTaskList tasklist = new ToDoTaskList();
            ToDoTask newTask = new ToDoTask("new");
            tasklist.AddTask(newTask);
            ToDoTask dupeTask = new ToDoTask("old");
            tasklist.AddTask(dupeTask);
            Assert.Throws<ArgumentException>(() => tasklist.UpdateTaskByDescription("old","new"));
        }

        [Fact]
        public void UpdateTaskByIndex_DuplicateTask_ThrowsError()
        {
            ToDoTaskList tasklist = new ToDoTaskList();
            ToDoTask newTask = new ToDoTask("new");
            tasklist.AddTask(newTask);
            ToDoTask dupeTask = new ToDoTask("old");
            tasklist.AddTask(dupeTask);
            Assert.Throws<ArgumentException>(() => tasklist.UpdateTaskByIndex(1,"new"));
        }

        [Fact]
        public void AddTask_NewTask_CreatesTask()
        {
            ToDoTaskList tasklist = new ToDoTaskList();
            ToDoTask newTask = new ToDoTask("new");
            tasklist.AddTask(newTask);
            ToDoTask returnTask = tasklist.GetTaskByDescription("new");
            Assert.Equal(newTask,returnTask);

        }

        [Fact]
        public void DeleteTaskByDescription_NonexistentTask_ThrowsError()
        {
            ToDoTask complete = new ToDoTask("test");
            complete.SetComplete();
            ToDoTask uncomplete = new ToDoTask("test");

            List<ToDoTask> initList = new List<ToDoTask>() { complete, uncomplete};
            ToDoTaskList taskList = new ToDoTaskList(initList);
            Assert.Throws<ArgumentException>(()=>taskList.DeleteTaskByDescription("I dont exist"));
        }

        [Fact]
        public void DeleteTaskMethods_EmptyTaskList_ThrowsError()
        {
            ToDoTaskList tasklist = new ToDoTaskList() { };
            Assert.Throws<InvalidOperationException>(() =>tasklist.DeleteTaskByDescription("abc"));
            Assert.Throws<InvalidOperationException>(() =>tasklist.DeleteTaskByIndex(0));
        }
    }
}

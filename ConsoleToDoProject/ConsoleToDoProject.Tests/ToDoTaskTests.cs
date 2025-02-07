using ConsoleToDoProject.Models;

namespace ConsoleToDoProject.Tests
{
    public class ToDoTaskTests
    {
        [Fact]
        public void ClassInit_TaskDescriptionNull_ThrowsException()
        {
            Assert.Throws<TypeInitializationException>(() => new ToDoTask(description: null));
        }

        [Fact]
        public void SetComplete_Execution_SetsFlag()
        {
            ToDoTask toDoTask = new ToDoTask("test");
            Assert.False(toDoTask.IsComplete);
            toDoTask.SetComplete();
            Assert.True(toDoTask.IsComplete);
        }

        [Fact]
        public void SetUncomplete_Execution_SetsFlag()
        {
            ToDoTask toDoTask = new ToDoTask("test");
            Assert.False(toDoTask.IsComplete);
            toDoTask.SetComplete();
            Assert.True(toDoTask.IsComplete);
            toDoTask.SetUncomplete();
            Assert.False(toDoTask.IsComplete);
        }

        [Fact]
        public void SetUncomplete_Execution_Resets_CompletionDatetime()
        {
            ToDoTask toDoTask = new ToDoTask("test");
            Assert.Null(toDoTask.CompletedDatetime);
            toDoTask.SetComplete();
            Assert.NotNull(toDoTask.CompletedDatetime);
            toDoTask.SetUncomplete();
            Assert.Null(toDoTask.CompletedDatetime);

        }

    }
}

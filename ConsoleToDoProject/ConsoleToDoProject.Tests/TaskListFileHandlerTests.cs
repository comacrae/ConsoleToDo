using ConsoleToDoProject.Services;
using ConsoleToDoProject.Models;

namespace ConsoleToDoProject.Tests
{
    public class TaskListFileHandlerTests
    {
        const string trueFolderPath = @"C:\Users\comac\source\repos\comacrae\ConsoleToDo\ConsoleToDoProject\ConsoleToDoProject.Tests\TestFolder\";
        const string trueFilePath = @"C:\Users\comac\source\repos\comacrae\ConsoleToDo\ConsoleToDoProject\ConsoleToDoProject.Tests\TestFolder\tasks.json";
        private ToDoTaskList createValidList()
        {
            ToDoTask t = new ToDoTask("test");
            ToDoTaskList tList = new ToDoTaskList();
            tList.AddTask(t);
            return tList;
        }
        [Fact]
        public void LoadFile_InvalidPath_ThrowsException()
        {
            TaskListFileHandler fileHandler = new TaskListFileHandler();
            Assert.Throws<FileNotFoundException>(() => fileHandler.LoadFile(trueFolderPath + @"\nonexistentfile.json"));
        }

        [Fact]
        public void LoadFile_InvalidFormat_ThrowsException()
        {
            TaskListFileHandler fileHandler = new TaskListFileHandler();
            Assert.Throws<FileLoadException>(() => fileHandler.LoadFile(trueFolderPath + @"\brokenfile.json"));
        }

        [Fact]
        public void WriteFile_AlreadyExistingNoOverwrite_ThrowsException()
        {
            TaskListFileHandler fileHandler = new TaskListFileHandler();
            ToDoTaskList tList = createValidList();
            Assert.Throws<ArgumentException>(() => fileHandler.WriteFile(tList,trueFolderPath + @"\existingFile.json"));
        }

        [Fact]
        public void WriteFile_WriteAndRead_CreatesIdenticalList() {
            TaskListFileHandler fileHandler = new TaskListFileHandler();
            ToDoTaskList tList = createValidList();
            fileHandler.WriteFile(tList,overwrite:true);
            ToDoTaskList readList = fileHandler.LoadFile(trueFilePath);
            Assert.Equal(tList,readList);
        }

    }
}

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
            string testFilePath = trueFolderPath + @"\existingFile.json";
            TaskListFileHandler fileHandler = new TaskListFileHandler();
            ToDoTaskList tList = createValidList();
            if(!File.Exists(testFilePath)) { 
                fileHandler.WriteFile(tList, testFilePath);
            }
            Assert.Throws<ArgumentException>(() => fileHandler.WriteFile(tList,testFilePath));
        }

        [Fact]
        public void LoadFile_ReadingPremadeFile_ExecutesSuccessfully()
        {
            TaskListFileHandler fileHandler = new TaskListFileHandler();
            ToDoTaskList expectedList = createValidList();
        }

        [Fact]
        public void WriteFile_WriteAndRead_CreatesIdenticalListCount() {
            TaskListFileHandler fileHandler = new TaskListFileHandler();
            ToDoTaskList writeList = createValidList();
            fileHandler.WriteFile(writeList, overwrite:true);
            ToDoTaskList readList = fileHandler.LoadFile(trueFilePath);
            Assert.Equal(writeList.Tasks.Count,readList.Tasks.Count);
        }

        [Fact]
        public void GetCurrentTasklistPath_NoFileLoaded_ThrowsException()
        {
            TaskListFileHandler fileHandler = new TaskListFileHandler();
            Assert.Throws<FileLoadException>(() => fileHandler.GetCurrentFilePath());

        }

    }
}

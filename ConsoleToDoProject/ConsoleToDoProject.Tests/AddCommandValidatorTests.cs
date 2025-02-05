using ConsoleToDoProject.Services;
namespace ConsoleToDoProject.Tests
{
    public class AddCommandValidatorTests
    {
        [Fact]
        public void Validate_EmptyAndNullString_ReturnErrorMessage()
        {
            AddCommandValidator validator = new AddCommandValidator();

        }

    }
}

using Chama.Domain.Validations.Course;

namespace Chama.Domain.Commands.Student
{
    public class RegisterNewStudentAsyncCommand : StudentCommand
    {
        public RegisterNewStudentAsyncCommand(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int Age { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewStudentCommandAsyncValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

using Chama.Domain.Validations.Course;

namespace Chama.Domain.Commands.Student
{
    public class RegisterNewStudentCommand : StudentCommand
    {
        public RegisterNewStudentCommand(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int Age { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewStudentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

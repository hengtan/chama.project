using Chama.Domain.Commands.Student;

namespace Chama.Domain.Validations.Course
{
    public class RegisterNewStudentCommandValidation : StudentValidation<RegisterNewStudentCommand>
    {
        public RegisterNewStudentCommandValidation()
        {
            ValidateName();
        }
    }
}


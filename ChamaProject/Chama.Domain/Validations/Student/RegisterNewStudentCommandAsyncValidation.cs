using Chama.Domain.Commands.Student;

namespace Chama.Domain.Validations.Course
{
    public class RegisterNewStudentCommandAsyncValidation : StudentValidation<RegisterNewStudentAsyncCommand>
    {
        public RegisterNewStudentCommandAsyncValidation()
        {
            ValidateName();
        }
    }
}


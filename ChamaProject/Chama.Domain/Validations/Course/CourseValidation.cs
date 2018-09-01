using Chama.Domain.Commands.Course;
using FluentValidation;

namespace Chama.Domain.Validations.Course
{
    public class CourseValidation<T> : AbstractValidator<T> where T : CourseCommand
    {
        //TODO VALIDATE COURSE SIZE HERE?
    }
}

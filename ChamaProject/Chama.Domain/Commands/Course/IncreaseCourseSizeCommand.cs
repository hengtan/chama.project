using Chama.Domain.Validations.Course;
using System;

namespace Chama.Domain.Commands.Course
{
    public class IncreaseCourseSizeCommand : CourseCommand
    {
        public IncreaseCourseSizeCommand(Guid courseId)
        {
            Id = courseId;
        }

        public override bool IsValid()
        {
            ValidationResult = new IncreaseCourseSizeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

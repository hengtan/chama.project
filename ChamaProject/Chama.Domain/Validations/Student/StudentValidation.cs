using Chama.Domain.Commands.Student;
using FluentValidation;
using System;

namespace Chama.Domain.Validations.Course
{
    public abstract class StudentValidation<T> : AbstractValidator<T> where T : StudentCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 3 and 50 characters");
        }
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        //TODO CHECK THE MINIMUM AGE TO SIGN UP
    }
}

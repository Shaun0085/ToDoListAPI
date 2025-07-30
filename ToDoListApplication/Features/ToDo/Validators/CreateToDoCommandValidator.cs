using FluentValidation;
using ToDoListApplication.Features.ToDo.Commands;

namespace ToDoListApplication.Features.ToDo.Validators
{
    public class CreateToDoCommandValidator : AbstractValidator<CreateToDoCommand>
    {
        public CreateToDoCommandValidator()
        {
            RuleFor(x => x.ItemTitle)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters");
        }
    }
}

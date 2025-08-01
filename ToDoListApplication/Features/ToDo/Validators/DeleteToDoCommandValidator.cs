using FluentValidation;
using ToDoListApplication.Features.ToDo.Commands;

namespace ToDoListApplication.Features.ToDo.Validators
{
    public class DeleteToDoCommandValidator : AbstractValidator<DeleteToDoCommand>
    {
        public DeleteToDoCommandValidator()
        {
            RuleFor(x => x.ItemId).NotEmpty();
        }
    }
}

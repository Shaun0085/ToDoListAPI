using FluentValidation;
using ToDoListApplication.Features.ToDo.Queries;

namespace ToDoListApplication.Features.ToDo.Validators
{
    public class GetToDoByIdQueryValidator : AbstractValidator<GetToDoByIdQuery>
    {
        public GetToDoByIdQueryValidator()
        {
            RuleFor(x => x.ItemId)
                .NotEmpty();
        }
    }
}

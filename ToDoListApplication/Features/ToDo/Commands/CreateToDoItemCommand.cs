using FluentResults;
using MediatR;

namespace ToDoListApplication.Features.ToDo.Commands
{
    public class CreateToDoCommand : IRequest<Result<Guid>>
    {
        public string ItemTitle { get; set; }
        public bool? IsCompleted { get; set; }
    }
}


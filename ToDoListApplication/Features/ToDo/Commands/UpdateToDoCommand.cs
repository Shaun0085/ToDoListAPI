using MediatR;
using FluentResults;
using ToDoListApplication.Dtos;

namespace ToDoListApplication.Features.ToDo.Commands
{
    public class UpdateToDoCommand : IRequest<Result<ToDoListItemDto>>
    {
        public Guid ItemId { get; set; }
        public string ItemTitle { get; set; }
        public bool? IsCompleted { get; set; }
    }
}

using FluentResults;
using MediatR;
using ToDoListApplication.Dtos;
using ToDoListApplication.Interfaces;

namespace ToDoListApplication.Features.ToDo.Commands
{
    public class UpdateToDoCommandHandler : IRequestHandler<UpdateToDoCommand, Result<ToDoListItemDto>>
    {
        private readonly IToDoListService _service;

        public UpdateToDoCommandHandler(IToDoListService service)
        {
            _service = service;
        }

        public async Task<Result<ToDoListItemDto>> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
        {
            var item = await _service.GetItemById(request.ItemId);
            if (item == null)
                return Result.Fail("To-Do item not found");

            var dto = new ToDoListItemDto
            {
                ItemId = request.ItemId,
                ItemTitle = request.ItemTitle,
                IsCompleted = request.IsCompleted
            };

            await _service.UpdateItem(dto);

            return Result.Ok(dto);
        }
    }
}

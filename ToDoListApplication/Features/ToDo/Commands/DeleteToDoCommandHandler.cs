using FluentResults;
using MediatR;
using ToDoListApplication.Dtos;
using ToDoListApplication.Interfaces;

namespace ToDoListApplication.Features.ToDo.Commands
{
    public class DeleteToDoCommandHandler :IRequestHandler<DeleteToDoCommand, Result<string>>
    {
        private readonly IToDoListService _service;

        public DeleteToDoCommandHandler(IToDoListService service)
        {
            _service = service;
        }

        public async Task<Result<string>> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            var item = await _service.GetItemById(request.ItemId);
            if (item == null)
                return Result.Fail("To-Do item not found");

            await _service.DeleteItem(request.ItemId);
            return Result.Ok("Item deleted successfully");
        }
    }
}

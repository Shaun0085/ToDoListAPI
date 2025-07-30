using MediatR;
using FluentResults;
using ToDoListApplication.Interfaces;
using ToDoListApplication.Dtos;

namespace ToDoListApplication.Features.ToDo.Queries
{
    public class GetToDoByIdQueryHandler :IRequestHandler<GetToDoByIdQuery, Result<ToDoListItemDto>>
    {
        private readonly IToDoListService _service;

        public GetToDoByIdQueryHandler(IToDoListService service)
        {
            _service = service;
        }
        public async Task<Result<ToDoListItemDto>> Handle(GetToDoByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _service.GetItemById(request.ItemId);

            if (item == null)
                return Result.Fail("To-do item not found");

            return Result.Ok(item);
        }
    }
}

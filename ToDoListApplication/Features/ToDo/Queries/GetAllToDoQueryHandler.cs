using FluentResults;
using MediatR;
using ToDoListApplication.Dtos;
using ToDoListApplication.Interfaces;

namespace ToDoListApplication.Features.ToDo.Queries
{
    public class GetAllToDoQueryHandler : IRequestHandler<GetAllToDoQuery, Result<List<ToDoListItemDto>>>
    {
        public readonly IToDoListService _service;

        public GetAllToDoQueryHandler(IToDoListService service)
        {
            _service = service;
        }

        public async Task<Result<List<ToDoListItemDto>>> Handle(GetAllToDoQuery request, CancellationToken cancellationToken)
        {
            var items = await _service.GetAllItem();
            return Result.Ok(items);
        }
    }
}

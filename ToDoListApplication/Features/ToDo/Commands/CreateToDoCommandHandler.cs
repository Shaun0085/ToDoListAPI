using FluentResults;
using MediatR;
using ToDoListApplication.Dtos;
using ToDoListApplication.Interfaces;

namespace ToDoListApplication.Features.ToDo.Commands;

public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand, Result<Guid>>
{
    private readonly IToDoListService _service;

    public CreateToDoCommandHandler(IToDoListService service)
    {
        _service = service;
    }

    public async Task<Result<Guid>> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
    {
        var dto = new ToDoListItemDto
        {
            ItemTitle = request.ItemTitle,
            IsCompleted = request.IsCompleted
        };

        return await _service.AddItem(dto);
    }
}
using MediatR;
using FluentResults;
using System.Collections.Generic;
using ToDoListApplication.Dtos;

namespace ToDoListApplication.Features.ToDo.Queries
{
    public class GetAllToDoQuery : IRequest<Result<List<ToDoListItemDto>>>
    {
    }
}

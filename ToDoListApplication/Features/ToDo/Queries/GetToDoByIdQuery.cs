using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApplication.Dtos;

namespace ToDoListApplication.Features.ToDo.Queries
{
    public class GetToDoByIdQuery : IRequest<Result<ToDoListItemDto>>
    {
        public Guid ItemId { get; set; }

        public GetToDoByIdQuery(Guid itemId)
        {
            ItemId = itemId;
        }
    }
}

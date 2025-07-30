using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApplication.Features.ToDo.Commands
{
    public class DeleteToDoCommand : IRequest<Result<string>>
    {
        public Guid ItemId { get; set; }

        public DeleteToDoCommand(Guid itemId)
        {
            ItemId = itemId;
        }
    }
}

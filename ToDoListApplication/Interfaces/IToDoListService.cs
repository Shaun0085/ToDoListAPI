using FluentResults;
using ToDoListApplication.Dtos;

namespace ToDoListApplication.Interfaces
{
    public interface IToDoListService
    {
        Task<List<ToDoListItemDto>> GetAllItem();
        Task<ToDoListItemDto?> GetItemById(Guid ItemId);
        Task<Result<Guid>> AddItem(ToDoListItemDto item);
        Task<Result> UpdateItem(ToDoListItemDto item);
        Task<Result> DeleteItem(Guid ItemId);
    }
}

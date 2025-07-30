using ToDoListDomain.Entities;

namespace ToDoListDomain.Interfaces
{
    public interface IToDoListRepository
    {
        Task<List<ToDoListItem>> GetAllItem();
        Task<ToDoListItem?> GetItemById(Guid id);
        Task AddItem(ToDoListItem item);
        Task UpdateItem(ToDoListItem item);
        Task DeleteItem(Guid id);
    }
}

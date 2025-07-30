using Microsoft.EntityFrameworkCore;
using ToDoListDomain.Entities;
using ToDoListDomain.Interfaces;
using ToDoListInfrastructure.DbContexts;

namespace ToDoListInfrastructure.Repositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly ApiDbContext _context;

        public ToDoListRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoListItem>> GetAllItem()
        {
            return await _context.ToDoListItems.ToListAsync();
        }

        public async Task<ToDoListItem?> GetItemById(Guid id)
        {
            return await _context.ToDoListItems.FindAsync(id);
        }

        public async Task AddItem(ToDoListItem item)
        {
            _context.ToDoListItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItem(ToDoListItem item)
        {
            var existingItem = await _context.ToDoListItems
                   .FirstOrDefaultAsync(x => x.ItemId == item.ItemId);
            existingItem.ItemTitle = item.ItemTitle;
            existingItem.IsCompleted = item.IsCompleted;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(Guid id)
        {
            var item = await _context.ToDoListItems.FindAsync(id);
            _context.ToDoListItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}

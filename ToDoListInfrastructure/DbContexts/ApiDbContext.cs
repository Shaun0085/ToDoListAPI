using Microsoft.EntityFrameworkCore;
using ToDoListDomain.Entities;

namespace ToDoListInfrastructure.DbContexts
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
        public DbSet<ToDoListItem> ToDoListItems { get; set; }
    }
}

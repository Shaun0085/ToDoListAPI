using System.ComponentModel.DataAnnotations;

namespace ToDoListDomain.Entities
{
    public class ToDoListItem
    {

        [Key]
        public Guid ItemId { get; set; } = Guid.NewGuid();

        [Required]
        public string ItemTitle { get; set; }

        public bool? IsCompleted { get; set; }

    }
}

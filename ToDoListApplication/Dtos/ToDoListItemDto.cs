namespace ToDoListApplication.Dtos
{
    public class ToDoListItemDto
    {
        public Guid ItemId { get; set; }
        public string? ItemTitle { get; set; }
        public bool? IsCompleted { get; set; }
    }
}

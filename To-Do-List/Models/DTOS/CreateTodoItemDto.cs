using static To_Do_List.Models.TodoItem;

namespace To_Do_List.Models.DTOS
{
    public class CreateTodoItemDto
    {
        public required string Title { get; set; }
        public required DateTime DueDate { get; set; }
        public ItemStatus Status { get; set; }
    }
}

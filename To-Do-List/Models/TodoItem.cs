using System.ComponentModel.DataAnnotations;

namespace To_Do_List.Models;

public class TodoItem
{
    public enum ItemStatus
    {
        Pending,
        Ongoing,
        Done,
        
    }
    [Key]
    public Guid ItemId { get; set; }
    public required string Title { get; set; }
    public required DateTime DueDate{ get; set; }
    public ItemStatus Status { get; set; }
}
using To_Do_List.Models;
using To_Do_List.Models.DTOS;

namespace To_Do_List.Services
{
    public interface ITodo
    {
        Task<ResponseDto> CreateTodoItem(CreateTodoItemDto item);
        Task<List<TodoItem>> GetAllTodoItems();
        Task<TodoItem> GetTodoItem(Guid id);
        Task<TodoItem> UpdateTodoItem(Guid id);
        Task<ResponseDto> DeleteTodoItem(Guid id);

    }
}

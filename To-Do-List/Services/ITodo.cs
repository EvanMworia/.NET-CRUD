using To_Do_List.Models;
using To_Do_List.Models.DTOS;

namespace To_Do_List.Services
{
    public interface ITodo
    {
        Task<ResponseDto> CreateTodoItem(CreateTodoItemDto item);
        Task<ResponseDto> GetAllTodoItems();
        Task<ResponseDto> GetTodoItem(Guid id);
        Task<ResponseDto> UpdateTodoItem(Guid id, CreateTodoItemDto updatedItemdto);
        Task<ResponseDto> DeleteTodoItem(Guid id);

    }
}

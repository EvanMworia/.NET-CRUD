using To_Do_List.Data;
using To_Do_List.Models;
using To_Do_List.Models.DTOS;

namespace To_Do_List.Services
{
    public class TodoService : ITodo
    {
        private readonly AppDbContext _context;
        private readonly ILogger<TodoService> _logger;
        public TodoService(AppDbContext context, ILogger<TodoService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<ResponseDto> CreateTodoItem(CreateTodoItemDto itemDto)
        {
            
                
                if (itemDto.DueDate < DateTime.UtcNow)
                {
                    
                    throw new ArgumentOutOfRangeException("Due Date cannot be in the past");
                    
                }
                var todoItem = new TodoItem
                {
                    ItemId = Guid.NewGuid(),
                    Title = itemDto.Title,
                    DueDate = itemDto.DueDate,
                    Status = itemDto.Status,

                };
                await _context.TodoItems.AddAsync(todoItem);
                 await _context.SaveChangesAsync();
                return new ResponseDto
                {
                    IsSuccess = true,
                    Message = $"New Todo-Item {todoItem.Title} has been created ",
                    Result = todoItem
                };
               
            
        }

        public Task<ResponseDto> DeleteTodoItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TodoItem>> GetAllTodoItems()
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> GetTodoItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> UpdateTodoItem(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

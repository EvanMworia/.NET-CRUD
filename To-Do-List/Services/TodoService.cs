using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using To_Do_List.Data;
using To_Do_List.Models;
using To_Do_List.Models.DTOS;

namespace To_Do_List.Services
{
    public class TodoService : ITodo
    {
        private readonly AppDbContext _context;
        private readonly ILogger<TodoService> _logger;
        //private readonly ResponseDto _responseDto;
        public TodoService(AppDbContext context, ILogger<TodoService> logger)
        {
            _context = context;
            _logger = logger;
            //_responseDto = new ResponseDto();
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
        public async Task<ResponseDto> GetAllTodoItems()
        {
            var items = await _context.TodoItems.ToListAsync();
            if (items.IsNullOrEmpty())
            {
                return new ResponseDto { IsSuccess = false, Message="Item List is currently empty, add new items....", Result=items };
            }
            return new ResponseDto { IsSuccess=true, Message="Here is what we found", Result = items };
        }

               

        public Task<ResponseDto> GetTodoItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> UpdateTodoItem(Guid id, CreateTodoItemDto updatedItem)
        {
            var foundItem = await _context.TodoItems.FindAsync(id);
            if (foundItem == null)
            {
                return new ResponseDto { IsSuccess = false, Message = "No item was found with that id" };
            }
            foundItem.Title = updatedItem.Title;
            foundItem.DueDate = updatedItem.DueDate;
            foundItem.Status = updatedItem.Status;
            if (foundItem.DueDate < DateTime.UtcNow)
            {

                return new ResponseDto { IsSuccess = false, Message = "Due Date cannot be in the past of current date/time" };

            }
            await _context.SaveChangesAsync();
            return new ResponseDto { IsSuccess = true, Message=$"Item id  has been updated", Result = foundItem };
        }
        public async Task<ResponseDto> DeleteTodoItem(Guid id)
        {
            var foundItem = await _context.TodoItems.FindAsync(id);
            if (foundItem == null)
            {
                return new ResponseDto { Message = "No items were found with that Id", IsSuccess=false};
            }
            _context.TodoItems.Remove(foundItem);
            await _context.SaveChangesAsync();

            return new ResponseDto { IsSuccess = true, Message="Item has been deleted" };
        }

    }
}

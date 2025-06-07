using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using To_Do_List.Models;
using To_Do_List.Models.DTOS;
using To_Do_List.Services;

namespace To_Do_List.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodo _todoService;
        private readonly ResponseDto _responseDto;
        public TodoController(ITodo todo)
        {
            _todoService = todo;
            _responseDto = new ResponseDto();

        }
        [HttpPost("createNewTodo")]
        public async Task<ActionResult<ResponseDto>> CreateNewItem([FromBody] CreateTodoItemDto itemDto)
        {

            try
            {
                var res = await _todoService.CreateTodoItem(itemDto);
                if (!res.IsSuccess)
                {
                    return BadRequest(res);
                }
                return Ok(res);

            }
            catch (ArgumentOutOfRangeException ex)
            {

                return BadRequest(_responseDto.Message = ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null) { 
                    return BadRequest(_responseDto.Message = $"{ex.InnerException.Message}");

                }
                return BadRequest(_responseDto.Message = $"{ex.Message}");
            }
        }
        [HttpGet("GetAllTodos")]
        public async Task<ActionResult<ResponseDto>> GetTodoItems()
        {
            try
            {
                var res= await _todoService.GetAllTodoItems();
                if (!res.IsSuccess)
                {
                    return NotFound(res);
                }
                return Ok(res);
                
            }
            catch (Exception ex)
            {

                if (ex.InnerException != null)
                {
                    return BadRequest(_responseDto.Message = $"RootCause: {ex.InnerException.Message}");
                }
                return BadRequest(_responseDto.Message = $"Server Error: {ex.Message}");
            }
        }

        [HttpPatch("update/{id}")]
        public async Task<ActionResult<ResponseDto>> UpdateTodoItem(Guid id, [FromBody] CreateTodoItemDto dto)
        {
            try
            {
                var res = await _todoService.UpdateTodoItem(id, dto);
                if (!res.IsSuccess) 
                {   
                    return BadRequest(res);
                
                }
                return Ok(res);


            }
            catch (Exception ex)
            {

                if (ex.InnerException != null)
                {
                    return BadRequest(_responseDto.Message = $"RootCause: {ex.InnerException.Message}");
                }
                return BadRequest(_responseDto.Message = $"Server Error: {ex.Message}");
            }

        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ResponseDto>> DeleteTodoItem(Guid id)
        {
            try
            {
                var res = await _todoService.DeleteTodoItem(id);
                if (!res.IsSuccess)
                {
                    return NotFound(res);
                }
                return Ok(res);
            }
            catch (Exception ex)
            {

                if (ex.InnerException != null)
                {
                    return BadRequest(_responseDto.Message = $"RootCause: {ex.InnerException.Message}");
                }
                return BadRequest(_responseDto.Message = $"Server Error: {ex.Message}");
            }
        }
    }
}

using AutoMapper;
using To_Do_List.Models;
using To_Do_List.Models.DTOS;

namespace To_Do_List.MappingProfiles
{
    public class TodoItemProfile:Profile
    {
        public TodoItemProfile()
        {
            CreateMap<CreateTodoItemDto, TodoItem>().ReverseMap();
        }
    }
}

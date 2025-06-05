namespace To_Do_List.Models
{
    public class ResponseDto
    {
        public String? Message { get; set; }
        public bool IsSuccess { get; set; }
        public object? Result { get; set; }
    }
}

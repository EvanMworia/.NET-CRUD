using Microsoft.EntityFrameworkCore;
using To_Do_List.Models;

namespace To_Do_List.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }
    public DbSet<TodoItem> TodoItems { get; set; }

}
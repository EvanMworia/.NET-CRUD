using Microsoft.EntityFrameworkCore;
using To_Do_List.Data;
using To_Do_List.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//1--------ADDING DBCONTEXT TO DI CONTAINER
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//2.--------REGISTERING OUR SERVICES, <Interface, Implementation>
builder.Services.AddScoped<ITodo, TodoService>();

//3.-------REGISTERING AUTOMAPPER
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

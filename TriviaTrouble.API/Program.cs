using Microsoft.EntityFrameworkCore;
using TriviaTrouble;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(o => o.UseSqlite("Data Source=database.db"));
builder.Services.AddCors(c =>
    c.AddPolicy("AllowAll", o =>
    {
        o.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowAll");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
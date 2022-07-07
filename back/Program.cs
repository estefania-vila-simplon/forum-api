using back.Repositories;
using back.Models;
using back.Repositories.Interfaces;
using back.Services;
using back.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories
builder.Services.AddSingleton<forumdbContext>();
//builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ICommentRepository, CommentRepository>();

// Services
builder.Services.AddSingleton<ICommentService, CommentService>();

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

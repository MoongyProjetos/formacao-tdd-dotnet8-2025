using Microsoft.EntityFrameworkCore;
using TodoApi.Controller;
using TodoApi.Model;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "TodoAPI";
    config.Title = "TodoAPI v1";
    config.Version = "v1";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "TodoAPI";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

var todoItems = app.MapGroup("/todoitems");

todoItems.MapGet("/", TodoController.GetAllTodos);
todoItems.MapGet("/complete", TodoController.GetCompleteTodos);
todoItems.MapGet("/{id}", TodoController.GetTodo);
todoItems.MapPost("/", TodoController.CreateTodo);
todoItems.MapPut("/{id}", TodoController.UpdateTodo);
todoItems.MapDelete("/{id}", TodoController.DeleteTodo);


await app.RunAsync();
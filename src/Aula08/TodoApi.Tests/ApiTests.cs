namespace TodoApi.Tests;


using Microsoft.AspNetCore.Http.HttpResults; // for Ok<T>
using System.Threading.Tasks;
using TodoApi.Controller;
using TodoApi.DTO;


public class ApiTests
{

    [Fact]
    public async Task GetAllTodos_ReturnsHttpOk()
    {
        // Arrange
        var db = TestHelpers.CreateDbContext();

        // Act
        var result = await TodoController.GetAllTodos(db);

        // Assert
        var okResult = Assert.IsType<Ok<TodoItemDTO[]>>(result);
        Assert.NotEmpty(okResult.Value);
    }


    [Fact]
    public async Task GetAllCompleteTodos_ReturnsHttpOk()
    {
        // Arrange
        var db = TestHelpers.CreateDbContext();

        // Act
        var result = await TodoController.GetCompleteTodos(db);

        // Assert
        var okResult = Assert.IsType<Ok<TodoItemDTO[]>>(result);
        Assert.NotEmpty(okResult.Value);
        Assert.True(okResult.Value.All(t => t.IsComplete));
        Assert.True(okResult.Value.Any());
    }




    [Fact]
    public async Task GetTodo_ReturnsHttpOk()
    {
        // Arrange
        var db = TestHelpers.CreateDbContext();

        // Act
        var result = await TodoController.GetTodo(1, db);

        // Assert
        Assert.IsType<Ok<TodoItemDTO>>(result);        
    }


    [Fact]
    public async Task GetTodo_ReturnsHttpNotFound()
    {
        // Arrange
        var db = TestHelpers.CreateDbContext();

        // Act
        var result = await TodoController.GetTodo(100, db);

        // Assert
        var notFoundResult = Assert.IsType<NotFound>(result);
    }


    [Fact]
    public async Task CreateTodo_ReturnsHttpCreated()
    {
        // Arrange
        var db = TestHelpers.CreateDbContext();
        var itemDto = new TodoItemDTO
        {
            Name = "New Task",
            IsComplete = false
        };

        // Act
        var result = await TodoController.CreateTodo(itemDto, db);

        // Assert
        Assert.IsType<Created<TodoItemDTO>>(result);
    }


    [Fact]
    public async Task UpdateTodo_ReturnsHttpNoContent()
    {
        // Arrange
        var db = TestHelpers.CreateDbContext();
        var itemDto = new TodoItemDTO
        {
            Name = "Updated Task",
            IsComplete = true
        };

        // Act
        var result = await TodoController.UpdateTodo(1, itemDto, db);

        // Assert
        Assert.IsType<NoContent>(result);
    }


    [Fact]
    public async Task DeleteTodo_ReturnsHttpNotfound()
    {
        // Arrange
        var db = TestHelpers.CreateDbContext();

        // Act
        var result = await TodoController.DeleteTodo(1000, db);

        // Assert
        Assert.IsType<NotFound>(result);
    }


    [Fact]
    public async Task DeleteTodo_ReturnsHttpNoContent()
    {
        // Arrange
        var db = TestHelpers.CreateDbContext();

        // Act
        var result = await TodoController.DeleteTodo(1, db);

        // Assert
        Assert.IsType<NoContent>(result);
    }
}

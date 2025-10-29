using Microsoft.EntityFrameworkCore;
using TodoApi.Model; // replace with where your DbContext is defined


namespace TodoApi.Tests;

public static class TestHelpers
{
    public static TodoDb CreateDbContext()
    {
        // Create a unique database name for isolation between tests
        var options = new DbContextOptionsBuilder<TodoDb>()
            .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
            .Options;

        var context = new TodoDb(options);

        // Optional: seed some test data
        context.Todos.AddRange(
            new Todo { Id = 1, Name = "Buy groceries", IsComplete = false },
            new Todo { Id = 2, Name = "Walk the dog", IsComplete = true },
            new Todo { Id = 3, Name = "Wash the cat", IsComplete = true }
        );
        context.SaveChanges();

        return context;
    }
}
namespace Mission8.Models;

public static class SeedData
{
    public static void EnsurePopulated(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TaskContext>();

        context.Database.EnsureCreated();

        if (!context.Categories.Any())
        {
            context.Categories.AddRange(
                new Category { CategoryName = "Home" },
                new Category { CategoryName = "School" },
                new Category { CategoryName = "Work" },
                new Category { CategoryName = "Church" }
            );

            context.SaveChanges();
        }
    }
}


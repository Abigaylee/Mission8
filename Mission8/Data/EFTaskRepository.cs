using Microsoft.EntityFrameworkCore;
using Mission8.Models;

namespace Mission8.Data;

public class EFTaskRepository : ITaskRepository
{
    private readonly TaskContext _context;

    public EFTaskRepository(TaskContext context)
    {
        _context = context;
    }

    public IQueryable<TaskModel> Tasks => _context.Tasks.Include(t => t.Category);
    public IQueryable<Category> Categories => _context.Categories;

    public void AddTask(TaskModel task) => _context.Add(task);
    public void UpdateTask(TaskModel task) => _context.Update(task);
    public void DeleteTask(TaskModel task) => _context.Remove(task);

    public void SaveChanges() => _context.SaveChanges();
}


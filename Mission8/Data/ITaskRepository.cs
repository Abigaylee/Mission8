using Mission8.Models;

namespace Mission8.Data;

public interface ITaskRepository
{
    IQueryable<TaskModel> Tasks { get; }
    IQueryable<Category> Categories { get; }

    void AddTask(TaskModel task);
    void UpdateTask(TaskModel task);
    void DeleteTask(TaskModel task);

    void SaveChanges();
}


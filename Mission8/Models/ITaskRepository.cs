namespace Mission8.Models;

public interface ITaskRepository
{
    IQueryable<TaskModel> Tasks { get; }
    IQueryable<Category> Categories { get; }

    void AddTask(TaskModel task);
    void UpdateTask(TaskModel task);
    void DeleteTask(TaskModel task);

    void SaveChanges();
}


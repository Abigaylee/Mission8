namespace Mission8.Models;

//Task interface and repository
public interface ITaskRepository
{
    IQueryable<TaskModel> Tasks { get; }
    IQueryable<Category> Categories { get; }

    //CRUD implementation
    void AddTask(TaskModel task);
    void UpdateTask(TaskModel task);
    void DeleteTask(TaskModel task);

    void SaveChanges();
}


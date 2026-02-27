using System.ComponentModel.DataAnnotations;

namespace Mission8.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    public string CategoryName { get; set; } = string.Empty;

    public ICollection<TaskModel> Tasks { get; set; } = new List<TaskModel>();
}


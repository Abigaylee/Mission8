using System.ComponentModel.DataAnnotations;

namespace Mission8.Models;

public class TaskModel
{
    [Key]
    public int TaskId { get; set; }

    [Required]
    public string Task { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime? DueDate { get; set; }

    [Required]
    [Range(1, 4)]
    public int Quadrant { get; set; }

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public bool Completed { get; set; }
}


namespace DailyPlanner.Models;

public class TaskModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; } = false;
    public DateTime Date { get; set; }
    public string Tag { get; set; } = string.Empty;
    public bool isEditing { get; set; } = false;
    
    public TaskModel(int id, string title, string description, bool isCompleted, DateTime date, string tag)
    {
        Id = id;
        Title = title;
        Description = description;
        IsCompleted = isCompleted;
        Date = date;
        Tag = tag;
    }
}
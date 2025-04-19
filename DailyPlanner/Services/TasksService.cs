using DailyPlanner.Models;

namespace DailyPlanner.Services;

public class TasksService
{
    public List<TaskModel> Tasks { get; private set; } = new();
    public List<string> Tags { get; private set; } = new() { "Škola", "Práce", "Lékař" };

    public void AddTask(TaskModel task)
    {
        Tasks.Add(task);
    }

    public void RemoveTask(TaskModel task)
    {
        Tasks.Remove(task);
    }

    public void AddTag(string tag)
    {
        if (!Tags.Contains(tag, StringComparer.OrdinalIgnoreCase))
        {
            Tags.Add(tag);
        }
    }

    public void RemoveTag(string tag)
    {
        Tags.RemoveAll(t => t.Equals(tag, StringComparison.OrdinalIgnoreCase));

        foreach (var task in Tasks)
        {
            if (task.Tag.Equals(tag, StringComparison.OrdinalIgnoreCase))
            {
                task.Tag = string.Empty;
            }
        }
    }

    public List<TaskModel> GetFilteredTasks(string filter, DateTime? custom = null, string tagFilter = "")
    {
        DateTime today = DateTime.Today;
        DateTime tomorrow = today.AddDays(1);
        DateTime in3 = today.AddDays(3);
        DateTime in7 = today.AddDays(7);

        var tasks = filter switch
        {
            "today" => Tasks.Where(e => e.Date.Date == today),
            "tomorrow" => Tasks.Where(e => e.Date.Date == tomorrow),
            "in3" => Tasks.Where(e => e.Date.Date >= today && e.Date.Date <= in3),
            "in7" => Tasks.Where(e => e.Date.Date >= today && e.Date.Date <= in7),
            "custom" when custom.HasValue => Tasks.Where(e => e.Date.Date == custom.Value.Date),
            _ => Tasks
        };

        if (!string.IsNullOrWhiteSpace(tagFilter))
        {
            tasks = tasks.Where(t => t.Tag == tagFilter);
        }

        return tasks.ToList();
    }
}
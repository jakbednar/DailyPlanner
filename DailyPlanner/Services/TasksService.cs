using DailyPlanner.Models;

namespace DailyPlanner.Services;

public class TasksService
{
    public List<TaskModel> Tasks { get; private set; } = new();

    public void AddTask(TaskModel task)
    {
        Tasks.Add(task);
    }

    public void RemoveTask(TaskModel task)
    {
        Tasks.Remove(task);
    }

    public List<TaskModel> GetFilteredTasks(string filter, DateTime? custom = null)
    {
        DateTime today = DateTime.Today;
        DateTime tomorrow = today.AddDays(1);
        DateTime in3 = today.AddDays(3);
        DateTime in7 = today.AddDays(7);

        return filter switch
        {
            "today" => Tasks.Where(e => e.Date.Date == today).ToList(),
            "tomorrow" => Tasks.Where(e => e.Date.Date == tomorrow).ToList(),
            "in3" => Tasks.Where(e => e.Date.Date >= today && e.Date.Date <= in3).ToList(),
            "in7" => Tasks.Where(e => e.Date.Date >= today && e.Date.Date <= in7).ToList(),
            "custom" when custom.HasValue => Tasks.Where(e => e.Date.Date == custom.Value.Date).ToList(),
            _ => Tasks
        };
    }
}
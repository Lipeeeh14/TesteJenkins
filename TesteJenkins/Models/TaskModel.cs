namespace TesteJenkins.Models;

public class TaskModel
{
    public long Id { get; private set; }
    public string TaskName { get; private set; } = string.Empty;
	public DateTime DueDate { get; private set; } = DateTime.UtcNow;

	public TaskModel()
	{
	}

	public TaskModel(string taskName, DateTime dueDate)
	{
		TaskName = taskName;
		DueDate = dueDate;
	}
}

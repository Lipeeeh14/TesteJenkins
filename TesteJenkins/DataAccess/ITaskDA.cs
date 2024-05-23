using TesteJenkins.Models;

namespace TesteJenkins.DataAccess;

public interface ITaskDA
{
	Task<IEnumerable<TaskModel>> GetTasks();
	Task SaveTask(TaskModel task);
}

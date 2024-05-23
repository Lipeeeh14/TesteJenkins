using Dapper;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System.Data;
using TesteJenkins.Models;

namespace TesteJenkins.DataAccess;

public class TaskDA : ITaskDA
{
	private readonly IConfiguration _configuration;
	private readonly string _connectionString;

	public TaskDA(IConfiguration configuration)
	{
		_configuration = configuration;
		_connectionString = _configuration["ConnectionStrings:DefaultConnection"] ?? throw new ArgumentNullException();
	}

	public async Task<IEnumerable<TaskModel>> GetTasks()
	{	
		using var connection = new MySqlConnection(_connectionString);
		await connection.OpenAsync();

		return await connection.QueryAsync<TaskModel>("SELECT * FROM Task");
	}

	public async Task SaveTask(TaskModel task)
	{
		await using var connection = new MySqlConnection(_connectionString);

		await connection.ExecuteAsync("INSERT INTO Task (taskName, dueDate) VALUES(@taskName, @dueDate)", task);
	}
}

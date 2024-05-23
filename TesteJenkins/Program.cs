using TesteJenkins.DataAccess;
using TesteJenkins.DTOs;
using TesteJenkins.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITaskDA, TaskDA>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/tasks", async (ITaskDA taskDA) =>
{
	return Results.Ok(await taskDA.GetTasks());
})
.WithName("GetTasks")
.WithOpenApi();

app.MapPost("/task", async (TaskDTO taskDTO, ITaskDA taskDA) =>
{
	try
	{
		await taskDA.SaveTask(new TaskModel(taskDTO.TaskName, taskDTO.DueDate));

		return Results.Ok();
	}
	catch (Exception)
	{
		return Results.BadRequest();
	}
})
.WithName("PostTask")
.WithOpenApi();

app.Run();
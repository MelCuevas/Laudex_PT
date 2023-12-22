namespace Laudex.Models.Interfaces;

public interface ILaudexTaskProvider
{
    public Task<List<LaudexTask>> GetTasksAsync();

    public Task<LaudexTask> GetTaskByIdAsync(int id);

    public Task AddTaskAsync(LaudexTaskModel task);

    public Task UpdateTaskAsync(LaudexTaskModel task);

    public Task DeleteTaskAsync(LaudexTaskModel task);
}
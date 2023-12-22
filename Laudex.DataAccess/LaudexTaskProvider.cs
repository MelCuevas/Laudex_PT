// ---------------------------------------------------------------------------------- 
// Copyright (c) Laudex
// Licensed under the MIT License
// ----------------------------------------------------------------------------------

namespace Laudex.DataAccess;

public class LaudexTaskProvider : ILaudexTaskProvider
{
    private readonly AppSettings appSettings;

    public LaudexTaskProvider(AppSettings appSettings)
    {
        this.appSettings = appSettings;
    }

    /// <summary>
    /// Obtiene todas las tareas
    /// </summary>
    /// <returns>Lista de tareas</returns>
    public async Task<List<LaudexTask>> GetTasksAsync()
    {
        using LaudexDbContext laudexDbContext = new(appSettings);

        List<LaudexTask> result = await laudexDbContext
                 .Tasks
                 .Join(laudexDbContext.Statuses, t => t.StatusId, s => s.Id, (t, s) => new LaudexTask
                 {
                     Id = t.Id,
                     Title = t.Title,
                     Description = t.Description,
                     ExpirationDate = DateOnly.FromDateTime(t.ExpirationDate),
                     Status = s
                 })
                 .ToListAsync();

        return result;
    }

    /// <summary>
    /// Obtiene una tarea por su id
    /// </summary>
    /// <param name="id">Id a buscar</param>
    /// <returns>Si existe, retorna la tarea</returns>
    public async Task<LaudexTask> GetTaskByIdAsync(int id)
    {
        using LaudexDbContext laudexDbContext = new(appSettings);

        var item = await laudexDbContext
                .Tasks
                .Join(laudexDbContext.Statuses, t => t.StatusId, s => s.Id, (t, s) => new LaudexTask
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    ExpirationDate = DateOnly.FromDateTime(t.ExpirationDate),
                    Status = s
                })
                .ToListAsync();

        return item.FirstOrDefault(t => t.Id == id);
    }

    /// <summary>
    /// Agrega una tarea
    /// </summary>
    /// <param name="task">Tarea a agregar</param>
    /// <returns>Awaitable task</returns>
    public async Task AddTaskAsync(LaudexTaskModel task)
    {
        using LaudexDbContext laudexDbContext = new(appSettings);

        laudexDbContext.Tasks.Add(task);
        await laudexDbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Actualiza una tarea
    /// </summary>
    /// <param name="task">Tarea a actualizar</param>
    /// <returns>Awaitable task</returns>
    public async Task UpdateTaskAsync(LaudexTaskModel task)
    {
        using LaudexDbContext laudexDbContext = new(appSettings);

        laudexDbContext.Update(task);
        await laudexDbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Elimina una tarea
    /// </summary>
    /// <param name="task">Tarea a eliminar</param>
    /// <returns>Awaitable task</returns>
    public async Task DeleteTaskAsync(LaudexTaskModel task)
    {
        using LaudexDbContext laudexDbContext = new(appSettings);

        laudexDbContext.Tasks.Remove(task);
        await laudexDbContext.SaveChangesAsync();
    }
}
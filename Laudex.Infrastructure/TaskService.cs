// ---------------------------------------------------------------------------------- 
// Copyright (c) Laudex
// Licensed under the MIT License
// ----------------------------------------------------------------------------------

namespace Laudex.Infrastructure;

public class TaskService
{
    private readonly ILaudexTaskProvider laudexTaskProvider;

    public TaskService(ILaudexTaskProvider laudexTaskProvider)
    {
        this.laudexTaskProvider = laudexTaskProvider;
    }

    /// <summary>
    /// Agrega una tarea
    /// </summary>
    /// <param name="task">Tarea a agregar</param>
    /// <returns>Awaitable task</returns>
    public async Task AddTaskAsync(LaudexTaskModel task)
    {
        Guard.AgainstNull(task?.ExpirationDate, nameof(LaudexTaskModel.ExpirationDate));
        Guard.AgainstNull(task?.StatusId, nameof(LaudexTaskModel.StatusId));

        try
        {
            await laudexTaskProvider.AddTaskAsync(task);
        }
        catch (Exception ex)
        {
            throw new FailedToAddException(ex.Message);
        }
    }

    /// <summary>
    /// Actualiza una tarea
    /// </summary>
    /// <param name="task">Tarea a actualizar</param>
    /// <returns>Awaitable task</returns>
    public async Task UpdateTaskAsync(LaudexTaskModel task)
    {
        Guard.AgainstNull(task?.ExpirationDate, nameof(LaudexTaskModel.ExpirationDate));
        Guard.AgainstNull(task?.StatusId, nameof(LaudexTaskModel.StatusId));

        try
        {
            await laudexTaskProvider.UpdateTaskAsync(task);
        }
        catch (Exception ex)
        {
            throw new FailedToUpdateException(ex.Message);
        }
    }

    /// <summary>
    /// Elimina una tarea
    /// </summary>
    /// <param name="task">Tarea a eliminar</param>
    /// <returns>Awaitable task</returns>
    public async Task DeleteTaskAsync(LaudexTaskModel task)
    {
        Guard.AgainstNull(task?.ExpirationDate, nameof(LaudexTaskModel.ExpirationDate));
        Guard.AgainstNull(task?.StatusId, nameof(LaudexTaskModel.StatusId));

        try
        {
            await laudexTaskProvider.DeleteTaskAsync(task);
        }
        catch (Exception ex)
        {
            throw new FailedToRemoveException(ex.Message);
        }
    }

    /// <summary>
    /// Obtiene una tarea por su id
    /// </summary>
    /// <param name="id">Id a buscar</param>
    /// <returns>Si existe, retorna la tarea</returns>
    public async Task<LaudexTask> GetTaskByIdAsync(int id)
    {
        Guard.AgainstNull(id, nameof(LaudexTaskModel.Id));

        try
        {
            return await laudexTaskProvider.GetTaskByIdAsync(id);
        }
        catch (Exception ex)
        {
            throw new FailedToGetByIdException(ex.Message);
        }
    }

    /// <summary>
    /// Obtiene todas las tareas
    /// </summary>
    /// <returns>Lista de tareas</returns>
    public async Task<List<LaudexTask>> GetTasksAsync()
    {
        try
        {
            return await laudexTaskProvider.GetTasksAsync();
        }
        catch (Exception ex)
        {
            throw new FailedToGetAllException(ex.Message);
        }
    }
}
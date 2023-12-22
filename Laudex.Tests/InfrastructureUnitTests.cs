using Laudex.DataAccess;
using Laudex.Infrastructure;
using Laudex.Models;
using Laudex.Models.Exceptions;
using Laudex.Models.Interfaces;
using Moq;

namespace Laudex.Tests;

[TestClass]
public class InfrastructureUnitTests
{
    [TestMethod]
    [TestCategory("InfrastructureTests")]
    [Description("Prueba el metodo de obtener todas las tareas")]
    public async Task GetAllMethodShouldNotFail()
    {
        // Arrange
        var tasks = new List<LaudexTask> {
            new LaudexTask() {
                Id = 1,
                Title = "Titulo"
            }
        };
        var taskRepository = new Mock<ILaudexTaskProvider>();
        taskRepository.Setup(x => x.GetTasksAsync()).ReturnsAsync(tasks);

        // Act
        var taskService = new TaskService(taskRepository.Object);
        var result = await taskService.GetTasksAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(tasks[0].Id, result[0].Id);
        Assert.AreEqual(tasks[0].Title, result[0].Title);
    }

    [TestMethod]
    [TestCategory("InfrastructureTests")]
    [Description("Prueba el metodo de obtener por id")]
    public async Task GetByIdMethodShouldNotFail()
    {
        // Arrange
        var task = new LaudexTask()
        {
            Id = 1,
            Title = "Titulo"
        };
        var taskRepository = new Mock<ILaudexTaskProvider>();
        taskRepository.Setup(x => x.GetTaskByIdAsync(It.IsAny<Int32>())).ReturnsAsync(task);

        // Act
        var taskService = new TaskService(taskRepository.Object);
        var result = await taskService.GetTaskByIdAsync(1);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(task.Id, result.Id);
        Assert.AreEqual(task.Title, result.Title);
    }

    [TestMethod]
    [TestCategory("InfrastructureTests")]
    [Description("Prueba el metodo de agregar task")]
    public async Task AddMethodShouldNotFail()
    {
        // Arrange
        var task = new LaudexTaskModel()
        {
            Id = 1,
            Title = "Titulo",
            ExpirationDate = DateTime.Now,
            StatusId = 1
        };
        var taskRepository = new Mock<ILaudexTaskProvider>();
        taskRepository.Setup(x => x.AddTaskAsync(task));

        // Act
        var taskService = new TaskService(taskRepository.Object);
        await taskService.AddTaskAsync(task);
    }

    [TestMethod]
    [TestCategory("InfrastructureTests")]
    [Description("Prueba las validaciones del metodo agregar")]
    [ExpectedException(typeof(MissingRequiredFieldException))]
    public async Task AddMethodShouldFailIfRequiredParametersAreNull()
    {
        // Arrange
        var task = new LaudexTaskModel()
        {
            Id = 1,
            Title = "Titulo"
        };
        var taskRepository = new Mock<ILaudexTaskProvider>();
        taskRepository.Setup(x => x.AddTaskAsync(task));

        // Act
        var taskService = new TaskService(taskRepository.Object);
        await taskService.AddTaskAsync(null);
    }
}
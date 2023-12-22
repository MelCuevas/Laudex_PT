// ---------------------------------------------------------------------------------- 
// Copyright (c) Laudex
// Licensed under the MIT License
// ----------------------------------------------------------------------------------

namespace Laudex.UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly TaskService taskService;

    public HomeController(
        ILogger<HomeController> logger,
        TaskService taskService)
    {
        _logger = logger;
        this.taskService = taskService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult NewTask()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> EditTask(int id)
    {
        var task = await taskService.GetTaskByIdAsync(id);

        return View(task);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var task = await taskService.GetTasksAsync();

        return Json(new { data = task });
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] LaudexTaskModel task)
    {
        await taskService.AddTaskAsync(task);

        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateTask([FromBody] LaudexTaskModel task)
    {
        await taskService.UpdateTaskAsync(task);

        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteTask([FromBody] LaudexTaskModel task)
    {
        await taskService.DeleteTaskAsync(task);

        return Ok();
    }
}
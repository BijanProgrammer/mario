using Microsoft.AspNetCore.Mvc;
using Portal.Database;
using Portal.Services.Abstractions;

namespace Portal.Controllers;

[ApiController]
[Route("[controller]")]
public class ExecuteController : ControllerBase
{
    private Context _context;
    private readonly IPipelineService _pipelineService;

    public ExecuteController(Context context, IPipelineService pipelineService)
    {
        _context = context;
        _pipelineService = pipelineService;
    }

    [HttpGet]
    public IActionResult Execute()
    {
        var result = _pipelineService.Execute();
        return Ok(result);
    }
}
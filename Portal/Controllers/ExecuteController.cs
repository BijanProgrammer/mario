using Microsoft.AspNetCore.Mvc;
using Portal.Database;
using Portal.Services.Abstractions;

namespace Portal.Controllers;

[ApiController]
[Route("[controller]")]
public class ExecuteController : ControllerBase
{
    private Context _context;
    private IPipelineService _pipelineService;
    private IJsonConvertorService _jsonConvertorService;

    public ExecuteController(Context context, IPipelineService pipelineService,
        IJsonConvertorService jsonConvertorService)
    {
        _context = context;
        _pipelineService = pipelineService;
        _jsonConvertorService = jsonConvertorService;
    }

    [HttpGet]
    public IActionResult Execute()
    {
        var result = _pipelineService.Execute();
        return Ok(result);
    }
}
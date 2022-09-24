using Microsoft.AspNetCore.Mvc;
using Portal.Database;
using Portal.Database.Tables;
using Portal.Models;
using Portal.Plugins;
using Portal.Services.Interfaces;

namespace Portal.Controllers;

[ApiController]
[Route("[controller]/[Action]")]
public class PipelineController : ControllerBase
{
    private Context _context;
    private readonly IPipelineService _pipelineService;

    public PipelineController(Context context, IPipelineService pipelineService)
    {
        _context = context;
        _pipelineService = pipelineService;
    }

    [HttpGet]
    public List<Pipeline> AllPipelines()
    {
        return _context.Pipelines.ToList();
    }

    [HttpGet]
    public ActionResult<string> ExecutePipeline(int pipelineId)
    {
        var pipeline = _context.Pipelines.Find(pipelineId);
        if (pipeline == null) return NotFound();

        return _pipelineService.Execute(pipeline);
    }

    [HttpPost]
    public ActionResult AddPipeline(string name)
    {
        _context.Pipelines.Add(new Pipeline()
        {
            Name = name, Plugins = new List<Plugin>()
            {
                new FilterPlugin()
                {
                    Id = 23,
                    Column = "Username",
                    Operator = LogicalOperator.Equal,
                    DesiredValue = "BijanProgrammer"
                }
            }
        });
        _context.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public ActionResult RemovePipeline(int pipelineId)
    {
        var pipeline = _context.Pipelines.Find(pipelineId);
        if (pipeline == null) return NotFound();

        _context.Pipelines.Remove(pipeline);
        _context.SaveChanges();

        return Ok();
    }


    [HttpPost]
    public ActionResult AddFilterPlugin(int pipelineId, [FromBody] FilterPlugin plugin)
    {
        return AddPlugin(pipelineId, plugin);
    }

    [HttpDelete]
    public ActionResult RemovePlugin(int pipelineId, [FromBody] int pluginId)
    {
        var pipeline = _context.Pipelines.Find(pipelineId);
        if (pipeline == null) return NotFound();

        var plugin = pipeline.Plugins.FirstOrDefault(plugin => plugin.Id == pluginId);
        if (plugin == null) return NotFound();

        pipeline.Plugins.Remove(plugin);
        _context.SaveChanges();

        return Ok();
    }

    private ActionResult AddPlugin(int pipelineId, Plugin plugin)
    {
        var pipeline = _context.Pipelines.Find(pipelineId);
        if (pipeline == null) return NotFound();

        pipeline.Plugins.Add(plugin);
        _context.Pipelines.Update(pipeline);
        _context.SaveChanges();

        return Ok();
    }
}
using Portal.Database.Tables;

namespace Portal.Services.Interfaces;

public interface IPipelineService
{
    public string Execute(Pipeline pipeline);
}
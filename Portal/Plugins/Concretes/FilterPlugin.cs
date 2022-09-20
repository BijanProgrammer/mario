using Portal.Plugins.Abstractions;
using Portal.Services.Abstractions;

namespace Portal.Plugins.Concretes;

public class FilterPlugin : IPlugin
{
    public string GenerateQuery()
    {
        return "SELECT * FROM \"IgnoreMe\"";
    }
}
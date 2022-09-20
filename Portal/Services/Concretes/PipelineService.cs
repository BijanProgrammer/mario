using Npgsql;
using Portal.Models;
using Portal.Plugins.Abstractions;
using Portal.Plugins.Concretes;
using Portal.Services.Abstractions;

namespace Portal.Services.Concretes;

public class PipelineService : IPipelineService
{
    private List<IPlugin> Plugins { get; set; } = new()
    {
        new FilterPlugin()
        {
            Id = 1,
            Column = "Username",
            Operator = LogicalOperator.Equal,
            DesiredValue = "BijanProgrammer"
        }
    };

    private readonly IJsonConvertorService _jsonConvertorService;

    public PipelineService(IJsonConvertorService jsonConvertorService)
    {
        _jsonConvertorService = jsonConvertorService;
    }

    public string Execute()
    {
        const string connectionString = "Server=127.0.0.1;Port=5432;Database=Mario;User Id=postgres;Password=1234;";

        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        var (query, parameters) = Plugins[0].GenerateQuery();

        using var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddRange(parameters.ToArray());

        using var reader = command.ExecuteReader();

        return _jsonConvertorService.ConvertDbDataReaderToJson(reader);
    }
}
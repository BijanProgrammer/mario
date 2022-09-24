using Npgsql;
using Portal.Database.Tables;
using Portal.Models;
using Portal.Services.Interfaces;

namespace Portal.Services.Concretes;

public class PipelineService : IPipelineService
{
    private readonly IJsonConvertorService _jsonConvertorService;

    public PipelineService(IJsonConvertorService jsonConvertorService)
    {
        _jsonConvertorService = jsonConvertorService;
    }

    public string Execute(Pipeline pipeline)
    {
        const string connectionString = "Server=127.0.0.1;Port=5432;Database=Mario;User Id=postgres;Password=1234;";

        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        var (query, parameters) = pipeline.Plugins[0].GenerateQuery();

        using var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddRange(parameters.ToArray());

        using var reader = command.ExecuteReader();

        return _jsonConvertorService.ConvertDbDataReaderToJson(reader);
    }
}
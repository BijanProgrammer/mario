using Npgsql;

namespace Portal.Plugins.Abstractions;

public interface IPlugin
{
    public (string query, List<NpgsqlParameter> parameters) GenerateQuery();
}
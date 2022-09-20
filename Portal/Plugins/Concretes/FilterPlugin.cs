using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Portal.Models;
using Portal.Plugins.Abstractions;
using Portal.Services.Abstractions;
using Portal.Utils;

namespace Portal.Plugins.Concretes;

public class FilterPlugin : IPlugin
{
    public int Id { get; set; }
    public string Column { get; set; }
    public LogicalOperator Operator { get; set; }
    public string DesiredValue { get; set; }


    public (string query, List<NpgsqlParameter> parameters) GenerateQuery()
    {
        var desiredValueParameter = $"Plugin{Id}DesiredValue";

        var query =
            $"SELECT * FROM \"IgnoreMe\" WHERE \"{Column}\" {Operator.Name()} @{desiredValueParameter}";

        var parameters = new List<NpgsqlParameter>()
        {
            new(desiredValueParameter, DesiredValue)
        };

        return (query, parameters);
    }
}
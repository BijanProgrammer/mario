using Npgsql;
using Portal.Models;
using Portal.Utils;

namespace Portal.Plugins;

public class FilterPlugin : Plugin
{
    public int Id { get; set; }
    public string Column { get; set; }
    public LogicalOperator Operator { get; set; }
    public string DesiredValue { get; set; }


    public override (string query, List<NpgsqlParameter> parameters) GenerateQuery()
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
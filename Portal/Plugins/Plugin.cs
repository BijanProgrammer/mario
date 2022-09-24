using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql;

namespace Portal.Plugins;

public class Plugin
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public virtual (string query, List<NpgsqlParameter> parameters) GenerateQuery()
    {
        throw new NotImplementedException();
    }
}
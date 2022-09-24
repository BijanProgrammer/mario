using System.Data.Common;
using System.Text;
using Newtonsoft.Json;
using Portal.Services.Interfaces;

namespace Portal.Services.Concretes;

public class JsonConvertorService : IJsonConvertorService
{
    public string ConvertDbDataReaderToJson(DbDataReader reader)
    {
        var result = new StringWriter(new StringBuilder());
        using var jsonWriter = new JsonTextWriter(result);
        jsonWriter.WriteStartArray();

        while (reader.Read())
        {
            jsonWriter.WriteStartObject();

            for (var i = 0; i < reader.FieldCount; i++)
            {
                jsonWriter.WritePropertyName(reader.GetName(i));
                jsonWriter.WriteValue(reader[i]);
            }

            jsonWriter.WriteEndObject();
        }

        jsonWriter.WriteEndArray();

        return result.ToString();
    }
}
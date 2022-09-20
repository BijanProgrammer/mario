using System.Data.Common;

namespace Portal.Services.Abstractions;

public interface IJsonConvertorService
{
    public string ConvertDbDataReaderToJson(DbDataReader reader);
}
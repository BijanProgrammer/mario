using System.Data.Common;

namespace Portal.Services.Interfaces;

public interface IJsonConvertorService
{
    public string ConvertDbDataReaderToJson(DbDataReader reader);
}
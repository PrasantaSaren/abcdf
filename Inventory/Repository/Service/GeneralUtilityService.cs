using System.Data;

namespace Inventory.Repository.Service;

public class GeneralUtilityService
{
    public static List<Dictionary<string, object>> ConvertDataTableToDictionaryList(DataTable dt)
    {
        var columns = dt.Columns.Cast<DataColumn>();
        return (from DataRow row in dt.Rows let dataColumns = columns.ToList() select dataColumns.ToDictionary(col => col.ColumnName, col => row[col])).ToList();
    }
}
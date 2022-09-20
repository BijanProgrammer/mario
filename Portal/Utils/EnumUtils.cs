using Portal.Models;

namespace Portal.Utils;

public static class EnumUtils
{
    public static string Name(this LogicalOperator logicalOperator)
    {
        return logicalOperator switch
        {
            LogicalOperator.Equal => "=",
            LogicalOperator.NotEqual => "!=",
            _ => "!!! NOT DEFINED !!!"
        };
    }
}
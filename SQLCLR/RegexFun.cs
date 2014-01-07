using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text.RegularExpressions;

public partial class RegexFun
{
    //验证字符串中是否包含与指定的匹配模式一致的字符串
    [SqlFunction]
    public static SqlBoolean RegexIsMatch(SqlString input,SqlString pattern)
    {
        return new SqlBoolean(Regex.IsMatch(input.ToString(), pattern.ToString(), RegexOptions.IgnorePatternWhitespace| RegexOptions.IgnoreCase));
    }

    //替换字符串中与指定的匹配模式一致的字符串 
    [SqlFunction]
    public static SqlString RegexReplace(SqlString input, SqlString pattern, SqlString replacement)
    {
        return new SqlString(Regex.Replace(input.ToString(), pattern.ToString(), replacement.ToString(), RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase));
    }

};


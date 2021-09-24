

using System;
using System.Collections.Generic;
using XUtliPoolLib;

public class JsonUtil
{
    public static float ParseFloat(object val, float defVal = 0.0f) => val == null ? defVal : float.Parse(val.ToString());

    public static int ParseInt(object val, int defVal = 0) => val == null ? defVal : int.Parse(val.ToString());

    public static bool ParseBool(object val, bool defVal = false)
    {
        if (val == null)
            return defVal;
        try
        {
            return (uint)JsonUtil.ParseInt(val, defVal ? 1 : 0) > 0U;
        }
        catch (Exception ex1)
        {
            try
            {
                return bool.Parse(val.ToString());
            }
            catch (Exception ex2)
            {
                return defVal;
            }
        }
    }

    public static DateTime ParseDateTime(object val) => DateTime.Parse(val.ToString());

    public static string ReadString(IDictionary<string, object> dic, string key, string defVal = "") => dic != null && dic.ContainsKey(key) ? (dic[key] == null ? defVal : dic[key].ToString()) : defVal;

    public static int ReadInt(IDictionary<string, object> dic, string key, int defVal = 0) => dic != null && dic.ContainsKey(key) ? JsonUtil.ParseInt(dic[key], defVal) : defVal;

    public static bool ReadBool(IDictionary<string, object> dic, string key, bool defVal = false) => dic != null && dic.ContainsKey(key) ? JsonUtil.ParseBool(dic[key], defVal) : defVal;

    public static float ReadFloat(IDictionary<string, object> dic, string key, float defVal = 0.0f) => dic != null && dic.ContainsKey(key) ? JsonUtil.ParseFloat(dic[key], defVal) : defVal;

    public static DateTime ReadDateTime(IDictionary<string, object> dic, string key) => JsonUtil.ReadDateTime(dic, key, new DateTime(1, 1, 1, 0, 0, 0));

    public static DateTime ReadDateTime(
      IDictionary<string, object> dic,
      string key,
      DateTime defVal)
    {
        if (dic == null || !dic.ContainsKey(key))
            return defVal;
        try
        {
            return JsonUtil.ParseDateTime(dic[key]);
        }
        catch (Exception ex)
        {
            XSingleton<XDebug>.singleton.AddErrorLog(ex.Message);
            return defVal;
        }
    }

    public static string ListToJsonStr(List<string> list)
    {
        if (list == null || list.Count < 1)
            return "[]";
        bool flag = true;
        string str1 = "[";
        foreach (string str2 in list)
        {
            if (flag)
                flag = false;
            else
                str1 += ",";
            str1 += str2;
        }
        return str1 + "]";
    }
}

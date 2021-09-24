using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XStringDefineProxy
	{

		public static string GetString(string key)
		{
			return XSingleton<XStringTable>.singleton.GetString(key);
		}

		public static string GetString(string key, params object[] args)
		{
			string value = "";
			bool data = XSingleton<XStringTable>.singleton.GetData(key, out value);
			return XStringDefineProxy.GetString(key, value, data, args);
		}

		public static string GetReplaceString(string key, params object[] args)
		{
			string text = "";
			bool data = XSingleton<XStringTable>.singleton.GetData(key, out text);
			text = XSingleton<UiUtility>.singleton.ReplaceReturn(text);
			return XStringDefineProxy.GetString(key, text, data, args);
		}

		private static string GetString(string key, string value, bool find, params object[] args)
		{
			for (int i = 0; i < args.Length; i++)
			{
				bool flag = args[i] is string;
				if (flag)
				{
					args[i] = XSingleton<XGameUI>.singleton.m_uiTool.GetLocalizedStr((string)args[i]);
				}
			}
			string result;
			if (find)
			{
				bool flag2 = args.Length == 0;
				if (flag2)
				{
					result = value;
				}
				else
				{
					result = string.Format(value, args);
				}
			}
			else
			{
				bool flag3 = key != "UNKNOWN_TARGET";
				if (flag3)
				{
					result = XStringDefineProxy.GetString("UNKNOWN_TARGET") + " " + key;
				}
				else
				{
					result = "UNKNOWN_TARGET not found in StringTable";
				}
			}
			return result;
		}

		public static string GetString(XStringDefine strEnum)
		{
			string text = strEnum.ToString();
			string text2 = "";
			bool data = XSingleton<XStringTable>.singleton.GetData(text, out text2);
			bool flag = data;
			string result;
			if (flag)
			{
				result = text2;
			}
			else
			{
				bool flag2 = text != "UNKNOWN_TARGET";
				if (flag2)
				{
					result = XStringDefineProxy.GetString("UNKNOWN_TARGET") + " " + text;
				}
				else
				{
					result = "UNKNOWN_TARGET not found in StringTable";
				}
			}
			return result;
		}

		public static string GetString(ErrorCode code)
		{
			string text = code.ToString();
			string text2 = "";
			bool data = XSingleton<XStringTable>.singleton.GetData(text, out text2);
			bool flag = data;
			string result;
			if (flag)
			{
				result = text2;
			}
			else
			{
				bool flag2 = text != "UNKNOWN_ERRCODE";
				if (flag2)
				{
					result = XStringDefineProxy.GetString("UNKNOWN_ERRCODE") + " " + text;
				}
				else
				{
					result = "UNKNOWN_ERRCODE not found in StringTable";
				}
			}
			return result;
		}

		public static string GetString(XAttributeDefine strEnum)
		{
			string text = strEnum.ToString();
			string text2 = "";
			bool data = XSingleton<XStringTable>.singleton.GetData(text, out text2);
			bool flag = data;
			string result;
			if (flag)
			{
				result = text2;
			}
			else
			{
				bool flag2 = text != "UNKNOWN_TARGET";
				if (flag2)
				{
					result = XStringDefineProxy.GetString("UNKNOWN_TARGET") + " " + text;
				}
				else
				{
					result = "UNKNOWN_TARGET not found in StringTable";
				}
			}
			return result;
		}
	}
}

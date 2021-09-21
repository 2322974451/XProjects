using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F17 RID: 3863
	internal class XStringDefineProxy
	{
		// Token: 0x0600CCE6 RID: 52454 RVA: 0x002F3904 File Offset: 0x002F1B04
		public static string GetString(string key)
		{
			return XSingleton<XStringTable>.singleton.GetString(key);
		}

		// Token: 0x0600CCE7 RID: 52455 RVA: 0x002F3924 File Offset: 0x002F1B24
		public static string GetString(string key, params object[] args)
		{
			string value = "";
			bool data = XSingleton<XStringTable>.singleton.GetData(key, out value);
			return XStringDefineProxy.GetString(key, value, data, args);
		}

		// Token: 0x0600CCE8 RID: 52456 RVA: 0x002F3954 File Offset: 0x002F1B54
		public static string GetReplaceString(string key, params object[] args)
		{
			string text = "";
			bool data = XSingleton<XStringTable>.singleton.GetData(key, out text);
			text = XSingleton<UiUtility>.singleton.ReplaceReturn(text);
			return XStringDefineProxy.GetString(key, text, data, args);
		}

		// Token: 0x0600CCE9 RID: 52457 RVA: 0x002F3990 File Offset: 0x002F1B90
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

		// Token: 0x0600CCEA RID: 52458 RVA: 0x002F3A34 File Offset: 0x002F1C34
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

		// Token: 0x0600CCEB RID: 52459 RVA: 0x002F3AA4 File Offset: 0x002F1CA4
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

		// Token: 0x0600CCEC RID: 52460 RVA: 0x002F3B14 File Offset: 0x002F1D14
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

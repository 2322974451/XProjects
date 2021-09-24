using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{

	public class UniqueString
	{

		public static string Intern(string str, bool removable = true)
		{
			bool flag = str == null;
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				string text = UniqueString.IsInterned(str);
				bool flag2 = text != null;
				if (flag2)
				{
					result = text;
				}
				else if (removable)
				{
					UniqueString.m_strings.Add(str, str);
					result = str;
				}
				else
				{
					result = string.Intern(str);
				}
			}
			return result;
		}

		public static string IsInterned(string str)
		{
			bool flag = str == null;
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				string text = string.IsInterned(str);
				bool flag2 = text != null;
				if (flag2)
				{
					result = text;
				}
				else
				{
					bool flag3 = UniqueString.m_strings.TryGetValue(str, out text);
					if (flag3)
					{
						result = text;
					}
					else
					{
						result = null;
					}
				}
			}
			return result;
		}

		public static void Clear()
		{
			UniqueString.m_strings.Clear();
		}

		private static Dictionary<string, string> m_strings = new Dictionary<string, string>();
	}
}

using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	// Token: 0x0200019A RID: 410
	public class UniqueString
	{
		// Token: 0x060008E1 RID: 2273 RVA: 0x0002F3D4 File Offset: 0x0002D5D4
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

		// Token: 0x060008E2 RID: 2274 RVA: 0x0002F428 File Offset: 0x0002D628
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

		// Token: 0x060008E3 RID: 2275 RVA: 0x0002F471 File Offset: 0x0002D671
		public static void Clear()
		{
			UniqueString.m_strings.Clear();
		}

		// Token: 0x04000404 RID: 1028
		private static Dictionary<string, string> m_strings = new Dictionary<string, string>();
	}
}

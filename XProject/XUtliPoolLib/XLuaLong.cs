using System;

namespace XUtliPoolLib
{

	public class XLuaLong
	{

		public XLuaLong(string _str)
		{
			this.str = _str;
		}

		public ulong Get()
		{
			bool flag = string.IsNullOrEmpty(this.str);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("", null, null, null, null, null);
			}
			return ulong.Parse(this.str);
		}

		public string str;
	}
}

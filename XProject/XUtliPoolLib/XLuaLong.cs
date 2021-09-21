using System;

namespace XUtliPoolLib
{
	// Token: 0x02000217 RID: 535
	public class XLuaLong
	{
		// Token: 0x06000C03 RID: 3075 RVA: 0x0003EA91 File Offset: 0x0003CC91
		public XLuaLong(string _str)
		{
			this.str = _str;
		}

		// Token: 0x06000C04 RID: 3076 RVA: 0x0003EAA4 File Offset: 0x0003CCA4
		public ulong Get()
		{
			bool flag = string.IsNullOrEmpty(this.str);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("", null, null, null, null, null);
			}
			return ulong.Parse(this.str);
		}

		// Token: 0x04000745 RID: 1861
		public string str;
	}
}

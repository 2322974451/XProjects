using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DC7 RID: 3527
	internal class XSysDefineMgr
	{
		// Token: 0x0600C015 RID: 49173 RVA: 0x002853A0 File Offset: 0x002835A0
		public static int GetTypeInt(XSysDefine eType)
		{
			return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(eType);
		}
	}
}

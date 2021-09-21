using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000997 RID: 2455
	internal class ExpBackTypeMgr
	{
		// Token: 0x060093F1 RID: 37873 RVA: 0x0015B910 File Offset: 0x00159B10
		public static int GetTypeInt(ExpBackType _type)
		{
			return XFastEnumIntEqualityComparer<ExpBackType>.ToInt(_type);
		}
	}
}

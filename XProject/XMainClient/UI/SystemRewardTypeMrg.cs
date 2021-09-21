using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200170F RID: 5903
	internal class SystemRewardTypeMrg
	{
		// Token: 0x0600F3BA RID: 62394 RVA: 0x00367308 File Offset: 0x00365508
		public static uint GetTypeUInt(SystemRewardType _type)
		{
			return (uint)XFastEnumIntEqualityComparer<SystemRewardType>.ToInt(_type);
		}
	}
}

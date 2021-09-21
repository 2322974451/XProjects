using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001232 RID: 4658
	internal class Process_PtcG2C_FightGroupChangeNtf
	{
		// Token: 0x0600DD96 RID: 56726 RVA: 0x0033218C File Offset: 0x0033038C
		public static void Process(PtcG2C_FightGroupChangeNtf roPtc)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(roPtc.Data.uid);
			bool flag = entity != null;
			if (flag)
			{
				entity.Attributes.OnFightGroupChange(roPtc.Data.fightgroup);
			}
		}
	}
}

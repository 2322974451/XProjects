using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020010A9 RID: 4265
	internal class Process_PtcG2C_BuffNotify
	{
		// Token: 0x0600D763 RID: 55139 RVA: 0x00327CD4 File Offset: 0x00325ED4
		public static void Process(PtcG2C_BuffNotify roPtc)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(roPtc.Data.uid);
			bool flag = entity != null && !entity.Deprecated && entity.Buffs != null;
			if (flag)
			{
				bool flag2 = roPtc.Data.removebuff != null;
				if (flag2)
				{
					entity.Buffs.RemoveBuffByServer(roPtc.Data.removebuff);
					BuffInfo buffInfo = roPtc.Data.removebuff;
				}
				bool flag3 = roPtc.Data.allbuffsinfo != null;
				if (flag3)
				{
					entity.Buffs.SetServerAllBuffsInfo(roPtc.Data.allbuffsinfo);
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("All buff data is missing, UID = ", roPtc.Data.uid.ToString(), null, null, null, null);
				}
				bool flag4 = roPtc.Data.addbuff != null;
				if (flag4)
				{
					entity.Buffs.AddBuffByServer(roPtc.Data.addbuff);
					BuffInfo buffInfo = roPtc.Data.addbuff;
				}
				bool flag5 = roPtc.Data.updatebuff != null;
				if (flag5)
				{
					entity.Buffs.UpdateBuffByServer(roPtc.Data.updatebuff);
					BuffInfo buffInfo = roPtc.Data.updatebuff;
				}
			}
		}
	}
}

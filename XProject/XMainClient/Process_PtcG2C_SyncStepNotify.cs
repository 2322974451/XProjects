using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200111B RID: 4379
	internal class Process_PtcG2C_SyncStepNotify
	{
		// Token: 0x0600D931 RID: 55601 RVA: 0x0032AA9C File Offset: 0x00328C9C
		public static void Process(PtcG2C_SyncStepNotify roPtc)
		{
			for (int i = 0; i < roPtc.Data.DataList.Count; i++)
			{
				XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(roPtc.Data.DataList[i].EntityID);
				bool flag = entityConsiderDeath == null;
				if (!flag)
				{
					XSingleton<XActionReceiver>.singleton.OnActionReceived(entityConsiderDeath, roPtc.Data.DataList[i]);
				}
			}
		}
	}
}

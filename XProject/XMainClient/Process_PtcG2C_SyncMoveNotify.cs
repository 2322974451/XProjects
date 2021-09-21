using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020013BE RID: 5054
	internal class Process_PtcG2C_SyncMoveNotify
	{
		// Token: 0x0600E3F5 RID: 58357 RVA: 0x0033B0E4 File Offset: 0x003392E4
		public static void Process(PtcG2C_SyncMoveNotify roPtc)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(roPtc.Data.EntityID);
			bool flag = entity == null;
			if (!flag)
			{
				XSingleton<XActionReceiver>.singleton.OnMoveReceived(entity, roPtc.Data);
			}
		}
	}
}

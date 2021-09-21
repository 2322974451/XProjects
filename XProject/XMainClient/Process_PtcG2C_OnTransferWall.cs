using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020011B6 RID: 4534
	internal class Process_PtcG2C_OnTransferWall
	{
		// Token: 0x0600DBA1 RID: 56225 RVA: 0x0032F4E8 File Offset: 0x0032D6E8
		public static void Process(PtcG2C_OnTransferWall roPtc)
		{
			XOnEntityTransferEventArgs @event = XEventPool<XOnEntityTransferEventArgs>.GetEvent();
			@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}
	}
}

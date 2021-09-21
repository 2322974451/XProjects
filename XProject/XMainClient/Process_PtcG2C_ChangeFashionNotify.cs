using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001034 RID: 4148
	internal class Process_PtcG2C_ChangeFashionNotify
	{
		// Token: 0x0600D57D RID: 54653 RVA: 0x003242E8 File Offset: 0x003224E8
		public static void Process(PtcG2C_ChangeFashionNotify roPtc)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(roPtc.Data.roleID);
			bool flag = entity != null;
			if (flag)
			{
				XEquipChangeEventArgs @event = XEventPool<XEquipChangeEventArgs>.GetEvent();
				@event.ItemID = roPtc.Data.newItemID;
				@event.EquipPart = roPtc.Data.position;
				@event.Firer = entity;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}
	}
}

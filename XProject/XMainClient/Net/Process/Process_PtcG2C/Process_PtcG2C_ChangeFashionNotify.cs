using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_ChangeFashionNotify
	{

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

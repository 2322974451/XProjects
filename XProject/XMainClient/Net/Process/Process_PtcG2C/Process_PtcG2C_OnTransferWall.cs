using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_OnTransferWall
	{

		public static void Process(PtcG2C_OnTransferWall roPtc)
		{
			XOnEntityTransferEventArgs @event = XEventPool<XOnEntityTransferEventArgs>.GetEvent();
			@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}
	}
}

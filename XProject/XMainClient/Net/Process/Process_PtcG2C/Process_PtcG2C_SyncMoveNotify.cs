using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_SyncMoveNotify
	{

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

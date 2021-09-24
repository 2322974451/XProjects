using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_SyncStepNotify
	{

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

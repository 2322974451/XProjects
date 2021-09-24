using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_UnitDisappear
	{

		public static void Process(PtcG2C_UnitDisappear roPtc)
		{
			XEntity xentity = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(roPtc.Data.uID);
			bool flag = xentity != null && xentity.IsRole;
			if (flag)
			{
				XSingleton<XEntityMgr>.singleton.DestroyEntity(xentity);
			}
			else
			{
				xentity = XSingleton<XEntityMgr>.singleton.GetEntity(roPtc.Data.uID);
				bool flag2 = xentity != null;
				if (flag2)
				{
					XSingleton<XEntityMgr>.singleton.DestroyEntity(xentity);
				}
			}
		}
	}
}

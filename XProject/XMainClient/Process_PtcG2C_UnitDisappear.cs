using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001004 RID: 4100
	internal class Process_PtcG2C_UnitDisappear
	{
		// Token: 0x0600D4BA RID: 54458 RVA: 0x00321D98 File Offset: 0x0031FF98
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

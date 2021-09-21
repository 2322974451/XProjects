using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020015CE RID: 5582
	internal class Player_academic_buff_fuhuo
	{
		// Token: 0x0600EC62 RID: 60514 RVA: 0x00347040 File Offset: 0x00345240
		public static bool ReviveAlly(XSkill skill)
		{
			return true;
		}

		// Token: 0x0600EC63 RID: 60515 RVA: 0x00347054 File Offset: 0x00345254
		public static bool ExternalCanCast()
		{
			List<XEntity> ally = XSingleton<XEntityMgr>.singleton.GetAlly(XSingleton<XEntityMgr>.singleton.Player);
			for (int i = 0; i < ally.Count; i++)
			{
				bool flag = ally[i].IsRole && !ally[i].IsPlayer && ally[i].IsDead;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}
	}
}

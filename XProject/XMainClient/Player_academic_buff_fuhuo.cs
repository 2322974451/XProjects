using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Player_academic_buff_fuhuo
	{

		public static bool ReviveAlly(XSkill skill)
		{
			return true;
		}

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

using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020010C3 RID: 4291
	internal class Player_warrior_charge
	{
		// Token: 0x0600D7C4 RID: 55236 RVA: 0x00328A38 File Offset: 0x00326C38
		public static bool checkInput(XSkill skill)
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			bool result;
			if (syncMode)
			{
				result = true;
			}
			else
			{
				bool flag = skill.Firer.IsPlayer && skill.Casting;
				if (flag)
				{
					bool flag2 = !XSingleton<XVirtualTab>.singleton.Feeding;
					if (flag2)
					{
						skill.Cease(true);
					}
				}
				result = true;
			}
			return result;
		}
	}
}

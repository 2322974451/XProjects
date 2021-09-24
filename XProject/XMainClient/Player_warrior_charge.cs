using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Player_warrior_charge
	{

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

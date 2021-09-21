using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020010C2 RID: 4290
	internal class Player_warrior_dash_start
	{
		// Token: 0x0600D7C1 RID: 55233 RVA: 0x00328960 File Offset: 0x00326B60
		public static bool canfirecharge(XSkill skill)
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			bool result;
			if (syncMode)
			{
				result = true;
			}
			else
			{
				XCombinedSkill xcombinedSkill = skill as XCombinedSkill;
				bool isPlayer = skill.Firer.IsPlayer;
				if (isPlayer)
				{
					XSkillCore skill2 = skill.Firer.SkillMgr.GetSkill(XSingleton<XCommon>.singleton.XHash(xcombinedSkill.MainCore.Soul.Combined[2].Name));
					bool flag = (skill2 != null && Player_warrior_dash_start.NoFire(skill.Firer, skill2)) || !XSingleton<XVirtualTab>.singleton.Feeding;
					if (flag)
					{
						xcombinedSkill.ShutDown();
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600D7C2 RID: 55234 RVA: 0x00328A0C File Offset: 0x00326C0C
		private static bool NoFire(XEntity entity, XSkillCore core)
		{
			bool isTransform = entity.IsTransform;
			return !isTransform && core.Level == 0U;
		}
	}
}

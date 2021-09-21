using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020015B8 RID: 5560
	internal class Process_PtcG2C_WarningRandomNtf
	{
		// Token: 0x0600EC05 RID: 60421 RVA: 0x00346800 File Offset: 0x00344A00
		public static void Process(PtcG2C_WarningRandomNtf roPtc)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(roPtc.Data.Firer);
			bool flag = entity == null;
			if (!flag)
			{
				XSkillCore skill = entity.SkillMgr.GetSkill(roPtc.Data.skill);
				bool flag2 = skill != null;
				if (flag2)
				{
					skill.BuildRandomWarningPos(roPtc.Data.WarningItems);
				}
			}
		}
	}
}

using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_WarningRandomNtf
	{

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

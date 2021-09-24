using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_CdCall
	{

		public static void Process(PtcG2C_CdCall roPtc)
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Player != null;
			if (flag)
			{
				XSkillCore skill = XSingleton<XEntityMgr>.singleton.Player.SkillMgr.GetSkill(roPtc.Data.skillid);
				bool flag2 = skill != null;
				if (flag2)
				{
					skill.OnCdCall(roPtc.Data.leftrunningtimeSpecified ? roPtc.Data.leftrunningtime : 0, roPtc.Data.onsyntonicSpecified);
					XSingleton<XEntityMgr>.singleton.Player.Net.LastReqSkill = skill.ID;
				}
			}
		}
	}
}

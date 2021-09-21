using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020013B1 RID: 5041
	internal class Process_PtcG2C_CdCall
	{
		// Token: 0x0600E3C2 RID: 58306 RVA: 0x0033AC08 File Offset: 0x00338E08
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

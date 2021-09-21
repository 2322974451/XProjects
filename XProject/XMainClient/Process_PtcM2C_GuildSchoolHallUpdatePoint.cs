using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200169D RID: 5789
	internal class Process_PtcM2C_GuildSchoolHallUpdatePoint
	{
		// Token: 0x0600EFCB RID: 61387 RVA: 0x0034BE68 File Offset: 0x0034A068
		public static void Process(PtcM2C_GuildSchoolHallUpdatePoint roPtc)
		{
			XGuildGrowthDocument specificDocument = XDocuments.GetSpecificDocument<XGuildGrowthDocument>(XGuildGrowthDocument.uuID);
			specificDocument.SetPoint(roPtc.Data.hallpoint, roPtc.Data.schoolpoint);
			bool flag = roPtc.Data.roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			if (flag)
			{
				specificDocument.CheckShowItemGet(roPtc.Data.deltahallpoint, roPtc.Data.deltaschoolpoint);
			}
		}
	}
}

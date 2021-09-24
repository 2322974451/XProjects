using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcM2C_GuildSchoolHallUpdatePoint
	{

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

using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200143A RID: 5178
	internal class Process_PtcM2C_NoticeGuildTerrall
	{
		// Token: 0x0600E5F1 RID: 58865 RVA: 0x0033DA4C File Offset: 0x0033BC4C
		public static void Process(PtcM2C_NoticeGuildTerrall roPtc)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("PtcM2C_NoticeGuildTerrall:", roPtc.Data.num.ToString(), null, null, null, null);
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.bHavaTerritoryRecCount = roPtc.Data.num;
		}
	}
}

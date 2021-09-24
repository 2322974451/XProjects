using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcM2C_NoticeGuildTerrall
	{

		public static void Process(PtcM2C_NoticeGuildTerrall roPtc)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("PtcM2C_NoticeGuildTerrall:", roPtc.Data.num.ToString(), null, null, null, null);
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.bHavaTerritoryRecCount = roPtc.Data.num;
		}
	}
}

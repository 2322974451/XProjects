using System;

namespace XMainClient
{

	internal class Process_PtcM2C_NoticeGuildTerrEnd
	{

		public static void Process(PtcM2C_NoticeGuildTerrEnd roPtc)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.bHavaShowMessageIcon = true;
		}
	}
}

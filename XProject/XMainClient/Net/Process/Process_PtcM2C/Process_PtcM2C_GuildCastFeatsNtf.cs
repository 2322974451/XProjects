using System;

namespace XMainClient
{

	internal class Process_PtcM2C_GuildCastFeatsNtf
	{

		public static void Process(PtcM2C_GuildCastFeatsNtf roPtc)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.OnFeatsChange(roPtc.Data.feats);
		}
	}
}

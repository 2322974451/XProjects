using System;

namespace XMainClient
{
	// Token: 0x02001666 RID: 5734
	internal class Process_PtcM2C_GuildCastFeatsNtf
	{
		// Token: 0x0600EEE3 RID: 61155 RVA: 0x0034A67C File Offset: 0x0034887C
		public static void Process(PtcM2C_GuildCastFeatsNtf roPtc)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.OnFeatsChange(roPtc.Data.feats);
		}
	}
}

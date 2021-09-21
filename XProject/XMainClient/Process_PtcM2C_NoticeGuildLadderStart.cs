using System;

namespace XMainClient
{
	// Token: 0x020012EE RID: 4846
	internal class Process_PtcM2C_NoticeGuildLadderStart
	{
		// Token: 0x0600E0A3 RID: 57507 RVA: 0x00336604 File Offset: 0x00334804
		public static void Process(PtcM2C_NoticeGuildLadderStart roPtc)
		{
			XGuildQualifierDocument specificDocument = XDocuments.GetSpecificDocument<XGuildQualifierDocument>(XGuildQualifierDocument.uuID);
			specificDocument.bHasAvailableLadderIcon = roPtc.Data.isstart;
		}
	}
}

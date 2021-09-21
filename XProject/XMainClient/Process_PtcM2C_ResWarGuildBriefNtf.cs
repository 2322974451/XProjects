using System;

namespace XMainClient
{
	// Token: 0x02001365 RID: 4965
	internal class Process_PtcM2C_ResWarGuildBriefNtf
	{
		// Token: 0x0600E288 RID: 57992 RVA: 0x00339320 File Offset: 0x00337520
		public static void Process(PtcM2C_ResWarGuildBriefNtf roPtc)
		{
			XGuildMineMainDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
			specificDocument.SetNewInfo(roPtc);
		}
	}
}

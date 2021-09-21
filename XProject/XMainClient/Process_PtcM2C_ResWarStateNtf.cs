using System;

namespace XMainClient
{
	// Token: 0x02001378 RID: 4984
	internal class Process_PtcM2C_ResWarStateNtf
	{
		// Token: 0x0600E2D8 RID: 58072 RVA: 0x00339A30 File Offset: 0x00337C30
		public static void Process(PtcM2C_ResWarStateNtf roPtc)
		{
			XGuildMineMainDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
			specificDocument.TeamLeaderOperate(roPtc);
		}
	}
}

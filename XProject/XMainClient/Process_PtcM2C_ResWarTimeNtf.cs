using System;

namespace XMainClient
{
	// Token: 0x020013BC RID: 5052
	internal class Process_PtcM2C_ResWarTimeNtf
	{
		// Token: 0x0600E3EE RID: 58350 RVA: 0x0033B06C File Offset: 0x0033926C
		public static void Process(PtcM2C_ResWarTimeNtf roPtc)
		{
			XGuildMineMainDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
			specificDocument.ActivityStatusChange(roPtc);
		}
	}
}

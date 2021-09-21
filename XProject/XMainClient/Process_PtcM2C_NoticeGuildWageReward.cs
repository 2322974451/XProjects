using System;

namespace XMainClient
{
	// Token: 0x02001349 RID: 4937
	internal class Process_PtcM2C_NoticeGuildWageReward
	{
		// Token: 0x0600E219 RID: 57881 RVA: 0x003388CC File Offset: 0x00336ACC
		public static void Process(PtcM2C_NoticeGuildWageReward roPtc)
		{
			XGuildSalaryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSalaryDocument>(XGuildSalaryDocument.uuID);
			specificDocument.HasRedPoint = true;
		}
	}
}

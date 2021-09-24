using System;

namespace XMainClient
{

	internal class Process_PtcM2C_NoticeGuildWageReward
	{

		public static void Process(PtcM2C_NoticeGuildWageReward roPtc)
		{
			XGuildSalaryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSalaryDocument>(XGuildSalaryDocument.uuID);
			specificDocument.HasRedPoint = true;
		}
	}
}

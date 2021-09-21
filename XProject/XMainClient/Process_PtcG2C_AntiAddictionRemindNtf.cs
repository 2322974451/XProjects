using System;

namespace XMainClient
{
	// Token: 0x020013C5 RID: 5061
	internal class Process_PtcG2C_AntiAddictionRemindNtf
	{
		// Token: 0x0600E411 RID: 58385 RVA: 0x0033B304 File Offset: 0x00339504
		public static void Process(PtcG2C_AntiAddictionRemindNtf roPtc)
		{
			AdditionRemindDocument specificDocument = XDocuments.GetSpecificDocument<AdditionRemindDocument>(AdditionRemindDocument.uuID);
			bool flag = specificDocument != null;
			if (flag)
			{
				specificDocument.OnRecieveAdditionTip(roPtc.Data.remindmsg);
			}
		}
	}
}

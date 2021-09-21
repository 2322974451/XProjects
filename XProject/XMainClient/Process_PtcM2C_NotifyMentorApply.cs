using System;

namespace XMainClient
{
	// Token: 0x020013DD RID: 5085
	internal class Process_PtcM2C_NotifyMentorApply
	{
		// Token: 0x0600E473 RID: 58483 RVA: 0x0033BC54 File Offset: 0x00339E54
		public static void Process(PtcM2C_NotifyMentorApply roPtc)
		{
			XMentorshipDocument.Doc.OnGetMentorshipNotify(roPtc);
		}
	}
}

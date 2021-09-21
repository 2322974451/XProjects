using System;

namespace XMainClient
{
	// Token: 0x020015A3 RID: 5539
	internal class Process_PtcM2C_NotifyMarriageApply
	{
		// Token: 0x0600EBB4 RID: 60340 RVA: 0x003462B0 File Offset: 0x003444B0
		public static void Process(PtcM2C_NotifyMarriageApply roPtc)
		{
			XWeddingDocument.Doc.OnGetMarriageApplyNotify(roPtc);
		}
	}
}

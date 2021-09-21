using System;

namespace XMainClient
{
	// Token: 0x020015A1 RID: 5537
	internal class Process_PtcM2C_WeddingInviteNtf
	{
		// Token: 0x0600EBAD RID: 60333 RVA: 0x0034624C File Offset: 0x0034444C
		public static void Process(PtcM2C_WeddingInviteNtf roPtc)
		{
			XWeddingDocument.Doc.WeddingInviteNtf(roPtc);
		}
	}
}

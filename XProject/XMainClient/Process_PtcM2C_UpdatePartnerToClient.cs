using System;

namespace XMainClient
{
	// Token: 0x020013EB RID: 5099
	internal class Process_PtcM2C_UpdatePartnerToClient
	{
		// Token: 0x0600E4AF RID: 58543 RVA: 0x0033C00C File Offset: 0x0033A20C
		public static void Process(PtcM2C_UpdatePartnerToClient roPtc)
		{
			XPartnerDocument.Doc.UpdatePartnerToClient(roPtc);
		}
	}
}

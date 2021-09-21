using System;

namespace XMainClient
{
	// Token: 0x020012A0 RID: 4768
	internal class Process_PtcM2C_NotifyIdipMessageMs
	{
		// Token: 0x0600DF61 RID: 57185 RVA: 0x00334854 File Offset: 0x00332A54
		public static void Process(PtcM2C_NotifyIdipMessageMs roPtc)
		{
			XIDIPDocument specificDocument = XDocuments.GetSpecificDocument<XIDIPDocument>(XIDIPDocument.uuID);
			specificDocument.DealWithIDIPMessage(roPtc.Data);
		}
	}
}

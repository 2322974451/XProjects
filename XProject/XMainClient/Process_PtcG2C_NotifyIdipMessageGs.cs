using System;

namespace XMainClient
{
	// Token: 0x0200129E RID: 4766
	internal class Process_PtcG2C_NotifyIdipMessageGs
	{
		// Token: 0x0600DF5A RID: 57178 RVA: 0x003347D8 File Offset: 0x003329D8
		public static void Process(PtcG2C_NotifyIdipMessageGs roPtc)
		{
			XIDIPDocument specificDocument = XDocuments.GetSpecificDocument<XIDIPDocument>(XIDIPDocument.uuID);
			specificDocument.DealWithIDIPMessage(roPtc.Data);
		}
	}
}

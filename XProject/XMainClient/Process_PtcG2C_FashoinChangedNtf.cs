using System;

namespace XMainClient
{
	// Token: 0x0200106D RID: 4205
	internal class Process_PtcG2C_FashoinChangedNtf
	{
		// Token: 0x0600D66C RID: 54892 RVA: 0x003260E0 File Offset: 0x003242E0
		public static void Process(PtcG2C_FashoinChangedNtf roPtc)
		{
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			specificDocument.UpdateFashionData(roPtc.Data);
		}
	}
}

using System;

namespace XMainClient
{
	// Token: 0x020012C9 RID: 4809
	internal class Process_PtcG2C_HallIconSNtf
	{
		// Token: 0x0600E00A RID: 57354 RVA: 0x003357C8 File Offset: 0x003339C8
		public static void Process(PtcG2C_HallIconSNtf roPtc)
		{
			XMainInterfaceDocument specificDocument = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
			specificDocument.OnHallIconNtfGet(roPtc.Data);
		}
	}
}

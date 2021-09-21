using System;

namespace XMainClient
{
	// Token: 0x02001398 RID: 5016
	internal class Process_PtcM2C_HallIconMNtf
	{
		// Token: 0x0600E35B RID: 58203 RVA: 0x0033A3FC File Offset: 0x003385FC
		public static void Process(PtcM2C_HallIconMNtf roPtc)
		{
			XMainInterfaceDocument specificDocument = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
			specificDocument.OnHallIconNtfGet(roPtc.Data);
		}
	}
}

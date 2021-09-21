using System;

namespace XMainClient
{
	// Token: 0x020012B4 RID: 4788
	internal class Process_PtcM2C_DERankChangNtf
	{
		// Token: 0x0600DFAF RID: 57263 RVA: 0x00334F54 File Offset: 0x00333154
		public static void Process(PtcM2C_DERankChangNtf roPtc)
		{
			XDragonCrusadeDocument specificDocument = XDocuments.GetSpecificDocument<XDragonCrusadeDocument>(XDragonCrusadeDocument.uuID);
			specificDocument.OnNotifyResult(roPtc.Data);
		}
	}
}

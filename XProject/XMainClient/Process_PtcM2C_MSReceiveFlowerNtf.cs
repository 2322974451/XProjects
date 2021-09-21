using System;

namespace XMainClient
{
	// Token: 0x020011F0 RID: 4592
	internal class Process_PtcM2C_MSReceiveFlowerNtf
	{
		// Token: 0x0600DC88 RID: 56456 RVA: 0x00330828 File Offset: 0x0032EA28
		public static void Process(PtcM2C_MSReceiveFlowerNtf roPtc)
		{
			XFlowerReplyDocument specificDocument = XDocuments.GetSpecificDocument<XFlowerReplyDocument>(XFlowerReplyDocument.uuID);
			specificDocument.OnReceiveFlower(roPtc.Data);
		}
	}
}

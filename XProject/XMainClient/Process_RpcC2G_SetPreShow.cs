using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001602 RID: 5634
	internal class Process_RpcC2G_SetPreShow
	{
		// Token: 0x0600ED39 RID: 60729 RVA: 0x00348110 File Offset: 0x00346310
		public static void OnReply(SetPreShowArg oArg, SetPreShowRes oRes)
		{
			XPrerogativeDocument specificDocument = XDocuments.GetSpecificDocument<XPrerogativeDocument>(XPrerogativeDocument.uuID);
			specificDocument.ReceivePreCache(oArg, oRes);
		}

		// Token: 0x0600ED3A RID: 60730 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SetPreShowArg oArg)
		{
		}
	}
}

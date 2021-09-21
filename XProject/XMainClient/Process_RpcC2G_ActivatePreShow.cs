using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200165A RID: 5722
	internal class Process_RpcC2G_ActivatePreShow
	{
		// Token: 0x0600EEB6 RID: 61110 RVA: 0x0034A2C8 File Offset: 0x003484C8
		public static void OnReply(ActivatePreShowArg oArg, ActivatePreShowRes oRes)
		{
			XPrerogativeDocument specificDocument = XDocuments.GetSpecificDocument<XPrerogativeDocument>(XPrerogativeDocument.uuID);
			specificDocument.ReceiveActiveReply(oArg, oRes);
		}

		// Token: 0x0600EEB7 RID: 61111 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ActivatePreShowArg oArg)
		{
		}
	}
}

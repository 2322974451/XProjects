using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001386 RID: 4998
	internal class Process_RpcC2G_JustDance
	{
		// Token: 0x0600E30E RID: 58126 RVA: 0x00339DF0 File Offset: 0x00337FF0
		public static void OnReply(JustDanceArg oArg, JustDanceRes oRes)
		{
			XDanceDocument specificDocument = XDocuments.GetSpecificDocument<XDanceDocument>(XDanceDocument.uuID);
			specificDocument.OnJustDance(oArg, oRes);
		}

		// Token: 0x0600E30F RID: 58127 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(JustDanceArg oArg)
		{
		}
	}
}

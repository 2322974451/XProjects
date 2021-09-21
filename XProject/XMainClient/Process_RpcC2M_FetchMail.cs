using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000B6A RID: 2922
	internal class Process_RpcC2M_FetchMail
	{
		// Token: 0x0600A91E RID: 43294 RVA: 0x001E1A78 File Offset: 0x001DFC78
		public static void OnReply(FetchMailArg oArg, FetchMailRes oRes)
		{
			bool flag = oRes == null;
			if (!flag)
			{
				XMailDocument specificDocument = XDocuments.GetSpecificDocument<XMailDocument>(XMailDocument.uuID);
				specificDocument.ResMailInfo(oRes);
			}
		}

		// Token: 0x0600A91F RID: 43295 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(FetchMailArg oArg)
		{
		}
	}
}

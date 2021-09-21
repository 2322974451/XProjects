using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001210 RID: 4624
	internal class Process_RpcC2G_TitleLevelUp
	{
		// Token: 0x0600DD08 RID: 56584 RVA: 0x00331218 File Offset: 0x0032F418
		public static void OnReply(TitleLevelUpArg oArg, TitleLevelUpRes oRes)
		{
			XTitleDocument specificDocument = XDocuments.GetSpecificDocument<XTitleDocument>(XTitleDocument.uuID);
			specificDocument.OnGetTitleLevelUp(oRes);
		}

		// Token: 0x0600DD09 RID: 56585 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(TitleLevelUpArg oArg)
		{
		}
	}
}

using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020011C1 RID: 4545
	internal class Process_RpcC2G_QueryPowerPoint
	{
		// Token: 0x0600DBCA RID: 56266 RVA: 0x0032F7E0 File Offset: 0x0032D9E0
		public static void OnReply(QueryPowerPointArg oArg, QueryPowerPointRes oRes)
		{
			XFPStrengthenDocument specificDocument = XDocuments.GetSpecificDocument<XFPStrengthenDocument>(XFPStrengthenDocument.uuID);
			specificDocument.RefreshUi(oRes);
		}

		// Token: 0x0600DBCB RID: 56267 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(QueryPowerPointArg oArg)
		{
		}
	}
}

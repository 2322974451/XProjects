using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001252 RID: 4690
	internal class Process_RpcC2G_DEProgressReq
	{
		// Token: 0x0600DE1B RID: 56859 RVA: 0x00332D70 File Offset: 0x00330F70
		public static void OnReply(DEProgressArg oArg, DEProgressRes oRes)
		{
			XDragonCrusadeDocument specificDocument = XDocuments.GetSpecificDocument<XDragonCrusadeDocument>(XDragonCrusadeDocument.uuID);
			specificDocument.OnDEProgressReq(oRes);
			XActivityDocument.Doc.OnGetDayCount();
		}

		// Token: 0x0600DE1C RID: 56860 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(DEProgressArg oArg)
		{
		}
	}
}

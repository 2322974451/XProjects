using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020015C2 RID: 5570
	internal class Process_RpcC2G_DragonGroupRecord
	{
		// Token: 0x0600EC2D RID: 60461 RVA: 0x00346B50 File Offset: 0x00344D50
		public static void OnReply(DragonGroupRecordC2S oArg, DragonGroupRecordS2C oRes)
		{
			XDragonPartnerDocument specificDocument = XDocuments.GetSpecificDocument<XDragonPartnerDocument>(XDragonPartnerDocument.uuID);
			specificDocument.ReceiveDragonGroupRecord(oArg, oRes);
		}

		// Token: 0x0600EC2E RID: 60462 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(DragonGroupRecordC2S oArg)
		{
		}
	}
}

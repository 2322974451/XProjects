using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020010E8 RID: 4328
	internal class Process_RpcC2G_GetTowerActivityTop
	{
		// Token: 0x0600D85A RID: 55386 RVA: 0x003296B0 File Offset: 0x003278B0
		public static void OnReply(GetTowerActivityTopArg oArg, GetTowerActivityTopRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
			if (!flag)
			{
				XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
				specificDocument.GetSingleTowerActivityTopRes(oRes);
			}
		}

		// Token: 0x0600D85B RID: 55387 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetTowerActivityTopArg oArg)
		{
		}
	}
}

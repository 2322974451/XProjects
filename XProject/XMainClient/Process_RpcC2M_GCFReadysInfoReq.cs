using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001405 RID: 5125
	internal class Process_RpcC2M_GCFReadysInfoReq
	{
		// Token: 0x0600E519 RID: 58649 RVA: 0x0033C864 File Offset: 0x0033AA64
		public static void OnReply(GCFReadyInfoArg oArg, GCFReadyInfoRes oRes)
		{
			bool flag = oRes == null;
			if (!flag)
			{
				XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
				specificDocument.RespGCFReadysInfo(oRes);
			}
		}

		// Token: 0x0600E51A RID: 58650 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GCFReadyInfoArg oArg)
		{
		}
	}
}

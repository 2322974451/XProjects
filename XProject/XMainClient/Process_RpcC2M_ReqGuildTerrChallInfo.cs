using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001411 RID: 5137
	internal class Process_RpcC2M_ReqGuildTerrChallInfo
	{
		// Token: 0x0600E54B RID: 58699 RVA: 0x0033CBE0 File Offset: 0x0033ADE0
		public static void OnReply(ReqGuildTerrChallInfoArg oArg, ReqGuildTerrChallInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
				specificDocument.ReceiveGuildTerritoryChallInfo(oArg, oRes);
			}
		}

		// Token: 0x0600E54C RID: 58700 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ReqGuildTerrChallInfoArg oArg)
		{
		}
	}
}

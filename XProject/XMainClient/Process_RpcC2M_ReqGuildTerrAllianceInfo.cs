using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001413 RID: 5139
	internal class Process_RpcC2M_ReqGuildTerrAllianceInfo
	{
		// Token: 0x0600E554 RID: 58708 RVA: 0x0033CC9C File Offset: 0x0033AE9C
		public static void OnReply(ReqGuildTerrAllianceInfoArg oArg, ReqGuildTerrAllianceInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
				specificDocument.ReceiveGuildTerrAllianceInfo(oRes);
			}
		}

		// Token: 0x0600E555 RID: 58709 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ReqGuildTerrAllianceInfoArg oArg)
		{
		}
	}
}

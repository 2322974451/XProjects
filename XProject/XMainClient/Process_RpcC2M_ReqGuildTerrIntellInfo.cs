using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020014AF RID: 5295
	internal class Process_RpcC2M_ReqGuildTerrIntellInfo
	{
		// Token: 0x0600E7C8 RID: 59336 RVA: 0x00340848 File Offset: 0x0033EA48
		public static void OnReply(ReqGuildTerrIntellInfoArg oArg, ReqGuildTerrIntellInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
				specificDocument.ReceiveTerritoryInterllInfo(oRes);
			}
		}

		// Token: 0x0600E7C9 RID: 59337 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ReqGuildTerrIntellInfoArg oArg)
		{
		}
	}
}

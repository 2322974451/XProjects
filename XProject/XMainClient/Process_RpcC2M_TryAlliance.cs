using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200142E RID: 5166
	internal class Process_RpcC2M_TryAlliance
	{
		// Token: 0x0600E5C0 RID: 58816 RVA: 0x0033D5F8 File Offset: 0x0033B7F8
		public static void OnReply(TryAllianceArg oArg, TryAlliance oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
				specificDocument.ReceiveTryAlliance(oArg, oRes);
			}
		}

		// Token: 0x0600E5C1 RID: 58817 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(TryAllianceArg oArg)
		{
		}
	}
}

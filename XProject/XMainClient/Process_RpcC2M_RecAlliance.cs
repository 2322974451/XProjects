using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200142C RID: 5164
	internal class Process_RpcC2M_RecAlliance
	{
		// Token: 0x0600E5B7 RID: 58807 RVA: 0x0033D538 File Offset: 0x0033B738
		public static void OnReply(RecAllianceArg oArg, RecAllianceRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
				specificDocument.ReceiveRecAlliance(oArg, oRes);
			}
		}

		// Token: 0x0600E5B8 RID: 58808 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(RecAllianceArg oArg)
		{
		}
	}
}

using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001436 RID: 5174
	internal class Process_RpcC2M_ClearGuildTerrAlliance
	{
		// Token: 0x0600E5E2 RID: 58850 RVA: 0x0033D928 File Offset: 0x0033BB28
		public static void OnReply(ClearGuildTerrAllianceArg oArg, ClearGuildTerrAllianceRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
				specificDocument.ReceiveClearGuildTerrAlliance(oRes);
			}
		}

		// Token: 0x0600E5E3 RID: 58851 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ClearGuildTerrAllianceArg oArg)
		{
		}
	}
}

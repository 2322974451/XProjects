using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001421 RID: 5153
	internal class Process_RpcC2M_AllianceGuildTerr
	{
		// Token: 0x0600E58B RID: 58763 RVA: 0x0033D228 File Offset: 0x0033B428
		public static void OnReply(AllianceGuildTerrArg oArg, AllianceGuildTerrRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
				specificDocument.ReceiveAllianceGuildTerr(oArg, oRes);
			}
		}

		// Token: 0x0600E58C RID: 58764 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AllianceGuildTerrArg oArg)
		{
		}
	}
}

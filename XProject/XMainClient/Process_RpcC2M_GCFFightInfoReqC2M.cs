using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200142A RID: 5162
	internal class Process_RpcC2M_GCFFightInfoReqC2M
	{
		// Token: 0x0600E5AE RID: 58798 RVA: 0x0033D478 File Offset: 0x0033B678
		public static void OnReply(GCFFightInfoArg oArg, GCFFightInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
				specificDocument.RespGCFFightInfo(oRes);
			}
		}

		// Token: 0x0600E5AF RID: 58799 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GCFFightInfoArg oArg)
		{
		}
	}
}

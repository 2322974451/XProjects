using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200136D RID: 4973
	internal class Process_RpcC2M_GetGuildIntegralInfo
	{
		// Token: 0x0600E2AB RID: 58027 RVA: 0x00339628 File Offset: 0x00337828
		public static void OnReply(GetGuildIntegralInfoArg oArg, GetGuildIntegralInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
				specificDocument.ReceiveIntegralBattleInfo(oRes);
			}
		}

		// Token: 0x0600E2AC RID: 58028 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetGuildIntegralInfoArg oArg)
		{
		}
	}
}

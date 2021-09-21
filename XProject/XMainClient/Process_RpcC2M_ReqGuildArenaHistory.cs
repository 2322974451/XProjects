using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001380 RID: 4992
	internal class Process_RpcC2M_ReqGuildArenaHistory
	{
		// Token: 0x0600E2F7 RID: 58103 RVA: 0x00339C54 File Offset: 0x00337E54
		public static void OnReply(ReqGuildArenaHistoryRes oArg, ReqGuildArenaHistoryRse oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
				specificDocument.ReceiveGuildArenaHistory(oRes);
			}
		}

		// Token: 0x0600E2F8 RID: 58104 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ReqGuildArenaHistoryRes oArg)
		{
		}
	}
}

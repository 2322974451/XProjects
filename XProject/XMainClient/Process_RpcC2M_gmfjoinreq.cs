using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001316 RID: 4886
	internal class Process_RpcC2M_gmfjoinreq
	{
		// Token: 0x0600E148 RID: 57672 RVA: 0x003374FC File Offset: 0x003356FC
		public static void OnReply(gmfjoinarg oArg, gmfjoinres oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
				specificDocument.ReceiveGuildArenaJoinBattle(oRes);
			}
		}

		// Token: 0x0600E149 RID: 57673 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(gmfjoinarg oArg)
		{
		}
	}
}

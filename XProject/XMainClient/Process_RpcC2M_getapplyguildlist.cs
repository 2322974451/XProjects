using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001369 RID: 4969
	internal class Process_RpcC2M_getapplyguildlist
	{
		// Token: 0x0600E299 RID: 58009 RVA: 0x003394B0 File Offset: 0x003376B0
		public static void OnReply(getapplyguildlistarg oArg, getapplyguildlistres oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
				specificDocument.ReceiveApplyGuildList(oRes);
			}
		}

		// Token: 0x0600E29A RID: 58010 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(getapplyguildlistarg oArg)
		{
		}
	}
}

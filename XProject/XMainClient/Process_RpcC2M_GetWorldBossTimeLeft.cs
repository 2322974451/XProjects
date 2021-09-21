using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020011C7 RID: 4551
	internal class Process_RpcC2M_GetWorldBossTimeLeft
	{
		// Token: 0x0600DBE3 RID: 56291 RVA: 0x0032F9E0 File Offset: 0x0032DBE0
		public static void OnReply(GetWorldBossTimeLeftArg oArg, GetWorldBossTimeLeftRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
				specificDocument.OnGetBattleInfo(oRes);
			}
		}

		// Token: 0x0600DBE4 RID: 56292 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetWorldBossTimeLeftArg oArg)
		{
		}
	}
}

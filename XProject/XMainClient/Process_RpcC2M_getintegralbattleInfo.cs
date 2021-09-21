using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200136B RID: 4971
	internal class Process_RpcC2M_getintegralbattleInfo
	{
		// Token: 0x0600E2A2 RID: 58018 RVA: 0x0033956C File Offset: 0x0033776C
		public static void OnReply(getintegralbattleInfoarg oArg, getintegralbattleInfores oRes)
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

		// Token: 0x0600E2A3 RID: 58019 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(getintegralbattleInfoarg oArg)
		{
		}
	}
}

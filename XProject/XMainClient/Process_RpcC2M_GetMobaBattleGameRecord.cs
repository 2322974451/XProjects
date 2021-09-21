using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001548 RID: 5448
	internal class Process_RpcC2M_GetMobaBattleGameRecord
	{
		// Token: 0x0600EA39 RID: 59961 RVA: 0x00343E84 File Offset: 0x00342084
		public static void OnReply(GetMobaBattleGameRecordArg oArg, GetMobaBattleGameRecordRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				XMobaEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XMobaEntranceDocument>(XMobaEntranceDocument.uuID);
				specificDocument.SetMobaRecordRound(oArg, oRes);
			}
		}

		// Token: 0x0600EA3A RID: 59962 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetMobaBattleGameRecordArg oArg)
		{
		}
	}
}

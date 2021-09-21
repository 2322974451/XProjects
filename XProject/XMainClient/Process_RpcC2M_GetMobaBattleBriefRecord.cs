using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200154A RID: 5450
	internal class Process_RpcC2M_GetMobaBattleBriefRecord
	{
		// Token: 0x0600EA42 RID: 59970 RVA: 0x00343F44 File Offset: 0x00342144
		public static void OnReply(GetMobaBattleBriefRecordArg oArg, GetMobaBattleBriefRecordRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				XMobaEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XMobaEntranceDocument>(XMobaEntranceDocument.uuID);
				specificDocument.SetMobaRecordTotal(oArg, oRes);
			}
		}

		// Token: 0x0600EA43 RID: 59971 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetMobaBattleBriefRecordArg oArg)
		{
		}
	}
}

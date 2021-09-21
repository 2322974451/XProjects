using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001569 RID: 5481
	internal class Process_RpcC2M_GetMobaBattleInfo
	{
		// Token: 0x0600EABC RID: 60092 RVA: 0x00344BFC File Offset: 0x00342DFC
		public static void OnReply(GetMobaBattleInfoArg oArg, GetMobaBattleInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				XMobaEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XMobaEntranceDocument>(XMobaEntranceDocument.uuID);
				specificDocument.SetMobaUIInfo(oArg, oRes);
			}
		}

		// Token: 0x0600EABD RID: 60093 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetMobaBattleInfoArg oArg)
		{
		}
	}
}

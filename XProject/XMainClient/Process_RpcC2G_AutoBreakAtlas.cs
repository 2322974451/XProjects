using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001242 RID: 4674
	internal class Process_RpcC2G_AutoBreakAtlas
	{
		// Token: 0x0600DDD9 RID: 56793 RVA: 0x0033276C File Offset: 0x0033096C
		public static void OnReply(AutoBreakAtlasArg oArg, AutoBreakAtlasRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				XCardCollectDocument specificDocument = XDocuments.GetSpecificDocument<XCardCollectDocument>(XCardCollectDocument.uuID);
				specificDocument.OnAutoBreak(oArg, oRes);
			}
		}

		// Token: 0x0600DDDA RID: 56794 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AutoBreakAtlasArg oArg)
		{
		}
	}
}

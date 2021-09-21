using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001240 RID: 4672
	internal class Process_RpcC2G_ActivatAtlas
	{
		// Token: 0x0600DDD0 RID: 56784 RVA: 0x003326A0 File Offset: 0x003308A0
		public static void OnReply(ActivatAtlasArg oArg, ActivatAtlasRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				XCardCollectDocument specificDocument = XDocuments.GetSpecificDocument<XCardCollectDocument>(XCardCollectDocument.uuID);
				specificDocument.OnActive(oArg, oRes);
			}
		}

		// Token: 0x0600DDD1 RID: 56785 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ActivatAtlasArg oArg)
		{
		}
	}
}

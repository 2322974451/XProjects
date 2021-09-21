using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001244 RID: 4676
	internal class Process_RpcC2G_breakAtlas
	{
		// Token: 0x0600DDE2 RID: 56802 RVA: 0x00332838 File Offset: 0x00330A38
		public static void OnReply(breakAtlas oArg, breakAtlasRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				XCardCollectDocument specificDocument = XDocuments.GetSpecificDocument<XCardCollectDocument>(XCardCollectDocument.uuID);
				specificDocument.OnBreak(oArg, oRes);
			}
		}

		// Token: 0x0600DDE3 RID: 56803 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(breakAtlas oArg)
		{
		}
	}
}

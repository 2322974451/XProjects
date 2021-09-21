using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001256 RID: 4694
	internal class Process_RpcC2M_WorldBossEnd
	{
		// Token: 0x0600DE2D RID: 56877 RVA: 0x00332EDC File Offset: 0x003310DC
		public static void OnReply(WorldBossEndArg oArg, WorldBossEndRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
				specificDocument.OnWorldBossEnd(oArg, oRes);
			}
		}

		// Token: 0x0600DE2E RID: 56878 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(WorldBossEndArg oArg)
		{
		}
	}
}

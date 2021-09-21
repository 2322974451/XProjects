using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001292 RID: 4754
	internal class Process_RpcC2M_getguildbosstimeleft
	{
		// Token: 0x0600DF27 RID: 57127 RVA: 0x0033420C File Offset: 0x0033240C
		public static void OnReply(getguildbosstimeleftArg oArg, getguildbosstimeleftRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildDragonDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
				specificDocument.OnGetBattleInfo(oRes);
			}
		}

		// Token: 0x0600DF28 RID: 57128 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(getguildbosstimeleftArg oArg)
		{
		}
	}
}

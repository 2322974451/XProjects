using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001445 RID: 5189
	internal class Process_RpcC2G_GetGuildBonusLeft
	{
		// Token: 0x0600E61E RID: 58910 RVA: 0x0033DE58 File Offset: 0x0033C058
		public static void OnReply(GetGuildBonusLeftArg oArg, GetGuildBonusLeftRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildRedPacketDocument specificDocument = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
				specificDocument.ReceiveGuildBonusLeft(oRes);
			}
		}

		// Token: 0x0600E61F RID: 58911 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetGuildBonusLeftArg oArg)
		{
		}
	}
}

using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001359 RID: 4953
	internal class Process_RpcC2M_GetGuildBonusSendList
	{
		// Token: 0x0600E256 RID: 57942 RVA: 0x00338E20 File Offset: 0x00337020
		public static void OnReply(GetGuildBonusSendListArg oArg, GetGuildBonusSendListRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildRedPacketDocument specificDocument = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
				specificDocument.ReceiveGuildBonusSendList(oRes);
			}
		}

		// Token: 0x0600E257 RID: 57943 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetGuildBonusSendListArg oArg)
		{
		}
	}
}

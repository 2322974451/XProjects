using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200135B RID: 4955
	internal class Process_RpcC2M_SendGuildBonusInSendList
	{
		// Token: 0x0600E25F RID: 57951 RVA: 0x00338EDC File Offset: 0x003370DC
		public static void OnReply(SendGuildBonusInSendListArg oArg, SendGuildBonusInSendListRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildRedPacketDocument specificDocument = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
				specificDocument.ReceiveGuildBonusInSend(oArg, oRes);
			}
		}

		// Token: 0x0600E260 RID: 57952 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SendGuildBonusInSendListArg oArg)
		{
		}
	}
}

using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_SendGuildBonusInSendList
	{

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

		public static void OnTimeout(SendGuildBonusInSendListArg oArg)
		{
		}
	}
}

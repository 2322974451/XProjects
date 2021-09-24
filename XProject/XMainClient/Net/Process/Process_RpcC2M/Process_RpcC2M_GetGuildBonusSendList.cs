using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GetGuildBonusSendList
	{

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

		public static void OnTimeout(GetGuildBonusSendListArg oArg)
		{
		}
	}
}

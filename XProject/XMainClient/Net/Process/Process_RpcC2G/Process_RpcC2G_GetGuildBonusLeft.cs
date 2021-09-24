using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetGuildBonusLeft
	{

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

		public static void OnTimeout(GetGuildBonusLeftArg oArg)
		{
		}
	}
}

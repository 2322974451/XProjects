using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_ReqGuildArenaHistory
	{

		public static void OnReply(ReqGuildArenaHistoryRes oArg, ReqGuildArenaHistoryRse oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
				specificDocument.ReceiveGuildArenaHistory(oRes);
			}
		}

		public static void OnTimeout(ReqGuildArenaHistoryRes oArg)
		{
		}
	}
}

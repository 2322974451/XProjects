using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_gmfjoinreq
	{

		public static void OnReply(gmfjoinarg oArg, gmfjoinres oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
				specificDocument.ReceiveGuildArenaJoinBattle(oRes);
			}
		}

		public static void OnTimeout(gmfjoinarg oArg)
		{
		}
	}
}

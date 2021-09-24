using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GetGuildIntegralInfo
	{

		public static void OnReply(GetGuildIntegralInfoArg oArg, GetGuildIntegralInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
				specificDocument.ReceiveIntegralBattleInfo(oRes);
			}
		}

		public static void OnTimeout(GetGuildIntegralInfoArg oArg)
		{
		}
	}
}

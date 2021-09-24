using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_getintegralbattleInfo
	{

		public static void OnReply(getintegralbattleInfoarg oArg, getintegralbattleInfores oRes)
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

		public static void OnTimeout(getintegralbattleInfoarg oArg)
		{
		}
	}
}

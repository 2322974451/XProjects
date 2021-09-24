using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GetWorldBossTimeLeft
	{

		public static void OnReply(GetWorldBossTimeLeftArg oArg, GetWorldBossTimeLeftRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
				specificDocument.OnGetBattleInfo(oRes);
			}
		}

		public static void OnTimeout(GetWorldBossTimeLeftArg oArg)
		{
		}
	}
}

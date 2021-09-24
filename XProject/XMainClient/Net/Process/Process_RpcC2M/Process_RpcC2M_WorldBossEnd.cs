using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_WorldBossEnd
	{

		public static void OnReply(WorldBossEndArg oArg, WorldBossEndRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
				specificDocument.OnWorldBossEnd(oArg, oRes);
			}
		}

		public static void OnTimeout(WorldBossEndArg oArg)
		{
		}
	}
}

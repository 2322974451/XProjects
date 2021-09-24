using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_ReqGuildBossTimeLeft
	{

		public static void OnReply(getguildbosstimeleftArg oArg, getguildbosstimeleftRes oRes)
		{
			XGuildDragonDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
			specificDocument.OnGetBattleInfo(oRes);
		}

		public static void OnTimeout(getguildbosstimeleftArg oArg)
		{
		}
	}
}

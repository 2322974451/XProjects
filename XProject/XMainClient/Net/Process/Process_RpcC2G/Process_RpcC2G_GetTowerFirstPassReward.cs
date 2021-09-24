using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_GetTowerFirstPassReward
	{

		public static void OnReply(GetTowerFirstPassRewardArg oArg, GetTowerFirstPassRewardRes oRes)
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			specificDocument.GetFirstPassRewardRes(oRes.error);
		}

		public static void OnTimeout(GetTowerFirstPassRewardArg oArg)
		{
		}
	}
}

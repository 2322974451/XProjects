using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_GmfReadyReq
	{

		public static void OnReply(GmfReadyArg oArg, GmfReadyRes oRes)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnReadyReq(oRes);
		}

		public static void OnTimeout(GmfReadyArg oArg)
		{
		}
	}
}

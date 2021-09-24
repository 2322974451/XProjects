using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_InspireReq
	{

		public static void OnReply(InspireArg oArg, InspireRes oRes)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnInspireReq(oRes);
		}

		public static void OnTimeout(InspireArg oArg)
		{
		}
	}
}

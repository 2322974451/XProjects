using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_VsPayReviveReq
	{

		public static void OnReply(VsPayRevivePara oArg, VsPayReviveRes oRes)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.ReceiveVSPayRevive(oArg, oRes);
		}

		public static void OnTimeout(VsPayRevivePara oArg)
		{
		}
	}
}

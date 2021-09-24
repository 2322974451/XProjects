using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_ResWarAllInfoReqOne
	{

		public static void OnReply(ResWarArg oArg, ResWarRes oRes)
		{
			XGuildMineBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineBattleDocument>(XGuildMineBattleDocument.uuID);
			specificDocument.SetBattleAllInfo(oArg, oRes);
		}

		public static void OnTimeout(ResWarArg oArg)
		{
		}
	}
}

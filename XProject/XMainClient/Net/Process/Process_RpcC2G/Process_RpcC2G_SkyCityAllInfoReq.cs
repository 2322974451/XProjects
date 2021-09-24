using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_SkyCityAllInfoReq
	{

		public static void OnReply(SkyCityArg oArg, SkyCityRes oRes)
		{
			XSkyArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XSkyArenaBattleDocument>(XSkyArenaBattleDocument.uuID);
			specificDocument.SetBattleAllInfo(oArg, oRes);
		}

		public static void OnTimeout(SkyCityArg oArg)
		{
		}
	}
}

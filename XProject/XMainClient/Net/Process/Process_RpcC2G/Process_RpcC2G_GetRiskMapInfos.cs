using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_GetRiskMapInfos
	{

		public static void OnReply(GetRiskMapInfosArg oArg, GetRiskMapInfosRes oRes)
		{
			XSuperRiskDocument.Doc.OnGetMapDynamicInfo(oArg, oRes);
		}

		public static void OnTimeout(GetRiskMapInfosArg oArg)
		{
		}
	}
}

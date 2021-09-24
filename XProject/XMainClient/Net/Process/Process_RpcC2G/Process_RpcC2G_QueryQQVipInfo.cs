using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_QueryQQVipInfo
	{

		public static void OnReply(QueryQQVipInfoArg oArg, QueryQQVipInfoRes oRes)
		{
			XPlatformAbilityDocument specificDocument = XDocuments.GetSpecificDocument<XPlatformAbilityDocument>(XPlatformAbilityDocument.uuID);
			specificDocument.OnQueryQQVipInfo(oArg, oRes);
		}

		public static void OnTimeout(QueryQQVipInfoArg oArg)
		{
		}
	}
}

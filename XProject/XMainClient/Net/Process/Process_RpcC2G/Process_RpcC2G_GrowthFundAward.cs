using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_GrowthFundAward
	{

		public static void OnReply(GrowthFundAwardArg oArg, GrowthFundAwardRes oRes)
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			specificDocument.OnGetGrowthFundAward(oArg, oRes);
		}

		public static void OnTimeout(GrowthFundAwardArg oArg)
		{
		}
	}
}

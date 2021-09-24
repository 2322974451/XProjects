using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_PayCardAward
	{

		public static void OnReply(PayCardAwardArg oArg, PayCardAwardRes oRes)
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			specificDocument.OnGetCardDailyDiamond(oArg, oRes);
		}

		public static void OnTimeout(PayCardAwardArg oArg)
		{
		}
	}
}

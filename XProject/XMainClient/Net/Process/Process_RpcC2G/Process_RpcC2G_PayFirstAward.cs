using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_PayFirstAward
	{

		public static void OnReply(PayFirstAwardArg oArg, PayFirstAwardRes oRes)
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			specificDocument.OnGetPayFirstAward(oRes);
		}

		public static void OnTimeout(PayFirstAwardArg oArg)
		{
		}
	}
}

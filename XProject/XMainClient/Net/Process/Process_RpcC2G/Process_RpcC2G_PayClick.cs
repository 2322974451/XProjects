using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_PayClick
	{

		public static void OnReply(PayClickArg oArg, PayClickRes oRes)
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			specificDocument.RefreshFirstClickTabRedpoint(oArg, oRes);
		}

		public static void OnTimeout(PayClickArg oArg)
		{
		}
	}
}

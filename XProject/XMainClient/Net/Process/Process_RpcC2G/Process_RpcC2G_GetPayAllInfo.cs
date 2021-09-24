using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_GetPayAllInfo
	{

		public static void OnReply(GetPayAllInfoArg oArg, GetPayAllInfoRes oRes)
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			specificDocument.OnGetPayAllInfo(oArg, oRes);
			XRechargeDocument specificDocument2 = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			specificDocument2.OnGetPayAllInfo(oArg, oRes);
		}

		public static void OnTimeout(GetPayAllInfoArg oArg)
		{
		}
	}
}

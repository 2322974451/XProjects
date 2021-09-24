using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_GetPartnerInfo
	{

		public static void OnReply(GetPartnerInfoArg oArg, GetPartnerInfoRes oRes)
		{
			XPartnerDocument.Doc.OnGetPartnerInfoBack(oRes);
		}

		public static void OnTimeout(GetPartnerInfoArg oArg)
		{
		}
	}
}

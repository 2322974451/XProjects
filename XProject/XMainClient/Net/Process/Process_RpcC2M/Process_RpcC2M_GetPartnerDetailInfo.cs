using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_GetPartnerDetailInfo
	{

		public static void OnReply(GetPartnerDetailInfoArg oArg, GetPartnerDetailInfoRes oRes)
		{
			XPartnerDocument.Doc.OnGetPartDetailInfoBack(oRes);
		}

		public static void OnTimeout(GetPartnerDetailInfoArg oArg)
		{
		}
	}
}

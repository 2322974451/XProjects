using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_GetPartnerLiveness
	{

		public static void OnReply(GetPartnerLivenessArg oArg, GetPartnerLivenessRes oRes)
		{
			XPartnerDocument.PartnerLivenessData.OnGetPartnerLivenessInfoBack(oRes);
		}

		public static void OnTimeout(GetPartnerLivenessArg oArg)
		{
		}
	}
}

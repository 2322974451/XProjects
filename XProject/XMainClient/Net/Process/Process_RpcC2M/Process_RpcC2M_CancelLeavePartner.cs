using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_CancelLeavePartner
	{

		public static void OnReply(CancelLeavePartnerArg oArg, CancelLeavePartnerRes oRes)
		{
			XPartnerDocument.Doc.OnCancleLeavePartnerBack(oRes);
		}

		public static void OnTimeout(CancelLeavePartnerArg oArg)
		{
		}
	}
}

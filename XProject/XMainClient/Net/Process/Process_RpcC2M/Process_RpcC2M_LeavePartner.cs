using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_LeavePartner
	{

		public static void OnReply(LeavePartnerArg oArg, LeavePartnerRes oRes)
		{
			XPartnerDocument.Doc.OnLeavePartnerBack(oRes);
		}

		public static void OnTimeout(LeavePartnerArg oArg)
		{
		}
	}
}

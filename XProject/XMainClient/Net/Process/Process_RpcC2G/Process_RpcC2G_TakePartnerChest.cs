using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_TakePartnerChest
	{

		public static void OnReply(TakePartnerChestArg oArg, TakePartnerChestRes oRes)
		{
			XPartnerDocument.PartnerLivenessData.OnTakePartnerChestBack((int)oArg.index, oRes);
		}

		public static void OnTimeout(TakePartnerChestArg oArg)
		{
		}
	}
}

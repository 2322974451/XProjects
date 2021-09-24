using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_BuyExtraSkillEmblemSlot
	{

		public static void OnReply(BuyExtraSkillEmblemSlotArg oArg, BuyExtraSkillEmblemSlotRes oRes)
		{
			XEmblemDocument specificDocument = XDocuments.GetSpecificDocument<XEmblemDocument>(XEmblemDocument.uuID);
			specificDocument.OnEmbleSlottingBack(oRes);
		}

		public static void OnTimeout(BuyExtraSkillEmblemSlotArg oArg)
		{
		}
	}
}

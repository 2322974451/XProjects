using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_SynPetInfo
	{

		public static void OnReply(SynPetInfoArg oArg, SynPetInfoRes oRes)
		{
			XPetDocument specificDocument = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			specificDocument.OnPetInfo(oArg, oRes);
		}

		public static void OnTimeout(SynPetInfoArg oArg)
		{
		}
	}
}

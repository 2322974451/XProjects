using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_ModifyMsGuildName
	{

		public static void OnReply(ModifyArg oArg, ModifyRes oRes)
		{
			XRenameDocument specificDocument = XDocuments.GetSpecificDocument<XRenameDocument>(XRenameDocument.uuID);
			specificDocument.ReceiveGuildRenameVolume(oArg, oRes);
		}

		public static void OnTimeout(ModifyArg oArg)
		{
		}
	}
}

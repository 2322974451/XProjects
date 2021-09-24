using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_ModifyDragonGuildName
	{

		public static void OnReply(ModifyDragonGuildNameArg oArg, ModifyDragonGuildNameRes oRes)
		{
			XRenameDocument specificDocument = XDocuments.GetSpecificDocument<XRenameDocument>(XRenameDocument.uuID);
			specificDocument.ReceiveDragonGuildRenameVolume(oArg, oRes);
		}

		public static void OnTimeout(ModifyDragonGuildNameArg oArg)
		{
		}
	}
}

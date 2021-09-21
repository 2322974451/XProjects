using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020014CC RID: 5324
	internal class Process_RpcC2M_ModifyMsGuildName
	{
		// Token: 0x0600E83B RID: 59451 RVA: 0x00341174 File Offset: 0x0033F374
		public static void OnReply(ModifyArg oArg, ModifyRes oRes)
		{
			XRenameDocument specificDocument = XDocuments.GetSpecificDocument<XRenameDocument>(XRenameDocument.uuID);
			specificDocument.ReceiveGuildRenameVolume(oArg, oRes);
		}

		// Token: 0x0600E83C RID: 59452 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ModifyArg oArg)
		{
		}
	}
}

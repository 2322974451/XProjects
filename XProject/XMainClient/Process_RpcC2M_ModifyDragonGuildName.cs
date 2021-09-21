using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001633 RID: 5683
	internal class Process_RpcC2M_ModifyDragonGuildName
	{
		// Token: 0x0600EE0C RID: 60940 RVA: 0x003493FC File Offset: 0x003475FC
		public static void OnReply(ModifyDragonGuildNameArg oArg, ModifyDragonGuildNameRes oRes)
		{
			XRenameDocument specificDocument = XDocuments.GetSpecificDocument<XRenameDocument>(XRenameDocument.uuID);
			specificDocument.ReceiveDragonGuildRenameVolume(oArg, oRes);
		}

		// Token: 0x0600EE0D RID: 60941 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ModifyDragonGuildNameArg oArg)
		{
		}
	}
}

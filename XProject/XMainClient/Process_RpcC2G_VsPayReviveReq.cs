using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020016A1 RID: 5793
	internal class Process_RpcC2G_VsPayReviveReq
	{
		// Token: 0x0600EFDA RID: 61402 RVA: 0x0034BFDC File Offset: 0x0034A1DC
		public static void OnReply(VsPayRevivePara oArg, VsPayReviveRes oRes)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.ReceiveVSPayRevive(oArg, oRes);
		}

		// Token: 0x0600EFDB RID: 61403 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(VsPayRevivePara oArg)
		{
		}
	}
}

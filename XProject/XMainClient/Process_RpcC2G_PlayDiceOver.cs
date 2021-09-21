using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200126E RID: 4718
	internal class Process_RpcC2G_PlayDiceOver
	{
		// Token: 0x0600DE94 RID: 56980 RVA: 0x00333735 File Offset: 0x00331935
		public static void OnReply(PlayDiceOverArg oArg, PlayDiceOverRes oRes)
		{
			XSuperRiskDocument.Doc.OnMoveOver(oRes);
		}

		// Token: 0x0600DE95 RID: 56981 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(PlayDiceOverArg oArg)
		{
		}
	}
}

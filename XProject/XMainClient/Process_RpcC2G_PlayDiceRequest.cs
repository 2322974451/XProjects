using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200125C RID: 4700
	internal class Process_RpcC2G_PlayDiceRequest
	{
		// Token: 0x0600DE46 RID: 56902 RVA: 0x00333091 File Offset: 0x00331291
		public static void OnReply(PlayDiceRequestArg oArg, PlayDiceRequestRes oRes)
		{
			XSuperRiskDocument.Doc.OnGetDicingResult(oRes);
		}

		// Token: 0x0600DE47 RID: 56903 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(PlayDiceRequestArg oArg)
		{
		}
	}
}

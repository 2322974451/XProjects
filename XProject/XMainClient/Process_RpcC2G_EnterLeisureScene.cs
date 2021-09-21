using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200166A RID: 5738
	internal class Process_RpcC2G_EnterLeisureScene
	{
		// Token: 0x0600EEF4 RID: 61172 RVA: 0x0034A7C9 File Offset: 0x003489C9
		public static void OnReply(EnterLeisureSceneArg oArg, EnterLeisureSceneRes oRes)
		{
			XYorozuyaDocument.Doc.OnReqBack(oRes);
		}

		// Token: 0x0600EEF5 RID: 61173 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(EnterLeisureSceneArg oArg)
		{
		}
	}
}

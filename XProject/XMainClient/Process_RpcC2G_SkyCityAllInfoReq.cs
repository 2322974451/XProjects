using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020012FC RID: 4860
	internal class Process_RpcC2G_SkyCityAllInfoReq
	{
		// Token: 0x0600E0DC RID: 57564 RVA: 0x00336B28 File Offset: 0x00334D28
		public static void OnReply(SkyCityArg oArg, SkyCityRes oRes)
		{
			XSkyArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XSkyArenaBattleDocument>(XSkyArenaBattleDocument.uuID);
			specificDocument.SetBattleAllInfo(oArg, oRes);
		}

		// Token: 0x0600E0DD RID: 57565 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SkyCityArg oArg)
		{
		}
	}
}

using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001258 RID: 4696
	internal class Process_RpcC2G_GetRiskMapInfos
	{
		// Token: 0x0600DE36 RID: 56886 RVA: 0x00332F99 File Offset: 0x00331199
		public static void OnReply(GetRiskMapInfosArg oArg, GetRiskMapInfosRes oRes)
		{
			XSuperRiskDocument.Doc.OnGetMapDynamicInfo(oArg, oRes);
		}

		// Token: 0x0600DE37 RID: 56887 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetRiskMapInfosArg oArg)
		{
		}
	}
}

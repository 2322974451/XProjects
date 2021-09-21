using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001360 RID: 4960
	internal class Process_RpcC2G_ResWarAllInfoReqOne
	{
		// Token: 0x0600E275 RID: 57973 RVA: 0x0033909C File Offset: 0x0033729C
		public static void OnReply(ResWarArg oArg, ResWarRes oRes)
		{
			XGuildMineBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineBattleDocument>(XGuildMineBattleDocument.uuID);
			specificDocument.SetBattleAllInfo(oArg, oRes);
		}

		// Token: 0x0600E276 RID: 57974 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ResWarArg oArg)
		{
		}
	}
}

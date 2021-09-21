using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020012F7 RID: 4855
	internal class Process_RpcC2G_ReqGuildBossTimeLeft
	{
		// Token: 0x0600E0C7 RID: 57543 RVA: 0x003369BC File Offset: 0x00334BBC
		public static void OnReply(getguildbosstimeleftArg oArg, getguildbosstimeleftRes oRes)
		{
			XGuildDragonDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
			specificDocument.OnGetBattleInfo(oRes);
		}

		// Token: 0x0600E0C8 RID: 57544 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(getguildbosstimeleftArg oArg)
		{
		}
	}
}

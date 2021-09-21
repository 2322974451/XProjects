using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020015FE RID: 5630
	internal class Process_RpcC2G_GetCompeteDragonInfo
	{
		// Token: 0x0600ED29 RID: 60713 RVA: 0x00347FD4 File Offset: 0x003461D4
		public static void OnReply(GetCompeteDragonInfoArg oArg, GetCompeteDragonInfoRes oRes)
		{
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.error);
			}
			else
			{
				bool flag2 = oArg.opArg == CompeteDragonOpArg.CompeteDragon_GetInfo;
				if (flag2)
				{
					XCompeteDocument.Doc.OnGetCompeteDragonInfo(oRes);
				}
				else
				{
					XCompeteDocument.Doc.OnFetchReward(oRes);
				}
			}
		}

		// Token: 0x0600ED2A RID: 60714 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetCompeteDragonInfoArg oArg)
		{
		}
	}
}

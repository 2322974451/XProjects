using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetCompeteDragonInfo
	{

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

		public static void OnTimeout(GetCompeteDragonInfoArg oArg)
		{
		}
	}
}

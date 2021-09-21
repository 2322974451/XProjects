using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200140F RID: 5135
	internal class Process_RpcC2M_ReqGuildTerrCityInfo
	{
		// Token: 0x0600E542 RID: 58690 RVA: 0x0033CB24 File Offset: 0x0033AD24
		public static void OnReply(ReqGuildTerrCityInfoArg oArg, ReqGuildTerrCityInfo oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
				specificDocument.ReceiveGuildTerritoryCityInfo(oRes);
			}
		}

		// Token: 0x0600E543 RID: 58691 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ReqGuildTerrCityInfoArg oArg)
		{
		}
	}
}

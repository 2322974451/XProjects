using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_ReqGuildTerrCityInfo
	{

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

		public static void OnTimeout(ReqGuildTerrCityInfoArg oArg)
		{
		}
	}
}

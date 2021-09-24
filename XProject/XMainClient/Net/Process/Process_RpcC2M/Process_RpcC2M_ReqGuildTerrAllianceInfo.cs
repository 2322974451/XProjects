using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_ReqGuildTerrAllianceInfo
	{

		public static void OnReply(ReqGuildTerrAllianceInfoArg oArg, ReqGuildTerrAllianceInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
				specificDocument.ReceiveGuildTerrAllianceInfo(oRes);
			}
		}

		public static void OnTimeout(ReqGuildTerrAllianceInfoArg oArg)
		{
		}
	}
}

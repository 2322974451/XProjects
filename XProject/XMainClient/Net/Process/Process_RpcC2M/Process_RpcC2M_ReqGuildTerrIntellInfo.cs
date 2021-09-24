using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_ReqGuildTerrIntellInfo
	{

		public static void OnReply(ReqGuildTerrIntellInfoArg oArg, ReqGuildTerrIntellInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
				specificDocument.ReceiveTerritoryInterllInfo(oRes);
			}
		}

		public static void OnTimeout(ReqGuildTerrIntellInfoArg oArg)
		{
		}
	}
}

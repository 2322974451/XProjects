using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_ClearGuildTerrAlliance
	{

		public static void OnReply(ClearGuildTerrAllianceArg oArg, ClearGuildTerrAllianceRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
				specificDocument.ReceiveClearGuildTerrAlliance(oRes);
			}
		}

		public static void OnTimeout(ClearGuildTerrAllianceArg oArg)
		{
		}
	}
}

using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_AllianceGuildTerr
	{

		public static void OnReply(AllianceGuildTerrArg oArg, AllianceGuildTerrRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
				specificDocument.ReceiveAllianceGuildTerr(oArg, oRes);
			}
		}

		public static void OnTimeout(AllianceGuildTerrArg oArg)
		{
		}
	}
}

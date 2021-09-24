using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GCFFightInfoReqC2M
	{

		public static void OnReply(GCFFightInfoArg oArg, GCFFightInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
				specificDocument.RespGCFFightInfo(oRes);
			}
		}

		public static void OnTimeout(GCFFightInfoArg oArg)
		{
		}
	}
}

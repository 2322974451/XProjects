using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GCFCommonReq
	{

		public static void OnReply(GCFCommonArg oArg, GCFCommonRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("ores is nil", null, null, null, null, null);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
					specificDocument.RespGCFCommon(oArg.reqtype, oRes);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString(oRes.errorcode), "fece00");
				}
			}
		}

		public static void OnTimeout(GCFCommonArg oArg)
		{
		}
	}
}

using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001403 RID: 5123
	internal class Process_RpcC2M_GCFCommonReq
	{
		// Token: 0x0600E510 RID: 58640 RVA: 0x0033C76C File Offset: 0x0033A96C
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

		// Token: 0x0600E511 RID: 58641 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GCFCommonArg oArg)
		{
		}
	}
}

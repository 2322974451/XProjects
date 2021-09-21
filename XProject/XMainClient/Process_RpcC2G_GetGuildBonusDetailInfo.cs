using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D91 RID: 3473
	internal class Process_RpcC2G_GetGuildBonusDetailInfo
	{
		// Token: 0x0600BD36 RID: 48438 RVA: 0x0027358C File Offset: 0x0027178C
		public static void OnReply(GetGuildBonusDetailInfoArg oArg, GetGuildBonusDetailInfoResult oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XGuildRedPacketDocument specificDocument = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
				specificDocument.OnGetDetail(oRes);
			}
		}

		// Token: 0x0600BD37 RID: 48439 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetGuildBonusDetailInfoArg oArg)
		{
		}
	}
}

using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012B8 RID: 4792
	internal class Process_RpcC2M_FetchGuildHistoryNew
	{
		// Token: 0x0600DFC0 RID: 57280 RVA: 0x003350EC File Offset: 0x003332EC
		public static void OnReply(GuildHistoryArg oArg, GuildHistoryRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XGuildHallDocument specificDocument = XDocuments.GetSpecificDocument<XGuildHallDocument>(XGuildHallDocument.uuID);
					specificDocument.OnGetLogList(oRes);
				}
			}
		}

		// Token: 0x0600DFC1 RID: 57281 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildHistoryArg oArg)
		{
		}
	}
}

using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020014F5 RID: 5365
	internal class Process_RpcC2G_GetGuildCampPartyExchangeInfo
	{
		// Token: 0x0600E8E9 RID: 59625 RVA: 0x00341EE4 File Offset: 0x003400E4
		public static void OnReply(GetGuildCampPartyExchangeInfoArg oArg, GetGuildCampPartyExchangeInfoRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
				else
				{
					XRequestDocument specificDocument = XDocuments.GetSpecificDocument<XRequestDocument>(XRequestDocument.uuID);
					specificDocument.OnRequestListGet(oRes.infos);
				}
			}
		}

		// Token: 0x0600E8EA RID: 59626 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetGuildCampPartyExchangeInfoArg oArg)
		{
		}
	}
}

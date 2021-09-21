using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D92 RID: 3474
	internal class Process_RpcC2G_GetGuildBonusList
	{
		// Token: 0x0600BD39 RID: 48441 RVA: 0x002735E0 File Offset: 0x002717E0
		public static void OnReply(GetGuildBonusListArg oArg, GetGuildBonusListResult oRes)
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
				specificDocument.OnGetList(oRes);
			}
		}

		// Token: 0x0600BD3A RID: 48442 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetGuildBonusListArg oArg)
		{
		}
	}
}

using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200168D RID: 5773
	internal class Process_RpcC2M_GuildHallGetBuffList
	{
		// Token: 0x0600EF88 RID: 61320 RVA: 0x0034B6C0 File Offset: 0x003498C0
		public static void OnReply(GuildHallGetBuffList_C2M oArg, GuildHallGetBuffList_M2C oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.ec == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.ec > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ec, "fece00");
					}
					else
					{
						XGuildGrowthDocument specificDocument = XDocuments.GetSpecificDocument<XGuildGrowthDocument>(XGuildGrowthDocument.uuID);
						specificDocument.OnBuffListReply(oRes);
					}
				}
			}
		}

		// Token: 0x0600EF89 RID: 61321 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildHallGetBuffList_C2M oArg)
		{
		}
	}
}

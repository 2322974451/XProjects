using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001695 RID: 5781
	internal class Process_RpcC2M_GuildZiCaiDonateHistory
	{
		// Token: 0x0600EFAC RID: 61356 RVA: 0x0034BB7C File Offset: 0x00349D7C
		public static void OnReply(GuildZiCaiDonateHistory_C2M oArg, GuildZiCaiDonateHistory_M2C oRes)
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
						specificDocument.OnGrowthRecordListGet(oRes.datalist);
					}
				}
			}
		}

		// Token: 0x0600EFAD RID: 61357 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildZiCaiDonateHistory_C2M oArg)
		{
		}
	}
}

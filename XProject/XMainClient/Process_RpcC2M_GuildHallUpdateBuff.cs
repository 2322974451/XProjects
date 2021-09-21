using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200168F RID: 5775
	internal class Process_RpcC2M_GuildHallUpdateBuff
	{
		// Token: 0x0600EF91 RID: 61329 RVA: 0x0034B7D8 File Offset: 0x003499D8
		public static void OnReply(GuildHallUpdateBuff_C2M oArg, GuildHallUpdateBuff_M2C oRes)
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
						specificDocument.OnBuffLevelUpSuccess(oRes.buffdata);
					}
				}
			}
		}

		// Token: 0x0600EF92 RID: 61330 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildHallUpdateBuff_C2M oArg)
		{
		}
	}
}

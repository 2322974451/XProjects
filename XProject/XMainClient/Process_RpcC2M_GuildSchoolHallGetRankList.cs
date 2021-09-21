using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001691 RID: 5777
	internal class Process_RpcC2M_GuildSchoolHallGetRankList
	{
		// Token: 0x0600EF9A RID: 61338 RVA: 0x0034B8F4 File Offset: 0x00349AF4
		public static void OnReply(GuildSchoolHallGetRankList_C2M oArg, GuildSchoolHallGetRankList_M2C oRes)
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
						specificDocument.OnBuildRankGet(oRes.unranklist, oRes.guildweeklyhallpoint, oRes.guildweeklyschoolpoint, oRes.guildweeklyhuntingcount, oRes.guildweeklydonatecount);
					}
				}
			}
		}

		// Token: 0x0600EF9B RID: 61339 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildSchoolHallGetRankList_C2M oArg)
		{
		}
	}
}

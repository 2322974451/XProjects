using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001451 RID: 5201
	internal class Process_RpcC2G_BuyHeroInHeroBattle
	{
		// Token: 0x0600E64E RID: 58958 RVA: 0x0033E40C File Offset: 0x0033C60C
		public static void OnReply(BuyHeroInHeroBattleArg oArg, BuyHeroInHeroBattleRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
				else
				{
					XHeroBattleSkillDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleSkillDocument>(XHeroBattleSkillDocument.uuID);
					specificDocument.OnBuyHeroSuccess(oArg.heroid);
				}
			}
		}

		// Token: 0x0600E64F RID: 58959 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(BuyHeroInHeroBattleArg oArg)
		{
		}
	}
}

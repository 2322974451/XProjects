using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200143F RID: 5183
	internal class Process_RpcC2G_SetHeroInHeroBattle
	{
		// Token: 0x0600E607 RID: 58887 RVA: 0x0033DC3C File Offset: 0x0033BE3C
		public static void OnReply(SetHeroInHeroBattleArg oArg, SetHeroInHeroBattleRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XHeroBattleSkillDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleSkillDocument>(XHeroBattleSkillDocument.uuID);
				bool flag2 = oRes.errorcode == ErrorCode.ERR_CANTCHOOSEHERO;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
					specificDocument.SetAlreadySelectHero();
				}
				else
				{
					bool flag3 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
					}
					else
					{
						specificDocument.OnSelectHeroSuccess(oArg.heroid);
					}
				}
			}
		}

		// Token: 0x0600E608 RID: 58888 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SetHeroInHeroBattleArg oArg)
		{
		}
	}
}

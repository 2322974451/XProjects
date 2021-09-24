using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_SetHeroInHeroBattle
	{

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

		public static void OnTimeout(SetHeroInHeroBattleArg oArg)
		{
		}
	}
}

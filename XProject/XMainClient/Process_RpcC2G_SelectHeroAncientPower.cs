using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200158F RID: 5519
	internal class Process_RpcC2G_SelectHeroAncientPower
	{
		// Token: 0x0600EB5D RID: 60253 RVA: 0x00345A58 File Offset: 0x00343C58
		public static void OnReply(SelectHeroAncientPowerArg oArg, SelectHeroAncientPowerRes oRes)
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
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString(string.Format("HeroAncientUse{0}", oArg.selectpower)), "fece00");
					XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
					specificDocument.OnAncientPercentGet(0f);
				}
			}
		}

		// Token: 0x0600EB5E RID: 60254 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SelectHeroAncientPowerArg oArg)
		{
		}
	}
}

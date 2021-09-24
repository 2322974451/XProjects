using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GuildZiCaiDonate
	{

		public static void OnReply(GuildZiCaiDonate_C2M oArg, GuildZiCaiDonate_M2C oRes)
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
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GuildGrowthDonateSucess"), "fece00");
						bool flag4 = DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.IsVisible();
						if (flag4)
						{
							XGuildGrowthDocument specificDocument = XDocuments.GetSpecificDocument<XGuildGrowthDocument>(XGuildGrowthDocument.uuID);
							specificDocument.QueryBuildRank();
							DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.Refresh();
						}
					}
				}
			}
		}

		public static void OnTimeout(GuildZiCaiDonate_C2M oArg)
		{
		}
	}
}

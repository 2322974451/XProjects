using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020014FD RID: 5373
	internal class Process_RpcC2G_GetGuildCampPartyReward
	{
		// Token: 0x0600E909 RID: 59657 RVA: 0x003421C8 File Offset: 0x003403C8
		public static void OnReply(GetGuildCampPartyRewardArg oArg, GetGuildCampPartyRewardRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
				else
				{
					bool flag3 = DlgBase<GuildCollectRewardDlg, GuildCollectRewardBehaviour>.singleton.IsVisible();
					if (flag3)
					{
						XGuildCollectDocument specificDocument = XDocuments.GetSpecificDocument<XGuildCollectDocument>(XGuildCollectDocument.uuID);
						specificDocument.QueryGetRewardCount();
						DlgBase<GuildCollectRewardDlg, GuildCollectRewardBehaviour>.singleton.Refresh();
					}
				}
			}
		}

		// Token: 0x0600E90A RID: 59658 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetGuildCampPartyRewardArg oArg)
		{
		}
	}
}

using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012BF RID: 4799
	internal class Process_RpcC2M_GetOtherGuildBriefNew
	{
		// Token: 0x0600DFDE RID: 57310 RVA: 0x0033538C File Offset: 0x0033358C
		public static void OnReply(GetOtherGuildBriefArg oArg, GetOtherGuildBriefRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.IsVisible();
					if (flag3)
					{
						DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.RefreshGuildInfo(oRes);
					}
				}
			}
		}

		// Token: 0x0600DFDF RID: 57311 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetOtherGuildBriefArg oArg)
		{
		}
	}
}

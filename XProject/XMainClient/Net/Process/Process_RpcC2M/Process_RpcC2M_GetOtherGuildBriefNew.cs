using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GetOtherGuildBriefNew
	{

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

		public static void OnTimeout(GetOtherGuildBriefArg oArg)
		{
		}
	}
}

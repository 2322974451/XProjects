using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_ChangeLiveVisible
	{

		public static void OnReply(ChangeLiveVisibleArg oArg, ChangeLiveVisibleRes oRes)
		{
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SpectateSettingSuccess"), "fece00");
				XSpectateDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID);
				specificDocument.VisibleSetting = oArg.visible;
				bool flag2 = DlgBase<SpectateView, SpectateBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<SpectateView, SpectateBehaviour>.singleton.SetVisibleSettingTextState();
				}
			}
		}

		public static void OnTimeout(ChangeLiveVisibleArg oArg)
		{
		}
	}
}

using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001513 RID: 5395
	internal class Process_RpcC2G_ChangeLiveVisible
	{
		// Token: 0x0600E964 RID: 59748 RVA: 0x00342A14 File Offset: 0x00340C14
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

		// Token: 0x0600E965 RID: 59749 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ChangeLiveVisibleArg oArg)
		{
		}
	}
}

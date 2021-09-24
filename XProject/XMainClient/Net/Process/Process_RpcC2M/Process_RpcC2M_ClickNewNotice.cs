using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_ClickNewNotice
	{

		public static void OnReply(ClickNewNoticeArg oArg, ClickNewNoticeRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				oArg.info.isnew = false;
				uint type = oArg.info.type;
				if (type == 5U)
				{
					bool flag2 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Patface);
					if (flag2)
					{
						DlgBase<XPatfaceView, XPatfaceBehaviour>.singleton.ShowPatface();
					}
				}
				XAnnouncementDocument specificDocument = XDocuments.GetSpecificDocument<XAnnouncementDocument>(XAnnouncementDocument.uuID);
				specificDocument.RefreshRedPoint();
			}
		}

		public static void OnTimeout(ClickNewNoticeArg oArg)
		{
		}
	}
}

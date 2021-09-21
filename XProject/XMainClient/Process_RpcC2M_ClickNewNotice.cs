using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200149F RID: 5279
	internal class Process_RpcC2M_ClickNewNotice
	{
		// Token: 0x0600E786 RID: 59270 RVA: 0x003401E8 File Offset: 0x0033E3E8
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

		// Token: 0x0600E787 RID: 59271 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ClickNewNoticeArg oArg)
		{
		}
	}
}

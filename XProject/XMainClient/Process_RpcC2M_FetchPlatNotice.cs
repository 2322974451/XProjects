using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020013AF RID: 5039
	internal class Process_RpcC2M_FetchPlatNotice
	{
		// Token: 0x0600E3BA RID: 58298 RVA: 0x0033AB30 File Offset: 0x00338D30
		public static void OnReply(FetchPlatNoticeArg oArg, FetchPlatNoticeRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.notice != null;
				if (flag2)
				{
					bool isopen = oRes.notice.isopen;
					if (isopen)
					{
						DlgBase<XAnnouncementView, XAnnouncementBehaviour>.singleton.ShowAnnouncement(oRes.notice.content);
					}
				}
				bool flag3 = oRes.result == ErrorCode.ERR_SUCCESS;
				if (flag3)
				{
					XAnnouncementDocument specificDocument = XDocuments.GetSpecificDocument<XAnnouncementDocument>(XAnnouncementDocument.uuID);
					specificDocument.GetNoticeData(oRes.data);
				}
			}
		}

		// Token: 0x0600E3BB RID: 58299 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(FetchPlatNoticeArg oArg)
		{
		}
	}
}

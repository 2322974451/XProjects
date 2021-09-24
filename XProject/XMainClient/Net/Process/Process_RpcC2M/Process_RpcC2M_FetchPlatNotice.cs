using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_FetchPlatNotice
	{

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

		public static void OnTimeout(FetchPlatNoticeArg oArg)
		{
		}
	}
}

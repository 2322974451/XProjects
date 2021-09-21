using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000915 RID: 2325
	internal class XAnnouncementDocument : XDocComponent
	{
		// Token: 0x17002B74 RID: 11124
		// (get) Token: 0x06008C42 RID: 35906 RVA: 0x0012F6E8 File Offset: 0x0012D8E8
		public override uint ID
		{
			get
			{
				return XAnnouncementDocument.uuID;
			}
		}

		// Token: 0x17002B75 RID: 11125
		// (get) Token: 0x06008C43 RID: 35907 RVA: 0x0012F700 File Offset: 0x0012D900
		public List<PlatNotice> NoticeList
		{
			get
			{
				return this._notice_list;
			}
		}

		// Token: 0x17002B76 RID: 11126
		// (get) Token: 0x06008C44 RID: 35908 RVA: 0x0012F718 File Offset: 0x0012D918
		// (set) Token: 0x06008C45 RID: 35909 RVA: 0x0012F730 File Offset: 0x0012D930
		public bool RedPoint
		{
			get
			{
				return this._red_point;
			}
			set
			{
				this._red_point = value;
			}
		}

		// Token: 0x06008C46 RID: 35910 RVA: 0x0012F73C File Offset: 0x0012D93C
		public bool GetTabRedPoint(int index)
		{
			return this._tab_red_point[index];
		}

		// Token: 0x06008C47 RID: 35911 RVA: 0x0012F758 File Offset: 0x0012D958
		public void SendFetchNotice()
		{
			RpcC2M_FetchPlatNotice rpcC2M_FetchPlatNotice = new RpcC2M_FetchPlatNotice();
			rpcC2M_FetchPlatNotice.oArg.type = XSingleton<XClientNetwork>.singleton.AccountType;
			RuntimePlatform platform = Application.platform;
			if (platform != (RuntimePlatform)8)
			{
				if (platform == (RuntimePlatform)11)
				{
					rpcC2M_FetchPlatNotice.oArg.platid = PlatType.PLAT_ANDROID;
				}
			}
			else
			{
				rpcC2M_FetchPlatNotice.oArg.platid = PlatType.PLAT_IOS;
			}
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_FetchPlatNotice);
		}

		// Token: 0x06008C48 RID: 35912 RVA: 0x0012F7C0 File Offset: 0x0012D9C0
		public void SendClickNotice(PlatNotice notice)
		{
			RpcC2M_ClickNewNotice rpcC2M_ClickNewNotice = new RpcC2M_ClickNewNotice();
			rpcC2M_ClickNewNotice.oArg.info = notice;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClickNewNotice);
		}

		// Token: 0x06008C49 RID: 35913 RVA: 0x0012F7F0 File Offset: 0x0012D9F0
		public void GetNoticeData(List<PlatNotice> noticeList)
		{
			this._red_point = false;
			Array.Clear(this._tab_red_point, 0, 2);
			this._notice_list.Clear();
			for (int i = 0; i < noticeList.Count; i++)
			{
				this._notice_list.Add(noticeList[i]);
				uint type = noticeList[i].type;
				if (type - 3U > 1U)
				{
					if (type == 6U)
					{
						this._tab_red_point[0] |= noticeList[i].isnew;
						this._red_point |= noticeList[i].isnew;
					}
				}
				else
				{
					this._tab_red_point[1] |= noticeList[i].isnew;
					this._red_point |= noticeList[i].isnew;
				}
			}
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Announcement, true);
			bool flag = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.IsVisible();
			if (flag)
			{
				bool flag2 = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_AnnouncementHandler != null;
				if (flag2)
				{
					DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_AnnouncementHandler.RefreshData();
				}
			}
			bool flag3 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Patface);
			if (flag3)
			{
				DlgBase<XPatfaceView, XPatfaceBehaviour>.singleton.ShowPatface();
			}
			else
			{
				XSingleton<XPandoraSDKDocument>.singleton.CheckPandoraPLPanel();
			}
		}

		// Token: 0x06008C4A RID: 35914 RVA: 0x0012F950 File Offset: 0x0012DB50
		public void RefreshRedPoint()
		{
			this._red_point = false;
			Array.Clear(this._tab_red_point, 0, 2);
			for (int i = 0; i < this._notice_list.Count; i++)
			{
				uint type = this._notice_list[i].type;
				if (type - 3U > 1U)
				{
					if (type == 6U)
					{
						this._tab_red_point[0] |= this._notice_list[i].isnew;
						this._red_point |= this._notice_list[i].isnew;
					}
				}
				else
				{
					this._tab_red_point[1] |= this._notice_list[i].isnew;
					this._red_point |= this._notice_list[i].isnew;
				}
			}
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Announcement, true);
			XOperatingActivityDocument specificDocument = XDocuments.GetSpecificDocument<XOperatingActivityDocument>(XOperatingActivityDocument.uuID);
			specificDocument.RefreshRedPoints();
			bool flag = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.IsVisible();
			if (flag)
			{
				bool flag2 = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_AnnouncementHandler != null;
				if (flag2)
				{
					DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.m_AnnouncementHandler.RefreshTab();
				}
			}
		}

		// Token: 0x06008C4B RID: 35915 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04002D39 RID: 11577
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("AnnouncementDocument");

		// Token: 0x04002D3A RID: 11578
		public const int TAB_COUNT = 2;

		// Token: 0x04002D3B RID: 11579
		private List<PlatNotice> _notice_list = new List<PlatNotice>();

		// Token: 0x04002D3C RID: 11580
		private bool _red_point = false;

		// Token: 0x04002D3D RID: 11581
		private bool[] _tab_red_point = new bool[2];

		// Token: 0x04002D3E RID: 11582
		public int CurrentTab = 0;
	}
}

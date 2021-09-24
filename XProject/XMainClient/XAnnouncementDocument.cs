using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XAnnouncementDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XAnnouncementDocument.uuID;
			}
		}

		public List<PlatNotice> NoticeList
		{
			get
			{
				return this._notice_list;
			}
		}

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

		public bool GetTabRedPoint(int index)
		{
			return this._tab_red_point[index];
		}

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

		public void SendClickNotice(PlatNotice notice)
		{
			RpcC2M_ClickNewNotice rpcC2M_ClickNewNotice = new RpcC2M_ClickNewNotice();
			rpcC2M_ClickNewNotice.oArg.info = notice;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClickNewNotice);
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("AnnouncementDocument");

		public const int TAB_COUNT = 2;

		private List<PlatNotice> _notice_list = new List<PlatNotice>();

		private bool _red_point = false;

		private bool[] _tab_red_point = new bool[2];

		public int CurrentTab = 0;
	}
}

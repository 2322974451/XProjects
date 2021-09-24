using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XAnnouncementView : DlgBase<XAnnouncementView, XAnnouncementBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "SelectChar/AnnouncementDlg";
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Enter.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterClicked));
		}

		private bool OnEnterClicked(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		public void ShowAnnouncement(string announcement)
		{
			this.SetVisibleWithAnimation(true, null);
			base.uiBehaviour.m_Announcement.SetText(announcement);
		}
	}
}

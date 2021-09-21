using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000B8F RID: 2959
	internal class XAnnouncementView : DlgBase<XAnnouncementView, XAnnouncementBehaviour>
	{
		// Token: 0x17003029 RID: 12329
		// (get) Token: 0x0600A9A8 RID: 43432 RVA: 0x001E4050 File Offset: 0x001E2250
		public override string fileName
		{
			get
			{
				return "SelectChar/AnnouncementDlg";
			}
		}

		// Token: 0x1700302A RID: 12330
		// (get) Token: 0x0600A9A9 RID: 43433 RVA: 0x001E4068 File Offset: 0x001E2268
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700302B RID: 12331
		// (get) Token: 0x0600A9AA RID: 43434 RVA: 0x001E407C File Offset: 0x001E227C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700302C RID: 12332
		// (get) Token: 0x0600A9AB RID: 43435 RVA: 0x001E4090 File Offset: 0x001E2290
		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700302D RID: 12333
		// (get) Token: 0x0600A9AC RID: 43436 RVA: 0x001E40A4 File Offset: 0x001E22A4
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600A9AD RID: 43437 RVA: 0x001E40B7 File Offset: 0x001E22B7
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Enter.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterClicked));
		}

		// Token: 0x0600A9AE RID: 43438 RVA: 0x001E40E0 File Offset: 0x001E22E0
		private bool OnEnterClicked(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600A9AF RID: 43439 RVA: 0x001E40FC File Offset: 0x001E22FC
		public void ShowAnnouncement(string announcement)
		{
			this.SetVisibleWithAnimation(true, null);
			base.uiBehaviour.m_Announcement.SetText(announcement);
		}
	}
}

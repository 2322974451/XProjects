using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B8D RID: 2957
	internal class XPatfaceView : DlgBase<XPatfaceView, XPatfaceBehaviour>
	{
		// Token: 0x17003024 RID: 12324
		// (get) Token: 0x0600A99B RID: 43419 RVA: 0x001E3DE4 File Offset: 0x001E1FE4
		public override string fileName
		{
			get
			{
				return "Hall/PatfaceDlg";
			}
		}

		// Token: 0x17003025 RID: 12325
		// (get) Token: 0x0600A99C RID: 43420 RVA: 0x001E3DFC File Offset: 0x001E1FFC
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003026 RID: 12326
		// (get) Token: 0x0600A99D RID: 43421 RVA: 0x001E3E10 File Offset: 0x001E2010
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003027 RID: 12327
		// (get) Token: 0x0600A99E RID: 43422 RVA: 0x001E3E24 File Offset: 0x001E2024
		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003028 RID: 12328
		// (get) Token: 0x0600A99F RID: 43423 RVA: 0x001E3E38 File Offset: 0x001E2038
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600A9A0 RID: 43424 RVA: 0x001E3E4B File Offset: 0x001E204B
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XAnnouncementDocument>(XAnnouncementDocument.uuID);
		}

		// Token: 0x0600A9A1 RID: 43425 RVA: 0x001E3E65 File Offset: 0x001E2065
		protected override void OnHide()
		{
			base.OnHide();
			base.uiBehaviour.m_Pic.SetTexturePath("");
		}

		// Token: 0x0600A9A2 RID: 43426 RVA: 0x001E3E85 File Offset: 0x001E2085
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_OK.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterClicked));
		}

		// Token: 0x0600A9A3 RID: 43427 RVA: 0x001E3EAC File Offset: 0x001E20AC
		private bool OnEnterClicked(IXUIButton button)
		{
			this.bShow = true;
			this.doc.SendClickNotice(this.doc.NoticeList[(int)button.ID]);
			return true;
		}

		// Token: 0x0600A9A4 RID: 43428 RVA: 0x001E3EEC File Offset: 0x001E20EC
		public void ShowPatface()
		{
			bool flag = !this.bShow;
			if (!flag)
			{
				this.bShow = false;
				this.doc = XDocuments.GetSpecificDocument<XAnnouncementDocument>(XAnnouncementDocument.uuID);
				for (int i = 0; i < this.doc.NoticeList.Count; i++)
				{
					bool flag2 = this.doc.NoticeList[i].type != 5U || !this.doc.NoticeList[i].isnew;
					if (!flag2)
					{
						this.SetVisible(true, true);
						XSingleton<XUICacheImage>.singleton.Load(this.doc.NoticeList[i].content, base.uiBehaviour.m_Pic, base.uiBehaviour);
						base.uiBehaviour.m_OK.ID = (ulong)i;
						return;
					}
				}
				XSingleton<XPandoraSDKDocument>.singleton.CheckPandoraPLPanel();
				this.SetVisible(false, true);
			}
		}

		// Token: 0x04003EC2 RID: 16066
		private XAnnouncementDocument doc;

		// Token: 0x04003EC3 RID: 16067
		public bool bShow = false;
	}
}

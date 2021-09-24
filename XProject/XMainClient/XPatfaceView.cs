using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XPatfaceView : DlgBase<XPatfaceView, XPatfaceBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Hall/PatfaceDlg";
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

		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XAnnouncementDocument>(XAnnouncementDocument.uuID);
		}

		protected override void OnHide()
		{
			base.OnHide();
			base.uiBehaviour.m_Pic.SetTexturePath("");
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_OK.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterClicked));
		}

		private bool OnEnterClicked(IXUIButton button)
		{
			this.bShow = true;
			this.doc.SendClickNotice(this.doc.NoticeList[(int)button.ID]);
			return true;
		}

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

		private XAnnouncementDocument doc;

		public bool bShow = false;
	}
}

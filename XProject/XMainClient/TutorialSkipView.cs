using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CAA RID: 3242
	internal class TutorialSkipView : DlgBase<TutorialSkipView, TutorialSkipBehaviour>
	{
		// Token: 0x17003241 RID: 12865
		// (get) Token: 0x0600B68F RID: 46735 RVA: 0x002435E0 File Offset: 0x002417E0
		public override string fileName
		{
			get
			{
				return "GameSystem/TutorialSkip";
			}
		}

		// Token: 0x17003242 RID: 12866
		// (get) Token: 0x0600B690 RID: 46736 RVA: 0x002435F8 File Offset: 0x002417F8
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003243 RID: 12867
		// (get) Token: 0x0600B691 RID: 46737 RVA: 0x0024360C File Offset: 0x0024180C
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003244 RID: 12868
		// (get) Token: 0x0600B692 RID: 46738 RVA: 0x00243620 File Offset: 0x00241820
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003245 RID: 12869
		// (get) Token: 0x0600B693 RID: 46739 RVA: 0x00243634 File Offset: 0x00241834
		public override bool hideMainMenu
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17003246 RID: 12870
		// (get) Token: 0x0600B694 RID: 46740 RVA: 0x00243648 File Offset: 0x00241848
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B695 RID: 46741 RVA: 0x0024365B File Offset: 0x0024185B
		protected override void Init()
		{
			base.uiBehaviour.m_Label.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("TUTORIAL_SKIP")));
		}

		// Token: 0x0600B696 RID: 46742 RVA: 0x00243684 File Offset: 0x00241884
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Skip.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSkipClicked));
			base.uiBehaviour.m_NoSkip.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600B697 RID: 46743 RVA: 0x002436EC File Offset: 0x002418EC
		public bool OnCloseClicked(IXUIButton btn)
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_SKIP_TUTORIAL, 0, false);
			this.SetVisibleWithAnimation(false, null);
			XSingleton<XTutorialHelper>.singleton.SelectSkipTutorial = true;
			return true;
		}

		// Token: 0x0600B698 RID: 46744 RVA: 0x0024372C File Offset: 0x0024192C
		public bool OnSkipClicked(IXUIButton btn)
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_SKIP_TUTORIAL, 1, false);
			XSingleton<XTutorialMgr>.singleton.SkipCurrentTutorial(true);
			this.SetVisibleWithAnimation(false, null);
			XSingleton<XTutorialHelper>.singleton.SelectSkipTutorial = true;
			return true;
		}

		// Token: 0x0600B699 RID: 46745 RVA: 0x00243778 File Offset: 0x00241978
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600B69A RID: 46746 RVA: 0x00243782 File Offset: 0x00241982
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B69B RID: 46747 RVA: 0x0024378C File Offset: 0x0024198C
		protected override void OnUnload()
		{
			base.OnUnload();
		}
	}
}

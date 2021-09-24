using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TutorialSkipView : DlgBase<TutorialSkipView, TutorialSkipBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/TutorialSkip";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
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

		public override bool hideMainMenu
		{
			get
			{
				return false;
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
			base.uiBehaviour.m_Label.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("TUTORIAL_SKIP")));
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Skip.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSkipClicked));
			base.uiBehaviour.m_NoSkip.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		public bool OnCloseClicked(IXUIButton btn)
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_SKIP_TUTORIAL, 0, false);
			this.SetVisibleWithAnimation(false, null);
			XSingleton<XTutorialHelper>.singleton.SelectSkipTutorial = true;
			return true;
		}

		public bool OnSkipClicked(IXUIButton btn)
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_SKIP_TUTORIAL, 1, false);
			XSingleton<XTutorialMgr>.singleton.SkipCurrentTutorial(true);
			this.SetVisibleWithAnimation(false, null);
			XSingleton<XTutorialHelper>.singleton.SelectSkipTutorial = true;
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}
	}
}

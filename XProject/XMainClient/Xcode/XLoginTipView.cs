using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XLoginTipView : DlgBase<XLoginTipView, XLoginTipBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/LoginTip";
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

		public void ShowTips(string str)
		{
			DlgBase<XLoginTipView, XLoginTipBehaviour>.singleton.SetVisible(true, true);
			base.uiBehaviour.m_TipTween.gameObject.SetActive(true);
			base.uiBehaviour.m_TipTween.ResetTween(true);
			base.uiBehaviour.m_TipLabel.SetText(str);
			base.uiBehaviour.m_TipTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnWelcomeTweenFinish));
			base.uiBehaviour.m_TipTween.PlayTween(true, -1f);
		}

		public void StopTips()
		{
			DlgBase<XLoginTipView, XLoginTipBehaviour>.singleton.SetVisible(false, true);
		}

		public void OnWelcomeTweenFinish(IXUITweenTool iPlayTween)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				base.uiBehaviour.m_TipTween.PlayTween(false, -1f);
			}
		}
	}
}

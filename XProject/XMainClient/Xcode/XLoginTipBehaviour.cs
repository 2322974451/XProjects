using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XLoginTipBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_TipTween = (base.transform.Find("Bg/Tip").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_TipLabel = (base.transform.Find("Bg/Tip/Text").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUITweenTool m_TipTween;

		public IXUILabel m_TipLabel;
	}
}

using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	public class SystemHelpBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/Label");
			this.m_Label = (transform.GetComponent("XUILabel") as IXUILabel);
			this.m_LabelSymbol = (transform.GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			Transform transform2 = base.transform.FindChild("Bg/Title");
			this.m_Title = (transform2.GetComponent("XUILabel") as IXUILabel);
			this.m_TitleSymbol = (transform2.GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			Transform transform3 = base.transform.FindChild("Bg/OK");
			this.m_OKButton = (transform3.GetComponent("XUIButton") as IXUIButton);
			this.m_Grey = (base.transform.Find("Grey").GetComponent("XUISprite") as IXUISprite);
			Transform transform4 = base.transform.Find("Bg");
			this.m_PlayTween = (transform4.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Panel = (base.transform.GetComponent("XUIPanel") as IXUIPanel);
		}

		public IXUILabel m_Label = null;

		public IXUILabelSymbol m_LabelSymbol = null;

		public IXUILabel m_Title = null;

		public IXUILabelSymbol m_TitleSymbol = null;

		public IXUIButton m_OKButton = null;

		public IXUISprite m_Grey = null;

		public IXUITweenTool m_PlayTween = null;

		public IXUIPanel m_Panel = null;
	}
}

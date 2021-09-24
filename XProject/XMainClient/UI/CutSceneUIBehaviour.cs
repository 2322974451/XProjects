using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	public class CutSceneUIBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_BG = (base.transform.FindChild("_canvas/DownBG").GetComponent("XUISprite") as IXUISprite);
			this.m_Text = (base.transform.FindChild("_canvas/DownBG/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_Skip = (base.transform.FindChild("_canvas/DownBG/UpBG/Skip").GetComponent("XUILabel") as IXUILabel);
			this.m_Overlay = (base.transform.FindChild("_canvas/Overlay").GetComponent("XUISprite") as IXUISprite);
			this.m_IntroTween = (base.transform.FindChild("_canvas/Intro").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Name = (base.transform.FindChild("_canvas/Intro/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_IntroText = (base.transform.FindChild("_canvas/Intro/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_IntroTween.gameObject.SetActive(false);
		}

		public IXUISprite m_BG;

		public IXUILabel m_Text;

		public IXUILabel m_Skip;

		public IXUISprite m_Overlay;

		public IXUITweenTool m_IntroTween;

		public IXUILabel m_Name;

		public IXUILabel m_IntroText;
	}
}

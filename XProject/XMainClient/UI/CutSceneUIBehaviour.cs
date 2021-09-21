using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020018FD RID: 6397
	public class CutSceneUIBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010B15 RID: 68373 RVA: 0x004290CC File Offset: 0x004272CC
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

		// Token: 0x04007A14 RID: 31252
		public IXUISprite m_BG;

		// Token: 0x04007A15 RID: 31253
		public IXUILabel m_Text;

		// Token: 0x04007A16 RID: 31254
		public IXUILabel m_Skip;

		// Token: 0x04007A17 RID: 31255
		public IXUISprite m_Overlay;

		// Token: 0x04007A18 RID: 31256
		public IXUITweenTool m_IntroTween;

		// Token: 0x04007A19 RID: 31257
		public IXUILabel m_Name;

		// Token: 0x04007A1A RID: 31258
		public IXUILabel m_IntroText;
	}
}

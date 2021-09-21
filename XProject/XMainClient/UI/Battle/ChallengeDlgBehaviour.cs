using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI.Battle
{
	// Token: 0x02001938 RID: 6456
	internal class ChallengeDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010F89 RID: 69513 RVA: 0x00451AA8 File Offset: 0x0044FCA8
		private void Awake()
		{
			this.m_Tween = (base.transform.FindChild("Bg").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Accept = (base.transform.FindChild("Bg/Accept").GetComponent("XUILabel") as IXUILabel);
			this.m_MainDesc = (base.transform.FindChild("Bg/MainDesc").GetComponent("XUILabel") as IXUILabel);
			for (int i = 0; i < 3; i++)
			{
				this.m_RewardValue[i] = (base.transform.FindChild(string.Format("Bg/Reward/Label{0}", i + 1)).GetComponent("XUILabel") as IXUILabel);
				this.m_RewardIcon[i] = (base.transform.FindChild(string.Format("Bg/Reward/Label{0}/Icon", i + 1)).GetComponent("XUISprite") as IXUISprite);
			}
			this.m_HintBg = (base.transform.FindChild("Hint").GetComponent("XUISprite") as IXUISprite);
			this.m_HintDesc = (base.transform.FindChild("Hint/Desc").GetComponent("XUILabel") as IXUILabel);
			this.m_HintState = (base.transform.FindChild("Hint/State").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x04007D21 RID: 32033
		public IXUITweenTool m_Tween;

		// Token: 0x04007D22 RID: 32034
		public IXUILabel m_Accept;

		// Token: 0x04007D23 RID: 32035
		public IXUILabel m_MainDesc;

		// Token: 0x04007D24 RID: 32036
		public IXUILabel m_HintDesc;

		// Token: 0x04007D25 RID: 32037
		public IXUISprite m_HintBg;

		// Token: 0x04007D26 RID: 32038
		public IXUILabel m_HintState;

		// Token: 0x04007D27 RID: 32039
		public IXUILabel[] m_RewardValue = new IXUILabel[3];

		// Token: 0x04007D28 RID: 32040
		public IXUISprite[] m_RewardIcon = new IXUISprite[3];
	}
}

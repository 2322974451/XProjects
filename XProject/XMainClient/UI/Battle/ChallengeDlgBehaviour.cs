using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI.Battle
{

	internal class ChallengeDlgBehaviour : DlgBehaviourBase
	{

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

		public IXUITweenTool m_Tween;

		public IXUILabel m_Accept;

		public IXUILabel m_MainDesc;

		public IXUILabel m_HintDesc;

		public IXUISprite m_HintBg;

		public IXUILabel m_HintState;

		public IXUILabel[] m_RewardValue = new IXUILabel[3];

		public IXUISprite[] m_RewardIcon = new IXUISprite[3];
	}
}

using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class GuildDragonChallengeResultBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Desription = (base.transform.FindChild("Bg/Leader").GetComponent("XUILabel") as IXUILabel);
			this.m_Time = (base.transform.FindChild("Bg/Leader/time").GetComponent("XUILabel") as IXUILabel);
			this.m_ReturnBtn = (base.transform.Find("Bg/p").GetComponent("XUISprite") as IXUISprite);
		}

		public IXUILabel m_Desription;

		public IXUILabel m_Time;

		public IXUISprite m_ReturnBtn;
	}
}

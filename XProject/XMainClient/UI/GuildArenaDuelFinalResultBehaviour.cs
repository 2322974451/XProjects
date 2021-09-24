using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class GuildArenaDuelFinalResultBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_BlueInfo.Init(base.transform.FindChild("Bg/Blue"));
			this.m_RedInfo.Init(base.transform.FindChild("Bg/Red"));
			this.m_maskSprite = (base.transform.FindChild("Bg/Mask").GetComponent("XUISprite") as IXUISprite);
			this.m_timeLabel = (base.transform.FindChild("Bg/CountDown/Time").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUISprite m_maskSprite;

		public IXUILabel m_timeLabel;

		public GuildArenadDuelFinalInfo m_BlueInfo = new GuildArenadDuelFinalInfo();

		public GuildArenadDuelFinalInfo m_RedInfo = new GuildArenadDuelFinalInfo();
	}
}

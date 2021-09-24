using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class GuildArenaDuelRoundResultBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Blue.Init(base.transform.FindChild("Bg/Blue"));
			this.m_Red.Init(base.transform.FindChild("Bg/Red"));
			this.m_RoundLabel = (base.transform.FindChild("Bg/Round").GetComponent("XUILabel") as IXUILabel);
			this.m_TimeLabel = (base.transform.FindChild("Bg/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_MaskSprite = (base.transform.FindChild("Bg/Mask").GetComponent("XUISprite") as IXUISprite);
			this.m_GuildName = (base.transform.FindChild("Bg/EmptyWin/GuildName").GetComponent("XUILabel") as IXUILabel);
			this.m_EmptyWin = base.transform.FindChild("Bg/EmptyWin");
		}

		public IXUILabel m_RoundLabel;

		public IXUILabel m_TimeLabel;

		public IXUISprite m_MaskSprite;

		public IXUILabel m_GuildName;

		public Transform m_EmptyWin;

		public GuildArenaDuelResultInfo m_Blue = new GuildArenaDuelResultInfo();

		public GuildArenaDuelResultInfo m_Red = new GuildArenaDuelResultInfo();
	}
}

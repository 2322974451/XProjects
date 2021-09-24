using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GuildMineRewardBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_Bg = base.transform.FindChild("Bg");
			this.m_Rank = (base.transform.FindChild("Bg/BtnRank").GetComponent("XUIButton") as IXUIButton);
			this.m_Win = (base.transform.FindChild("Bg/GuildWin/Info").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("Bg/Guild/GuildTpl");
			this.m_GuildPool.SetupPool(null, transform.gameObject, 3U, false);
		}

		public IXUIButton m_Close;

		public IXUIButton m_Help;

		public Transform m_Bg;

		public IXUIButton m_Rank;

		public IXUILabel m_Win;

		public XUIPool m_GuildPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}

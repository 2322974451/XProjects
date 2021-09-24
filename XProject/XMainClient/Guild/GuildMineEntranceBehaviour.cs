using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GuildMineEntranceBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_Join = (base.transform.FindChild("Bg/Join").GetComponent("XUIButton") as IXUIButton);
			this.m_GameRule = (base.transform.FindChild("Bg/GameRule").GetComponent("XUILabel") as IXUILabel);
			this.m_ActivityTime = (base.transform.FindChild("Bg/Time").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("Bg/ExReward/ListPanel/ItemTpl");
			this.m_RewardPool.SetupPool(null, transform.gameObject, 5U, false);
		}

		public IXUIButton m_Close;

		public IXUIButton m_Help;

		public IXUIButton m_Join;

		public IXUILabel m_GameRule;

		public IXUILabel m_ActivityTime;

		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}

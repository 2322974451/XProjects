using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class RaceEntranceBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_SingleJoin = (base.transform.FindChild("Bg/SingleJoin").GetComponent("XUIButton") as IXUIButton);
			this.m_GameRule = (base.transform.FindChild("Bg/GameRule").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("Bg/Reward/RewardList/ItemTpl");
			this.m_RewardPool.SetupPool(null, transform.gameObject, 3U, false);
		}

		public IXUIButton m_Close;

		public IXUIButton m_Help;

		public IXUIButton m_SingleJoin;

		public IXUILabel m_GameRule;

		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}

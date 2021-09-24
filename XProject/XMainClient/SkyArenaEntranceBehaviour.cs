using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class SkyArenaEntranceBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Bg = base.transform.FindChild("Bg");
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_SingleJoin = (base.transform.FindChild("Bg/SingleJoin").GetComponent("XUIButton") as IXUIButton);
			this.m_TeamJoin = (base.transform.FindChild("Bg/TeamJoin").GetComponent("XUIButton") as IXUIButton);
			this.m_RewardBtn = (base.transform.FindChild("Bg/PointRewardBtn").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Bg/Reward/ItemTpl");
			this.m_RewardPool.SetupPool(null, transform.gameObject, 5U, false);
			this.m_Time = (base.transform.FindChild("Bg/Time").GetComponent("XUILabel") as IXUILabel);
		}

		public Transform m_Bg;

		public IXUIButton m_Close;

		public IXUIButton m_Help;

		public IXUIButton m_SingleJoin;

		public IXUIButton m_TeamJoin;

		public IXUIButton m_RewardBtn;

		public IXUILabel m_Time;

		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}

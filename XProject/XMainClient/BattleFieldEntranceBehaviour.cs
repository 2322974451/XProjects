using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class BattleFieldEntranceBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Bg = base.transform.FindChild("Bg");
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_Join = (base.transform.FindChild("Bg/Join").GetComponent("XUIButton") as IXUIButton);
			this.m_PointRewardBtn = (base.transform.FindChild("Bg/PointRewardBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_FallBtn = (base.transform.FindChild("Bg/FallBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_Rule = (base.transform.FindChild("Bg/Left/Rule").GetComponent("XUILabel") as IXUILabel);
			this.m_Time = (base.transform.FindChild("Bg/Left/Time").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("Bg/Left/Reward/ItemTpl");
			this.m_RewardShowPool.SetupPool(null, transform.gameObject, 5U, false);
		}

		public Transform m_Bg;

		public IXUIButton m_Close;

		public IXUIButton m_Help;

		public IXUIButton m_Join;

		public IXUIButton m_PointRewardBtn;

		public IXUIButton m_FallBtn;

		public XUIPool m_RewardShowPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_Rule;

		public IXUILabel m_Time;
	}
}

using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XRewardDlgBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			Transform tabTpl = base.transform.FindChild("Bg/Tabs/TabTpl");
			this.m_tabcontrol.SetTabTpl(tabTpl);
			this.m_achivementFrame = base.transform.Find("Bg/AchivementFrame");
			this.m_activityFrame = base.transform.Find("Bg/ActivityFrame");
			this.m_rewardSysFrame = base.transform.Find("Bg/RewardFrame");
			this.m_loginFrame = base.transform.Find("Bg/LoginFrame");
			this.m_levelFrame = base.transform.Find("Bg/LevelFrame");
		}

		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_LoginPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIButton m_close;

		public XUITabControl m_tabcontrol = new XUITabControl();

		public Transform m_achivementFrame;

		public Transform m_activityFrame;

		public Transform m_rewardSysFrame;

		public Transform m_loginFrame;

		public Transform m_levelFrame;
	}
}

using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F04 RID: 3844
	internal class XRewardDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600CC35 RID: 52277 RVA: 0x002EF154 File Offset: 0x002ED354
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

		// Token: 0x04005AB0 RID: 23216
		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04005AB1 RID: 23217
		public XUIPool m_LoginPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04005AB2 RID: 23218
		public IXUIButton m_close;

		// Token: 0x04005AB3 RID: 23219
		public XUITabControl m_tabcontrol = new XUITabControl();

		// Token: 0x04005AB4 RID: 23220
		public Transform m_achivementFrame;

		// Token: 0x04005AB5 RID: 23221
		public Transform m_activityFrame;

		// Token: 0x04005AB6 RID: 23222
		public Transform m_rewardSysFrame;

		// Token: 0x04005AB7 RID: 23223
		public Transform m_loginFrame;

		// Token: 0x04005AB8 RID: 23224
		public Transform m_levelFrame;
	}
}

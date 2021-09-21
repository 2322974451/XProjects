using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016FB RID: 5883
	internal class GuildTerritoryRewardBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F2A7 RID: 62119 RVA: 0x0035D37C File Offset: 0x0035B57C
		private void Awake()
		{
			this.m_scrool = (base.transform.Find("Bg/Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_objTpl = base.transform.Find("Bg/Bg/ScrollView/wrapcontent/Item").gameObject;
			this._close_btn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_wrap = (base.transform.Find("Bg/Bg/ScrollView/wrapcontent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_RewardItemPool.SetupPool(base.transform.gameObject, this.m_objTpl, 30U, false);
		}

		// Token: 0x040067FE RID: 26622
		public IXUIButton _close_btn;

		// Token: 0x040067FF RID: 26623
		public IXUIWrapContent m_wrap;

		// Token: 0x04006800 RID: 26624
		public IXUIScrollView m_scrool;

		// Token: 0x04006801 RID: 26625
		public GameObject m_objTpl;

		// Token: 0x04006802 RID: 26626
		public XUIPool m_RewardItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}

using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200170A RID: 5898
	internal class EndlessAbyssBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F382 RID: 62338 RVA: 0x00365C6C File Offset: 0x00363E6C
		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg");
			this.m_closedBtn = (transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_goBattleBtn = (transform.FindChild("GoBattle").GetComponent("XUIButton") as IXUIButton);
			this.m_shopBtn = (transform.FindChild("BtnShop").GetComponent("XUIButton") as IXUIButton);
			this.m_noTimesGo = transform.FindChild("NoJoinTimesTips").gameObject;
			Transform transform2 = transform.FindChild("Reward/Item/ItemTpl");
			this.m_ItemPool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 3U, false);
			this.m_canJoinTimeslab = (transform.FindChild("times").GetComponent("XUILabel") as IXUILabel);
			this.m_canJoinTimeslab.SetText("");
		}

		// Token: 0x0400688D RID: 26765
		public IXUIButton m_closedBtn;

		// Token: 0x0400688E RID: 26766
		public IXUIButton m_Help;

		// Token: 0x0400688F RID: 26767
		public IXUIButton m_shopBtn;

		// Token: 0x04006890 RID: 26768
		public IXUIButton m_goBattleBtn;

		// Token: 0x04006891 RID: 26769
		public GameObject m_noTimesGo;

		// Token: 0x04006892 RID: 26770
		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006893 RID: 26771
		public IXUILabel m_canJoinTimeslab;
	}
}

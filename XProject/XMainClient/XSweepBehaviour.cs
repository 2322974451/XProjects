using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EF9 RID: 3833
	internal class XSweepBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600CB6E RID: 52078 RVA: 0x002E62AC File Offset: 0x002E44AC
		private void Awake()
		{
			this.m_dragBox = base.transform.FindChild("Bg/DragBox").GetComponent<BoxCollider>();
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Exp = (base.transform.FindChild("Bg/ExpBar").GetComponent("XUIProgress") as IXUIProgress);
			this.m_ExpText = (base.transform.FindChild("Bg/ExpBar/ExpLabel").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("Bg/RewardDisplay/RewardTpl/Parent/ItemTpl");
			this.m_DropPool.SetupPool(transform.parent.parent.gameObject, transform.gameObject, 8U, false);
			transform = base.transform.FindChild("Bg/RewardDisplay/RewardTpl");
			this.m_RewardPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
			this.m_ScrollView = (base.transform.FindChild("Bg/RewardDisplay").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_SweepTip = (base.transform.FindChild("Bg/RewardDisplay/Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_SealTip = base.transform.Find("Bg/SealTip");
		}

		// Token: 0x040059FB RID: 23035
		public IXUIButton m_Close = null;

		// Token: 0x040059FC RID: 23036
		public IXUIProgress m_Exp = null;

		// Token: 0x040059FD RID: 23037
		public IXUILabel m_ExpText = null;

		// Token: 0x040059FE RID: 23038
		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040059FF RID: 23039
		public IXUIScrollView m_ScrollView = null;

		// Token: 0x04005A00 RID: 23040
		public XUIPool m_DropPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04005A01 RID: 23041
		public IXUILabel m_SweepTip;

		// Token: 0x04005A02 RID: 23042
		public Transform m_SealTip;

		// Token: 0x04005A03 RID: 23043
		public BoxCollider m_dragBox;
	}
}

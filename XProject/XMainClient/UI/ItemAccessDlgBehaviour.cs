using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018C8 RID: 6344
	internal class ItemAccessDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x060108B3 RID: 67763 RVA: 0x004107CC File Offset: 0x0040E9CC
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Item = base.transform.FindChild("Bg/Item").gameObject;
			this.m_BossItem = base.transform.FindChild("Bg/Boss").gameObject;
			this.m_bossDec = (this.m_BossItem.transform.Find("Des").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("Bg/ListPanel/ItemTpl");
			this.m_RecordPool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			this.m_RecordScrollView = (base.transform.FindChild("Bg/ListPanel").GetComponent("XUIScrollView") as IXUIScrollView);
		}

		// Token: 0x040077CD RID: 30669
		public GameObject m_Item;

		// Token: 0x040077CE RID: 30670
		public XUIPool m_RecordPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040077CF RID: 30671
		public IXUIScrollView m_RecordScrollView;

		// Token: 0x040077D0 RID: 30672
		public IXUIButton m_Close;

		// Token: 0x040077D1 RID: 30673
		public GameObject m_BossItem;

		// Token: 0x040077D2 RID: 30674
		public IXUILabel m_bossDec;
	}
}

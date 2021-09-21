using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A19 RID: 2585
	internal class XBackFlowBehavior : DlgBehaviourBase
	{
		// Token: 0x06009E1E RID: 40478 RVA: 0x0019E020 File Offset: 0x0019C220
		private void Awake()
		{
			Transform transform = base.transform.Find("Bg/Tabs/TabTpl");
			this.TabItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
			this.CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.HandlersParent = base.transform.Find("Bg/Handler");
		}

		// Token: 0x04003803 RID: 14339
		public XUIPool TabItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003804 RID: 14340
		public IXUIButton CloseBtn;

		// Token: 0x04003805 RID: 14341
		public Transform HandlersParent;
	}
}

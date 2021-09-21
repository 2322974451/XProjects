using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E8D RID: 3725
	internal class XWelfareBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C6F7 RID: 50935 RVA: 0x002C12B4 File Offset: 0x002BF4B4
		private void Awake()
		{
			Transform transform = base.transform.Find("Bg/TabList/TabGrid/Tpl");
			this.m_TabPool.SetupPool(transform.gameObject.gameObject, transform.gameObject, 5U, false);
			this.m_RightHandlerParent = base.transform.Find("Bg/RightHander");
			this.m_TabList = (base.transform.Find("Bg/TabList/TabGrid").GetComponent("XUIList") as IXUIList);
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x04005748 RID: 22344
		public IXUIButton m_Close;

		// Token: 0x04005749 RID: 22345
		public IXUIList m_TabList;

		// Token: 0x0400574A RID: 22346
		public XUIPool m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400574B RID: 22347
		public Transform m_RightHandlerParent;
	}
}

using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001894 RID: 6292
	internal class XBriefLevelupBehaviour : DlgBehaviourBase
	{
		// Token: 0x0601061E RID: 67102 RVA: 0x003FDF08 File Offset: 0x003FC108
		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Close2 = (base.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite);
			Transform transform = base.transform.FindChild("Bg/Panel/Tpl");
			this.m_FuncPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
		}

		// Token: 0x04007631 RID: 30257
		public IXUIButton m_Close;

		// Token: 0x04007632 RID: 30258
		public IXUISprite m_Close2;

		// Token: 0x04007633 RID: 30259
		public XUIPool m_FuncPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}

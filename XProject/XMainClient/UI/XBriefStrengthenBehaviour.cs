using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001899 RID: 6297
	internal class XBriefStrengthenBehaviour : DlgBehaviourBase
	{
		// Token: 0x0601064D RID: 67149 RVA: 0x003FFA04 File Offset: 0x003FDC04
		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Close2 = (base.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite);
			Transform transform = base.transform.FindChild("Bg/P/Tpl");
			this.m_FuncPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.m_More = (base.transform.FindChild("Bg/More").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x04007657 RID: 30295
		public IXUIButton m_Close;

		// Token: 0x04007658 RID: 30296
		public IXUISprite m_Close2;

		// Token: 0x04007659 RID: 30297
		public IXUILabel m_More;

		// Token: 0x0400765A RID: 30298
		public XUIPool m_FuncPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}

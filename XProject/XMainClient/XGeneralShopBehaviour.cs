using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E4A RID: 3658
	internal class XGeneralShopBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C455 RID: 50261 RVA: 0x002AD7D8 File Offset: 0x002AB9D8
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_ShopTypePool.SetupPool(base.transform.FindChild("Bg/ListFrame/Panel").gameObject, base.transform.FindChild("Bg/ListFrame/Panel/RecordTpl").gameObject, 10U, false);
		}

		// Token: 0x04005560 RID: 21856
		public IXUIButton m_Close;

		// Token: 0x04005561 RID: 21857
		public IXUIButton m_Help;

		// Token: 0x04005562 RID: 21858
		public XUIPool m_ShopTypePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}

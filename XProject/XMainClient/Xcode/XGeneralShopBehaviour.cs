using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGeneralShopBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_ShopTypePool.SetupPool(base.transform.FindChild("Bg/ListFrame/Panel").gameObject, base.transform.FindChild("Bg/ListFrame/Panel/RecordTpl").gameObject, 10U, false);
		}

		public IXUIButton m_Close;

		public IXUIButton m_Help;

		public XUIPool m_ShopTypePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}

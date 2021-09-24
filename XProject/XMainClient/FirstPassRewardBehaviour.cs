using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class FirstPassRewardBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_itemParentGo = base.transform.FindChild("Panel/List").gameObject;
			Transform transform = this.m_itemParentGo.transform.FindChild("Tpl");
			this.m_ItemPool1.SetupPool(this.m_itemParentGo, transform.gameObject, 5U, false);
			this.m_ItemPool2.SetupPool(transform.gameObject, this.m_itemParentGo.transform.FindChild("Item").gameObject, 4U, false);
		}

		public IXUIButton m_Close;

		public GameObject m_itemParentGo;

		public XUIPool m_ItemPool1 = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_ItemPool2 = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}

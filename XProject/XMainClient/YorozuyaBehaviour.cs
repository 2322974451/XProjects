using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class YorozuyaBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_closedBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_parentTra = base.transform.Find("Bg/Panel");
			this.m_itemPool.SetupPool(base.transform.Find("Bg").gameObject, base.transform.Find("Bg/Panel/Tpl").gameObject, 2U, true);
		}

		public IXUIButton m_closedBtn;

		public Transform m_parentTra;

		public XUIPool m_itemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}

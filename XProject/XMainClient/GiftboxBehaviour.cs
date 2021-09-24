using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class GiftboxBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_checkbox1 = (base.transform.Find("item1/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_checkbox2 = (base.transform.Find("item2/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_tip0 = base.transform.Find("Bg/Tip2").gameObject;
			this.m_tip1 = base.transform.Find("Bg/Tip1").gameObject;
			this.m_btnClose = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_wrap = (base.transform.Find("scrollview/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_scroll = (base.transform.Find("scrollview").GetComponent("XUIScrollView") as IXUIScrollView);
		}

		public IXUICheckBox m_checkbox1;

		public IXUICheckBox m_checkbox2;

		public IXUIButton m_btnClose;

		public IXUIWrapContent m_wrap;

		public IXUIScrollView m_scroll;

		public GameObject m_tip0;

		public GameObject m_tip1;
	}
}

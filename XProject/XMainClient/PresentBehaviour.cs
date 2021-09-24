using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class PresentBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_btnPay = (base.transform.Find("OK").GetComponent("XUIButton") as IXUIButton);
			this.m_btnCancel = (base.transform.Find("Cancel").GetComponent("XUIButton") as IXUIButton);
			this.m_input = (base.transform.Find("item2/input").GetComponent("XUIInput") as IXUIInput);
			this.m_icon = base.transform.Find("item2").gameObject;
			this.m_lblPrice = (base.transform.Find("item2/Price").GetComponent("XUILabel") as IXUILabel);
			this.m_lblTitle = (base.transform.Find("item2/Title").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUIButton m_btnPay;

		public IXUIButton m_btnCancel;

		public IXUIInput m_input;

		public GameObject m_icon;

		public IXUILabel m_lblPrice;

		public IXUILabel m_lblTitle;
	}
}

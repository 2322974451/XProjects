using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XBuyCountBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/Content");
			this.m_Content = (transform.GetComponent("XUILabel") as IXUILabel);
			this.m_ContentLabelSymbol = (transform.GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_LeftBuyCount = (base.transform.Find("Bg/LeftBuyCount").GetComponent("XUILabel") as IXUILabel);
			Transform transform2 = base.transform.FindChild("Bg/OK");
			this.m_OKButton = (transform2.GetComponent("XUIButton") as IXUIButton);
			Transform transform3 = base.transform.FindChild("Bg/Cancel");
			this.m_CancelButton = (transform3.GetComponent("XUIButton") as IXUIButton);
		}

		public IXUILabel m_Content = null;

		public IXUILabelSymbol m_ContentLabelSymbol = null;

		public IXUILabel m_LeftBuyCount = null;

		public IXUIButton m_OKButton = null;

		public IXUIButton m_CancelButton = null;
	}
}

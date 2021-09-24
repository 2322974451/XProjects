using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	public class ModalThreeDlgBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Button1 = (base.transform.FindChild("Bg/choice1").GetComponent("XUIButton") as IXUIButton);
			this.m_Button2 = (base.transform.FindChild("Bg/choice2").GetComponent("XUIButton") as IXUIButton);
			this.m_Button3 = (base.transform.FindChild("Bg/choice3").GetComponent("XUIButton") as IXUIButton);
			this.m_CloseButton = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Panel = (base.transform.GetComponent("XUIPanel") as IXUIPanel);
			Transform transform = base.transform.FindChild("Bg/Info");
			this.m_Label = (transform.GetComponent("XUILabel") as IXUILabel);
			this.m_LabelSymbol = (transform.GetComponent("XUILabelSymbol") as IXUILabelSymbol);
		}

		public IXUIButton m_Button1;

		public IXUIButton m_Button2;

		public IXUIButton m_Button3;

		public IXUIButton m_CloseButton;

		public IXUIPanel m_Panel;

		public IXUILabel m_Label = null;

		public IXUILabelSymbol m_LabelSymbol = null;
	}
}

using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	public class ModalDlgBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/Label");
			this.m_Label = (transform.GetComponent("XUILabel") as IXUILabel);
			this.m_LabelSymbol = (transform.GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			Transform transform2 = base.transform.FindChild("Bg/OK");
			this.m_OKButton = (transform2.GetComponent("XUIButton") as IXUIButton);
			Transform transform3 = base.transform.FindChild("Bg/Cancel");
			this.m_CancelButton = (transform3.GetComponent("XUIButton") as IXUIButton);
			this.m_CloseButton = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_CloseButton.SetVisible(false);
			this.m_Grey = (base.transform.Find("Grey").GetComponent("XUISprite") as IXUISprite);
			Transform transform4 = base.transform.Find("Bg");
			this.m_PlayTween = (transform4.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Panel = (base.transform.GetComponent("XUIPanel") as IXUIPanel);
			this.m_TwoButtonPos0 = base.transform.Find("Bg/TwoButtonPos0").gameObject;
			this.m_TwoButtonPos1 = base.transform.Find("Bg/TwoButtonPos1").gameObject;
			this.m_NoTip = (transform4.Find("NoTip/NoTip").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_lblTip = (transform4.transform.Find("NoTip/T").GetComponent("XUILabel") as IXUILabel);
			this.m_title = (transform4.transform.Find("Title").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUILabel m_Label = null;

		public IXUILabelSymbol m_LabelSymbol = null;

		public IXUIButton m_OKButton = null;

		public IXUIButton m_CancelButton = null;

		public IXUIButton m_CloseButton = null;

		public IXUISprite m_Grey = null;

		public IXUITweenTool m_PlayTween = null;

		public IXUIPanel m_Panel = null;

		public GameObject m_TwoButtonPos0;

		public GameObject m_TwoButtonPos1;

		public IXUICheckBox m_NoTip = null;

		public IXUILabel m_lblTip = null;

		public IXUILabel m_title = null;
	}
}

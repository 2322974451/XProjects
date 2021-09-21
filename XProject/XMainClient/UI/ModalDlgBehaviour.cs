using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001925 RID: 6437
	public class ModalDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010DBD RID: 69053 RVA: 0x004435A0 File Offset: 0x004417A0
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

		// Token: 0x04007C14 RID: 31764
		public IXUILabel m_Label = null;

		// Token: 0x04007C15 RID: 31765
		public IXUILabelSymbol m_LabelSymbol = null;

		// Token: 0x04007C16 RID: 31766
		public IXUIButton m_OKButton = null;

		// Token: 0x04007C17 RID: 31767
		public IXUIButton m_CancelButton = null;

		// Token: 0x04007C18 RID: 31768
		public IXUIButton m_CloseButton = null;

		// Token: 0x04007C19 RID: 31769
		public IXUISprite m_Grey = null;

		// Token: 0x04007C1A RID: 31770
		public IXUITweenTool m_PlayTween = null;

		// Token: 0x04007C1B RID: 31771
		public IXUIPanel m_Panel = null;

		// Token: 0x04007C1C RID: 31772
		public GameObject m_TwoButtonPos0;

		// Token: 0x04007C1D RID: 31773
		public GameObject m_TwoButtonPos1;

		// Token: 0x04007C1E RID: 31774
		public IXUICheckBox m_NoTip = null;

		// Token: 0x04007C1F RID: 31775
		public IXUILabel m_lblTip = null;

		// Token: 0x04007C20 RID: 31776
		public IXUILabel m_title = null;
	}
}

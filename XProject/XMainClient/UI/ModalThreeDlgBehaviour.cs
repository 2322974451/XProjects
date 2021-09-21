using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001926 RID: 6438
	public class ModalThreeDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010DBF RID: 69055 RVA: 0x004437D8 File Offset: 0x004419D8
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

		// Token: 0x04007C21 RID: 31777
		public IXUIButton m_Button1;

		// Token: 0x04007C22 RID: 31778
		public IXUIButton m_Button2;

		// Token: 0x04007C23 RID: 31779
		public IXUIButton m_Button3;

		// Token: 0x04007C24 RID: 31780
		public IXUIButton m_CloseButton;

		// Token: 0x04007C25 RID: 31781
		public IXUIPanel m_Panel;

		// Token: 0x04007C26 RID: 31782
		public IXUILabel m_Label = null;

		// Token: 0x04007C27 RID: 31783
		public IXUILabelSymbol m_LabelSymbol = null;
	}
}

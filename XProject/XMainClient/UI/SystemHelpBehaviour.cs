using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001878 RID: 6264
	public class SystemHelpBehaviour : DlgBehaviourBase
	{
		// Token: 0x060104DB RID: 66779 RVA: 0x003F20C4 File Offset: 0x003F02C4
		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/Label");
			this.m_Label = (transform.GetComponent("XUILabel") as IXUILabel);
			this.m_LabelSymbol = (transform.GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			Transform transform2 = base.transform.FindChild("Bg/Title");
			this.m_Title = (transform2.GetComponent("XUILabel") as IXUILabel);
			this.m_TitleSymbol = (transform2.GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			Transform transform3 = base.transform.FindChild("Bg/OK");
			this.m_OKButton = (transform3.GetComponent("XUIButton") as IXUIButton);
			this.m_Grey = (base.transform.Find("Grey").GetComponent("XUISprite") as IXUISprite);
			Transform transform4 = base.transform.Find("Bg");
			this.m_PlayTween = (transform4.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Panel = (base.transform.GetComponent("XUIPanel") as IXUIPanel);
		}

		// Token: 0x04007543 RID: 30019
		public IXUILabel m_Label = null;

		// Token: 0x04007544 RID: 30020
		public IXUILabelSymbol m_LabelSymbol = null;

		// Token: 0x04007545 RID: 30021
		public IXUILabel m_Title = null;

		// Token: 0x04007546 RID: 30022
		public IXUILabelSymbol m_TitleSymbol = null;

		// Token: 0x04007547 RID: 30023
		public IXUIButton m_OKButton = null;

		// Token: 0x04007548 RID: 30024
		public IXUISprite m_Grey = null;

		// Token: 0x04007549 RID: 30025
		public IXUITweenTool m_PlayTween = null;

		// Token: 0x0400754A RID: 30026
		public IXUIPanel m_Panel = null;
	}
}

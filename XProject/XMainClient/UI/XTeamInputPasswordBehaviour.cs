using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001860 RID: 6240
	internal class XTeamInputPasswordBehaviour : DlgBehaviourBase
	{
		// Token: 0x060103FB RID: 66555 RVA: 0x003ED918 File Offset: 0x003EBB18
		private void Awake()
		{
			this.m_BtnOK = (base.transform.Find("Bg/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnClose = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Input = (base.transform.Find("Bg/Input").GetComponent("XUIInput") as IXUIInput);
		}

		// Token: 0x040074C4 RID: 29892
		public IXUIInput m_Input;

		// Token: 0x040074C5 RID: 29893
		public IXUIButton m_BtnOK;

		// Token: 0x040074C6 RID: 29894
		public IXUIButton m_BtnClose;
	}
}

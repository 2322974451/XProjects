using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000BEE RID: 3054
	internal class XTeamLeagueCreateBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600ADF8 RID: 44536 RVA: 0x002083E0 File Offset: 0x002065E0
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("CreateMenu/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_OK = (base.transform.FindChild("CreateMenu/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_Cancel = (base.transform.FindChild("CreateMenu/Cancel").GetComponent("XUIButton") as IXUIButton);
			this.m_NameInput = (base.transform.FindChild("CreateMenu/NameInput").GetComponent("XUIInput") as IXUIInput);
		}

		// Token: 0x040041D7 RID: 16855
		public IXUIButton m_Close;

		// Token: 0x040041D8 RID: 16856
		public IXUIButton m_OK;

		// Token: 0x040041D9 RID: 16857
		public IXUIButton m_Cancel;

		// Token: 0x040041DA RID: 16858
		public IXUIInput m_NameInput;
	}
}

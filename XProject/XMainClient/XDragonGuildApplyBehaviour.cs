using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000A4A RID: 2634
	internal class XDragonGuildApplyBehaviour : DlgBehaviourBase
	{
		// Token: 0x06009FD8 RID: 40920 RVA: 0x001A8CF8 File Offset: 0x001A6EF8
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/ApplyMenu/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnApply = (base.transform.FindChild("Bg/ApplyMenu/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnEnterGuild = (base.transform.FindChild("Bg/ResultMenu/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_Annoucement = (base.transform.FindChild("Bg/ApplyMenu/Annoucement").GetComponent("XUILabel") as IXUILabel);
			this.m_Annoucement.SetText("");
			this.m_PPT = (base.transform.FindChild("Bg/ApplyMenu/PPT").GetComponent("XUILabel") as IXUILabel);
			this.m_NeedApprove = (base.transform.FindChild("Bg/ApplyMenu/NeedApprove").GetComponent("XUILabel") as IXUILabel);
			this.m_ResultNote = (base.transform.FindChild("Bg/ResultMenu/Note").GetComponent("XUILabel") as IXUILabel);
			this.m_ApplyMenu = base.transform.FindChild("Bg/ApplyMenu").gameObject;
			this.m_ResultMenu = base.transform.FindChild("Bg/ResultMenu").gameObject;
		}

		// Token: 0x0400391E RID: 14622
		public IXUIButton m_Close = null;

		// Token: 0x0400391F RID: 14623
		public IXUIButton m_BtnApply = null;

		// Token: 0x04003920 RID: 14624
		public IXUIButton m_BtnEnterGuild;

		// Token: 0x04003921 RID: 14625
		public IXUILabel m_Annoucement;

		// Token: 0x04003922 RID: 14626
		public IXUILabel m_PPT;

		// Token: 0x04003923 RID: 14627
		public IXUILabel m_NeedApprove;

		// Token: 0x04003924 RID: 14628
		public IXUILabel m_ResultNote;

		// Token: 0x04003925 RID: 14629
		public GameObject m_ApplyMenu;

		// Token: 0x04003926 RID: 14630
		public GameObject m_ResultMenu;
	}
}

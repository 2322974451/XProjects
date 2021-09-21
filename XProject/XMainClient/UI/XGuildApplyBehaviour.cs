using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020018B4 RID: 6324
	internal class XGuildApplyBehaviour : DlgBehaviourBase
	{
		// Token: 0x060107C3 RID: 67523 RVA: 0x00409598 File Offset: 0x00407798
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

		// Token: 0x04007725 RID: 30501
		public IXUIButton m_Close = null;

		// Token: 0x04007726 RID: 30502
		public IXUIButton m_BtnApply = null;

		// Token: 0x04007727 RID: 30503
		public IXUIButton m_BtnEnterGuild;

		// Token: 0x04007728 RID: 30504
		public IXUILabel m_Annoucement;

		// Token: 0x04007729 RID: 30505
		public IXUILabel m_PPT;

		// Token: 0x0400772A RID: 30506
		public IXUILabel m_NeedApprove;

		// Token: 0x0400772B RID: 30507
		public IXUILabel m_ResultNote;

		// Token: 0x0400772C RID: 30508
		public GameObject m_ApplyMenu;

		// Token: 0x0400772D RID: 30509
		public GameObject m_ResultMenu;
	}
}

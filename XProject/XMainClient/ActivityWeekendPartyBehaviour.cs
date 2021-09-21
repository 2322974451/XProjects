using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B8B RID: 2955
	internal class ActivityWeekendPartyBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600A997 RID: 43415 RVA: 0x001E3B80 File Offset: 0x001E1D80
		private void Awake()
		{
			this.m_Rule = (base.transform.FindChild("Bg/Left/GameRule").GetComponent("XUILabel") as IXUILabel);
			this.m_CurrActName = (base.transform.FindChild("Bg/Left/CurrName").GetComponent("XUILabel") as IXUILabel);
			this.m_Times = (base.transform.FindChild("Bg/Right/Times").GetComponent("XUILabel") as IXUILabel);
			this.m_TimeTip = (base.transform.FindChild("Bg/Right/Times/time").GetComponent("XUILabel") as IXUILabel);
			this.m_SingleMatch = (base.transform.FindChild("Bg/Right/BtnStartSingle").GetComponent("XUIButton") as IXUIButton);
			this.m_TeamMatch = (base.transform.FindChild("Bg/Right/BtnStartTeam").GetComponent("XUIButton") as IXUIButton);
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_SingleMatchLabel = (this.m_SingleMatch.gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_Bg = (base.transform.FindChild("Bg/Texture").GetComponent("XUITexture") as IXUITexture);
			this.m_DropAward = (base.transform.FindChild("Bg/WeekReward/ListPanel/Grid").GetComponent("XUIList") as IXUIList);
			Transform transform = this.m_DropAward.gameObject.transform.FindChild("ItemTpl");
			this.m_DropAwardPool.SetupPool(transform.parent.parent.gameObject, transform.gameObject, 4U, false);
		}

		// Token: 0x04003EB4 RID: 16052
		public IXUILabel m_CurrActName;

		// Token: 0x04003EB5 RID: 16053
		public IXUILabel m_Rule;

		// Token: 0x04003EB6 RID: 16054
		public IXUILabel m_Times;

		// Token: 0x04003EB7 RID: 16055
		public IXUIButton m_SingleMatch;

		// Token: 0x04003EB8 RID: 16056
		public IXUIButton m_TeamMatch;

		// Token: 0x04003EB9 RID: 16057
		public IXUIButton m_Close;

		// Token: 0x04003EBA RID: 16058
		public IXUILabel m_SingleMatchLabel;

		// Token: 0x04003EBB RID: 16059
		public IXUIButton m_Help;

		// Token: 0x04003EBC RID: 16060
		public IXUITexture m_Bg;

		// Token: 0x04003EBD RID: 16061
		public IXUILabel m_TimeTip;

		// Token: 0x04003EBE RID: 16062
		public IXUIList m_DropAward;

		// Token: 0x04003EBF RID: 16063
		public XUIPool m_DropAwardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}

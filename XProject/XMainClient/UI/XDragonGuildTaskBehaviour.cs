using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020016DB RID: 5851
	public class XDragonGuildTaskBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F154 RID: 61780 RVA: 0x00353E9C File Offset: 0x0035209C
		private void Awake()
		{
			this.m_close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Trooplevel = base.transform.Find("Bg/TroopLevel");
			this.m_progress = (this.m_Trooplevel.Find("ProgressBar").GetComponent("XUIProgress") as IXUIProgress);
			this.m_GuildLevel = (this.m_Trooplevel.Find("Level").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildExpCur = (this.m_Trooplevel.Find("Value").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildExpMax = (this.m_Trooplevel.Find("ValueMax").GetComponent("XUILabel") as IXUILabel);
			this.m_cdrewards = (base.transform.Find("Bg/CDRewards").GetComponent("XUILabel") as IXUILabel);
			this.m_task = (base.transform.Find("Bg/buttons/SelectTask").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_taskrep = base.transform.Find("Bg/buttons/SelectTask/redpoint");
			this.m_achieve = (base.transform.Find("Bg/buttons/SelectAchieve").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_acieverep = base.transform.Find("Bg/buttons/SelectAchieve/redpoint");
			this.m_Toptask = base.transform.Find("Bg/Task/Top/Brunch/Task");
			this.m_Topachieve = base.transform.Find("Bg/Task/Top/Brunch/Achieve");
			this.m_wrapcontent = (base.transform.Find("Bg/Task/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		// Token: 0x04006715 RID: 26389
		public IXUIButton m_close;

		// Token: 0x04006716 RID: 26390
		public Transform m_Trooplevel;

		// Token: 0x04006717 RID: 26391
		public IXUILabel m_GuildLevel;

		// Token: 0x04006718 RID: 26392
		public IXUIProgress m_progress;

		// Token: 0x04006719 RID: 26393
		public IXUILabel m_GuildExpMax;

		// Token: 0x0400671A RID: 26394
		public IXUILabel m_GuildExpCur;

		// Token: 0x0400671B RID: 26395
		public IXUILabel m_cdrewards;

		// Token: 0x0400671C RID: 26396
		public IXUICheckBox m_task;

		// Token: 0x0400671D RID: 26397
		public IXUICheckBox m_achieve;

		// Token: 0x0400671E RID: 26398
		public Transform m_Toptask;

		// Token: 0x0400671F RID: 26399
		public Transform m_Topachieve;

		// Token: 0x04006720 RID: 26400
		public IXUIWrapContent m_wrapcontent;

		// Token: 0x04006721 RID: 26401
		public Transform m_taskrep;

		// Token: 0x04006722 RID: 26402
		public Transform m_acieverep;
	}
}

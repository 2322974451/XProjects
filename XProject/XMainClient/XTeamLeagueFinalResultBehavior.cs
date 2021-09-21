using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000BF2 RID: 3058
	internal class XTeamLeagueFinalResultBehavior : DlgBehaviourBase
	{
		// Token: 0x0600AE0B RID: 44555 RVA: 0x00208920 File Offset: 0x00206B20
		private void Awake()
		{
			this.Details = base.transform.Find("Bg2/Details");
			this.EnterMatch = (base.transform.Find("Bg2/BeginMatch").GetComponent("XUIButton") as IXUIButton);
			this.CloseBtn = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.NoChampion = base.transform.Find("Bg2/ChampionFrame/NoChampion");
			this.ChampionMembers = base.transform.Find("Bg2/ChampionFrame/Members");
			this.GuildName = (base.transform.Find("Bg2/ChampionFrame/GuildName").GetComponent("XUILabel") as IXUILabel);
			this.FinalTimeLabel = (base.transform.Find("Schedule").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x040041E2 RID: 16866
		public Transform Details;

		// Token: 0x040041E3 RID: 16867
		public IXUIButton EnterMatch;

		// Token: 0x040041E4 RID: 16868
		public IXUIButton CloseBtn;

		// Token: 0x040041E5 RID: 16869
		public Transform NoChampion;

		// Token: 0x040041E6 RID: 16870
		public Transform ChampionMembers;

		// Token: 0x040041E7 RID: 16871
		public IXUILabel GuildName;

		// Token: 0x040041E8 RID: 16872
		public IXUILabel FinalTimeLabel;
	}
}

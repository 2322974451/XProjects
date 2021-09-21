using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x0200177F RID: 6015
	internal class HallFameShareBehavior : DlgBehaviourBase
	{
		// Token: 0x0600F84C RID: 63564 RVA: 0x0038BD70 File Offset: 0x00389F70
		private void Awake()
		{
			this.ShareBtn = (base.transform.Find("Bg/Board/ShareBtn").GetComponent("XUIButton") as IXUIButton);
			this.CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.Find("Bg/Snapshot");
			this.uiDummy = (transform.GetComponent("UIDummy") as IUIDummy);
			this.ParticleHanging = base.transform.Find("Bg/pHanging");
			this.RecentSeason = (base.transform.Find("Bg/Board/RecentSeason").GetComponent("XUILabel") as IXUILabel);
			this.RoleName = (base.transform.Find("Bg/Board/RoleName").GetComponent("XUILabel") as IXUILabel);
			this.ChampionTimes = (base.transform.Find("Bg/Board/ChampionTimes").GetComponent("XUILabel") as IXUILabel);
			this.SeasonSpan = (base.transform.Find("Bg/Board/SeasonSpan").GetComponent("XUILabel") as IXUILabel);
			this.TopTenTimes = (base.transform.Find("Bg/Board/TopTenTimes").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x04006C57 RID: 27735
		public IXUIButton ShareBtn;

		// Token: 0x04006C58 RID: 27736
		public IXUIButton CloseBtn;

		// Token: 0x04006C59 RID: 27737
		public IUIDummy uiDummy;

		// Token: 0x04006C5A RID: 27738
		public Transform ParticleHanging;

		// Token: 0x04006C5B RID: 27739
		public IXUILabel RecentSeason;

		// Token: 0x04006C5C RID: 27740
		public IXUILabel RoleName;

		// Token: 0x04006C5D RID: 27741
		public IXUILabel ChampionTimes;

		// Token: 0x04006C5E RID: 27742
		public IXUILabel SeasonSpan;

		// Token: 0x04006C5F RID: 27743
		public IXUILabel TopTenTimes;
	}
}

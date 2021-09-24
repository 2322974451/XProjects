using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class HallFameShareBehavior : DlgBehaviourBase
	{

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

		public IXUIButton ShareBtn;

		public IXUIButton CloseBtn;

		public IUIDummy uiDummy;

		public Transform ParticleHanging;

		public IXUILabel RecentSeason;

		public IXUILabel RoleName;

		public IXUILabel ChampionTimes;

		public IXUILabel SeasonSpan;

		public IXUILabel TopTenTimes;
	}
}

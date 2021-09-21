using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B9A RID: 2970
	internal class LevelRewardBigMeleeHandler : DlgHandlerBase
	{
		// Token: 0x1700303F RID: 12351
		// (get) Token: 0x0600AA70 RID: 43632 RVA: 0x001E816C File Offset: 0x001E636C
		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardBigMeleeFrame";
			}
		}

		// Token: 0x0600AA71 RID: 43633 RVA: 0x001E8184 File Offset: 0x001E6384
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.entDoc = XDocuments.GetSpecificDocument<XBigMeleeEntranceDocument>(XBigMeleeEntranceDocument.uuID);
			this.m_Return = (base.PanelObject.transform.Find("Return").GetComponent("XUISprite") as IXUISprite);
			this.m_RankImg = (base.PanelObject.transform.Find("Rank/RankImg").GetComponent("XUISprite") as IXUISprite);
			this.m_RankNum = (base.PanelObject.transform.Find("Rank/RankNum").GetComponent("XUILabel") as IXUILabel);
			this.m_Score = (base.PanelObject.transform.Find("Result/Score/T").GetComponent("XUILabel") as IXUILabel);
			this.m_Kill = (base.PanelObject.transform.Find("Result/Kill/T").GetComponent("XUILabel") as IXUILabel);
			this.m_Death = (base.PanelObject.transform.Find("Result/Death/T").GetComponent("XUILabel") as IXUILabel);
			this.m_BattleData = (base.PanelObject.transform.Find("ItemList/BattleData").GetComponent("XUIButton") as IXUIButton);
			this.m_snapshot = (base.PanelObject.transform.Find("Snapshot/Snapshot").GetComponent("UIDummy") as IUIDummy);
		}

		// Token: 0x0600AA72 RID: 43634 RVA: 0x001E8309 File Offset: 0x001E6509
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Return.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnReturnClicked));
			this.m_BattleData.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankClicked));
		}

		// Token: 0x0600AA73 RID: 43635 RVA: 0x001E8343 File Offset: 0x001E6543
		private void OnReturnClicked(IXUISprite sp)
		{
			this.doc.SendLeaveScene();
		}

		// Token: 0x0600AA74 RID: 43636 RVA: 0x001E8354 File Offset: 0x001E6554
		private bool OnRankClicked(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<BigMeleeRankHandler>(ref this.entDoc.RankHandler, base.transform, true, null);
			this.entDoc.RankHandler.SetType(true);
			return true;
		}

		// Token: 0x0600AA75 RID: 43637 RVA: 0x001E8392 File Offset: 0x001E6592
		protected override void OnShow()
		{
			base.OnShow();
			this.OnShowUI();
		}

		// Token: 0x0600AA76 RID: 43638 RVA: 0x001E83A3 File Offset: 0x001E65A3
		public override void OnUnload()
		{
			XSingleton<X3DAvatarMgr>.singleton.OnUIUnloadMainDummy(this.m_snapshot);
			DlgHandlerBase.EnsureUnload<BigMeleeRankHandler>(ref this.entDoc.RankHandler);
			base.OnUnload();
		}

		// Token: 0x0600AA77 RID: 43639 RVA: 0x001E83D0 File Offset: 0x001E65D0
		private void OnShowUI()
		{
			XLevelRewardDocument.BigMeleeData bigMeleeBattleData = this.doc.BigMeleeBattleData;
			this.m_Score.SetText(bigMeleeBattleData.score.ToString());
			this.m_Kill.SetText(bigMeleeBattleData.kill.ToString());
			this.m_Death.SetText(bigMeleeBattleData.death.ToString());
			XSingleton<UiUtility>.singleton.ShowRank(this.m_RankImg, this.m_RankNum, (int)bigMeleeBattleData.rank);
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, this.m_snapshot);
			float interval = XSingleton<X3DAvatarMgr>.singleton.SetMainAnimationGetLength(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.Disappear);
			this.m_show_time_token = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this.KillDummyTimer), null);
		}

		// Token: 0x0600AA78 RID: 43640 RVA: 0x001E84A3 File Offset: 0x001E66A3
		private void KillDummyTimer(object sender)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_show_time_token);
			XSingleton<X3DAvatarMgr>.singleton.SetMainAnimation(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.AttackIdle);
		}

		// Token: 0x04003F2D RID: 16173
		private XLevelRewardDocument doc = null;

		// Token: 0x04003F2E RID: 16174
		private XBigMeleeEntranceDocument entDoc = null;

		// Token: 0x04003F2F RID: 16175
		private IUIDummy m_snapshot;

		// Token: 0x04003F30 RID: 16176
		private uint m_show_time_token = 0U;

		// Token: 0x04003F31 RID: 16177
		private IXUISprite m_Return;

		// Token: 0x04003F32 RID: 16178
		private IXUILabel m_RankNum;

		// Token: 0x04003F33 RID: 16179
		private IXUISprite m_RankImg;

		// Token: 0x04003F34 RID: 16180
		private IXUILabel m_Score;

		// Token: 0x04003F35 RID: 16181
		private IXUILabel m_Kill;

		// Token: 0x04003F36 RID: 16182
		private IXUILabel m_Death;

		// Token: 0x04003F37 RID: 16183
		private IXUIButton m_BattleData;
	}
}

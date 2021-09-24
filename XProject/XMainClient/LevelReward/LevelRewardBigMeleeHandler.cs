using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardBigMeleeHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardBigMeleeFrame";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Return.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnReturnClicked));
			this.m_BattleData.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankClicked));
		}

		private void OnReturnClicked(IXUISprite sp)
		{
			this.doc.SendLeaveScene();
		}

		private bool OnRankClicked(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<BigMeleeRankHandler>(ref this.entDoc.RankHandler, base.transform, true, null);
			this.entDoc.RankHandler.SetType(true);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.OnShowUI();
		}

		public override void OnUnload()
		{
			XSingleton<X3DAvatarMgr>.singleton.OnUIUnloadMainDummy(this.m_snapshot);
			DlgHandlerBase.EnsureUnload<BigMeleeRankHandler>(ref this.entDoc.RankHandler);
			base.OnUnload();
		}

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

		private void KillDummyTimer(object sender)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_show_time_token);
			XSingleton<X3DAvatarMgr>.singleton.SetMainAnimation(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.AttackIdle);
		}

		private XLevelRewardDocument doc = null;

		private XBigMeleeEntranceDocument entDoc = null;

		private IUIDummy m_snapshot;

		private uint m_show_time_token = 0U;

		private IXUISprite m_Return;

		private IXUILabel m_RankNum;

		private IXUISprite m_RankImg;

		private IXUILabel m_Score;

		private IXUILabel m_Kill;

		private IXUILabel m_Death;

		private IXUIButton m_BattleData;
	}
}

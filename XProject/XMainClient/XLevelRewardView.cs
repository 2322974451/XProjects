using System;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E14 RID: 3604
	internal class XLevelRewardView : DlgBase<XLevelRewardView, XLevelRewardBehaviour>
	{
		// Token: 0x17003405 RID: 13317
		// (get) Token: 0x0600C212 RID: 49682 RVA: 0x0029A1C0 File Offset: 0x002983C0
		public override string fileName
		{
			get
			{
				return "Battle/LevelRewardDlg";
			}
		}

		// Token: 0x17003406 RID: 13318
		// (get) Token: 0x0600C213 RID: 49683 RVA: 0x0029A1D8 File Offset: 0x002983D8
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003407 RID: 13319
		// (get) Token: 0x0600C214 RID: 49684 RVA: 0x0029A1EC File Offset: 0x002983EC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600C215 RID: 49685 RVA: 0x0029A1FF File Offset: 0x002983FF
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
		}

		// Token: 0x0600C216 RID: 49686 RVA: 0x0029A21C File Offset: 0x0029841C
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<LevelRewardGerenalHandler>(ref this._GerenalHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardSelectChestHandler>(ref this._SelectChestHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardPVPHandler>(ref this._PVPHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardSkyArenaHandler>(ref this._SkyArenaHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardBigMeleeHandler>(ref this._BigMeleeHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardBattleFieldHandler>(ref this._BattleFieldHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardAbyssPartyHandler>(ref this._AbyssPartyHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardRaceHandler>(ref this._RaceHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardBattleDataHandler>(ref this._BattleDataHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardStageFailHandler>(ref this._StageFailHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardArenaHandler>(ref this._ArenaHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardActivityHandler>(ref this._ActivityHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardSuperRiskHandler>(ref this._SuperRiskHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardSuperRiskFailHandler>(ref this._SuperRiskFailHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardProfTrialsHandler>(ref this._ProfTrialsHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardTerritoryHandler>(ref this._territoryHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardHeroBattleHandler>(ref this._heroBattleHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardMobaBattleHandler>(ref this._mobaBattleHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardCustomBattleHandler>(ref this._customBattleHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardReportHandler>(ref this._reportHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardWeekendPartyBattleHandler>(ref this._weekendPartyBattleHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardBattleRoyaleHandler>(ref this._battleRoyaleHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardRiftHandler>(ref this._riftHandler);
			this._DlgHandler = null;
			base.OnUnload();
		}

		// Token: 0x0600C217 RID: 49687 RVA: 0x0029A34C File Offset: 0x0029854C
		public void SetPowerpoint(int value)
		{
			DlgBase<PPTDlg, PPTBehaviour>.singleton.ShowPPT(value);
		}

		// Token: 0x0600C218 RID: 49688 RVA: 0x0029A35C File Offset: 0x0029855C
		public void ShowLevelReward(SceneType type)
		{
			bool flag = this._DlgHandler != null;
			if (flag)
			{
				this._DlgHandler.SetVisible(false);
				this._DlgHandler = null;
			}
			switch (type)
			{
			case SceneType.SCENE_ARENA:
			case SceneType.SCENE_PK:
			case SceneType.SCENE_INVFIGHT:
				this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardArenaHandler>(ref this._ArenaHandler, base.uiBehaviour.transform, true, null);
				return;
			case SceneType.SCENE_BOSSRUSH:
			case SceneType.SCENE_TOWER:
				this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardActivityHandler>(ref this._ActivityHandler, base.uiBehaviour.transform, true, null);
				return;
			case SceneType.SCENE_PVP:
				this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardPVPHandler>(ref this._PVPHandler, base.uiBehaviour.transform, true, null);
				return;
			case SceneType.SCENE_RISK:
			case SceneType.SCENE_RESWAR_PVP:
			case SceneType.SCENE_RESWAR_PVE:
				this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardSuperRiskHandler>(ref this._SuperRiskHandler, base.uiBehaviour.transform, true, null);
				return;
			case SceneType.SKYCITY_FIGHTING:
				this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardSkyArenaHandler>(ref this._SkyArenaHandler, base.uiBehaviour.transform, true, null);
				return;
			case SceneType.SCENE_PROF_TRIALS:
				this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardProfTrialsHandler>(ref this._ProfTrialsHandler, base.uiBehaviour.transform, true, null);
				return;
			case SceneType.SCENE_HORSE_RACE:
				this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardRaceHandler>(ref this._RaceHandler, base.uiBehaviour.transform, true, null);
				return;
			case SceneType.SCENE_HEROBATTLE:
				this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardHeroBattleHandler>(ref this._heroBattleHandler, base.uiBehaviour.transform, false, null);
				this._heroBattleHandler.PlayCutScene();
				return;
			case SceneType.SCENE_CASTLE_WAIT:
			case SceneType.SCENE_CASTLE_FIGHT:
				this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardTerritoryHandler>(ref this._territoryHandler, base.uiBehaviour.transform, true, null);
				return;
			case SceneType.SCENE_ABYSS_PARTY:
				this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardAbyssPartyHandler>(ref this._AbyssPartyHandler, base.uiBehaviour.transform, true, this);
				return;
			case SceneType.SCENE_CUSTOMPK:
			case SceneType.SCENE_CUSTOMPKTWO:
				this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardCustomBattleHandler>(ref this._customBattleHandler, base.uiBehaviour.transform, true, null);
				return;
			case SceneType.SCENE_MOBA:
				this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardMobaBattleHandler>(ref this._mobaBattleHandler, base.uiBehaviour.transform, false, null);
				this._mobaBattleHandler.PlayCutScene();
				return;
			case SceneType.SCENE_WEEKEND4V4_MONSTERFIGHT:
			case SceneType.SCENE_WEEKEND4V4_GHOSTACTION:
			case SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE:
			case SceneType.SCENE_WEEKEND4V4_CRAZYBOMB:
			case SceneType.SCENE_WEEKEND4V4_HORSERACING:
			case SceneType.SCENE_WEEKEND4V4_DUCK:
				this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardWeekendPartyBattleHandler>(ref this._weekendPartyBattleHandler, base.uiBehaviour.transform, true, null);
				return;
			case SceneType.SCENE_BIGMELEE_FIGHT:
				this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardBigMeleeHandler>(ref this._BigMeleeHandler, base.uiBehaviour.transform, true, null);
				return;
			case SceneType.SCENE_BATTLEFIELD_FIGHT:
				this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardBattleFieldHandler>(ref this._BattleFieldHandler, base.uiBehaviour.transform, true, null);
				return;
			case SceneType.SCENE_SURVIVE:
				this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardBattleRoyaleHandler>(ref this._battleRoyaleHandler, base.uiBehaviour.transform, true, null);
				return;
			case SceneType.SCENE_RIFT:
				this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardRiftHandler>(ref this._riftHandler, base.uiBehaviour.transform, true, null);
				return;
			}
			this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardGerenalHandler>(ref this._GerenalHandler, base.uiBehaviour.transform, true, null);
		}

		// Token: 0x0600C219 RID: 49689 RVA: 0x0029A762 File Offset: 0x00298962
		protected override void OnShow()
		{
			base.OnShow();
			XPlatformAbilityDocument.Doc.QueryQQVipInfo();
		}

		// Token: 0x0600C21A RID: 49690 RVA: 0x0029A778 File Offset: 0x00298978
		public void RefreshQQVip()
		{
			bool flag = base.IsVisible() && this._GerenalHandler != null && this._GerenalHandler.IsVisible();
			if (flag)
			{
				this._GerenalHandler.RefreshQQVipInfo(this._doc.CurrentStage);
			}
		}

		// Token: 0x0600C21B RID: 49691 RVA: 0x0029A7C4 File Offset: 0x002989C4
		public void ShowSelectChestFrame()
		{
			bool flag = this._DlgHandler != null;
			if (flag)
			{
				this._DlgHandler.SetVisible(false);
				this._DlgHandler = null;
			}
			this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardSelectChestHandler>(ref this._SelectChestHandler, base.uiBehaviour.transform, true, null);
		}

		// Token: 0x0600C21C RID: 49692 RVA: 0x0029A813 File Offset: 0x00298A13
		public void ShowBattleDataFrame()
		{
			DlgHandlerBase.EnsureCreate<LevelRewardBattleDataHandler>(ref this._BattleDataHandler, base.uiBehaviour.transform, true, null);
		}

		// Token: 0x0600C21D RID: 49693 RVA: 0x0029A830 File Offset: 0x00298A30
		public void RefreshSelectChest()
		{
			bool flag = this._SelectChestHandler != null && this._DlgHandler == this._SelectChestHandler && this._SelectChestHandler.CurrentStatus != LevelRewardSelectChestHandler.SelectChestStatus.SelectFinish;
			if (flag)
			{
				this._SelectChestHandler.RefreshSelectChest();
			}
		}

		// Token: 0x0600C21E RID: 49694 RVA: 0x0029A87C File Offset: 0x00298A7C
		public void RefreshSelectChestLeftTime()
		{
			bool flag = this._SelectChestHandler != null && this._DlgHandler == this._SelectChestHandler && this._SelectChestHandler.CurrentStatus != LevelRewardSelectChestHandler.SelectChestStatus.SelectFinish;
			if (flag)
			{
				this._SelectChestHandler.RefreshLeftTime();
			}
		}

		// Token: 0x0600C21F RID: 49695 RVA: 0x0029A8C8 File Offset: 0x00298AC8
		public void ShowAllChest()
		{
			bool flag = this._SelectChestHandler != null && this._DlgHandler == this._SelectChestHandler && this._SelectChestHandler.CurrentStatus != LevelRewardSelectChestHandler.SelectChestStatus.SelectFinish;
			if (flag)
			{
				this._SelectChestHandler.ShowAllChest();
			}
		}

		// Token: 0x0600C220 RID: 49696 RVA: 0x0029A914 File Offset: 0x00298B14
		public void SetPeerResult()
		{
			bool flag = this._SelectChestHandler != null && this._DlgHandler == this._SelectChestHandler && this._SelectChestHandler.CurrentStatus != LevelRewardSelectChestHandler.SelectChestStatus.SelectFinish;
			if (flag)
			{
				this._SelectChestHandler.SetPeerResult();
			}
		}

		// Token: 0x0600C221 RID: 49697 RVA: 0x0029A960 File Offset: 0x00298B60
		public void ShowStageFailFrame(SceneType type)
		{
			bool flag = this._DlgHandler != null;
			if (flag)
			{
				this._DlgHandler.SetVisible(false);
				this._DlgHandler = null;
			}
			bool flag2 = DlgBase<RadioBattleDlg, RadioBattleBahaviour>.singleton.IsLoaded();
			if (flag2)
			{
				DlgBase<RadioBattleDlg, RadioBattleBahaviour>.singleton.Show(false);
			}
			bool flag3 = DlgBase<XChatView, XChatBehaviour>.singleton.IsLoaded();
			if (flag3)
			{
				DlgBase<XChatView, XChatBehaviour>.singleton.SetVisible(false, true);
			}
			DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetFakeHide(true);
			if (type <= SceneType.SCENE_RESWAR_PVE)
			{
				if (type == SceneType.SCENE_RISK || type - SceneType.SCENE_RESWAR_PVP <= 1)
				{
					this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardSuperRiskFailHandler>(ref this._SuperRiskFailHandler, base.uiBehaviour.transform, true, null);
					return;
				}
			}
			else if (type == SceneType.SCENE_CUSTOMPK || type == SceneType.SCENE_CUSTOMPKTWO)
			{
				this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardCustomBattleHandler>(ref this._customBattleHandler, base.uiBehaviour.transform, true, null);
				return;
			}
			this._DlgHandler = DlgHandlerBase.EnsureCreate<LevelRewardStageFailHandler>(ref this._StageFailHandler, base.uiBehaviour.transform, true, null);
		}

		// Token: 0x0600C222 RID: 49698 RVA: 0x0029AA60 File Offset: 0x00298C60
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this._DlgHandler != null;
			if (flag)
			{
				this._DlgHandler.OnUpdate();
			}
		}

		// Token: 0x0600C223 RID: 49699 RVA: 0x0029AA90 File Offset: 0x00298C90
		public LevelRewardTerritoryHandler GetTerritoryHandler()
		{
			return this._territoryHandler;
		}

		// Token: 0x0600C224 RID: 49700 RVA: 0x0029AAA8 File Offset: 0x00298CA8
		public void CutSceneShowEnd()
		{
			SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
			if (sceneType != SceneType.SCENE_HEROBATTLE)
			{
				if (sceneType == SceneType.SCENE_MOBA)
				{
					bool flag = this._mobaBattleHandler != null;
					if (flag)
					{
						this._mobaBattleHandler.ShowUI();
					}
				}
			}
			else
			{
				bool flag2 = this._heroBattleHandler != null;
				if (flag2)
				{
					this._heroBattleHandler.ShowUI();
				}
			}
		}

		// Token: 0x0600C225 RID: 49701 RVA: 0x0029AB08 File Offset: 0x00298D08
		public void ShowReport(ulong uid, string name, IXUISprite reportBtn)
		{
			bool flag = this._reportHandler == null;
			if (flag)
			{
				DlgHandlerBase.EnsureCreate<LevelRewardReportHandler>(ref this._reportHandler, base.uiBehaviour.transform, true, null);
			}
			else
			{
				this._reportHandler.SetVisible(true);
			}
			this._reportHandler.InitShow(uid, name, reportBtn);
		}

		// Token: 0x04005290 RID: 21136
		public DlgHandlerBase _DlgHandler = null;

		// Token: 0x04005291 RID: 21137
		private LevelRewardGerenalHandler _GerenalHandler = null;

		// Token: 0x04005292 RID: 21138
		private LevelRewardSelectChestHandler _SelectChestHandler = null;

		// Token: 0x04005293 RID: 21139
		private LevelRewardPVPHandler _PVPHandler = null;

		// Token: 0x04005294 RID: 21140
		private LevelRewardSkyArenaHandler _SkyArenaHandler = null;

		// Token: 0x04005295 RID: 21141
		private LevelRewardBigMeleeHandler _BigMeleeHandler = null;

		// Token: 0x04005296 RID: 21142
		private LevelRewardBattleFieldHandler _BattleFieldHandler = null;

		// Token: 0x04005297 RID: 21143
		private LevelRewardAbyssPartyHandler _AbyssPartyHandler = null;

		// Token: 0x04005298 RID: 21144
		private LevelRewardRaceHandler _RaceHandler = null;

		// Token: 0x04005299 RID: 21145
		private LevelRewardBattleDataHandler _BattleDataHandler = null;

		// Token: 0x0400529A RID: 21146
		private LevelRewardStageFailHandler _StageFailHandler = null;

		// Token: 0x0400529B RID: 21147
		private LevelRewardArenaHandler _ArenaHandler = null;

		// Token: 0x0400529C RID: 21148
		private LevelRewardActivityHandler _ActivityHandler = null;

		// Token: 0x0400529D RID: 21149
		private LevelRewardSuperRiskHandler _SuperRiskHandler = null;

		// Token: 0x0400529E RID: 21150
		private LevelRewardSuperRiskFailHandler _SuperRiskFailHandler = null;

		// Token: 0x0400529F RID: 21151
		private LevelRewardProfTrialsHandler _ProfTrialsHandler = null;

		// Token: 0x040052A0 RID: 21152
		private LevelRewardTerritoryHandler _territoryHandler = null;

		// Token: 0x040052A1 RID: 21153
		private LevelRewardHeroBattleHandler _heroBattleHandler = null;

		// Token: 0x040052A2 RID: 21154
		private LevelRewardMobaBattleHandler _mobaBattleHandler = null;

		// Token: 0x040052A3 RID: 21155
		private LevelRewardCustomBattleHandler _customBattleHandler = null;

		// Token: 0x040052A4 RID: 21156
		private LevelRewardWeekendPartyBattleHandler _weekendPartyBattleHandler = null;

		// Token: 0x040052A5 RID: 21157
		private LevelRewardBattleRoyaleHandler _battleRoyaleHandler = null;

		// Token: 0x040052A6 RID: 21158
		public LevelRewardReportHandler _reportHandler = null;

		// Token: 0x040052A7 RID: 21159
		private LevelRewardRiftHandler _riftHandler = null;

		// Token: 0x040052A8 RID: 21160
		private XLevelRewardDocument _doc;
	}
}

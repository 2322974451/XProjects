using System;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLevelRewardView : DlgBase<XLevelRewardView, XLevelRewardBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Battle/LevelRewardDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
		}

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

		public void SetPowerpoint(int value)
		{
			DlgBase<PPTDlg, PPTBehaviour>.singleton.ShowPPT(value);
		}

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

		protected override void OnShow()
		{
			base.OnShow();
			XPlatformAbilityDocument.Doc.QueryQQVipInfo();
		}

		public void RefreshQQVip()
		{
			bool flag = base.IsVisible() && this._GerenalHandler != null && this._GerenalHandler.IsVisible();
			if (flag)
			{
				this._GerenalHandler.RefreshQQVipInfo(this._doc.CurrentStage);
			}
		}

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

		public void ShowBattleDataFrame()
		{
			DlgHandlerBase.EnsureCreate<LevelRewardBattleDataHandler>(ref this._BattleDataHandler, base.uiBehaviour.transform, true, null);
		}

		public void RefreshSelectChest()
		{
			bool flag = this._SelectChestHandler != null && this._DlgHandler == this._SelectChestHandler && this._SelectChestHandler.CurrentStatus != LevelRewardSelectChestHandler.SelectChestStatus.SelectFinish;
			if (flag)
			{
				this._SelectChestHandler.RefreshSelectChest();
			}
		}

		public void RefreshSelectChestLeftTime()
		{
			bool flag = this._SelectChestHandler != null && this._DlgHandler == this._SelectChestHandler && this._SelectChestHandler.CurrentStatus != LevelRewardSelectChestHandler.SelectChestStatus.SelectFinish;
			if (flag)
			{
				this._SelectChestHandler.RefreshLeftTime();
			}
		}

		public void ShowAllChest()
		{
			bool flag = this._SelectChestHandler != null && this._DlgHandler == this._SelectChestHandler && this._SelectChestHandler.CurrentStatus != LevelRewardSelectChestHandler.SelectChestStatus.SelectFinish;
			if (flag)
			{
				this._SelectChestHandler.ShowAllChest();
			}
		}

		public void SetPeerResult()
		{
			bool flag = this._SelectChestHandler != null && this._DlgHandler == this._SelectChestHandler && this._SelectChestHandler.CurrentStatus != LevelRewardSelectChestHandler.SelectChestStatus.SelectFinish;
			if (flag)
			{
				this._SelectChestHandler.SetPeerResult();
			}
		}

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

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this._DlgHandler != null;
			if (flag)
			{
				this._DlgHandler.OnUpdate();
			}
		}

		public LevelRewardTerritoryHandler GetTerritoryHandler()
		{
			return this._territoryHandler;
		}

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

		public DlgHandlerBase _DlgHandler = null;

		private LevelRewardGerenalHandler _GerenalHandler = null;

		private LevelRewardSelectChestHandler _SelectChestHandler = null;

		private LevelRewardPVPHandler _PVPHandler = null;

		private LevelRewardSkyArenaHandler _SkyArenaHandler = null;

		private LevelRewardBigMeleeHandler _BigMeleeHandler = null;

		private LevelRewardBattleFieldHandler _BattleFieldHandler = null;

		private LevelRewardAbyssPartyHandler _AbyssPartyHandler = null;

		private LevelRewardRaceHandler _RaceHandler = null;

		private LevelRewardBattleDataHandler _BattleDataHandler = null;

		private LevelRewardStageFailHandler _StageFailHandler = null;

		private LevelRewardArenaHandler _ArenaHandler = null;

		private LevelRewardActivityHandler _ActivityHandler = null;

		private LevelRewardSuperRiskHandler _SuperRiskHandler = null;

		private LevelRewardSuperRiskFailHandler _SuperRiskFailHandler = null;

		private LevelRewardProfTrialsHandler _ProfTrialsHandler = null;

		private LevelRewardTerritoryHandler _territoryHandler = null;

		private LevelRewardHeroBattleHandler _heroBattleHandler = null;

		private LevelRewardMobaBattleHandler _mobaBattleHandler = null;

		private LevelRewardCustomBattleHandler _customBattleHandler = null;

		private LevelRewardWeekendPartyBattleHandler _weekendPartyBattleHandler = null;

		private LevelRewardBattleRoyaleHandler _battleRoyaleHandler = null;

		public LevelRewardReportHandler _reportHandler = null;

		private LevelRewardRiftHandler _riftHandler = null;

		private XLevelRewardDocument _doc;
	}
}

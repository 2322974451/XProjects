using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XHeroBattleDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XHeroBattleDocument.uuID;
			}
		}

		private XHeroBattleSkillDocument _skillDoc
		{
			get
			{
				bool flag = this._valueDoc == null;
				if (flag)
				{
					this._valueDoc = XDocuments.GetSpecificDocument<XHeroBattleSkillDocument>(XHeroBattleSkillDocument.uuID);
				}
				return this._valueDoc;
			}
		}

		public OverWatchTable OverWatchReader
		{
			get
			{
				return XHeroBattleDocument._overWatchReader;
			}
		}

		public HeroBattleMapCenter HeroBattleMapReader
		{
			get
			{
				return XHeroBattleDocument._heroBattleMapReader;
			}
		}

		public HeroBattleTips HerobattletipsReader
		{
			get
			{
				return XHeroBattleDocument._herobattletips;
			}
		}

		public HeroBattleWeekReward HeroBattleWeekRewardReader
		{
			get
			{
				return XHeroBattleDocument._heroBattleWeekReward;
			}
		}

		public HeroBattleExperienceHero HeroExperienceReader
		{
			get
			{
				return XHeroBattleDocument._experienceReader;
			}
		}

		public List<BattleRecordGameInfo> RecordList
		{
			get
			{
				return this._recordList;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XHeroBattleDocument.AsyncLoader.AddTask("Table/OverWatch", XHeroBattleDocument._overWatchReader, false);
			XHeroBattleDocument.AsyncLoader.AddTask("Table/HeroBattleTips", XHeroBattleDocument._herobattletips, false);
			XHeroBattleDocument.AsyncLoader.AddTask("Table/HeroBattleWeekReward", XHeroBattleDocument._heroBattleWeekReward, false);
			XHeroBattleDocument.AsyncLoader.AddTask("Table/HeroBattleMapCenter", XHeroBattleDocument._heroBattleMapReader, false);
			XHeroBattleDocument.AsyncLoader.AddTask("Table/HeroBattleExperienceHero", XHeroBattleDocument._experienceReader, false);
			XHeroBattleDocument.AsyncLoader.Execute(callback);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_RealDead, new XComponent.XEventHandler(this.OnPlayerDeathEvent));
			base.RegisterEvent(XEventDefine.XEvent_OnRevived, new XComponent.XEventHandler(this.OnPlayerReviveEvent));
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool loadSkillHandler = XHeroBattleDocument.LoadSkillHandler;
			if (loadSkillHandler)
			{
				XHeroBattleSkillDocument.IsWeekendNestLoad = true;
				XHeroBattleDocument.LoadSkillHandler = false;
			}
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE;
			if (flag)
			{
				XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
				bool flag2 = !XSingleton<XScene>.singleton.bSpectator && !specificDocument.bInTeam;
				if (flag2)
				{
					XSingleton<XUICacheMgr>.singleton.CacheUI(XSysDefine.XSys_HeroBattle, EXStage.Hall);
				}
			}
			else
			{
				bool isWeekendNestLoad = XHeroBattleSkillDocument.IsWeekendNestLoad;
				if (isWeekendNestLoad)
				{
					XSingleton<XTimerMgr>.singleton.SetTimer(2f, new XTimerMgr.ElapsedEventHandler(this.ShowHeroNestTips), null);
				}
			}
		}

		private void ShowHeroNestTips(object o = null)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("WeekendHeroNestLevelTips"), "fece00");
		}

		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			this.TeamBlood.Clear();
		}

		public void QueryHeroBattleUIInfo()
		{
			RpcC2G_GetHeroBattleInfo rpc = new RpcC2G_GetHeroBattleInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void QueryGetReward()
		{
			RpcC2G_GetHeroBattleWeekReward rpc = new RpcC2G_GetHeroBattleWeekReward();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnGetRewardSuccess(bool getState, uint stage)
		{
			this.GetRewardStage = stage;
			this.RewardState = HeroBattleRewardState.CanNotGet;
			if (getState)
			{
				this.RewardState = HeroBattleRewardState.CanGet;
			}
			bool flag = this.GetRewardStage == this.HeroBattleWeekRewardReader.Table[this.HeroBattleWeekRewardReader.Table.Length - 1].id;
			if (flag)
			{
				this.GetRewardStage -= 1U;
				this.RewardState = HeroBattleRewardState.GetEnd;
			}
			bool flag2 = DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.RefreshInfo();
			}
		}

		public void QueryBattleRecord()
		{
			RpcC2G_GetHeroBattleGameRecord rpc = new RpcC2G_GetHeroBattleGameRecord();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void QueryRankInfo()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.HeroBattleRank);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		public void QueryLastSeasonRankInfo()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.LastWeek_HeroBattleRank);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		public void SetBattleRecord(List<HeroBattleOneGame> list)
		{
			this._recordList.Clear();
			for (int i = list.Count - 1; i >= 0; i--)
			{
				BattleRecordGameInfo battleRecordGameInfo = new BattleRecordGameInfo();
				bool flag = true;
				for (int j = 0; j < list[i].team1.Count; j++)
				{
					bool flag2 = list[i].team1[j].roleID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag2)
					{
						flag = true;
						battleRecordGameInfo.left.Add(this.GetOnePlayerInfo(list[i].team1[j]));
					}
				}
				for (int k = 0; k < list[i].team2.Count; k++)
				{
					bool flag3 = list[i].team2[k].roleID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag3)
					{
						flag = false;
						battleRecordGameInfo.left.Add(this.GetOnePlayerInfo(list[i].team2[k]));
					}
				}
				for (int l = 0; l < list[i].team1.Count; l++)
				{
					bool flag4 = list[i].team1[l].roleID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (!flag4)
					{
						bool flag5 = flag;
						if (flag5)
						{
							battleRecordGameInfo.left.Add(this.GetOnePlayerInfo(list[i].team1[l]));
						}
						else
						{
							battleRecordGameInfo.right.Add(this.GetOnePlayerInfo(list[i].team1[l]));
						}
					}
				}
				for (int m = 0; m < list[i].team2.Count; m++)
				{
					bool flag6 = list[i].team2[m].roleID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (!flag6)
					{
						bool flag7 = flag;
						if (flag7)
						{
							battleRecordGameInfo.right.Add(this.GetOnePlayerInfo(list[i].team2[m]));
						}
						else
						{
							battleRecordGameInfo.left.Add(this.GetOnePlayerInfo(list[i].team2[m]));
						}
					}
				}
				battleRecordGameInfo.result = list[i].over;
				battleRecordGameInfo.militaryExploit = list[i].exploit;
				this._recordList.Add(battleRecordGameInfo);
			}
			bool flag8 = DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.IsVisible() && DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.m_HeroBattleRecordHandler != null && DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.m_HeroBattleRecordHandler.IsVisible();
			if (flag8)
			{
				DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.m_HeroBattleRecordHandler.SetupRecord(this.RecordList);
			}
			bool flag9 = DlgBase<MilitaryRankDlg, MilitaryRankBehaviour>.singleton.IsVisible() && DlgBase<MilitaryRankDlg, MilitaryRankBehaviour>.singleton.m_BattleRecordHandler != null && DlgBase<MilitaryRankDlg, MilitaryRankBehaviour>.singleton.m_BattleRecordHandler.IsVisible();
			if (flag9)
			{
				DlgBase<MilitaryRankDlg, MilitaryRankBehaviour>.singleton.m_BattleRecordHandler.SetupRecord(this.RecordList);
			}
		}

		public BattleRecordPlayerInfo GetOnePlayerInfo(RoleSmallInfo data)
		{
			return new BattleRecordPlayerInfo
			{
				name = data.roleName,
				profression = data.roleProfession,
				roleID = data.roleID
			};
		}

		public void SetHeroBattleInfo(GetHeroBattleInfoRes data)
		{
			this._skillDoc.SetHeroHoldStatus(data.weekhero, data.havehero, data.experiencehero, data.experienceherolefttime);
			this.BattleTotal = data.totalnum;
			this.BattleWin = data.winnum;
			this.BattleLose = data.losenum;
			this.WinThisWeek = data.winthisweek;
			this.JoinToday = data.todaygetspcount;
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_HeroBattle, true);
			this.GetRewardStage = data.weekprize;
			this.RewardState = HeroBattleRewardState.CanNotGet;
			bool cangetprize = data.cangetprize;
			if (cangetprize)
			{
				this.RewardState = HeroBattleRewardState.CanGet;
			}
			bool flag = this.GetRewardStage == this.HeroBattleWeekRewardReader.Table[this.HeroBattleWeekRewardReader.Table.Length - 1].id;
			if (flag)
			{
				this.GetRewardStage -= 1U;
				this.RewardState = HeroBattleRewardState.GetEnd;
			}
			bool flag2 = DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.RefreshInfo();
				bool flag3 = DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.m_HeroBattleSkillHandler != null;
				if (flag3)
				{
					DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.m_HeroBattleSkillHandler.SetupTabs();
				}
			}
			bool flag4 = DlgBase<MobaEntranceView, MobaEntranceBehaviour>.singleton.IsVisible();
			if (flag4)
			{
				bool flag5 = DlgBase<MobaEntranceView, MobaEntranceBehaviour>.singleton.m_HeroBattleSkillHandler != null;
				if (flag5)
				{
					DlgBase<MobaEntranceView, MobaEntranceBehaviour>.singleton.m_HeroBattleSkillHandler.SetupTabs();
				}
			}
		}

		public void SetHeroBattleInfo(HeroBattleRecord data)
		{
			this._skillDoc.SetHeroHoldStatus(data.freeweekhero, data.havehero, data.experiencehero, data.experienceherotime);
			this.BattleTotal = data.totalnum;
			this.BattleWin = data.winnum;
			this.BattleLose = data.losenum;
			this.WinThisWeek = data.winthisweek;
			this.JoinToday = data.todayspcount;
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_HeroBattle, true);
			this.GetRewardStage = data.weekprize;
			this.RewardState = HeroBattleRewardState.CanNotGet;
			bool cangetprize = data.cangetprize;
			if (cangetprize)
			{
				this.RewardState = HeroBattleRewardState.CanGet;
			}
			bool flag = this.GetRewardStage == this.HeroBattleWeekRewardReader.Table[this.HeroBattleWeekRewardReader.Table.Length - 1].id;
			if (flag)
			{
				this.GetRewardStage -= 1U;
				this.RewardState = HeroBattleRewardState.GetEnd;
			}
		}

		public void SetHeroBattleMyTeam(HeroBattleTeamRoleData data)
		{
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
			if (!flag)
			{
				bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
				ulong num;
				if (bSpectator)
				{
					num = this.SpectateUid;
				}
				else
				{
					num = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				}
				this.heroIDIndex.Clear();
				for (int i = 0; i < data.members1.Count; i++)
				{
					this.heroIDIndex[data.members1[i].uid] = data.members1[i].heroid;
					bool flag2 = data.members1[i].uid == num;
					if (flag2)
					{
						this.MyTeam = data.team1;
						bool flag3 = !this._skillDoc.AlSelectHero && data.members1[i].heroid > 0U;
						if (flag3)
						{
							this._skillDoc.SetAlreadySelectHero();
						}
					}
				}
				for (int j = 0; j < data.members2.Count; j++)
				{
					this.heroIDIndex[data.members2[j].uid] = data.members2[j].heroid;
					bool flag4 = data.members2[j].uid == num;
					if (flag4)
					{
						this.MyTeam = data.team2;
						bool flag5 = !this._skillDoc.AlSelectHero && data.members2[j].heroid > 0U;
						if (flag5)
						{
							this._skillDoc.SetAlreadySelectHero();
						}
					}
				}
				BattleIndicateHandler battleIndicateHandler = XSingleton<XScene>.singleton.bSpectator ? DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler : DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler;
				bool flag6 = battleIndicateHandler != null;
				if (flag6)
				{
					for (int k = 0; k < data.members1.Count; k++)
					{
						battleIndicateHandler.SetHeroMiniMapElement(data.members1[k].uid, data.members1[k].heroid, data.team1 == this.MyTeam, false);
						bool flag7 = data.members1[k].uid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
						if (flag7)
						{
							bool flag8 = this._HeroBattleHandler != null && this._HeroBattleHandler.IsVisible();
							if (flag8)
							{
								this._HeroBattleHandler.RefreshScoreBoard(data.members1[k].killnum, data.members1[k].deathnum, data.members1[k].assitnum);
							}
						}
					}
					for (int l = 0; l < data.members2.Count; l++)
					{
						battleIndicateHandler.SetHeroMiniMapElement(data.members2[l].uid, data.members2[l].heroid, data.team2 == this.MyTeam, false);
						bool flag9 = data.members2[l].uid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
						if (flag9)
						{
							bool flag10 = this._HeroBattleHandler != null && this._HeroBattleHandler.IsVisible();
							if (flag10)
							{
								this._HeroBattleHandler.RefreshScoreBoard(data.members2[l].killnum, data.members2[l].deathnum, data.members2[l].assitnum);
							}
						}
					}
				}
				bool flag11 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor != null;
				if (flag11)
				{
					this.TeamBlood.Clear();
					this._skillDoc.TAS.Clear();
					bool flag12 = this.MyTeam == data.team1;
					if (flag12)
					{
						for (int m = 0; m < data.members1.Count; m++)
						{
							this.TeamBlood.Add(this.Turn2TeamBloodData(data.members1[m]));
							bool flag13 = data.members1[m].uid != num;
							if (flag13)
							{
								this._skillDoc.TAS.Add(data.members1[m].heroid);
							}
						}
					}
					else
					{
						for (int n = 0; n < data.members2.Count; n++)
						{
							this.TeamBlood.Add(this.Turn2TeamBloodData(data.members2[n]));
							bool flag14 = data.members2[n].uid != num;
							if (flag14)
							{
								this._skillDoc.TAS.Add(data.members2[n].heroid);
							}
						}
					}
					bool flag15 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE;
					if (flag15)
					{
						DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.TeamInfoChangeOnSpectate(this.TeamBlood);
					}
					bool flag16 = this._skillDoc._HeroBattleTeamHandler != null;
					if (flag16)
					{
						this._skillDoc._HeroBattleTeamHandler.Refresh();
					}
					bool flag17 = !this._skillDoc.CSSH && this._skillDoc.m_HeroBattleSkillHandler != null;
					if (flag17)
					{
						this._skillDoc.m_HeroBattleSkillHandler.RefreshTab();
					}
				}
				bool flag18 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded() && DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor != null;
				if (flag18)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor.OnTeamInfoChanged();
				}
				bool flag19 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE;
				if (flag19)
				{
					this.RankList.Clear();
					bool flag20 = !DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() || data.team1 == this.MyTeam;
					if (flag20)
					{
						for (int num2 = 0; num2 < data.members1.Count; num2++)
						{
							this.RankList.Add(this.Turn2DamageData(data.members1[num2]));
						}
					}
					bool flag21 = !DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() || data.team2 == this.MyTeam;
					if (flag21)
					{
						for (int num3 = 0; num3 < data.members2.Count; num3++)
						{
							this.RankList.Add(this.Turn2DamageData(data.members2[num3]));
						}
					}
					XSceneDamageRankDocument specificDocument = XDocuments.GetSpecificDocument<XSceneDamageRankDocument>(XSceneDamageRankDocument.uuID);
					specificDocument.OnGetRank(this.RankList);
				}
			}
		}

		private XTeamBloodUIData Turn2TeamBloodData(HeroBattleTeamMember data)
		{
			return new XTeamBloodUIData
			{
				uid = data.uid,
				entityID = data.uid,
				level = 0U,
				name = data.name,
				bIsLeader = false,
				profession = RoleType.Role_Warrior
			};
		}

		private XCaptainPVPInfo Turn2DamageData(HeroBattleTeamMember data)
		{
			return new XCaptainPVPInfo
			{
				name = data.name,
				kill = (int)data.killnum,
				dead = (int)data.deathnum,
				id = data.uid,
				assit = (int)data.assitnum
			};
		}

		public void SetHeroBattleTeamData(HeroBattleTeamMsg data)
		{
			bool flag = this._HeroBattleHandler != null;
			if (flag)
			{
				this._HeroBattleHandler.SetTeamData(data);
			}
		}

		public void SetHeroBattleProgressData(HeroBattleSyncData data)
		{
			bool flag = this._HeroBattleHandler != null;
			if (flag)
			{
				this._HeroBattleHandler.SetProgressData(data);
			}
		}

		public void SetHeroBattleInCircleData(HeroBattleInCircle data)
		{
			bool flag = this._HeroBattleHandler != null;
			if (flag)
			{
				this._HeroBattleHandler.SetInCircleData(data);
			}
		}

		public void StartHeroBattleAddTime(int time)
		{
			bool flag = this._HeroBattleHandler != null;
			if (flag)
			{
				this._HeroBattleHandler.StartAddTime(time);
			}
		}

		public bool OnPlayerDeathEvent(XEventArgs args)
		{
			bool flag = this._HeroBattleHandler == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XRealDeadEventArgs xrealDeadEventArgs = args as XRealDeadEventArgs;
				bool flag2 = !xrealDeadEventArgs.TheDead.IsPlayer;
				if (flag2)
				{
					result = false;
				}
				else
				{
					this._HeroBattleHandler.SetDeathGoState(true);
					this._HeroBattleHandler.SetReviveLeftTime();
					bool flag3 = this._skillDoc.m_HeroBattleSkillHandler != null;
					if (flag3)
					{
						this._skillDoc.m_HeroBattleSkillHandler.SetCountDown(float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("HeroBattleReviveTime")), false);
					}
					result = true;
				}
			}
			return result;
		}

		public bool OnPlayerReviveEvent(XEventArgs args)
		{
			bool flag = this._HeroBattleHandler == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XOnRevivedArgs xonRevivedArgs = args as XOnRevivedArgs;
				bool flag2 = !xonRevivedArgs.entity.IsPlayer;
				if (flag2)
				{
					result = false;
				}
				else
				{
					this._HeroBattleHandler.SetDeathGoState(false);
					result = true;
				}
			}
			return result;
		}

		public void SetUIDeathGoState(bool state)
		{
			bool flag = this._HeroBattleHandler != null;
			if (flag)
			{
				this._HeroBattleHandler.SetDeathGoState(state);
			}
			bool flag2 = this._skillDoc.m_HeroBattleSkillHandler != null;
			if (flag2)
			{
				this._skillDoc.m_HeroBattleSkillHandler.SetVisible(false);
			}
		}

		public void ReceiveBattleSkill(PvpBattleKill battleSkillInfo)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_HEROBATTLE;
			if (!flag)
			{
				GVGBattleSkill gvgbattleSkill = new GVGBattleSkill();
				gvgbattleSkill.killerID = battleSkillInfo.killID;
				gvgbattleSkill.deadID = battleSkillInfo.deadID;
				gvgbattleSkill.contiKillCount = battleSkillInfo.contiKillCount;
				bool flag2 = false;
				for (int i = 0; i < battleSkillInfo.assitids.Count; i++)
				{
					bool flag3 = battleSkillInfo.assitids[i] == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag3)
					{
						flag2 = true;
						break;
					}
				}
				bool flag4 = flag2;
				if (flag4)
				{
					gvgbattleSkill.contiKillCount = -1;
					DlgBase<BattleContiDlg, BattleContiBehaviour>.singleton.AddBattleSkill(gvgbattleSkill);
				}
				else
				{
					XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(gvgbattleSkill.killerID);
					XEntity entityConsiderDeath2 = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(gvgbattleSkill.deadID);
					bool flag5 = entityConsiderDeath == null || entityConsiderDeath2 == null;
					if (flag5)
					{
						XSingleton<XDebug>.singleton.AddLog("entity id: " + gvgbattleSkill.killerID, " dead id: " + gvgbattleSkill.deadID, null, null, null, null, XDebugColor.XDebug_None);
						return;
					}
					gvgbattleSkill.killerName = entityConsiderDeath.Name;
					gvgbattleSkill.deadName = entityConsiderDeath2.Name;
					gvgbattleSkill.killerPosition = XSingleton<XEntityMgr>.singleton.IsAlly(entityConsiderDeath);
					DlgBase<BattleContiDlg, BattleContiBehaviour>.singleton.AddBattleSkill(gvgbattleSkill);
					XSingleton<XDebug>.singleton.AddGreenLog(string.Format("ReceiveBattleSkill:{0} --- ,{1} ,.... {2}", gvgbattleSkill.killerName, gvgbattleSkill.deadName, gvgbattleSkill.contiKillCount), null, null, null, null, null);
				}
				for (int j = 0; j < this.RankList.Count; j++)
				{
					bool flag6 = battleSkillInfo.killID == this.RankList[j].id;
					if (flag6)
					{
						this.RankList[j].kill++;
					}
					bool flag7 = battleSkillInfo.deadID == this.RankList[j].id;
					if (flag7)
					{
						this.RankList[j].dead++;
					}
				}
				XSceneDamageRankDocument specificDocument = XDocuments.GetSpecificDocument<XSceneDamageRankDocument>(XSceneDamageRankDocument.uuID);
				specificDocument.OnGetRank(this.RankList);
			}
		}

		public void GetBattleTips(uint id)
		{
			bool flag = !DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (!flag)
			{
				HeroBattleTips.RowData byid = XHeroBattleDocument._herobattletips.GetByid(id);
				bool flag2 = byid != null;
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.ShowNotice(byid.tips, 3f, 3f);
				}
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.QueryHeroBattleUIInfo();
			}
		}

		public void StartMvpCutScene()
		{
			bool flag = DlgBase<HeroAttrDlg, HeroAttrBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<HeroAttrDlg, HeroAttrBehaviour>.singleton.SetVisible(false, true);
			}
			HeroBattleMapCenter.RowData bySceneID = XHeroBattleDocument._heroBattleMapReader.GetBySceneID(XSingleton<XScene>.singleton.SceneID);
			bool flag2 = bySceneID == null;
			if (flag2)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Can't find mvp map data by sceneID = ", XSingleton<XScene>.singleton.SceneID.ToString(), null, null, null, null);
			}
			else
			{
				XSingleton<XCutScene>.singleton.Start(bySceneID.MVPCutScene, true, true);
			}
		}

		public uint GetExperienceTicketID(uint heroID)
		{
			for (int i = 0; i < XHeroBattleDocument._experienceReader.Table.Length; i++)
			{
				bool flag = XHeroBattleDocument._experienceReader.Table[i].HeroID == heroID;
				if (flag)
				{
					ulong itemCount = XBagDocument.BagDoc.GetItemCount((int)XHeroBattleDocument._experienceReader.Table[i].ItemID);
					bool flag2 = itemCount > 0UL;
					if (flag2)
					{
						return XHeroBattleDocument._experienceReader.Table[i].ItemID;
					}
				}
			}
			return 0U;
		}

		public void SetRankInfo(ClientQueryRankListRes oRes, bool LastWeek = false)
		{
			bool flag = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
			}
			else
			{
				bool flag2 = oRes.RankList == null;
				if (!flag2)
				{
					HeroBattleRankData heroBattleRankData = LastWeek ? this.LastWeek_MyRankData : this.MyRankData;
					List<HeroBattleRankData> list = LastWeek ? this.LastWeek_MainRankList : this.MainRankList;
					heroBattleRankData.roleID = 0UL;
					heroBattleRankData.name = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
					heroBattleRankData.rank = oRes.RoleRankData.Rank;
					heroBattleRankData.winTotal = this.BattleWin;
					heroBattleRankData.fightTotal = this.BattleTotal;
					list.Clear();
					for (int i = 0; i < oRes.RankList.RankData.Count; i++)
					{
						list.Add(this.TurnServerData(oRes.RankList.RankData[i], (uint)i));
					}
					bool flag3 = DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.IsVisible() && !LastWeek;
					if (flag3)
					{
						DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.SetupRankFrame();
					}
				}
			}
		}

		public HeroBattleRankData TurnServerData(RankData data, uint rank)
		{
			return new HeroBattleRankData
			{
				roleID = data.RoleId,
				name = data.RoleName,
				rank = rank,
				winTotal = data.heroinfo.winNum,
				fightTotal = data.heroinfo.totalNum,
				maxContinue = data.heroinfo.continueWinNum,
				maxKills = data.heroinfo.maxKillNum
			};
		}

		public static void GetIconByHeroID(uint heroID, out string atlas, out string icon)
		{
			OverWatchTable.RowData byHeroID = XHeroBattleDocument._overWatchReader.GetByHeroID(heroID);
			bool flag = byHeroID != null;
			if (flag)
			{
				atlas = byHeroID.IconAtlas;
				icon = byHeroID.Icon;
			}
			else
			{
				atlas = "";
				icon = "";
			}
		}

		public static string GetSmallIconByHeroID(uint heroID)
		{
			OverWatchTable.RowData byHeroID = XHeroBattleDocument._overWatchReader.GetByHeroID(heroID);
			bool flag = byHeroID != null;
			string result;
			if (flag)
			{
				result = byHeroID.MiniMapIcon;
			}
			else
			{
				result = "";
			}
			return result;
		}

		public static OverWatchTable.RowData GetDataByHeroID(uint heroID)
		{
			return XHeroBattleDocument._overWatchReader.GetByHeroID(heroID);
		}

		public void OnAncientPercentGet(float percent)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_HeroBattleHandler != null;
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_HeroBattleHandler.SetAncientPercent(percent);
			}
		}

		public void QueryUseAncientSkill(int skillIndex)
		{
			RpcC2G_SelectHeroAncientPower rpcC2G_SelectHeroAncientPower = new RpcC2G_SelectHeroAncientPower();
			rpcC2G_SelectHeroAncientPower.oArg.selectpower = (uint)skillIndex;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SelectHeroAncientPower);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("HeroBattleDocument");

		private XHeroBattleSkillDocument _valueDoc;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static OverWatchTable _overWatchReader = new OverWatchTable();

		private static HeroBattleMapCenter _heroBattleMapReader = new HeroBattleMapCenter();

		private static HeroBattleTips _herobattletips = new HeroBattleTips();

		private static HeroBattleWeekReward _heroBattleWeekReward = new HeroBattleWeekReward();

		private static HeroBattleExperienceHero _experienceReader = new HeroBattleExperienceHero();

		private List<BattleRecordGameInfo> _recordList = new List<BattleRecordGameInfo>();

		private Dictionary<ulong, string> _nameIndex = new Dictionary<ulong, string>();

		public HeroBattleHandler _HeroBattleHandler;

		public List<XCaptainPVPInfo> RankList = new List<XCaptainPVPInfo>();

		public List<XTeamBloodUIData> TeamBlood = new List<XTeamBloodUIData>();

		public Dictionary<ulong, uint> heroIDIndex = new Dictionary<ulong, uint>();

		public List<HeroBattleRankData> MainRankList = new List<HeroBattleRankData>();

		public HeroBattleRankData MyRankData = new HeroBattleRankData();

		public List<HeroBattleRankData> LastWeek_MainRankList = new List<HeroBattleRankData>();

		public HeroBattleRankData LastWeek_MyRankData = new HeroBattleRankData();

		public bool MaininterfaceState = false;

		public uint BattleTotal;

		public uint BattleWin;

		public uint BattleLose;

		public uint WinThisWeek;

		public uint JoinToday;

		public uint MyTeam;

		public ulong SpectateUid = 0UL;

		public HeroBattleRewardState RewardState;

		public uint GetRewardStage;

		public static bool LoadSkillHandler = false;
	}
}

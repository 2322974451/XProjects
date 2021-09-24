using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLevelRewardDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XLevelRewardDocument.uuID;
			}
		}

		public bool RequestServer
		{
			get
			{
				return this._requestServer;
			}
			set
			{
				this._requestServer = value;
			}
		}

		public uint Rank
		{
			get
			{
				return this.GetRankByBit(this._rank);
			}
		}

		public uint FirstStars { get; set; }

		public SceneType CurrentStage
		{
			get
			{
				return XSingleton<XScene>.singleton.SceneType;
			}
		}

		public uint CurrentScene
		{
			get
			{
				return XSingleton<XScene>.singleton.SceneID;
			}
		}

		public SceneTable.RowData CurrentSceneData
		{
			get
			{
				return this._current_scene_data;
			}
		}

		public int LevelFinishTime { get; set; }

		public uint LevelFinishHp { get; set; }

		public bool CanPeerBox
		{
			get
			{
				bool flag = this.CurrentSceneData == null;
				return !flag && this.CurrentSceneData.PeerBox[0] > 0U;
			}
		}

		public uint PeerBoxCost
		{
			get
			{
				bool flag = this.CurrentSceneData == null;
				uint result;
				if (flag)
				{
					result = 0U;
				}
				else
				{
					result = this.CurrentSceneData.PeerBox[1];
				}
				return result;
			}
		}

		public bool IsArenaMiss { get; set; }

		public int ArenaRankUp { get; set; }

		public uint ArenaGemUp { get; set; }

		public int TotalDamage { get; set; }

		public bool IsSelect { get; set; }

		public int SelectLeftTime { get; set; }

		public bool IsWin { get; set; }

		public bool IsStageFailed { get; set; }

		public int PickUpTotalTime { get; set; }

		public int RandomTaskExp { get; set; }

		public int RandomTaskMoney { get; set; }

		public int RandomTask { get; set; }

		public int StartLevel { get; set; }

		public float StartPercent { get; set; }

		public float TotalExpPercent { get; set; }

		public float CurrentExpPercent { get; set; }

		public float GrowExpPercent { get; set; }

		public float TotalExp { get; set; }

		public int SmallMonsterRank { get; set; }

		public bool BrokeRecords { get; set; }

		public bool RedSmallMonsterKilled { get; set; }

		public int TowerFloor { get; set; }

		public bool IsEndLevel { get; set; }

		public uint WatchCount { get; set; }

		public uint LikeCount { get; set; }

		public static void Execute(OnLoadedCallback callback = null)
		{
			XLevelRewardDocument.AsyncLoader.AddTask("Table/StageRank", XLevelRewardDocument.Table, false);
			XLevelRewardDocument.AsyncLoader.Execute(callback);
		}

		public override void OnEnterScene()
		{
			base.OnEnterScene();
			this.PvpBattleData.Init();
			this.InvFightBattleData.Init();
			this.SkyArenaBattleData.Init();
			this.AbyssPartyBattleData.Init();
			this.BigMeleeBattleData.Init();
			this.BattleFieldBattleData.Init();
			this.RaceBattleData.Init();
			this.GuildMineBattleData.Init();
			this.GerenalBattleData.Init();
			this.SelectChestFrameData.Init();
			this.DragonCrusadeDataWin.Init();
			this.QualifyingBattleData.Init();
			this.CustomBattleData.Init();
			this._current_scene_data = XSingleton<XSceneMgr>.singleton.GetSceneData(this.CurrentScene);
		}

		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			this.DestroyFx(this.TheGoddessWinFx);
			this.TheGoddessWinFx = null;
		}

		public void SendLeaveScene()
		{
			bool flag = Time.time - this.LastLeaveSceneTime < 3f;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CLICK_TOO_FAST"), "fece00");
			}
			else
			{
				this.LastLeaveSceneTime = Time.time;
				XSingleton<XScene>.singleton.ReqLeaveScene();
			}
		}

		public void SendSelectChest(uint index)
		{
			RpcC2G_SelectChestReward rpcC2G_SelectChestReward = new RpcC2G_SelectChestReward();
			rpcC2G_SelectChestReward.oArg.chestIdx = index;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SelectChestReward);
		}

		public void SendPeerChest(uint index)
		{
			RpcC2G_PeerBox rpcC2G_PeerBox = new RpcC2G_PeerBox();
			rpcC2G_PeerBox.oArg.index = index;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PeerBox);
		}

		public void SetPeerChest(uint index, ItemBrief item, uint type)
		{
			this.SelectChestFrameData.Player.chestList[(int)index].itemID = (int)item.itemID;
			this.SelectChestFrameData.Player.chestList[(int)index].itemCount = (int)item.itemCount;
			this.SelectChestFrameData.Player.chestList[(int)index].isbind = item.isbind;
			this.SelectChestFrameData.Player.chestList[(int)index].chestType = (int)type;
			bool flag = !DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.SetPeerResult();
			}
		}

		public void SendQueryBoxs(bool force = false)
		{
			bool flag = !force && Time.time - this._last_query_box_time < 1f;
			if (!flag)
			{
				this._last_query_box_time = Time.time;
				RpcC2G_QueryBoxs rpc = new RpcC2G_QueryBoxs();
				XSingleton<XClientNetwork>.singleton.Send(rpc);
			}
		}

		public void SetSelectBoxLeftTime(uint leftTime)
		{
			this.SelectChestFrameData.SelectLeftTime = (int)leftTime;
			bool flag = !DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.RefreshSelectChestLeftTime();
			}
		}

		public void SetBoxsInfo(List<BoxInfos> boxs)
		{
			this.SetSelectBoxLeftTime(0U);
			for (int i = 0; i < boxs.Count; i++)
			{
				bool flag = boxs[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					this.SelectChestFrameData.Player.BoxID = (int)boxs[i].index;
					for (int j = 0; j < this.SelectChestFrameData.Player.chestList.Count; j++)
					{
						this.SelectChestFrameData.Player.chestList[j].itemID = (int)boxs[i].items[j].itemID;
						this.SelectChestFrameData.Player.chestList[j].itemCount = (int)boxs[i].items[j].itemCount;
						this.SelectChestFrameData.Player.chestList[j].isbind = boxs[i].items[j].isbind;
						this.SelectChestFrameData.Player.chestList[j].chestType = (int)boxs[i].type[j];
					}
				}
				else
				{
					for (int k = 0; k < this.SelectChestFrameData.Others.Count; k++)
					{
						bool flag2 = boxs[i].roleid == this.SelectChestFrameData.Others[k].uid;
						if (flag2)
						{
							XLevelRewardDocument.LevelRewardRoleData levelRewardRoleData = this.SelectChestFrameData.Others[k];
							levelRewardRoleData.BoxID = (int)boxs[i].index;
							for (int l = 0; l < this.SelectChestFrameData.Player.chestList.Count; l++)
							{
								levelRewardRoleData.chestList[l].itemID = (int)boxs[i].items[l].itemID;
								levelRewardRoleData.chestList[l].itemCount = (int)boxs[i].items[l].itemCount;
								levelRewardRoleData.chestList[l].isbind = boxs[i].items[l].isbind;
								levelRewardRoleData.chestList[l].chestType = (int)boxs[i].type[l];
							}
							this.SelectChestFrameData.Others[k] = levelRewardRoleData;
						}
					}
				}
			}
			bool flag3 = !DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.IsVisible();
			if (!flag3)
			{
				DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowAllChest();
			}
		}

		public void SendReturnWaitBattleField()
		{
			bool flag = Time.time - this.LastLeaveSceneTime < 3f;
			if (!flag)
			{
				this.LastLeaveSceneTime = Time.time;
				PtcC2M_GoBackReadySceneNtf proto = new PtcC2M_GoBackReadySceneNtf();
				XSingleton<XClientNetwork>.singleton.Send(proto);
			}
		}

		public void ReEnterLevel()
		{
			bool flag = Time.time - this.LastLeaveSceneTime < 3f;
			if (!flag)
			{
				this.LastLeaveSceneTime = Time.time;
				PtcC2G_EnterSceneReq ptcC2G_EnterSceneReq = new PtcC2G_EnterSceneReq();
				ptcC2G_EnterSceneReq.Data.sceneID = this.CurrentScene;
				XSingleton<XClientNetwork>.singleton.Send(ptcC2G_EnterSceneReq);
			}
		}

		public void SendReEnterAbyssParty(uint ID)
		{
			bool flag = Time.time - this.LastLeaveSceneTime < 3f;
			if (!flag)
			{
				this.LastLeaveSceneTime = Time.time;
				bool flag2 = ID == 0U;
				if (flag2)
				{
					DlgBase<AbyssPartyEntranceView, AbyssPartyEntranceBehaviour>.singleton.OnJoinClicked(null);
				}
				else
				{
					XAbyssPartyDocument.Doc.AbyssPartyEnter((int)ID);
				}
			}
		}

		public void SendReEnterRiskBattle()
		{
			bool flag = Time.time - this.LastLeaveSceneTime < 3f;
			if (!flag)
			{
				this.LastLeaveSceneTime = Time.time;
				RpcC2G_ReEnterRiskBattle rpc = new RpcC2G_ReEnterRiskBattle();
				XSingleton<XClientNetwork>.singleton.Send(rpc);
			}
		}

		public void SetBattleResult(List<uint> stars, uint money, List<ItemBrief> items, uint firstStars, List<ItemBrief> starsItems)
		{
			this.Stars.Clear();
			for (int i = 0; i < stars.Count; i++)
			{
				this.Stars.Add(stars[i]);
			}
			this.Items.Clear();
			for (int j = 0; j < items.Count; j++)
			{
				bool flag = false;
				for (int k = 0; k < this.Items.Count; k++)
				{
					bool flag2 = items[j].itemID == this.Items[k].itemID;
					if (flag2)
					{
						flag = true;
						this.Items[k].itemCount += items[j].itemCount;
						break;
					}
				}
				bool flag3 = !flag;
				if (flag3)
				{
					this.Items.Add(this.CopyItemBrief(items[j]));
				}
			}
			bool flag4 = money > 0U;
			if (flag4)
			{
				ItemBrief itemBrief = new ItemBrief
				{
					itemID = (uint)XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.GOLD),
					itemCount = money
				};
				bool flag = false;
				for (int l = 0; l < this.Items.Count; l++)
				{
					bool flag5 = itemBrief.itemID == this.Items[l].itemID;
					if (flag5)
					{
						flag = true;
						this.Items[l].itemCount += itemBrief.itemCount;
						break;
					}
				}
				bool flag6 = !flag;
				if (flag6)
				{
					this.Items.Add(this.CopyItemBrief(itemBrief));
				}
			}
			this.FirstStars = firstStars;
			this.StarsItems.Clear();
			for (int m = 0; m < starsItems.Count; m++)
			{
				this.StarsItems.Add(this.CopyItemBrief(starsItems[m]));
			}
			this.MemberSelectChest.Clear();
			this.IsSelect = false;
			this.SelectLeftTime = XSingleton<XGlobalConfig>.singleton.GetInt("LevelFinishSelectChestTime");
		}

		public void SetQualifyingResult(PkResult data)
		{
			this.IsWin = (data.result == PkResultType.PkResult_Win);
			this.QualifyingBattleData.Init();
			this.QualifyingBattleData.QualifyingResult = data.result;
			this.QualifyingBattleData.QualifyingRankChange = data.rank;
			this.QualifyingBattleData.FirstRank = data.firstrank;
			this.QualifyingBattleData.QualifyingPointChange = data.winpoint;
			this.QualifyingBattleData.QualifyingHonorChange = data.honorpoint;
			this.QualifyingBattleData.QualifyingHonorItems = data.items;
			bool flag = data.dragoncount > 0U;
			if (flag)
			{
				ItemBrief itemBrief = new ItemBrief();
				itemBrief.itemID = 7U;
				itemBrief.itemCount = data.dragoncount;
				this.QualifyingBattleData.QualifyingHonorItems.Add(itemBrief);
			}
			this.QualifyingBattleData.myState = data.mystate;
			this.QualifyingBattleData.opState = data.opstate;
		}

		public void SetDamageRank(List<string> name, List<uint> damage)
		{
			this.Member.Clear();
			this.TotalDamage = 0;
			for (int i = 0; i < name.Count; i++)
			{
				XLevelRewardDocument.DamageRank item = new XLevelRewardDocument.DamageRank
				{
					Name = name[i],
					Damage = (int)damage[i]
				};
				this.Member.Add(item);
				this.TotalDamage += item.Damage;
			}
			this.TotalDamage = Math.Max(1, this.TotalDamage);
			this.Member.Sort(new Comparison<XLevelRewardDocument.DamageRank>(XLevelRewardDocument.DamageCompare));
		}

		public void ShowBattleResultFrame()
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.ResetPressState();
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetVisiblePure(false);
			}
			bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag2)
			{
				DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetVisiblePure(false);
			}
			bool flag3 = DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.IsLoaded();
			if (flag3)
			{
				DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.SetVisiblePure(false);
			}
			bool isWin = this.IsWin;
			if (isWin)
			{
				XLevelFinishMgr.PlayVictory();
			}
			bool isEndLevel = this.IsEndLevel;
			if (isEndLevel)
			{
				this.DestroyFx(this.TheGoddessWinFx);
				this.TheGoddessWinFx = null;
				this.TheGoddessWinFx = XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_TheGoddessWin", XSingleton<XGameUI>.singleton.UIRoot, Vector3.zero, Vector3.one, 1f, true, (float)XSingleton<XGlobalConfig>.singleton.GetInt("LevelFinishFxTime"), true);
				XSingleton<XTimerMgr>.singleton.SetTimer((float)XSingleton<XGlobalConfig>.singleton.GetInt("LevelFinishFxTime"), new XTimerMgr.ElapsedEventHandler(this.ShowLevelRewardUI), null);
			}
			else
			{
				XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.ShowLevelRewardUI), null);
			}
		}

		public void ShowLevelReward()
		{
			this.ShowLevelRewardUI(null);
		}

		private void ShowLevelRewardUI(object o)
		{
			this.DestroyFx(this.TheGoddessWinFx);
			this.TheGoddessWinFx = null;
			bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
			if (!bSpectator)
			{
				XSingleton<XVirtualTab>.singleton.Cancel();
				bool flag = !DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.IsVisible();
				if (flag)
				{
					DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.SetVisible(true, true);
				}
				SceneType currentStage = this.CurrentStage;
				switch (currentStage)
				{
				case SceneType.SCENE_BATTLE:
				case SceneType.SCENE_NEST:
				case (SceneType)4:
				case (SceneType)6:
				case SceneType.SCENE_WORLDBOSS:
				case (SceneType)8:
				case SceneType.SCENE_BOSSRUSH:
				case SceneType.SCENE_GUILD_HALL:
				case SceneType.SCENE_GUILD_BOSS:
				case SceneType.SCENE_ABYSSS:
				case (SceneType)14:
				case SceneType.SCENE_FAMILYGARDEN:
				case SceneType.SCENE_TOWER:
				case SceneType.SCENE_DRAGON:
				case SceneType.SCENE_GMF:
				case SceneType.SCENE_GODDESS:
				case SceneType.SCENE_ENDLESSABYSS:
					goto IL_2A9;
				case SceneType.SCENE_ARENA:
					XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/UI/PvP_Victory");
					DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(SceneType.SCENE_ARENA);
					goto IL_2CE;
				case SceneType.SCENE_PK:
					break;
				case SceneType.SCENE_PVP:
					XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/mapambience/PVP_score");
					DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(SceneType.SCENE_PVP);
					goto IL_2CE;
				case SceneType.SCENE_DRAGON_EXP:
					XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/UI/guankashenli");
					DlgBase<DragonCrusadeGateWin, DragonCrusadeGateWinBehavior>.singleton.SetVisible(true, true);
					DlgBase<DragonCrusadeGateWin, DragonCrusadeGateWinBehavior>.singleton.Refresh();
					goto IL_2CE;
				case SceneType.SCENE_RISK:
					XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/UI/guankashenli");
					DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(SceneType.SCENE_RISK);
					goto IL_2CE;
				default:
					switch (currentStage)
					{
					case SceneType.SCENE_WEEK_NEST:
					case SceneType.SCENE_VS_CHALLENGE:
					case SceneType.SCENE_HORSE:
					case SceneType.SCENE_HORSE_RACE:
					case SceneType.SCENE_CASTLE_WAIT:
					case SceneType.SCENE_CASTLE_FIGHT:
					case SceneType.SCENE_LEAGUE_BATTLE:
					case SceneType.SCENE_ACTIVITY_ONE:
					case SceneType.SCENE_ACTIVITY_TWO:
					case SceneType.SCENE_ACTIVITY_THREE:
					case SceneType.SCENE_ABYSS_PARTY:
						goto IL_2A9;
					case SceneType.SCENE_HEROBATTLE:
					case SceneType.SCENE_MOBA:
						DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(this.CurrentStage);
						goto IL_2CE;
					case SceneType.SCENE_INVFIGHT:
					{
						bool isWin = this.InvFightBattleData.isWin;
						if (isWin)
						{
							XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/UI/PvP_Victory");
						}
						else
						{
							XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/UI/PvP_Lose");
						}
						DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(SceneType.SCENE_INVFIGHT);
						goto IL_2CE;
					}
					case SceneType.SCENE_CUSTOMPK:
					case SceneType.SCENE_CUSTOMPKTWO:
						XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/mapambience/PVP_score");
						DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(this.CurrentStage);
						goto IL_2CE;
					case SceneType.SCENE_PKTWO:
						break;
					case SceneType.SCENE_WEEKEND4V4_MONSTERFIGHT:
					case SceneType.SCENE_WEEKEND4V4_GHOSTACTION:
					case SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE:
					case SceneType.SCENE_WEEKEND4V4_CRAZYBOMB:
					case SceneType.SCENE_WEEKEND4V4_HORSERACING:
					case SceneType.SCENE_WEEKEND4V4_DUCK:
						DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(this.CurrentStage);
						goto IL_2CE;
					default:
						if (currentStage != SceneType.SCENE_SURVIVE)
						{
							goto IL_2A9;
						}
						goto IL_2CE;
					}
					break;
				}
				bool flag2 = this.QualifyingBattleData.QualifyingResult == PkResultType.PkResult_Win;
				if (flag2)
				{
					XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/UI/PvP_Victory");
				}
				else
				{
					XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/UI/PvP_Lose");
				}
				DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(SceneType.SCENE_PK);
				goto IL_2CE;
				IL_2A9:
				XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/UI/guankashenli");
				DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(this.CurrentStage);
				IL_2CE:
				int sceneAutoLeaveTime = XSingleton<XSceneMgr>.singleton.GetSceneAutoLeaveTime(this.CurrentScene);
				bool flag3 = sceneAutoLeaveTime != 0;
				if (flag3)
				{
					this._autoReturnTimeToken = XSingleton<XTimerMgr>.singleton.SetTimer((float)sceneAutoLeaveTime, new XTimerMgr.ElapsedEventHandler(this.AutoLeaveScene), null);
				}
			}
		}

		public void ShowStageFailUI(object o)
		{
			bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
			if (!bSpectator)
			{
				XSingleton<XVirtualTab>.singleton.Cancel();
				bool flag = !DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.IsVisible();
				if (flag)
				{
					DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.SetVisible(true, true);
				}
				SceneType currentStage = this.CurrentStage;
				if (currentStage != SceneType.SCENE_RISK)
				{
					DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowStageFailFrame(this.CurrentStage);
				}
				else
				{
					DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowStageFailFrame(SceneType.SCENE_RISK);
				}
			}
		}

		private void AutoLeaveScene(object o)
		{
			bool flag = this.CurrentScene != XSingleton<XScene>.singleton.SceneID;
			if (!flag)
			{
				bool flag2 = this.CurrentStage == SceneType.SCENE_GODDESS || this.CurrentStage == SceneType.SCENE_ENDLESSABYSS;
				if (flag2)
				{
					XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
					bool flag3 = !specificDocument.bIsLeader;
					if (!flag3)
					{
						XExpeditionDocument specificDocument2 = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
						int num = 0;
						bool flag4 = this.CurrentStage == SceneType.SCENE_GODDESS;
						if (flag4)
						{
							num = specificDocument2.GetDayCount(TeamLevelType.TeamLevelGoddessTrial, null);
						}
						else
						{
							bool flag5 = this.CurrentStage == SceneType.SCENE_ENDLESSABYSS;
							if (flag5)
							{
								num = specificDocument2.GetDayCount(TeamLevelType.TeamLevelEndlessAbyss, null);
							}
						}
						bool flag6 = num - 1 <= 0;
						if (!flag6)
						{
							specificDocument.ReqTeamOp(TeamOperate.TEAM_BATTLE_CONTINUE, 0UL, null, TeamMemberType.TMT_NORMAL, null);
						}
					}
				}
				else
				{
					this.SendLeaveScene();
				}
			}
		}

		public void ShowSelectChestFrame()
		{
			DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowSelectChestFrame();
		}

		public void ShowFirstPassShareView()
		{
			bool flag = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_DungeonShareReward);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("ShowFirstPassShareView", null, null, null, null, null, XDebugColor.XDebug_None);
				XAchievementDocument specificDocument = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
				bool flag2 = this.CurrentScene != 0U && this.CurrentScene == specificDocument.FirstPassSceneID;
				if (flag2)
				{
					XSingleton<XTimerMgr>.singleton.KillTimer(this._autoReturnTimeToken);
					this._autoReturnTimeToken = 0U;
					XScreenShotShareDocument specificDocument2 = XDocuments.GetSpecificDocument<XScreenShotShareDocument>(XScreenShotShareDocument.uuID);
					XSingleton<PDatabase>.singleton.shareCallbackType = ShareCallBackType.DungeonShare;
					specificDocument2.CurShareBgType = ShareBgType.DungeonType;
					DlgBase<DungeonShareView, DungeonShareBehavior>.singleton.SetVisibleWithAnimation(true, null);
				}
			}
		}

		private static int DamageCompare(XLevelRewardDocument.DamageRank member1, XLevelRewardDocument.DamageRank member2)
		{
			return member2.Damage.CompareTo(member1.Damage);
		}

		public void SetPickItemList(List<ItemBrief> items)
		{
			for (int i = 0; i < items.Count; i++)
			{
				this.Items.Add(this.CopyItemBrief(items[i]));
			}
		}

		public void SetBattleResultData(NewBattleResult data)
		{
			this.IsWin = true;
			int index = 0;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					index = i;
					break;
				}
			}
			this.IsEndLevel = data.isFinalResult;
			StageRoleResult stageRoleResult = data.roleReward[index];
			bool flag2 = !stageRoleResult.ishelper;
			if (flag2)
			{
				XSingleton<XStageProgress>.singleton.SetRank((int)data.stageInfo.stageID, (int)stageRoleResult.stars);
			}
			this._rank = stageRoleResult.stars;
			this.SetBattleResult(this.GetStarsByBit(stageRoleResult.stars), stageRoleResult.money, stageRoleResult.items, stageRoleResult.firststars, stageRoleResult.starreward);
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (syncMode)
			{
				this.LevelFinishTime = (int)data.stageInfo.timespan;
			}
			bool flag3 = data.specialStage != null;
			if (flag3)
			{
				this.ArenaRankUp = (int)data.specialStage.arenaup;
				this.IsArenaMiss = data.specialStage.arenamissed;
			}
			this.ArenaGemUp = 0U;
			for (int j = 0; j < stageRoleResult.items.Count; j++)
			{
				bool flag4 = stageRoleResult.items[j].itemID == 7U;
				if (flag4)
				{
					this.ArenaGemUp = stageRoleResult.items[j].itemCount;
				}
			}
			this.IsStageFailed = data.stageInfo.isStageFailed;
			bool flag5 = stageRoleResult.pkresult != null;
			if (flag5)
			{
				this.SetQualifyingResult(stageRoleResult.pkresult);
			}
			bool flag6 = stageRoleResult.stars < 7U && data.stageInfo.stageType == 2U;
			if (flag6)
			{
				XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
				bool flag7 = player != null && player.Attributes.Level > 10U;
				if (flag7)
				{
					XFPStrengthenDocument specificDocument = XDocuments.GetSpecificDocument<XFPStrengthenDocument>(XFPStrengthenDocument.uuID);
					specificDocument.TryShowBrief();
				}
			}
			bool flag8 = stageRoleResult.guildGoblinResult != null;
			if (flag8)
			{
				this.SmallMonsterRank = stageRoleResult.guildGoblinResult.curRank;
				this.RedSmallMonsterKilled = stageRoleResult.guildGoblinResult.getGuildBonus;
			}
			bool flag9 = data.specialStage != null;
			if (flag9)
			{
				this.BrokeRecords = false;
				bool flag10 = data.specialStage.bossrushresult != null;
				if (flag10)
				{
					this.BrokeRecords = (data.specialStage.bossrushresult.lastmax < data.specialStage.bossrushresult.currentmax);
				}
			}
			bool flag11 = stageRoleResult.towerResult != null;
			if (flag11)
			{
				this.BrokeRecords = stageRoleResult.towerResult.isNewRecord;
				this.TowerFloor = stageRoleResult.towerResult.towerFloor;
			}
			this.WatchCount = 0U;
			this.LikeCount = 0U;
			bool flag12 = data.watchinfo != null;
			if (flag12)
			{
				this.WatchCount = data.watchinfo.wathccount;
				this.LikeCount = data.watchinfo.likecount;
			}
			XSingleton<XLevelStatistics>.singleton.OnSetBattleResult();
			this.SetBattleDataList(data);
			this.SetSelectChestResult(data);
			this.SetGerenalResult(data);
			SceneType stageType = (SceneType)data.stageInfo.stageType;
			if (stageType <= SceneType.SCENE_WEEKEND4V4_DUCK)
			{
				if (stageType != SceneType.SCENE_PVP)
				{
					if (stageType != SceneType.SCENE_DRAGON_EXP)
					{
						switch (stageType)
						{
						case SceneType.SKYCITY_FIGHTING:
							this.SetSkyArenaResult(data);
							break;
						case SceneType.SCENE_RESWAR_PVP:
						case SceneType.SCENE_RESWAR_PVE:
							this.SetGuildMineResult(data);
							break;
						case SceneType.SCENE_HORSE_RACE:
							this.SetRaceResult(data);
							break;
						case SceneType.SCENE_HEROBATTLE:
							this.SetHeroBattleResult(data);
							break;
						case SceneType.SCENE_INVFIGHT:
							this.SetInviFightResult(data);
							break;
						case SceneType.SCENE_ABYSS_PARTY:
							this.SetAbyssPartyResult(data);
							break;
						case SceneType.SCENE_CUSTOMPK:
						case SceneType.SCENE_CUSTOMPKTWO:
							this.SetCustomBattleResult(data);
							break;
						case SceneType.SCENE_MOBA:
							this.SetMobaBattleResult(data);
							break;
						case SceneType.SCENE_WEEKEND4V4_MONSTERFIGHT:
						case SceneType.SCENE_WEEKEND4V4_GHOSTACTION:
						case SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE:
						case SceneType.SCENE_WEEKEND4V4_CRAZYBOMB:
						case SceneType.SCENE_WEEKEND4V4_HORSERACING:
						case SceneType.SCENE_WEEKEND4V4_DUCK:
							this.SetWeekendPartyBattleResult(data);
							break;
						}
					}
					else
					{
						this.SetDragonCrusadeResult(data);
					}
				}
				else
				{
					this.SetPVPResult(data);
				}
			}
			else if (stageType != SceneType.SCENE_BIGMELEE_FIGHT)
			{
				if (stageType != SceneType.SCENE_BATTLEFIELD_FIGHT)
				{
					if (stageType == SceneType.SCENE_RIFT)
					{
						this.SetRiftData(data);
					}
				}
				else
				{
					this.SetBattleFieldResult(data);
				}
			}
			else
			{
				this.SetBigMeleeResult(data);
			}
			bool canDrawBox = this.CurrentSceneData.CanDrawBox;
			if (canDrawBox)
			{
				this.SendQueryBoxs(false);
			}
		}

		private void SetWeekendPartyBattleResult(NewBattleResult data)
		{
			this.WeekendPartyBattleData.Init();
			StageRoleResult stageRoleResult = null;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					stageRoleResult = data.roleReward[i];
					bool flag2 = data.roleReward[i].weekend4v4roledata != null;
					if (flag2)
					{
						this.WeekendPartyBattleData.PlayerRedBlue = stageRoleResult.weekend4v4roledata.redblue;
						XSingleton<XDebug>.singleton.AddLog("WeekendPary result selfRedBlue = " + this.WeekendPartyBattleData.PlayerRedBlue.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
					}
					break;
				}
			}
			bool flag3 = stageRoleResult == null;
			if (!flag3)
			{
				for (int j = 0; j < data.roleReward.Count; j++)
				{
					WeekendPartyBattleRoleInfo weekendPartyBattleRoleInfo = new WeekendPartyBattleRoleInfo();
					WeekEnd4v4BattleRoleData weekend4v4roledata = data.roleReward[j].weekend4v4roledata;
					bool flag4 = weekend4v4roledata != null && weekend4v4roledata.isline;
					if (flag4)
					{
						weekendPartyBattleRoleInfo.roleName = weekend4v4roledata.rolename;
						weekendPartyBattleRoleInfo.roleID = weekend4v4roledata.roleid;
						weekendPartyBattleRoleInfo.kill = weekend4v4roledata.killCount;
						weekendPartyBattleRoleInfo.beKilled = weekend4v4roledata.bekilledCount;
						weekendPartyBattleRoleInfo.score = weekend4v4roledata.score;
						weekendPartyBattleRoleInfo.redBlue = weekend4v4roledata.redblue;
						weekendPartyBattleRoleInfo.RoleProf = (int)weekend4v4roledata.profession;
						this.WeekendPartyBattleData.AllRoleData.Add(weekendPartyBattleRoleInfo);
					}
				}
				bool flag5 = data.stageInfo != null && data.stageInfo.weekend4v4tmresult != null;
				if (flag5)
				{
					this.WeekendPartyBattleData.WarTime = data.stageInfo.weekend4v4tmresult.teamSeconds;
					this.WeekendPartyBattleData.Team1Score = ((this.WeekendPartyBattleData.PlayerRedBlue == 1U) ? data.stageInfo.weekend4v4tmresult.redTeamScore : data.stageInfo.weekend4v4tmresult.blueTeamScore);
					this.WeekendPartyBattleData.Team2Score = ((this.WeekendPartyBattleData.PlayerRedBlue != 1U) ? data.stageInfo.weekend4v4tmresult.redTeamScore : data.stageInfo.weekend4v4tmresult.blueTeamScore);
					this.WeekendPartyBattleData.HasRewardsID = data.stageInfo.weekend4v4tmresult.hasRewardsID;
					XSingleton<XDebug>.singleton.AddLog("WeekendPary result redTeamScore = " + data.stageInfo.weekend4v4tmresult.redTeamScore.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
					XSingleton<XDebug>.singleton.AddLog("WeekendPary result blueTeamScore = " + data.stageInfo.weekend4v4tmresult.blueTeamScore.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
				}
			}
		}

		private void SetRiftData(NewBattleResult data)
		{
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					StageRoleResult stageRoleResult = data.roleReward[i];
					this.RiftResult = stageRoleResult.riftResult;
					break;
				}
			}
		}

		private void SetCustomBattleResult(NewBattleResult data)
		{
			this.CustomBattleData.Init();
			StageRoleResult stageRoleResult = null;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					stageRoleResult = data.roleReward[i];
					break;
				}
			}
			bool flag2 = stageRoleResult == null;
			if (!flag2)
			{
				this.CustomBattleData.GameType = (uint)XFastEnumIntEqualityComparer<CustomBattleType>.ToInt(stageRoleResult.custombattle.type);
				this.CustomBattleData.Result = stageRoleResult.custombattle.result;
				for (int j = 0; j < data.roleReward.Count; j++)
				{
					XLevelRewardDocument.CustomBattleInfo item = new XLevelRewardDocument.CustomBattleInfo
					{
						RoleName = data.roleReward[j].rolename,
						RoleID = data.roleReward[j].roleid,
						RoleProf = data.roleReward[j].profession,
						KillCount = data.roleReward[j].killcount,
						MaxKillCount = data.roleReward[j].killcontinuemax,
						DeathCount = (int)data.roleReward[j].deathcount,
						Damage = (ulong)data.roleReward[j].damage,
						Heal = (ulong)data.roleReward[j].treat,
						PointChange = data.roleReward[j].custombattle.point,
						IsMvp = false
					};
					bool flag3 = stageRoleResult.custombattle.fightgroup == data.roleReward[j].custombattle.fightgroup;
					if (flag3)
					{
						this.CustomBattleData.Team1Data.Add(item);
					}
					else
					{
						this.CustomBattleData.Team2Data.Add(item);
					}
				}
			}
		}

		public void SetDragonCrusadeWin()
		{
		}

		public void SetPlayerSelectChestID(int index)
		{
			this.SelectChestFrameData.Player.BoxID = index;
			bool flag = !DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.RefreshSelectChest();
			}
		}

		public void SetBattleDataList(NewBattleResult data)
		{
			this.BattleDataList.Clear();
			float num = 0f;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				num += data.roleReward[i].damage;
			}
			bool flag = num == 0f;
			if (flag)
			{
				num = 1f;
			}
			for (int j = 0; j < data.roleReward.Count; j++)
			{
				XLevelRewardDocument.BattleData item = new XLevelRewardDocument.BattleData
				{
					uid = data.roleReward[j].roleid,
					Name = data.roleReward[j].rolename,
					ProfID = data.roleReward[j].profession,
					Rank = this.GetRankByBit(data.roleReward[j].stars),
					isLeader = data.roleReward[j].isLeader,
					DamageTotal = (ulong)data.roleReward[j].damage,
					DamagePercent = data.roleReward[j].damage * 100f / num,
					HealTotal = (ulong)data.roleReward[j].treat,
					DeathCount = data.roleReward[j].deathcount,
					ComboCount = data.roleReward[j].maxcombo
				};
				this.BattleDataList.Add(item);
			}
		}

		private void SetSelectChestResult(NewBattleResult data)
		{
			this.SelectChestFrameData.Init();
			StageRoleResult stageRoleResult = null;
			int num = -1;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					stageRoleResult = data.roleReward[i];
					num = i;
					break;
				}
			}
			bool flag2 = stageRoleResult == null;
			if (!flag2)
			{
				this.SelectChestFrameData.Player.uid = stageRoleResult.roleid;
				this.SelectChestFrameData.Player.Name = stageRoleResult.rolename;
				this.SelectChestFrameData.Player.Rank = this.GetRankByBit(stageRoleResult.stars);
				this.SelectChestFrameData.Player.Level = stageRoleResult.endlevel;
				this.SelectChestFrameData.Player.ProfID = stageRoleResult.profession;
				this.SelectChestFrameData.Player.isLeader = stageRoleResult.isLeader;
				this.SelectChestFrameData.Player.BoxID = 0;
				List<BattleRewardChest> chestList = new List<BattleRewardChest>
				{
					new BattleRewardChest(),
					new BattleRewardChest(),
					new BattleRewardChest(),
					new BattleRewardChest()
				};
				this.SelectChestFrameData.Player.chestList = chestList;
				this.SelectChestFrameData.Player.isHelper = stageRoleResult.ishelper;
				this.SelectChestFrameData.Player.noneReward = stageRoleResult.isboxexcept;
				this.SelectChestFrameData.Others.Clear();
				for (int j = 0; j < data.roleReward.Count; j++)
				{
					bool flag3 = j != num;
					if (flag3)
					{
						chestList = new List<BattleRewardChest>
						{
							new BattleRewardChest(),
							new BattleRewardChest(),
							new BattleRewardChest(),
							new BattleRewardChest()
						};
						XLevelRewardDocument.LevelRewardRoleData item = new XLevelRewardDocument.LevelRewardRoleData
						{
							uid = data.roleReward[j].roleid,
							Name = data.roleReward[j].rolename,
							Level = data.roleReward[j].endlevel,
							ProfID = data.roleReward[j].profession,
							isLeader = data.roleReward[j].isLeader,
							Rank = this.GetRankByBit(data.roleReward[j].stars),
							BoxID = 0,
							chestList = chestList,
							isHelper = data.roleReward[j].ishelper,
							noneReward = data.roleReward[j].isboxexcept,
							ServerID = data.roleReward[j].serverid
						};
						this.SelectChestFrameData.Others.Add(item);
					}
				}
				this.SelectChestFrameData.SelectLeftTime = XSingleton<XGlobalConfig>.singleton.GetInt("LevelFinishSelectChestTime");
			}
		}

		private void SetGerenalResult(NewBattleResult data)
		{
			this.GerenalBattleData.Init();
			StageRoleResult stageRoleResult = null;
			int num = -1;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					stageRoleResult = data.roleReward[i];
					num = i;
					break;
				}
			}
			bool flag2 = stageRoleResult == null;
			if (!flag2)
			{
				this.GerenalBattleData.Score = stageRoleResult.score;
				this.GerenalBattleData.Rank = this.GetRankByBit(this._rank);
				List<uint> starsByBit = this.GetStarsByBit(this._rank);
				for (int j = 0; j < starsByBit.Count; j++)
				{
					this.GerenalBattleData.Stars.Add(starsByBit[j]);
				}
				this.GerenalBattleData.Items.Clear();
				for (int k = 0; k < stageRoleResult.items.Count; k++)
				{
					bool flag3 = false;
					for (int l = 0; l < this.GerenalBattleData.Items.Count; l++)
					{
						bool flag4 = stageRoleResult.items[k].itemID == this.GerenalBattleData.Items[l].itemID;
						if (flag4)
						{
							flag3 = true;
							this.GerenalBattleData.Items[l].itemCount += stageRoleResult.items[k].itemCount;
							break;
						}
					}
					bool flag5 = !flag3;
					if (flag5)
					{
						this.GerenalBattleData.Items.Add(this.CopyItemBrief(stageRoleResult.items[k]));
					}
				}
				bool flag6 = stageRoleResult.money > 0U;
				if (flag6)
				{
					ItemBrief itemBrief = new ItemBrief
					{
						itemID = (uint)XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.GOLD),
						itemCount = stageRoleResult.money
					};
					bool flag3 = false;
					for (int m = 0; m < this.GerenalBattleData.Items.Count; m++)
					{
						bool flag7 = itemBrief.itemID == this.Items[m].itemID;
						if (flag7)
						{
							flag3 = true;
							this.GerenalBattleData.Items[m].itemCount += itemBrief.itemCount;
							break;
						}
					}
					bool flag8 = !flag3;
					if (flag8)
					{
						this.GerenalBattleData.Items.Add(this.CopyItemBrief(itemBrief));
					}
				}
				this.GerenalBattleData.LevelFinishTime = data.stageInfo.timespan;
				XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
				this.GerenalBattleData.StartLevel = stageRoleResult.startLevel;
				this.GerenalBattleData.StartPercent = 1f * stageRoleResult.startExp / (float)xplayerData.GetLevelUpExp((int)(stageRoleResult.startLevel + 1U));
				this.GerenalBattleData.TotalExpPercent = stageRoleResult.endlevel - stageRoleResult.startLevel + 1f * stageRoleResult.endexp / (float)xplayerData.GetLevelUpExp((int)(stageRoleResult.endlevel + 1U)) - 1f * stageRoleResult.startExp / (float)xplayerData.GetLevelUpExp((int)(stageRoleResult.startLevel + 1U));
				this.GerenalBattleData.CurrentExpPercent = 1f * stageRoleResult.startExp / (float)xplayerData.GetLevelUpExp((int)(stageRoleResult.startLevel + 1U));
				this.GerenalBattleData.GrowExpPercent = this.GerenalBattleData.TotalExpPercent / 60f;
				this.GerenalBattleData.TotalExp = stageRoleResult.exp;
				this.GerenalBattleData.GuildBuff = 0f;
				for (int n = 0; n < data.roleReward.Count; n++)
				{
					bool flag9 = num != n && data.roleReward[n].gid != 0UL && data.roleReward[num].gid == data.roleReward[n].gid;
					if (flag9)
					{
						SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this.CurrentScene);
						this.GerenalBattleData.GuildBuff = sceneData.GuildExpBounus;
						break;
					}
				}
				this.GerenalBattleData.SwitchLeftTime = 0;
				this.GerenalBattleData.GuildExp = stageRoleResult.guildexp;
				this.GerenalBattleData.GuildContribution = stageRoleResult.guildcon;
				this.GerenalBattleData.GuildDragonCoin = stageRoleResult.guilddargon;
				bool flag10 = stageRoleResult.teamcostreward != null;
				if (flag10)
				{
					this.GerenalBattleData.GoldGroupReward = new ItemBrief();
					this.GerenalBattleData.GoldGroupReward.itemID = stageRoleResult.teamcostreward.itemID;
					this.GerenalBattleData.GoldGroupReward.itemCount = stageRoleResult.teamcostreward.itemCount;
					this.GerenalBattleData.GoldGroupReward.isbind = stageRoleResult.teamcostreward.isbind;
				}
				this.GerenalBattleData.isHelper = stageRoleResult.ishelper;
				this.GerenalBattleData.noneReward = stageRoleResult.isboxexcept;
				this.GerenalBattleData.isSeal = stageRoleResult.isexpseal;
			}
		}

		private void SetPVPResult(NewBattleResult data)
		{
			this.PvpBattleData.Init();
			PVPResult pvpresult = null;
			int num = -1;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					pvpresult = data.roleReward[i].pvpresult;
					num = i;
					break;
				}
			}
			bool flag2 = pvpresult == null;
			if (!flag2)
			{
				this.IsWin = (pvpresult.wingroup == pvpresult.mygroup);
				bool flag3 = pvpresult.wingroup == 3;
				if (flag3)
				{
					this.PvpBattleData.PVPResult = 3;
				}
				else
				{
					bool flag4 = pvpresult.wingroup == pvpresult.mygroup;
					if (flag4)
					{
						this.PvpBattleData.PVPResult = 1;
					}
					else
					{
						this.PvpBattleData.PVPResult = 2;
					}
				}
				for (int j = 0; j < pvpresult.dayjoinreward.Count; j++)
				{
					this.PvpBattleData.DayJoinReward.Add(pvpresult.dayjoinreward[j]);
				}
				for (int k = 0; k < pvpresult.winreward.Count; k++)
				{
					this.PvpBattleData.WinReward.Add(pvpresult.winreward[k]);
				}
				this.PvpBattleData.Team1Data.Add(this.GetPVPRoleInfo(num, data, true));
				for (int l = 0; l < data.roleReward.Count; l++)
				{
					bool flag5 = l == num;
					if (!flag5)
					{
						bool flag6 = pvpresult.mygroup == data.roleReward[l].pvpresult.mygroup;
						if (flag6)
						{
							this.PvpBattleData.Team1Data.Add(this.GetPVPRoleInfo(l, data, true));
						}
						else
						{
							this.PvpBattleData.Team2Data.Add(this.GetPVPRoleInfo(l, data, true));
						}
					}
				}
			}
		}

		private void SetHeroBattleResult(NewBattleResult data)
		{
			this.HeroData.Init();
			uint num = uint.MaxValue;
			int num2 = -1;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					this.HeroData.Result = data.roleReward[i].heroresult.over;
					num = data.roleReward[i].heroresult.teamid;
					num2 = i;
					break;
				}
			}
			bool flag2 = num == uint.MaxValue;
			if (!flag2)
			{
				this.HeroData.Team1Data.Add(this.GetPVPRoleInfo(num2, data, false));
				for (int j = 0; j < data.roleReward[num2].heroresult.winreward.Count; j++)
				{
					this.HeroData.WinReward.Add(this.CopyItemBrief(data.roleReward[num2].heroresult.winreward[j]));
				}
				for (int k = 0; k < data.roleReward[num2].heroresult.dayjoinreward.Count; k++)
				{
					this.HeroData.DayJoinReward.Add(this.CopyItemBrief(data.roleReward[num2].heroresult.dayjoinreward[k]));
				}
				for (int l = 0; l < data.roleReward.Count; l++)
				{
					bool flag3 = data.roleReward[l].heroresult.mvpid == data.roleReward[l].roleid;
					if (flag3)
					{
						this.HeroData.MvpData = this.GetPVPRoleInfo(l, data, false);
						this.HeroData.MvpHeroID = data.roleReward[l].heroresult.mvpheroid;
					}
					bool flag4 = data.roleReward[l].killcount > this.HeroData.KillMax;
					if (flag4)
					{
						this.HeroData.KillMax = data.roleReward[l].killcount;
					}
					bool flag5 = (ulong)data.roleReward[l].deathcount < (ulong)((long)this.HeroData.DeathMin);
					if (flag5)
					{
						this.HeroData.DeathMin = (int)data.roleReward[l].deathcount;
					}
					bool flag6 = (ulong)data.roleReward[l].assitnum > (ulong)((long)this.HeroData.AssitMax);
					if (flag6)
					{
						this.HeroData.AssitMax = (int)data.roleReward[l].assitnum;
					}
					bool flag7 = data.roleReward[l].damage > this.HeroData.DamageMax;
					if (flag7)
					{
						this.HeroData.DamageMax = (ulong)data.roleReward[l].damage;
					}
					bool flag8 = data.roleReward[l].behitdamage > this.HeroData.BeHitMax;
					if (flag8)
					{
						this.HeroData.BeHitMax = data.roleReward[l].behitdamage;
					}
					bool flag9 = l == num2;
					if (!flag9)
					{
						bool flag10 = num == data.roleReward[l].heroresult.teamid;
						if (flag10)
						{
							this.HeroData.Team1Data.Add(this.GetPVPRoleInfo(l, data, false));
						}
						else
						{
							this.HeroData.Team2Data.Add(this.GetPVPRoleInfo(l, data, false));
						}
					}
				}
			}
		}

		private void SetMobaBattleResult(NewBattleResult data)
		{
			this.MobaData.Init();
			XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
			int num = -1;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					this.MobaData.Result = (data.roleReward[i].mobabattle.isWin ? HeroBattleOver.HeroBattleOver_Win : HeroBattleOver.HeroBattleOver_Lose);
					num = i;
					break;
				}
			}
			bool flag2 = num == -1;
			if (!flag2)
			{
				this.MobaData.Team1Data.Add(this.GetMobaRoleInfo(num, data, false));
				for (int j = 0; j < data.roleReward[num].mobabattle.winreward.Count; j++)
				{
					this.MobaData.WinReward.Add(this.CopyItemBrief(data.roleReward[num].mobabattle.winreward[j]));
				}
				this.MobaData.BeHitMaxUid = data.stageInfo.mobabattle.behitdamagemaxid;
				this.MobaData.DamageMaxUid = data.stageInfo.mobabattle.damagemaxid;
				for (int k = 0; k < data.roleReward.Count; k++)
				{
					bool flag3 = data.stageInfo.mobabattle.mvpid == data.roleReward[k].roleid;
					if (flag3)
					{
						this.MobaData.MvpData = this.GetMobaRoleInfo(k, data, false);
						this.MobaData.MvpHeroID = data.roleReward[k].mobabattle.heroid;
					}
					bool flag4 = data.roleReward[k].killcount > this.MobaData.KillMax;
					if (flag4)
					{
						this.MobaData.KillMax = data.roleReward[k].killcount;
					}
					bool flag5 = (ulong)data.roleReward[k].deathcount < (ulong)((long)this.MobaData.DeathMin);
					if (flag5)
					{
						this.MobaData.DeathMin = (int)data.roleReward[k].deathcount;
					}
					bool flag6 = (ulong)data.roleReward[k].assitnum > (ulong)((long)this.MobaData.AssitMax);
					if (flag6)
					{
						this.MobaData.AssitMax = (int)data.roleReward[k].assitnum;
					}
					bool flag7 = k == num;
					if (!flag7)
					{
						bool flag8 = specificDocument.isAlly(data.roleReward[k].roleid);
						if (flag8)
						{
							this.MobaData.Team1Data.Add(this.GetMobaRoleInfo(k, data, false));
						}
						else
						{
							this.MobaData.Team2Data.Add(this.GetMobaRoleInfo(k, data, false));
						}
					}
				}
			}
		}

		private void SetGuildMineResult(NewBattleResult data)
		{
			this.GuildMineBattleData.Init();
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					this.GuildMineBattleData.item = data.roleReward[i].items;
					this.GuildMineBattleData.mine = data.roleReward[i].reswar;
					break;
				}
			}
		}

		private void SetRaceResult(NewBattleResult data)
		{
			this.RaceBattleData.Init();
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				StageRoleResult stageRoleResult = data.roleReward[i];
				bool flag = stageRoleResult.money > 0U;
				if (flag)
				{
					ItemBrief item = new ItemBrief
					{
						itemID = (uint)XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.GOLD),
						itemCount = stageRoleResult.money
					};
					stageRoleResult.items.Add(item);
				}
				this.RaceBattleData.rolename.Add(stageRoleResult.rolename);
				this.RaceBattleData.profession.Add(stageRoleResult.profession);
				this.RaceBattleData.item.Add(stageRoleResult.items);
				this.RaceBattleData.time.Add(stageRoleResult.horse.time);
				this.RaceBattleData.petid.Add(stageRoleResult.horse.horse);
				this.RaceBattleData.rank.Add(stageRoleResult.horse.rank);
			}
		}

		private void SetInviFightResult(NewBattleResult data)
		{
			this.InvFightBattleData.Init();
			int num = 0;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					num = i;
					break;
				}
			}
			StageRoleResult stageRoleResult = (num < data.roleReward.Count) ? data.roleReward[num] : null;
			bool flag2 = stageRoleResult != null;
			if (flag2)
			{
				this.InvFightBattleData.isWin = (stageRoleResult.invfightresult.resulttype == PkResultType.PkResult_Win);
				this.InvFightBattleData.rivalName = stageRoleResult.invfightresult.opname;
			}
		}

		private void SetSkyArenaResult(NewBattleResult data)
		{
			this.SkyArenaBattleData.Init();
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				StageRoleResult stageRoleResult = data.roleReward[i];
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					this.SkyArenaBattleData.roleid.Add(stageRoleResult.roleid);
					this.SkyArenaBattleData.killcount.Add(stageRoleResult.killcount);
					this.SkyArenaBattleData.deathcount.Add((int)stageRoleResult.deathcount);
					this.SkyArenaBattleData.damage.Add((ulong)stageRoleResult.damage);
					this.SkyArenaBattleData.ismvp.Add(stageRoleResult.skycity.ismvp);
					this.SkyArenaBattleData.item = stageRoleResult.skycity.item;
					this.SkyArenaBattleData.floor = stageRoleResult.skycity.floor;
				}
			}
			for (int j = 0; j < data.roleReward.Count; j++)
			{
				bool flag2 = data.roleReward[j].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (!flag2)
				{
					StageRoleResult stageRoleResult = data.roleReward[j];
					this.SkyArenaBattleData.roleid.Add(stageRoleResult.roleid);
					this.SkyArenaBattleData.killcount.Add(stageRoleResult.killcount);
					this.SkyArenaBattleData.deathcount.Add((int)stageRoleResult.deathcount);
					this.SkyArenaBattleData.damage.Add((ulong)stageRoleResult.damage);
					this.SkyArenaBattleData.ismvp.Add(stageRoleResult.skycity.ismvp);
				}
			}
		}

		private void SetAbyssPartyResult(NewBattleResult data)
		{
			this.AbyssPartyBattleData.Init();
			this.AbyssPartyBattleData.Time = data.stageInfo.timespan;
			bool flag = data.roleReward.Count > 0;
			if (flag)
			{
				this.AbyssPartyBattleData.item = data.roleReward[0].items;
			}
			this.AbyssPartyBattleData.AbysssPartyListId = (int)data.stageInfo.abyssid;
		}

		private void SetBigMeleeResult(NewBattleResult data)
		{
			this.BigMeleeBattleData.Init();
			bool flag = data.roleReward.Count == 0;
			if (!flag)
			{
				this.BigMeleeBattleData.rank = data.roleReward[0].bigmelee.rank;
				this.BigMeleeBattleData.score = data.roleReward[0].bigmelee.score;
				this.BigMeleeBattleData.kill = data.roleReward[0].bigmelee.kill;
				this.BigMeleeBattleData.death = data.roleReward[0].bigmelee.death;
				this.BigMeleeBattleData.item = data.roleReward[0].bigmelee.items;
			}
		}

		private void SetBattleFieldResult(NewBattleResult data)
		{
			this.BattleFieldBattleData.Init();
			this.BattleFieldBattleData.allend = data.stageInfo.end;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				XLevelRewardDocument.BattleRankRoleInfo battleRankRoleInfo = default(XLevelRewardDocument.BattleRankRoleInfo);
				battleRankRoleInfo.RoleID = data.roleReward[i].battlefield.roleid;
				battleRankRoleInfo.Rank = data.roleReward[i].battlefield.rank;
				battleRankRoleInfo.Point = data.roleReward[i].battlefield.point;
				battleRankRoleInfo.KillCount = data.roleReward[i].battlefield.killer;
				battleRankRoleInfo.DeathCount = data.roleReward[i].battlefield.death;
				battleRankRoleInfo.ServerName = data.roleReward[i].battlefield.svrname;
				battleRankRoleInfo.isMVP = data.roleReward[i].battlefield.ismvp;
				battleRankRoleInfo.Damage = (ulong)data.roleReward[i].battlefield.hurt;
				battleRankRoleInfo.Name = data.roleReward[i].battlefield.name;
				battleRankRoleInfo.RoleProf = (int)data.roleReward[i].battlefield.job;
				battleRankRoleInfo.CombKill = data.roleReward[i].battlefield.killstreak;
				this.BattleFieldBattleData.MemberData.Add(battleRankRoleInfo);
				bool flag = battleRankRoleInfo.RoleID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					this.BattleFieldBattleData.item = data.roleReward[i].items;
				}
			}
		}

		public void ShowBattleRoyaleResultUI()
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.ResetPressState();
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetVisiblePure(false);
				DlgBase<RadioBattleDlg, RadioBattleBahaviour>.singleton.Show(false);
				DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetFakeHide(true);
			}
			bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag2)
			{
				DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetVisiblePure(false);
				DlgBase<RadioDlg, RadioBehaviour>.singleton.Show(false);
				DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetFakeHide(false);
			}
			bool flag3 = DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.IsLoaded();
			if (flag3)
			{
				DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.SetVisiblePure(false);
			}
			bool flag4 = DlgBase<XChatView, XChatBehaviour>.singleton.IsLoaded();
			if (flag4)
			{
				DlgBase<XChatView, XChatBehaviour>.singleton.SetVisible(false, true);
			}
			XSingleton<XVirtualTab>.singleton.Cancel();
			bool flag5 = !DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.IsVisible();
			if (flag5)
			{
				DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.SetVisible(true, true);
			}
			DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(SceneType.SCENE_SURVIVE);
		}

		private void SetDragonCrusadeResult(NewBattleResult data)
		{
			this.DragonCrusadeDataWin.Init();
			StageRoleResult stageRoleResult = null;
			int num = -1;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					stageRoleResult = data.roleReward[i];
					num = i;
					this.DragonCrusadeDataWin.MyResult = data.roleReward[i].deresult;
					break;
				}
			}
			bool flag2 = stageRoleResult == null;
			if (!flag2)
			{
				this.DragonCrusadeDataWin.Player.uid = stageRoleResult.roleid;
				this.DragonCrusadeDataWin.Player.Name = stageRoleResult.rolename;
				this.DragonCrusadeDataWin.Player.Rank = this.GetRankByBit(stageRoleResult.stars);
				this.DragonCrusadeDataWin.Player.Level = stageRoleResult.endlevel;
				this.DragonCrusadeDataWin.Player.ProfID = stageRoleResult.profession;
				this.DragonCrusadeDataWin.Player.isLeader = stageRoleResult.isLeader;
				this.DragonCrusadeDataWin.Player.BoxID = 0;
				this.DragonCrusadeDataWin.Player.chestList = stageRoleResult.box;
				this.DragonCrusadeDataWin.Player.isHelper = stageRoleResult.ishelper;
				this.DragonCrusadeDataWin.Others.Clear();
				for (int j = 0; j < data.roleReward.Count; j++)
				{
					bool flag3 = j != num;
					if (flag3)
					{
						XLevelRewardDocument.LevelRewardRoleData item = new XLevelRewardDocument.LevelRewardRoleData
						{
							uid = data.roleReward[j].roleid,
							Name = data.roleReward[j].rolename,
							Level = data.roleReward[j].endlevel,
							ProfID = data.roleReward[j].profession,
							isLeader = data.roleReward[j].isLeader,
							Rank = this.GetRankByBit(data.roleReward[j].stars),
							BoxID = 0,
							chestList = data.roleReward[j].box,
							isHelper = data.roleReward[j].ishelper
						};
						this.DragonCrusadeDataWin.Others.Add(item);
					}
				}
			}
		}

		private XLevelRewardDocument.PVPRoleInfo GetPVPRoleInfo(int id, NewBattleResult data, bool isCapData = true)
		{
			return new XLevelRewardDocument.PVPRoleInfo
			{
				uID = data.roleReward[id].roleid,
				Name = data.roleReward[id].rolename,
				Prof = data.roleReward[id].profession,
				Level = data.roleReward[id].endlevel,
				KillCount = data.roleReward[id].killcount,
				MaxKillCount = data.roleReward[id].killcontinuemax,
				DeathCount = data.roleReward[id].deathcount,
				AssitCount = data.roleReward[id].assitnum,
				IsMvp = (isCapData ? data.roleReward[id].pvpresult.ismvp : (data.roleReward[id].heroresult.mvpid == data.roleReward[id].roleid || data.roleReward[id].heroresult.losemvpid == data.roleReward[id].roleid)),
				Damage = (ulong)data.roleReward[id].damage,
				BeHit = data.roleReward[id].behitdamage,
				Kda = ((data.roleReward[id].heroresult == null) ? 0f : data.roleReward[id].heroresult.kda),
				Heal = (ulong)data.roleReward[id].treat,
				ServerID = data.roleReward[id].serverid,
				militaryRank = data.roleReward[id].military_rank
			};
		}

		private XLevelRewardDocument.PVPRoleInfo GetMobaRoleInfo(int id, NewBattleResult data, bool isCapData = true)
		{
			return new XLevelRewardDocument.PVPRoleInfo
			{
				uID = data.roleReward[id].roleid,
				Name = data.roleReward[id].rolename,
				Prof = data.roleReward[id].profession,
				Level = data.roleReward[id].endlevel,
				KillCount = data.roleReward[id].killcount,
				MaxKillCount = (int)data.roleReward[id].multikillcountmax,
				DeathCount = data.roleReward[id].deathcount,
				AssitCount = data.roleReward[id].assitnum,
				IsMvp = (data.roleReward[id].roleid == data.stageInfo.mobabattle.mvpid || data.roleReward[id].roleid == data.stageInfo.mobabattle.losemvpid),
				Damage = (ulong)data.roleReward[id].damage,
				BeHit = data.roleReward[id].behitdamage,
				Kda = ((data.roleReward[id].mobabattle == null) ? 0f : data.roleReward[id].mobabattle.kda),
				Heal = (ulong)data.roleReward[id].treat,
				ServerID = data.roleReward[id].serverid,
				militaryRank = data.roleReward[id].military_rank,
				isescape = data.roleReward[id].mobabattle.isescape
			};
		}

		private List<uint> GetStarsByBit(uint rank)
		{
			List<uint> list = new List<uint>();
			int i = 0;
			int num = 1;
			while (i < 5)
			{
				bool flag = ((ulong)rank & (ulong)((long)num)) > 0UL;
				if (flag)
				{
					list.Add(1U);
				}
				else
				{
					list.Add(0U);
				}
				i++;
				num <<= 1;
			}
			return list;
		}

		public uint GetRankByBit(uint bit)
		{
			uint num = 0U;
			while (bit > 0U)
			{
				bool flag = (bit & 1U) == 1U;
				if (flag)
				{
					num += 1U;
				}
				bit >>= 1;
			}
			return num;
		}

		public ItemBrief CopyItemBrief(ItemBrief item)
		{
			return new ItemBrief
			{
				itemID = item.itemID,
				itemCount = item.itemCount,
				isbind = item.isbind
			};
		}

		public void DestroyFx(XFx fx)
		{
			bool flag = fx == null;
			if (!flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(fx, true);
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World && (this._requestServer || XSingleton<XGame>.singleton.SyncMode);
			if (flag)
			{
				XSingleton<XLevelFinishMgr>.singleton.SendBattleReport(null);
			}
		}

		public void ReportPlayer(ulong uid, List<reportType> list)
		{
			RpcC2G_ReportBadPlayer rpcC2G_ReportBadPlayer = new RpcC2G_ReportBadPlayer();
			rpcC2G_ReportBadPlayer.oArg.roleid = uid;
			rpcC2G_ReportBadPlayer.oArg.reason.Clear();
			for (int i = 0; i < list.Count; i++)
			{
				bool state = list[i].state;
				if (state)
				{
					rpcC2G_ReportBadPlayer.oArg.reason.Add(list[i].type);
				}
			}
			rpcC2G_ReportBadPlayer.oArg.scenetype = (uint)XFastEnumIntEqualityComparer<SceneType>.ToInt(XSingleton<XScene>.singleton.SceneType);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ReportBadPlayer);
		}

		public List<string> GetMobaIconList(XLevelRewardDocument.PVPRoleInfo data, ulong DamageMaxUid = 0UL, ulong BeHitMaxUid = 0UL, int KillMax = 0, int AssistsMax = 0)
		{
			List<string> list = new List<string>();
			bool flag = data.MaxKillCount > 2;
			if (flag)
			{
				int maxKillCount = data.MaxKillCount;
				if (maxKillCount != 3)
				{
					if (maxKillCount != 4)
					{
						list.Add("ic_pf5");
					}
					else
					{
						list.Add("ic_pf4");
					}
				}
				else
				{
					list.Add("ic_pf3");
				}
			}
			bool flag2 = data.KillCount == KillMax && KillMax != 0;
			if (flag2)
			{
				list.Add("ic_pf1");
			}
			bool flag3 = (ulong)data.AssitCount == (ulong)((long)AssistsMax) && AssistsMax != 0;
			if (flag3)
			{
				list.Add("ic_pf6");
			}
			bool flag4 = data.uID == BeHitMaxUid && BeHitMaxUid > 0UL;
			if (flag4)
			{
				list.Add("ic_pf2");
			}
			bool flag5 = data.uID == DamageMaxUid && DamageMaxUid > 0UL;
			if (flag5)
			{
				list.Add("ic_pf0");
			}
			bool isescape = data.isescape;
			if (isescape)
			{
				list.Add("ic_pf8");
			}
			return list;
		}

		public static int MEMBER_COUNT = 16;

		public RiftResult RiftResult;

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("LevelRewardDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private bool _requestServer = false;

		private uint _rank = 0U;

		public List<uint> Stars = new List<uint>();

		public List<ItemBrief> Items = new List<ItemBrief>();

		public List<ItemBrief> StarsItems = new List<ItemBrief>();

		private SceneTable.RowData _current_scene_data = null;

		private float _last_query_box_time = 0f;

		public List<XLevelRewardDocument.DamageRank> Member = new List<XLevelRewardDocument.DamageRank>();

		public Dictionary<ulong, int> MemberSelectChest = new Dictionary<ulong, int>();

		public static StageRankTable Table = new StageRankTable();

		public XLevelRewardDocument.PVPData PvpBattleData = default(XLevelRewardDocument.PVPData);

		public XLevelRewardDocument.HeroBattleData HeroData = default(XLevelRewardDocument.HeroBattleData);

		public XLevelRewardDocument.HeroBattleData MobaData = default(XLevelRewardDocument.HeroBattleData);

		public XLevelRewardDocument.RaceData RaceBattleData = default(XLevelRewardDocument.RaceData);

		public XLevelRewardDocument.InvFightData InvFightBattleData = default(XLevelRewardDocument.InvFightData);

		public XLevelRewardDocument.SkyArenaData SkyArenaBattleData = default(XLevelRewardDocument.SkyArenaData);

		public XLevelRewardDocument.AbyssPartyData AbyssPartyBattleData = default(XLevelRewardDocument.AbyssPartyData);

		public XLevelRewardDocument.BigMeleeData BigMeleeBattleData = default(XLevelRewardDocument.BigMeleeData);

		public XLevelRewardDocument.BattleFieldData BattleFieldBattleData = default(XLevelRewardDocument.BattleFieldData);

		public XLevelRewardDocument.GuildMineData GuildMineBattleData = default(XLevelRewardDocument.GuildMineData);

		public XLevelRewardDocument.GerenalData GerenalBattleData = default(XLevelRewardDocument.GerenalData);

		public XLevelRewardDocument.SelectChestData SelectChestFrameData = default(XLevelRewardDocument.SelectChestData);

		public XLevelRewardDocument.DragonCrusadeData DragonCrusadeDataWin = default(XLevelRewardDocument.DragonCrusadeData);

		public List<XLevelRewardDocument.BattleData> BattleDataList = new List<XLevelRewardDocument.BattleData>();

		public XLevelRewardDocument.QualifyingData QualifyingBattleData = default(XLevelRewardDocument.QualifyingData);

		public XLevelRewardDocument.CustomBattleGameData CustomBattleData = default(XLevelRewardDocument.CustomBattleGameData);

		public XLevelRewardDocument.WeekendPartyData WeekendPartyBattleData = default(XLevelRewardDocument.WeekendPartyData);

		public XLevelRewardDocument.BattleRoyaleData BattleRoyaleDataInfo = default(XLevelRewardDocument.BattleRoyaleData);

		private float LastLeaveSceneTime = 0f;

		private XFx TheGoddessWinFx = null;

		private uint _autoReturnTimeToken = 0U;

		public struct DamageRank
		{

			public string Name { get; set; }

			public int Damage { get; set; }
		}

		public struct PVPRoleInfo
		{

			public string Name;

			public ulong uID;

			public uint Level;

			public int Prof;

			public int KillCount;

			public int MaxKillCount;

			public uint DeathCount;

			public uint AssitCount;

			public bool IsMvp;

			public ulong Damage;

			public uint BeHit;

			public float Kda;

			public ulong Heal;

			public uint ServerID;

			public uint militaryRank;

			public bool isescape;
		}

		public struct PVPData
		{

			public void Init()
			{
				this.PVPResult = 0;
				this.DayJoinReward = new List<ItemBrief>();
				this.WinReward = new List<ItemBrief>();
				this.Team1Data = new List<XLevelRewardDocument.PVPRoleInfo>();
				this.Team2Data = new List<XLevelRewardDocument.PVPRoleInfo>();
			}

			public int PVPResult;

			public List<ItemBrief> DayJoinReward;

			public List<ItemBrief> WinReward;

			public List<XLevelRewardDocument.PVPRoleInfo> Team1Data;

			public List<XLevelRewardDocument.PVPRoleInfo> Team2Data;
		}

		public struct CustomBattleInfo
		{

			public string RoleName;

			public ulong RoleID;

			public int RoleProf;

			public int KillCount;

			public int MaxKillCount;

			public int DeathCount;

			public ulong Damage;

			public ulong Heal;

			public int PointChange;

			public bool IsMvp;
		}

		public struct CustomBattleGameData
		{

			public void Init()
			{
				this.GameType = 0U;
				this.Result = PkResultType.PkResult_Draw;
				this.Team1Data = new List<XLevelRewardDocument.CustomBattleInfo>();
				this.Team2Data = new List<XLevelRewardDocument.CustomBattleInfo>();
			}

			public uint GameType;

			public PkResultType Result;

			public List<XLevelRewardDocument.CustomBattleInfo> Team1Data;

			public List<XLevelRewardDocument.CustomBattleInfo> Team2Data;
		}

		public struct WeekendPartyData
		{

			public void Init()
			{
				this.WarTime = 0U;
				this.Team1Score = 0U;
				this.Team2Score = 0U;
				this.PlayerRedBlue = 0U;
				this.AllRoleData = new List<WeekendPartyBattleRoleInfo>();
				this.HasRewardsID = new List<ulong>();
			}

			public uint WarTime;

			public List<WeekendPartyBattleRoleInfo> AllRoleData;

			public uint Team1Score;

			public uint Team2Score;

			public uint PlayerRedBlue;

			public List<ulong> HasRewardsID;
		}

		public struct HeroBattleData
		{

			public void Init()
			{
				this.MvpHeroID = 1U;
				this.KillMax = 0;
				this.AssitMax = 0;
				this.DamageMax = 0UL;
				this.BeHitMax = 0U;
				this.DeathMin = int.MaxValue;
				this.DayJoinReward = new List<ItemBrief>();
				this.WinReward = new List<ItemBrief>();
				this.Team1Data = new List<XLevelRewardDocument.PVPRoleInfo>();
				this.Team2Data = new List<XLevelRewardDocument.PVPRoleInfo>();
			}

			public HeroBattleOver Result;

			public uint MvpHeroID;

			public int KillMax;

			public int DeathMin;

			public int AssitMax;

			public ulong DamageMax;

			public uint BeHitMax;

			public ulong DamageMaxUid;

			public ulong BeHitMaxUid;

			public List<ItemBrief> DayJoinReward;

			public List<ItemBrief> WinReward;

			public XLevelRewardDocument.PVPRoleInfo MvpData;

			public List<XLevelRewardDocument.PVPRoleInfo> Team1Data;

			public List<XLevelRewardDocument.PVPRoleInfo> Team2Data;
		}

		public struct GuildMineData
		{

			public void Init()
			{
				this.mine = 0U;
				this.item = new List<ItemBrief>();
			}

			public uint mine;

			public List<ItemBrief> item;
		}

		public struct RaceData
		{

			public void Init()
			{
				this.rolename = new List<string>();
				this.profession = new List<int>();
				this.item = new List<List<ItemBrief>>();
				this.time = new List<uint>();
				this.petid = new List<uint>();
				this.rank = new List<uint>();
			}

			public List<string> rolename;

			public List<int> profession;

			public List<List<ItemBrief>> item;

			public List<uint> time;

			public List<uint> petid;

			public List<uint> rank;
		}

		public struct InvFightData
		{

			public void Init()
			{
				this.rivalName = "";
				this.isWin = false;
			}

			public string rivalName;

			public bool isWin;
		}

		public struct SkyArenaData
		{

			public void Init()
			{
				this.roleid = new List<ulong>();
				this.killcount = new List<int>();
				this.deathcount = new List<int>();
				this.damage = new List<ulong>();
				this.ismvp = new List<bool>();
				this.floor = 0U;
				this.item = new List<ItemBrief>();
			}

			public List<ulong> roleid;

			public List<int> killcount;

			public List<int> deathcount;

			public List<ulong> damage;

			public List<bool> ismvp;

			public uint floor;

			public List<ItemBrief> item;
		}

		public struct AbyssPartyData
		{

			public void Init()
			{
				this.AbysssPartyListId = 0;
				this.Time = 0U;
				this.item = new List<ItemBrief>();
			}

			public int AbysssPartyListId;

			public uint Time;

			public List<ItemBrief> item;
		}

		public struct BigMeleeData
		{

			public void Init()
			{
				this.rank = 0U;
				this.score = 0U;
				this.kill = 0U;
				this.death = 0U;
				this.item = new List<ItemBrief>();
			}

			public uint rank;

			public uint score;

			public uint kill;

			public uint death;

			public List<ItemBrief> item;
		}

		public struct BattleRankRoleInfo
		{

			public ulong RoleID;

			public uint Rank;

			public string Name;

			public string ServerName;

			public uint KillCount;

			public uint CombKill;

			public uint DeathCount;

			public bool isMVP;

			public ulong Damage;

			public int RoleProf;

			public uint Point;
		}

		public struct BattleFieldData
		{

			public void Init()
			{
				this.allend = false;
				this.MemberData = new List<XLevelRewardDocument.BattleRankRoleInfo>();
				this.item = new List<ItemBrief>();
			}

			public bool allend;

			public List<XLevelRewardDocument.BattleRankRoleInfo> MemberData;

			public List<ItemBrief> item;
		}

		public struct GerenalData
		{

			public void Init()
			{
				this.Rank = 0U;
				this.Stars = new List<uint>();
				this.Items = new List<ItemBrief>();
				this.LevelFinishTime = 0U;
				this.StartLevel = 0U;
				this.StartPercent = 0f;
				this.TotalExpPercent = 0f;
				this.CurrentExpPercent = 0f;
				this.GrowExpPercent = 0f;
				this.TotalExp = 0f;
				this.SwitchLeftTime = 0;
				this.GuildExp = 0U;
				this.GuildContribution = 0U;
				this.GuildDragonCoin = 0U;
				this.GoldGroupReward = null;
				this.isHelper = false;
				this.noneReward = false;
				this.isSeal = false;
			}

			public uint Rank;

			public uint Score;

			public List<uint> Stars;

			public List<ItemBrief> Items;

			public uint LevelFinishTime;

			public uint StartLevel;

			public float StartPercent;

			public float TotalExpPercent;

			public float CurrentExpPercent;

			public float GrowExpPercent;

			public float TotalExp;

			public float GuildBuff;

			public int SwitchLeftTime;

			public uint GuildExp;

			public uint GuildContribution;

			public uint GuildDragonCoin;

			public ItemBrief GoldGroupReward;

			public bool isHelper;

			public bool noneReward;

			public bool isSeal;
		}

		public struct LevelRewardRoleData
		{

			public void Init()
			{
				this.uid = 0UL;
				this.Name = "";
				this.Level = 0U;
				this.isLeader = false;
				this.isHelper = false;
				this.noneReward = false;
				this.ProfID = 0;
				this.Rank = 0U;
				this.BoxID = 0;
				this.chestList = new List<BattleRewardChest>();
			}

			public ulong uid;

			public string Name;

			public uint Level;

			public bool isLeader;

			public bool isHelper;

			public bool noneReward;

			public int ProfID;

			public uint Rank;

			public int BoxID;

			public uint ServerID;

			public List<BattleRewardChest> chestList;
		}

		public struct SelectChestData
		{

			public void Init()
			{
				this.Player.Init();
				this.Others = new List<XLevelRewardDocument.LevelRewardRoleData>();
				this.SelectLeftTime = 0;
			}

			public XLevelRewardDocument.LevelRewardRoleData Player;

			public List<XLevelRewardDocument.LevelRewardRoleData> Others;

			public int SelectLeftTime;
		}

		public struct DragonCrusadeData
		{

			public void Init()
			{
				this.Player.Init();
				this.Others = new List<XLevelRewardDocument.LevelRewardRoleData>();
				this.BossDamageHP = 0;
				this.BossLeftHP = 0;
				this.MyResult = null;
			}

			public XLevelRewardDocument.LevelRewardRoleData Player;

			public List<XLevelRewardDocument.LevelRewardRoleData> Others;

			public int BossDamageHP;

			public int BossLeftHP;

			public DragonExpResult MyResult;
		}

		public struct BattleData
		{

			public ulong uid;

			public string Name;

			public int ProfID;

			public bool isLeader;

			public uint Rank;

			public ulong DamageTotal;

			public float DamagePercent;

			public ulong HealTotal;

			public uint DeathCount;

			public uint ComboCount;
		}

		public struct QualifyingData
		{

			public void Init()
			{
				this.QualifyingResult = PkResultType.PkResult_Draw;
				this.QualifyingRankChange = 0;
				this.FirstRank = 0;
				this.QualifyingPointChange = 0;
				this.QualifyingHonorChange = 0U;
				this.QualifyingHonorItems = new List<ItemBrief>();
				this.myState = KKVsRoleState.KK_VS_ROLE_NORMAL;
				this.opState = KKVsRoleState.KK_VS_ROLE_NORMAL;
			}

			public PkResultType QualifyingResult;

			public int QualifyingRankChange;

			public int FirstRank;

			public int QualifyingPointChange;

			public uint QualifyingHonorChange;

			public List<ItemBrief> QualifyingHonorItems;

			public KKVsRoleState myState;

			public KKVsRoleState opState;
		}

		public struct BattleRoyaleData
		{

			public void Init()
			{
				this.SelfRank = 0U;
				this.AllRank = 0U;
				this.KillCount = 0U;
				this.KilledBy = "";
				this.LiveTime = 0U;
				this.AddPoint = 0;
			}

			public uint SelfRank;

			public uint AllRank;

			public uint KillCount;

			public string KilledBy;

			public uint LiveTime;

			public int AddPoint;
		}
	}
}

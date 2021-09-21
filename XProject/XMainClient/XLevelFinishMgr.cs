using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E09 RID: 3593
	internal class XLevelFinishMgr : XSingleton<XLevelFinishMgr>
	{
		// Token: 0x170033F7 RID: 13303
		// (get) Token: 0x0600C1AD RID: 49581 RVA: 0x00296D60 File Offset: 0x00294F60
		// (set) Token: 0x0600C1AE RID: 49582 RVA: 0x00296D68 File Offset: 0x00294F68
		public bool NeedUpdate { get; set; }

		// Token: 0x170033F8 RID: 13304
		// (get) Token: 0x0600C1AF RID: 49583 RVA: 0x00296D71 File Offset: 0x00294F71
		// (set) Token: 0x0600C1B0 RID: 49584 RVA: 0x00296D79 File Offset: 0x00294F79
		public uint LastFinishScene { get; set; }

		// Token: 0x170033F9 RID: 13305
		// (get) Token: 0x0600C1B1 RID: 49585 RVA: 0x00296D82 File Offset: 0x00294F82
		// (set) Token: 0x0600C1B2 RID: 49586 RVA: 0x00296D8A File Offset: 0x00294F8A
		public string LevelRewardToken { get; set; }

		// Token: 0x170033FA RID: 13306
		// (get) Token: 0x0600C1B3 RID: 49587 RVA: 0x00296D93 File Offset: 0x00294F93
		// (set) Token: 0x0600C1B4 RID: 49588 RVA: 0x00296D9B File Offset: 0x00294F9B
		public bool HaveBattleResultData { get; set; }

		// Token: 0x170033FB RID: 13307
		// (get) Token: 0x0600C1B5 RID: 49589 RVA: 0x00296DA4 File Offset: 0x00294FA4
		// (set) Token: 0x0600C1B6 RID: 49590 RVA: 0x00296DAC File Offset: 0x00294FAC
		public bool IsCurrentLevelFinished { get; set; }

		// Token: 0x170033FC RID: 13308
		// (get) Token: 0x0600C1B7 RID: 49591 RVA: 0x00296DB5 File Offset: 0x00294FB5
		// (set) Token: 0x0600C1B8 RID: 49592 RVA: 0x00296DBD File Offset: 0x00294FBD
		public bool IsCurrentLevelWin { get; set; }

		// Token: 0x170033FD RID: 13309
		// (get) Token: 0x0600C1B9 RID: 49593 RVA: 0x00296DC6 File Offset: 0x00294FC6
		// (set) Token: 0x0600C1BA RID: 49594 RVA: 0x00296DCE File Offset: 0x00294FCE
		public bool NeedCheckLevelfinishScript { get; set; }

		// Token: 0x170033FE RID: 13310
		// (get) Token: 0x0600C1BB RID: 49595 RVA: 0x00296DD7 File Offset: 0x00294FD7
		// (set) Token: 0x0600C1BC RID: 49596 RVA: 0x00296DDF File Offset: 0x00294FDF
		public bool WaitingLevelContinueSelect { get; set; }

		// Token: 0x170033FF RID: 13311
		// (get) Token: 0x0600C1BD RID: 49597 RVA: 0x00296DE8 File Offset: 0x00294FE8
		// (set) Token: 0x0600C1BE RID: 49598 RVA: 0x00296DF0 File Offset: 0x00294FF0
		public bool IsFastLevelFinish { get; set; }

		// Token: 0x17003400 RID: 13312
		// (get) Token: 0x0600C1BF RID: 49599 RVA: 0x00296DF9 File Offset: 0x00294FF9
		// (set) Token: 0x0600C1C0 RID: 49600 RVA: 0x00296E01 File Offset: 0x00295001
		public bool IsReturnClicked { get; set; }

		// Token: 0x17003401 RID: 13313
		// (get) Token: 0x0600C1C1 RID: 49601 RVA: 0x00296E0A File Offset: 0x0029500A
		// (set) Token: 0x0600C1C2 RID: 49602 RVA: 0x00296E12 File Offset: 0x00295012
		public int KeyNpcID { get; set; }

		// Token: 0x0600C1C3 RID: 49603 RVA: 0x00296E1C File Offset: 0x0029501C
		public override bool Init()
		{
			return true;
		}

		// Token: 0x0600C1C4 RID: 49604 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Uninit()
		{
		}

		// Token: 0x0600C1C5 RID: 49605 RVA: 0x00296E30 File Offset: 0x00295030
		public void OnSceneLoaded(uint sceneID)
		{
			this._current_scene_id = sceneID;
			this.NeedUpdate = false;
			this.HaveBattleResultData = false;
			this.IsCurrentLevelFinished = false;
			this.IsCurrentLevelWin = false;
			this.NeedCheckLevelfinishScript = false;
			this.WaitingLevelContinueSelect = false;
			this.IsFastLevelFinish = (sceneID == 100U || sceneID == 25U);
			this.IsReturnClicked = false;
			this.KeyNpcID = 0;
			XLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			specificDocument.RequestServer = false;
			this._WinCondition.Clear();
			this._LoseCondition.Clear();
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(sceneID);
			bool flag = sceneData != null;
			if (flag)
			{
				for (int i = 0; i < sceneData.WinCondition.Count; i++)
				{
					XLevelWin item = default(XLevelWin);
					item.cond = (XLevelWinCondition)sceneData.WinCondition[i, 0];
					item.param = sceneData.WinCondition[i, 1];
					this._WinCondition.Add(item);
				}
				for (int j = 0; j < sceneData.LoseCondition.Count; j++)
				{
					XLevelLose xlevelLose = default(XLevelLose);
					xlevelLose.cond = (XLevelLoseCondtion)sceneData.LoseCondition[j, 0];
					xlevelLose.param = sceneData.LoseCondition[j, 1];
					this._LoseCondition.Add(xlevelLose);
					bool flag2 = xlevelLose.cond == XLevelLoseCondtion.LevelLose_NpcDie;
					if (flag2)
					{
						this.KeyNpcID = sceneData.LoseCondition[j, 1];
					}
				}
			}
		}

		// Token: 0x0600C1C6 RID: 49606 RVA: 0x00296FC3 File Offset: 0x002951C3
		public void OnLeaveScene()
		{
			this.NeedUpdate = false;
			this.NeedCheckLevelfinishScript = false;
			this.IsFastLevelFinish = false;
		}

		// Token: 0x0600C1C7 RID: 49607 RVA: 0x00296FE0 File Offset: 0x002951E0
		public void CanLevelFinished(XLevelState ls)
		{
			bool isCurrentLevelFinished = this.IsCurrentLevelFinished;
			if (!isCurrentLevelFinished)
			{
				bool needCheckLevelfinishScript = this.NeedCheckLevelfinishScript;
				if (!needCheckLevelfinishScript)
				{
					bool waitingLevelContinueSelect = this.WaitingLevelContinueSelect;
					if (!waitingLevelContinueSelect)
					{
						bool flag = false;
						bool flag2 = false;
						bool bKillOpponent = true;
						bool flag3 = false;
						for (int i = 0; i < this._WinCondition.Count; i++)
						{
							switch (this._WinCondition[i].cond)
							{
							case XLevelWinCondition.LevelWin_Boss:
							{
								bool flag4 = ls._boss_total > 0 && ls._boss_total == ls._boss_kill;
								if (flag4)
								{
									flag = true;
									flag2 = XSingleton<XLevelSpawnMgr>.singleton.ExecuteWaveExtraScript(ls._BossWave);
								}
								break;
							}
							case XLevelWinCondition.LevelWin_Killall:
							{
								bool flag5 = ls._total_monster > 0 && ls._total_monster == ls._total_kill;
								if (flag5)
								{
									flag = true;
									bool flag6 = ls._BossWave > 0;
									if (flag6)
									{
										flag2 = XSingleton<XLevelSpawnMgr>.singleton.ExecuteWaveExtraScript(ls._BossWave);
									}
								}
								break;
							}
							case XLevelWinCondition.LevelWin_Kill_N:
							{
								bool flag7 = ls._total_kill >= this._WinCondition[i].param;
								if (flag7)
								{
									flag = true;
								}
								break;
							}
							case XLevelWinCondition.LevelWin_Time:
							{
								float time = Time.time;
								bool flag8 = time - ls._start_time > (float)this._WinCondition[i].param;
								if (flag8)
								{
									flag = true;
								}
								break;
							}
							case XLevelWinCondition.LevelWin_PVP:
							{
								bool flag9 = ls._total_kill == this._WinCondition[i].param;
								if (flag9)
								{
									flag = true;
								}
								break;
							}
							case XLevelWinCondition.LevelWin_BossRush:
							{
								float time2 = Time.time;
								uint num = uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("BossRushTime"));
								bool flag10 = this.IsReturnClicked || ls._refuseRevive || time2 - ls._start_time > num || (ls._boss_kill > 0 && DlgBase<BossRushDlg, BossRushBehavior>.singleton.isWin);
								if (flag10)
								{
									XBossBushDocument specificDocument = XDocuments.GetSpecificDocument<XBossBushDocument>(XBossBushDocument.uuID);
									bool flag11 = ls._boss_kill > 0 || specificDocument.respData.currank > 1;
									if (flag11)
									{
										flag = true;
										bKillOpponent = false;
									}
									else
									{
										flag3 = true;
										bKillOpponent = false;
									}
									bool flag12 = XSingleton<XEntityMgr>.singleton.Boss != null;
									if (flag12)
									{
										XSingleton<XEntityMgr>.singleton.Puppets(XSingleton<XEntityMgr>.singleton.Boss, true, false);
									}
								}
								break;
							}
							}
							bool flag13 = flag || flag3;
							if (flag13)
							{
								break;
							}
						}
						bool flag14 = flag;
						if (flag14)
						{
							this.StopPlayerAllysAI();
							bool flag15 = !flag2;
							if (flag15)
							{
								this.OnLevelFinish(ls._lastDieEntityPos + new Vector3(0f, ls._lastDieEntityHeight, 0f) / 2f, ls._lastDieEntityPos, 500U, 0U, bKillOpponent);
								this.IsCurrentLevelFinished = true;
								this.IsCurrentLevelWin = true;
								return;
							}
							this.KillAllOpponent();
							this.NeedCheckLevelfinishScript = true;
						}
						bool flag16 = flag3;
						if (flag16)
						{
							this.OnLevelFailed();
							this.IsCurrentLevelFinished = true;
							this.IsCurrentLevelWin = false;
						}
						else
						{
							for (int j = 0; j < this._LoseCondition.Count; j++)
							{
								switch (this._LoseCondition[j].cond)
								{
								case XLevelLoseCondtion.LevelLose_PlayerDie:
								{
									bool flag17 = ls._my_team_alive == 0U && ls._refuseRevive;
									if (flag17)
									{
										flag3 = true;
									}
									break;
								}
								case XLevelLoseCondtion.LevelTime_Out:
								{
									float time3 = Time.time;
									bool flag18 = time3 - ls._start_time > (float)this._LoseCondition[j].param;
									if (flag18)
									{
										flag3 = true;
									}
									break;
								}
								case XLevelLoseCondtion.LevelLose_NpcDie:
								{
									bool key_npc_die = ls._key_npc_die;
									if (key_npc_die)
									{
										flag3 = true;
									}
									break;
								}
								}
								bool flag19 = flag3;
								if (flag19)
								{
									break;
								}
							}
							bool flag20 = flag3;
							if (flag20)
							{
								this.OnLevelFailed();
								this.IsCurrentLevelFinished = true;
								this.IsCurrentLevelWin = false;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600C1C8 RID: 49608 RVA: 0x002973EC File Offset: 0x002955EC
		public void ForceLevelFinish(bool win)
		{
			this.IsCurrentLevelFinished = true;
			if (win)
			{
				XLevelState ls = XSingleton<XLevelStatistics>.singleton.ls;
				this.IsCurrentLevelWin = true;
				this.OnLevelFinish(ls._lastDieEntityPos + new Vector3(0f, ls._lastDieEntityHeight, 0f) / 2f, ls._lastDieEntityPos, 500U, 0U, true);
			}
			else
			{
				this.OnLevelFailed();
			}
		}

		// Token: 0x0600C1C9 RID: 49609 RVA: 0x00297468 File Offset: 0x00295668
		public void OnLevelFailed()
		{
			XSingleton<XPandoraSDKDocument>.singleton.SetLastFailSceneID(this._current_scene_id);
			this.LastFinishScene = 0U;
			this.IsCurrentLevelWin = false;
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
			XSingleton<XPostEffectMgr>.singleton.MakeEffectEnable(XPostEffect.BlackWhite, true);
			XLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			specificDocument.ShowStageFailUI(null);
			XFPStrengthenDocument specificDocument2 = XDocuments.GetSpecificDocument<XFPStrengthenDocument>(XFPStrengthenDocument.uuID);
			specificDocument2.TryShowBrief();
			XSingleton<XGameSysMgr>.singleton.bStopBlockRedPoint = true;
		}

		// Token: 0x0600C1CA RID: 49610 RVA: 0x00297538 File Offset: 0x00295738
		public void OnLevelFinish(Vector3 dropInitPos, Vector3 dropGounrdPos, uint money, uint itemCount, bool bKillOpponent)
		{
			bool flag = DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.SetVisiblePure(false);
			}
			if (bKillOpponent)
			{
				this.KillAllOpponent();
			}
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this._current_scene_id);
			List<XEntity> ally = XSingleton<XEntityMgr>.singleton.GetAlly(XSingleton<XEntityMgr>.singleton.Player);
			for (int i = 0; i < ally.Count; i++)
			{
				XAIEnableAI @event = XEventPool<XAIEnableAI>.GetEvent();
				@event.Firer = ally[i];
				@event.Enable = false;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
			bool flag2 = string.IsNullOrEmpty(sceneData.EndCutScene);
			if (flag2)
			{
				XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.SendBattleReport), null);
			}
			else
			{
				XSingleton<XTimerMgr>.singleton.SetTimer(sceneData.EndCutSceneTime, new XTimerMgr.ElapsedEventHandler(this.PlayCutScene), sceneData.EndCutScene);
			}
		}

		// Token: 0x0600C1CB RID: 49611 RVA: 0x00297634 File Offset: 0x00295834
		private void PlayCutScene(object o)
		{
			string str = (string)o;
			this.NeedUpdate = true;
			XSingleton<XCutScene>.singleton.Start("CutScene/" + str, true, true);
		}

		// Token: 0x0600C1CC RID: 49612 RVA: 0x0029766C File Offset: 0x0029586C
		public void KillAllOpponent()
		{
			XSingleton<XLevelStatistics>.singleton.OnBeforeKillMonster();
			List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(XSingleton<XEntityMgr>.singleton.Player);
			for (int i = 0; i < opponent.Count; i++)
			{
				bool flag = !XEntity.ValideEntity(opponent[i]) || opponent[i].IsPuppet;
				if (!flag)
				{
					XSingleton<XLevelStatistics>.singleton.ls._after_force_kill++;
					opponent[i].Attributes.ForceDeath();
				}
			}
		}

		// Token: 0x0600C1CD RID: 49613 RVA: 0x00297700 File Offset: 0x00295900
		public void StopPlayerAllysAI()
		{
			XAIStopEventArgs @event = XEventPool<XAIStopEventArgs>.GetEvent();
			@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			List<XEntity> ally = XSingleton<XEntityMgr>.singleton.GetAlly(XSingleton<XEntityMgr>.singleton.Player);
			for (int i = 0; i < ally.Count; i++)
			{
				XAIStopEventArgs event2 = XEventPool<XAIStopEventArgs>.GetEvent();
				event2.Firer = ally[i];
				XSingleton<XEventMgr>.singleton.FireEvent(event2);
			}
		}

		// Token: 0x0600C1CE RID: 49614 RVA: 0x00160161 File Offset: 0x0015E361
		protected void ForceReturnHall(object o)
		{
			XSingleton<XScene>.singleton.ReqLeaveScene();
		}

		// Token: 0x0600C1CF RID: 49615 RVA: 0x00297780 File Offset: 0x00295980
		public void Update(float deltaT)
		{
			bool needCheckLevelfinishScript = this.NeedCheckLevelfinishScript;
			if (needCheckLevelfinishScript)
			{
				bool flag = !XSingleton<XLevelSpawnMgr>.singleton.BossExtarScriptExecuting;
				if (flag)
				{
					this.NeedCheckLevelfinishScript = false;
					this.ForceLevelFinish(true);
				}
			}
			bool flag2 = !this.NeedUpdate;
			if (!flag2)
			{
				bool isPlaying = XSingleton<XCutScene>.singleton.IsPlaying;
				if (!isPlaying)
				{
					this.NeedUpdate = false;
					bool syncMode = XSingleton<XGame>.singleton.SyncMode;
					if (syncMode)
					{
						this.ShowLevelFinishUI();
					}
					else
					{
						this.SendBattleReport(null);
					}
				}
			}
		}

		// Token: 0x0600C1D0 RID: 49616 RVA: 0x0029780C File Offset: 0x00295A0C
		public void SendBattleReport(object o)
		{
			this.LastFinishScene = this._current_scene_id;
			XLevelState ls = XSingleton<XLevelStatistics>.singleton.ls;
			XAttributes attributes = XSingleton<XEntityMgr>.singleton.Player.Attributes;
			RpcC2G_ReportBattle rpcC2G_ReportBattle = new RpcC2G_ReportBattle();
			rpcC2G_ReportBattle.oArg.battledata = new BattleData();
			rpcC2G_ReportBattle.oArg.battledata.timespan = (int)(ls._end_time - ls._start_time);
			double attr = XSingleton<XEntityMgr>.singleton.Player.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
			double attr2 = XSingleton<XEntityMgr>.singleton.Player.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total);
			rpcC2G_ReportBattle.oArg.battledata.hppercent = (uint)(attr * 100.0 / attr2);
			rpcC2G_ReportBattle.oArg.battledata.Combo = (int)XSingleton<XLevelStatistics>.singleton.ls._max_combo;
			rpcC2G_ReportBattle.oArg.battledata.BeHit = (int)XSingleton<XLevelStatistics>.singleton.ls._player_behit;
			rpcC2G_ReportBattle.oArg.battledata.found = XSingleton<XLevelStatistics>.singleton.ls._enemy_in_fight;
			for (int i = 0; i < XLevelRewardDocument.Table.Table.Length; i++)
			{
				StageRankTable.RowData rowData = XLevelRewardDocument.Table.Table[i];
				bool flag = rowData.scendid != this._current_scene_id;
				if (!flag)
				{
					bool flag2 = false;
					uint num = 0U;
					bool flag3 = rowData.star2[0] == 5U;
					if (flag3)
					{
						flag2 = true;
						num = rowData.star2[1];
					}
					bool flag4 = rowData.star3[0] == 5U;
					if (flag4)
					{
						flag2 = true;
						num = rowData.star3[1];
					}
					bool flag5 = !flag2;
					if (!flag5)
					{
						List<XEntity> all = XSingleton<XEntityMgr>.singleton.GetAll();
						for (int j = 0; j < all.Count; j++)
						{
							XEntity xentity = all[j];
							bool flag6 = !xentity.IsRole && xentity.TypeID == num;
							if (flag6)
							{
								rpcC2G_ReportBattle.oArg.battledata.npchp = (uint)(xentity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic) * 100.0 / xentity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total));
								break;
							}
						}
						break;
					}
				}
			}
			XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
			foreach (KeyValuePair<uint, uint> keyValuePair in specificDocument.TaskMonstersKilled)
			{
				bool flag7 = keyValuePair.Value == 0U;
				if (!flag7)
				{
					rpcC2G_ReportBattle.oArg.battledata.monster_id.Add(keyValuePair.Key);
					rpcC2G_ReportBattle.oArg.battledata.monster_num.Add(keyValuePair.Value);
				}
			}
			List<ulong> list = new List<ulong>(ls._entity_die.Keys);
			for (int k = 0; k < list.Count; k++)
			{
				rpcC2G_ReportBattle.oArg.battledata.smallmonster.Add((uint)list[k]);
				rpcC2G_ReportBattle.oArg.battledata.smallmonster.Add((uint)ls._entity_die[list[k]]);
			}
			bool flag8 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BOSSRUSH;
			if (flag8)
			{
				rpcC2G_ReportBattle.oArg.battledata.bossrush.Add(DlgBase<BossRushDlg, BossRushBehavior>.singleton.killAllMonster);
			}
			rpcC2G_ReportBattle.oArg.battledata.OpenChest = ls._box_enemy_kill;
			XSingleton<XLevelDoodadMgr>.singleton.PickAllDoodad();
			XSingleton<XLevelDoodadMgr>.singleton.ReportServerList(rpcC2G_ReportBattle.oArg.battledata.pickDoodadWaveID);
			XLevelRewardDocument specificDocument2 = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			specificDocument2.LevelFinishTime = rpcC2G_ReportBattle.oArg.battledata.timespan;
			specificDocument2.LevelFinishHp = rpcC2G_ReportBattle.oArg.battledata.hppercent;
			specificDocument2.RequestServer = true;
			rpcC2G_ReportBattle.oArg.battledata.anticheatInfo = new CliAntiCheatInfo();
			rpcC2G_ReportBattle.oArg.battledata.anticheatInfo.battleStamp = this.LevelRewardToken;
			rpcC2G_ReportBattle.oArg.battledata.anticheatInfo.totalDamage = (uint)XSingleton<XLevelStatistics>.singleton.ls._total_damage;
			rpcC2G_ReportBattle.oArg.battledata.anticheatInfo.totalHurt = (uint)XSingleton<XLevelStatistics>.singleton.ls._total_hurt;
			rpcC2G_ReportBattle.oArg.battledata.anticheatInfo.totalRecovery = (uint)XSingleton<XLevelStatistics>.singleton.ls._total_heal;
			rpcC2G_ReportBattle.oArg.battledata.anticheatInfo.currentHp = (uint)XSingleton<XEntityMgr>.singleton.Player.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
			for (int l = 0; l < XSingleton<XLevelStatistics>.singleton.ls._monster_refresh_time.Count; l++)
			{
				rpcC2G_ReportBattle.oArg.battledata.anticheatInfo.monsterRfsTimes.Add(XSingleton<XLevelStatistics>.singleton.ls._monster_refresh_time[l]);
			}
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ReportBattle);
		}

		// Token: 0x0600C1D1 RID: 49617 RVA: 0x00297D88 File Offset: 0x00295F88
		public void SendLevelFailData()
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (!syncMode)
			{
				RpcC2G_ReportBattle rpcC2G_ReportBattle = new RpcC2G_ReportBattle();
				rpcC2G_ReportBattle.oArg.battledata = new BattleData();
				rpcC2G_ReportBattle.oArg.battledata.isfailed = true;
				rpcC2G_ReportBattle.oArg.battledata.failedinfo = new BattleFailedData();
				rpcC2G_ReportBattle.oArg.battledata.failedinfo.timespan = (uint)(Time.time - XSingleton<XLevelStatistics>.singleton.ls._start_time);
				rpcC2G_ReportBattle.oArg.battledata.failedinfo.deathcount = XSingleton<XLevelStatistics>.singleton.ls._death_count;
				double attr = XSingleton<XEntityMgr>.singleton.Player.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
				double attr2 = XSingleton<XEntityMgr>.singleton.Player.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total);
				rpcC2G_ReportBattle.oArg.battledata.failedinfo.hppercent = (uint)(attr * 100.0 / attr2);
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ReportBattle);
			}
		}

		// Token: 0x0600C1D2 RID: 49618 RVA: 0x00297E9C File Offset: 0x0029609C
		public static void PlayVictory()
		{
			XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
			bool isMounted = player.IsMounted;
			if (!isMounted)
			{
				player.Net.ReportSkillAction(null, player.SkillMgr.GetDisappearIdentity(), -1);
				XSingleton<XScene>.singleton.GameCamera.TargetOffset = 7f;
				XComponent xcomponent = XSingleton<XScene>.singleton.GameCamera.GetXComponent(XCameraVAdjustComponent.uuID);
				bool flag = xcomponent != null;
				if (flag)
				{
					xcomponent.Enabled = false;
				}
			}
		}

		// Token: 0x0600C1D3 RID: 49619 RVA: 0x00297F14 File Offset: 0x00296114
		public void StartLevelFinish()
		{
			XAIEnableAI @event = XEventPool<XAIEnableAI>.GetEvent();
			@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
			@event.Enable = false;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			bool isFastLevelFinish = this.IsFastLevelFinish;
			if (isFastLevelFinish)
			{
				this.ForceReturnHall(null);
			}
			else
			{
				SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this._current_scene_id);
				bool flag = !string.IsNullOrEmpty(sceneData.EndCutScene) && XSingleton<XGame>.singleton.SyncMode;
				if (flag)
				{
					XSingleton<XTimerMgr>.singleton.SetTimer(sceneData.EndCutSceneTime, new XTimerMgr.ElapsedEventHandler(this.PlayCutScene), sceneData.EndCutScene);
				}
				else
				{
					this.ShowLevelFinishUI();
				}
			}
		}

		// Token: 0x0600C1D4 RID: 49620 RVA: 0x00297FC0 File Offset: 0x002961C0
		private void ShowLevelFinishUI()
		{
			this.IsCurrentLevelFinished = true;
			XSingleton<XShell>.singleton.Pause = false;
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
			XLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			specificDocument.ShowBattleResultFrame();
		}

		// Token: 0x04005240 RID: 21056
		private uint _current_scene_id;

		// Token: 0x04005243 RID: 21059
		private List<XLevelWin> _WinCondition = new List<XLevelWin>();

		// Token: 0x04005244 RID: 21060
		private List<XLevelLose> _LoseCondition = new List<XLevelLose>();
	}
}

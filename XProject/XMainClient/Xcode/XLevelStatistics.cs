using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLevelStatistics : XSingleton<XLevelStatistics>
	{

		public uint ComboCount
		{
			get
			{
				return this._comboCount;
			}
			set
			{
				this._comboCount = value;
			}
		}

		public void Clear()
		{
			this._comboCount = 0U;
			this._lastHitTime = 0f;
		}

		public void OnEnterScene(uint sceneID)
		{
			this.ls.Reset();
			this.ls._current_scene_id = sceneID;
			this.ls._start_time = Time.time;
			XSingleton<XLevelSpawnMgr>.singleton.GetMonsterCount(XSingleton<XLevelSpawnMgr>.singleton.CurrentSpawner, ref this.ls._total_monster, ref this.ls._boss_total);
			this._combo_interval = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("ComboInterval"));
		}

		public void OnLeaveScene()
		{
		}

		public void OnMonsterDie(XEntity entity)
		{
			Vector3 lastDieEntityPos = entity.EngineObject.Position + new Vector3(0f, entity.Height / 2f, 0f);
			bool flag = entity.IsOpposer || entity.IsBoss || entity.IsRole;
			if (flag)
			{
				bool flag2 = XSingleton<XEntityMgr>.singleton.IsOpponent(entity, XSingleton<XEntityMgr>.singleton.Player);
				if (flag2)
				{
					bool flag3 = entity.Wave >= 0 && this.ls.CheckEntityInLevelSpawn(entity.ID);
					if (flag3)
					{
						this.ls._total_kill++;
						bool flag4 = entity.CreateTime > 0f;
						if (flag4)
						{
							this.ls._monster_exist_time += (int)(Time.realtimeSinceStartup - entity.CreateTime);
						}
						bool isBoss = entity.IsBoss;
						if (isBoss)
						{
							this.ls._boss_kill++;
							this.ls._BossWave = entity.Wave;
							bool flag5 = entity.CreateTime > 0f;
							if (flag5)
							{
								this.ls._boss_exist_time += (int)(Time.realtimeSinceStartup - entity.CreateTime);
							}
						}
						Dictionary<ulong, int> entity_in_level_spawn = this.ls._entity_in_level_spawn;
						ulong id = entity.ID;
						entity_in_level_spawn[id]--;
						bool flag6 = (XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position - entity.EngineObject.Position).sqrMagnitude > 2500f;
						if (flag6)
						{
							this.ls._abnormal_monster++;
						}
					}
					this.ls.AddEntityDieCount((ulong)entity.TypeID);
					bool flag7 = this.ls._boss_kill <= this.ls._boss_total;
					if (flag7)
					{
						this.ls._lastDieEntityPos = lastDieEntityPos;
						this.ls._lastDieEntityHeight = entity.Height;
					}
				}
			}
			bool isBoss2 = entity.IsBoss;
			if (isBoss2)
			{
				this.ls._boss_rush_kill++;
			}
			bool flag8 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag8)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.OnMonsterDie(entity);
			}
			bool flag9 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag9)
			{
				DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler.OnMonsterDie(entity);
			}
			bool isPlayer = entity.IsPlayer;
			if (isPlayer)
			{
				this.ls._my_team_alive -= 1U;
				this.OnPlayerDie();
			}
			bool flag10 = (ulong)entity.TypeID == (ulong)((long)XLevelStatistics.BOX_ENEMY_ID);
			if (flag10)
			{
				this.ls._box_enemy_kill++;
			}
			bool flag11 = (ulong)entity.TypeID == (ulong)((long)XSingleton<XLevelFinishMgr>.singleton.KeyNpcID);
			if (flag11)
			{
				this.ls._key_npc_die = true;
			}
			XSingleton<XLevelSpawnMgr>.singleton.OnMonsterDie(entity);
		}

		public void OnPlayerDie()
		{
			this.ls._death_count += 1U;
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this.ls._current_scene_id);
			XSingleton<XPostEffectMgr>.singleton.MakeEffectEnable(XPostEffect.BlackWhite, true);
			bool flag = sceneData.type == 7 || sceneData.type == 11;
			if (!flag)
			{
				XReviveDocument specificDocument = XDocuments.GetSpecificDocument<XReviveDocument>(XReviveDocument.uuID);
				bool flag2 = !sceneData.CanRevive || (specificDocument.ReviveUsedTime >= specificDocument.ReviveMaxTime && !XSingleton<XGame>.singleton.SyncMode);
				if (flag2)
				{
					this.ls._refuseRevive = true;
				}
				else
				{
					bool flag3 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
					if (flag3)
					{
						DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.SetVisible(false);
					}
					specificDocument.StartRevive();
				}
			}
		}

		public void OnPlayerRevive()
		{
			this.ls._revive_count += 1U;
			this.ls._my_team_alive += 1U;
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this.ls._current_scene_id);
			XSingleton<XPostEffectMgr>.singleton.MakeEffectEnable(XPostEffect.BlackWhite, false);
			bool flag = sceneData.type == 7 || sceneData.type == 11;
			if (flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.OnPlayerRevive();
				}
			}
			else
			{
				bool flag3 = DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.IsLoaded();
				if (flag3)
				{
					DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.SetVisible(false, true);
				}
				bool flag4 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag4)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.SetVisible(true);
				}
				XPlayerAttributes xplayerAttributes = XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes;
				xplayerAttributes.HPMPReset();
				XSingleton<XFxMgr>.singleton.CreateAndPlay(XSingleton<XGlobalConfig>.singleton.GetValue("ReviveFx"), XSingleton<XEntityMgr>.singleton.Player.EngineObject, Vector3.zero, Vector3.one, 1f, true, 5f, true);
			}
		}

		public void OnPlayerRefuseRevive()
		{
			this.ls._refuseRevive = true;
		}

		public void OnHitEnemy(int comboCount = -1)
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			this._lastHitTime = realtimeSinceStartup;
			bool flag = comboCount < 0;
			if (flag)
			{
				this._comboCount += 1U;
			}
			else
			{
				this._comboCount = (uint)comboCount;
			}
			bool flag2 = this._comboCount > this.ls._max_combo;
			if (flag2)
			{
				this.ls._max_combo = this._comboCount;
			}
			bool flag3 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag3)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.OnComboChange(this._comboCount);
			}
			this._SendComboCountEvent();
		}

		public void OnEnemyHitEnemy(XEntity entity)
		{
			bool flag = entity == null || entity.Attributes == null || entity.Attributes.HostID != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			if (!flag)
			{
				XOthersAttributes xothersAttributes = entity.Attributes as XOthersAttributes;
				bool flag2 = xothersAttributes != null && xothersAttributes.LinkCombo == 1;
				if (flag2)
				{
					this.OnHitEnemy(-1);
				}
			}
		}

		public void OnPlayerBeHit()
		{
			this.ls._player_behit += 1U;
		}

		public void OnAIinFight(XEntity entity)
		{
			bool isEnemy = entity.IsEnemy;
			if (isEnemy)
			{
				this.ls._enemy_in_fight += 1U;
			}
		}

		public void SetPlayerContineIndex(int index)
		{
			this.ls._player_continue_index = index;
			this.ls._start_time = Time.time;
			XSingleton<XLevelScriptMgr>.singleton.SetExternalString("playercontinue" + this.ls._player_continue_index.ToString(), false);
		}

		public void AddPlayerContinueIndex()
		{
			this.ls._player_continue_index++;
			this.ls._start_time = Time.time;
			XSingleton<XLevelScriptMgr>.singleton.SetExternalString("playercontinue" + this.ls._player_continue_index.ToString(), false);
		}

		public void Update()
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			bool flag = realtimeSinceStartup - this._lastHitTime > this._combo_interval;
			if (flag)
			{
				bool flag2 = this._comboCount > 0U;
				if (flag2)
				{
					this._comboCount = 0U;
					this._SendComboCountEvent();
				}
				bool flag3 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag3)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.OnComboChange(this._comboCount);
				}
			}
			bool flag4 = !XSingleton<XGame>.singleton.SyncMode;
			if (flag4)
			{
				XSingleton<XLevelFinishMgr>.singleton.CanLevelFinished(this.ls);
				bool isCurrentLevelFinished = XSingleton<XLevelFinishMgr>.singleton.IsCurrentLevelFinished;
				if (isCurrentLevelFinished)
				{
					bool flag5 = this.ls._end_time <= 0f;
					if (flag5)
					{
						this.ls._end_time = Time.time;
					}
				}
			}
		}

		public void OnSetBattleResult()
		{
			this.ls._remain_monster = XSingleton<XEntityMgr>.singleton.GetOpponent(XSingleton<XEntityMgr>.singleton.Player).Count;
		}

		public void OnBeforeKillMonster()
		{
			this.ls._before_force_kill = this.ls._total_kill;
		}

		private void _SendComboCountEvent()
		{
			bool flag = XSingleton<XGame>.singleton.SyncMode || XSingleton<XEntityMgr>.singleton.Player == null;
			if (!flag)
			{
				XOnComboChangeEventArgs @event = XEventPool<XOnComboChangeEventArgs>.GetEvent();
				@event.ComboCount = this._comboCount;
				@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		public void SendData()
		{
			XStaticSecurityStatistics.Append("PlayerDeadCount", this.ls._death_count);
			XStaticSecurityStatistics.Append("PlayerReliveCount", this.ls._revive_count);
			XStaticSecurityStatistics.Append("MonsterCount", (float)(this.ls._total_monster + XStaticSecurityStatistics._MonsterAIInfo._BossCallMonsterTotal));
			XStaticSecurityStatistics.Append("MonsterEndCount", (float)this.ls._remain_monster);
			XStaticSecurityStatistics.Append("MonsterCount1", (float)this.ls._before_force_kill);
			XStaticSecurityStatistics.Append("MonsterCount2", (float)this.ls._after_force_kill);
			XStaticSecurityStatistics.Append("MonsterCount3", (float)this.ls._abnormal_monster);
			XStaticSecurityStatistics.Append("BossCount", (float)this.ls._boss_total);
			XStaticSecurityStatistics.Append("BossKillCount", (float)this.ls._boss_kill);
			XStaticSecurityStatistics.Append("BossTimeTotal", (float)this.ls._boss_exist_time);
			XStaticSecurityStatistics.Append("MonsterTimeTotal", (float)this.ls._monster_exist_time);
			XStaticSecurityStatistics.Append("RoundTimeUse", (this.ls._end_time > this.ls._start_time) ? ((this.ls._end_time - this.ls._start_time) * 1000f) : 0f);
		}

		public XLevelState ls = new XLevelState();

		public static readonly int BOX_ENEMY_ID = 5011;

		private uint _comboCount;

		private float _lastHitTime;

		private float _combo_interval = 2f;
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E0F RID: 3599
	internal class XLevelSpawnMgr : XSingleton<XLevelSpawnMgr>
	{
		// Token: 0x17003402 RID: 13314
		// (get) Token: 0x0600C1EE RID: 49646 RVA: 0x0029930C File Offset: 0x0029750C
		public bool HasRobot
		{
			get
			{
				return this._CachedRobotFromServer != null;
			}
		}

		// Token: 0x17003403 RID: 13315
		// (get) Token: 0x0600C1EF RID: 49647 RVA: 0x00299328 File Offset: 0x00297528
		public XLevelSpawnInfo CurrentSpawner
		{
			get
			{
				return this._curSpawner;
			}
		}

		// Token: 0x17003404 RID: 13316
		// (get) Token: 0x0600C1F0 RID: 49648 RVA: 0x00299340 File Offset: 0x00297540
		public XAIGlobal AIGlobal
		{
			get
			{
				return this._aiGlobal;
			}
		}

		// Token: 0x0600C1F1 RID: 49649 RVA: 0x00299358 File Offset: 0x00297558
		public override bool Init()
		{
			XSingleton<XResourceLoaderMgr>.singleton.ReadFile("Table/RandomEntityList", this._RandomBossReader);
			return true;
		}

		// Token: 0x0600C1F2 RID: 49650 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Uninit()
		{
		}

		// Token: 0x0600C1F3 RID: 49651 RVA: 0x00299384 File Offset: 0x00297584
		private List<int> GetCollectionEntityID(int RandomID)
		{
			this.ret.Clear();
			for (int i = 0; i < this._RandomBossReader.Table.Length; i++)
			{
				bool flag = this._RandomBossReader.Table[i].RandomID == RandomID;
				if (flag)
				{
					this.ret.Add(this._RandomBossReader.Table[i].EntityID);
				}
			}
			return this.ret;
		}

		// Token: 0x0600C1F4 RID: 49652 RVA: 0x00299400 File Offset: 0x00297600
		public bool OnSceneLoaded(uint sceneID)
		{
			XSingleton<XLevelFinishMgr>.singleton.OnSceneLoaded(sceneID);
			string sceneConfigFile = XSingleton<XSceneMgr>.singleton.GetSceneConfigFile(sceneID);
			bool flag = sceneConfigFile.Length == 0;
			bool result;
			if (flag)
			{
				this._curSpawner = null;
				XSingleton<XLevelScriptMgr>.singleton.ClearWallInfo();
				XSingleton<XLevelScriptMgr>.singleton.Reset();
				result = false;
			}
			else
			{
				this.ReadFromSpawnConfig(sceneID, sceneConfigFile);
				XSingleton<XLevelScriptMgr>.singleton.CommandCount = 0U;
				this.BossExtarScriptExecuting = false;
				result = true;
			}
			return result;
		}

		// Token: 0x0600C1F5 RID: 49653 RVA: 0x00299478 File Offset: 0x00297678
		public void GetMonsterCount(XLevelSpawnInfo spawner, ref int totalMonster, ref int totalBoss)
		{
			bool flag = spawner == null;
			if (!flag)
			{
				int num = 0;
				int num2 = 0;
				for (int i = 0; i < spawner._waves.Count; i++)
				{
					XLevelWave xlevelWave = spawner._waves[i];
					bool flag2 = xlevelWave._spawnType == LevelSpawnType.Spawn_Source_Monster;
					if (flag2)
					{
						XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(xlevelWave._EnemyID);
						bool flag3 = byID != null && XSingleton<XEntityMgr>.singleton.IsOpponent((uint)byID.Fightgroup);
						if (flag3)
						{
							bool flag4 = 1 == byID.Type;
							if (flag4)
							{
								num += xlevelWave._monsterPos.Count + xlevelWave._roundCount;
								num2 += xlevelWave._monsterPos.Count + xlevelWave._roundCount;
							}
							bool flag5 = 6 == byID.Type || 2 == byID.Type;
							if (flag5)
							{
								num += xlevelWave._monsterPos.Count + xlevelWave._roundCount;
							}
						}
					}
					else
					{
						bool flag6 = xlevelWave._spawnType == LevelSpawnType.Spawn_Source_Random;
						if (flag6)
						{
							num += xlevelWave._monsterPos.Count + xlevelWave._roundCount;
							int randomID = xlevelWave._randomID;
							List<int> collectionEntityID = this.GetCollectionEntityID(randomID);
							bool flag7 = collectionEntityID.Count > 0;
							if (flag7)
							{
								int key = collectionEntityID[0];
								XEntityStatistics.RowData byID2 = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID((uint)key);
								bool flag8 = 1 == byID2.Type;
								if (flag8)
								{
									num2 += xlevelWave._monsterPos.Count + xlevelWave._roundCount;
								}
							}
						}
						else
						{
							num += xlevelWave._monsterPos.Count + xlevelWave._roundCount;
						}
					}
				}
				totalMonster = num;
				totalBoss = num2;
			}
		}

		// Token: 0x0600C1F6 RID: 49654 RVA: 0x0029964C File Offset: 0x0029784C
		private void ReadFromSpawnConfig(uint sceneID, string configFile)
		{
			this._time = 0f;
			bool flag = this._curSpawner == null;
			if (flag)
			{
				this._curSpawner = new XLevelSpawnInfo();
			}
			else
			{
				this._curSpawner.Clear();
			}
			Stream stream = XSingleton<XResourceLoaderMgr>.singleton.ReadText("Table/" + configFile, ".txt", true);
			StreamReader streamReader = new StreamReader(stream);
			string text = streamReader.ReadLine();
			int num = int.Parse(text);
			text = streamReader.ReadLine();
			int num2 = int.Parse(text);
			for (int i = 0; i < num2; i++)
			{
				text = streamReader.ReadLine();
				string[] array = text.Split(new char[]
				{
					','
				});
				int key = int.Parse(array[0].Substring(3));
				int value = int.Parse(array[1]);
				bool forcePreloadOneWave = this.ForcePreloadOneWave;
				if (forcePreloadOneWave)
				{
					bool flag2 = i == 0;
					if (flag2)
					{
						this._curSpawner._preloadInfo.Add(key, value);
					}
				}
				else
				{
					bool flag3 = this._curSpawner._preloadInfo.Count < this.MaxPreloadCount;
					if (flag3)
					{
						this._curSpawner._preloadInfo.Add(key, value);
					}
				}
			}
			for (int j = 0; j < num; j++)
			{
				XLevelWave xlevelWave = new XLevelWave();
				xlevelWave.ReadFromFile(streamReader);
				this._curSpawner._waves.Add(xlevelWave);
				XLevelDynamicInfo xlevelDynamicInfo = new XLevelDynamicInfo();
				xlevelDynamicInfo._id = xlevelWave._id;
				xlevelDynamicInfo._TotalCount = xlevelWave._monsterPos.Count + xlevelWave._roundCount;
				xlevelDynamicInfo.Reset();
				this._curSpawner._wavesDynamicInfo.Add(xlevelWave._id, xlevelDynamicInfo);
			}
			XSingleton<XResourceLoaderMgr>.singleton.ClearStream(stream);
			this._time = 0f;
			XSingleton<XLevelScriptMgr>.singleton.PreloadLevelScript(configFile + "_sc");
		}

		// Token: 0x0600C1F7 RID: 49655 RVA: 0x0029984C File Offset: 0x00297A4C
		public void InitGlobalAI(uint sceneId)
		{
			bool flag = !XSingleton<XGame>.singleton.SyncMode;
			if (flag)
			{
				this._aiGlobal = new XAIGlobal();
				SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(sceneId);
				bool flag2 = sceneData != null;
				if (flag2)
				{
					this._aiGlobal.InitAIGlobal(sceneData.SceneAI);
				}
				else
				{
					this._aiGlobal.InitAIGlobal("default");
				}
			}
		}

		// Token: 0x0600C1F8 RID: 49656 RVA: 0x002998B4 File Offset: 0x00297AB4
		public void UnInitGlobalAI()
		{
			bool flag = this._aiGlobal != null;
			if (flag)
			{
				this._aiGlobal.UnInitAIGlobal();
				this._aiGlobal = null;
			}
			XSingleton<XLevelAIMgr>.singleton.ClearAIData();
		}

		// Token: 0x0600C1F9 RID: 49657 RVA: 0x002998F0 File Offset: 0x00297AF0
		public void OnLeaveScene()
		{
			bool flag = this._curSpawner != null;
			if (flag)
			{
				this._curSpawner.Clear();
				this._curSpawner = null;
			}
			this.robot = null;
			XSingleton<XLevelFinishMgr>.singleton.OnLeaveScene();
		}

		// Token: 0x0600C1FA RID: 49658 RVA: 0x00299934 File Offset: 0x00297B34
		public XLevelSpawnInfo GetSpawnerBySceneID(uint sceneID)
		{
			return this._curSpawner;
		}

		// Token: 0x0600C1FB RID: 49659 RVA: 0x0029994C File Offset: 0x00297B4C
		public void OnMonsterDie(XEntity entity)
		{
			XPlayer xplayer = entity as XPlayer;
			bool flag = entity != null && this._curSpawner != null;
			if (flag)
			{
				this._curSpawner.OnMonsterDie(entity);
			}
		}

		// Token: 0x0600C1FC RID: 49660 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void OnMonsterSpawn(int waveid)
		{
		}

		// Token: 0x0600C1FD RID: 49661 RVA: 0x00299984 File Offset: 0x00297B84
		public void Update(float delta)
		{
			bool isCurrentLevelFinished = XSingleton<XLevelFinishMgr>.singleton.IsCurrentLevelFinished;
			if (!isCurrentLevelFinished)
			{
				bool needCheckLevelfinishScript = XSingleton<XLevelFinishMgr>.singleton.NeedCheckLevelfinishScript;
				if (!needCheckLevelfinishScript)
				{
					this._time += delta;
					bool flag = this._curSpawner != null;
					if (flag)
					{
						this._curSpawner.Update(this._time);
					}
				}
			}
		}

		// Token: 0x0600C1FE RID: 49662 RVA: 0x002999E0 File Offset: 0x00297BE0
		public void SetMonster(UnitAppearance monster)
		{
			uint waveID = monster.waveID;
			monster.waveID = waveID - 1U;
			this._CachedMonsterFromServer[monster.waveID] = monster;
		}

		// Token: 0x0600C1FF RID: 49663 RVA: 0x00299A14 File Offset: 0x00297C14
		public void CacheServerMonster(List<UnitAppearance> Monsters)
		{
			this._CachedMonsterFromServer.Clear();
			for (int i = 0; i < Monsters.Count; i++)
			{
				this._CachedMonsterFromServer.Add(Monsters[i].waveID, Monsters[i]);
			}
		}

		// Token: 0x0600C200 RID: 49664 RVA: 0x00299A64 File Offset: 0x00297C64
		public void CacheServerRobot(UnitAppearance Robot)
		{
			this._CachedRobotFromServer = Robot;
		}

		// Token: 0x0600C201 RID: 49665 RVA: 0x00299A70 File Offset: 0x00297C70
		public UnitAppearance GetCacheServerMonster(uint wave)
		{
			UnitAppearance unitAppearance;
			bool flag = this._CachedMonsterFromServer.TryGetValue(wave, out unitAppearance);
			UnitAppearance result;
			if (flag)
			{
				result = unitAppearance;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600C202 RID: 49666 RVA: 0x00299A9C File Offset: 0x00297C9C
		public void CreateRobot(uint sceneid)
		{
			bool flag = this._CachedRobotFromServer == null;
			if (!flag)
			{
				Vector3 sceneStartPos = XSingleton<XSceneMgr>.singleton.GetSceneStartPos(sceneid);
				Vector3 forward = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Forward;
				Vector3 position = sceneStartPos + forward;
				Quaternion sceneStartRot = XSingleton<XSceneMgr>.singleton.GetSceneStartRot(sceneid);
				XAttributes attr = XSingleton<XAttributeMgr>.singleton.InitAttrFromServer(this._CachedRobotFromServer.uID, this._CachedRobotFromServer.nickid, this._CachedRobotFromServer.unitType, this._CachedRobotFromServer.unitName, this._CachedRobotFromServer.attributes, this._CachedRobotFromServer.fightgroup, this._CachedRobotFromServer.isServerControl, this._CachedRobotFromServer.skills, null, new XOutLookAttr((this._CachedRobotFromServer.outlook != null) ? this._CachedRobotFromServer.outlook.guild : null), this._CachedRobotFromServer.level, 0U);
				this.robot = XSingleton<XEntityMgr>.singleton.Add(XSingleton<XEntityMgr>.singleton.CreateRole(attr, position, sceneStartRot, false, false));
				bool isDead = this._CachedRobotFromServer.IsDead;
				if (isDead)
				{
					XSingleton<XDeath>.singleton.DeathDetect(this.robot, null, true);
				}
			}
		}

		// Token: 0x0600C203 RID: 49667 RVA: 0x00299BD0 File Offset: 0x00297DD0
		public bool ExecuteWaveExtraScript(int wave)
		{
			bool flag = this._curSpawner != null;
			return flag && this._curSpawner.ExecuteWaveExtraScript(wave);
		}

		// Token: 0x0600C204 RID: 49668 RVA: 0x00299C00 File Offset: 0x00297E00
		public void SpawnExternalMonster(uint enemyID, Vector3 pos, int rot = 0)
		{
			bool flag = this._curSpawner != null;
			if (flag)
			{
				this._curSpawner.GenerateExternalSpawnTask(enemyID, pos, rot);
			}
		}

		// Token: 0x0600C205 RID: 49669 RVA: 0x00299C2C File Offset: 0x00297E2C
		public void KillAllMonster()
		{
			List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(XSingleton<XEntityMgr>.singleton.Player);
			for (int i = 0; i < opponent.Count; i++)
			{
				XSingleton<XDeath>.singleton.DeathDetect(opponent[i], null, true);
			}
		}

		// Token: 0x0600C206 RID: 49670 RVA: 0x00299C7C File Offset: 0x00297E7C
		public void CacheServerMonsterID(List<uint> idList)
		{
			this.MonsterIDs.Clear();
			for (int i = 0; i < idList.Count; i++)
			{
				this.MonsterIDs.Add(idList[i]);
			}
		}

		// Token: 0x0600C207 RID: 49671 RVA: 0x00299CC0 File Offset: 0x00297EC0
		public bool QueryMonsterStaticInfo(uint monsterID, ref Vector3 position, ref float face)
		{
			bool flag = this.CurrentSpawner == null;
			return !flag && this.CurrentSpawner.QueryMonsterStaticInfo(monsterID, ref position, ref face);
		}

		// Token: 0x0400527B RID: 21115
		private float _time = 0f;

		// Token: 0x0400527C RID: 21116
		private XLevelSpawnInfo _curSpawner;

		// Token: 0x0400527D RID: 21117
		private XAIGlobal _aiGlobal;

		// Token: 0x0400527E RID: 21118
		private Dictionary<uint, UnitAppearance> _CachedMonsterFromServer = new Dictionary<uint, UnitAppearance>();

		// Token: 0x0400527F RID: 21119
		private UnitAppearance _CachedRobotFromServer = null;

		// Token: 0x04005280 RID: 21120
		private RandomBossTable _RandomBossReader = new RandomBossTable();

		// Token: 0x04005281 RID: 21121
		public XEntity robot;

		// Token: 0x04005282 RID: 21122
		public bool BossExtarScriptExecuting = false;

		// Token: 0x04005283 RID: 21123
		public List<uint> MonsterIDs = new List<uint>();

		// Token: 0x04005284 RID: 21124
		public bool ForcePreloadOneWave = false;

		// Token: 0x04005285 RID: 21125
		public int MaxPreloadCount = 6;

		// Token: 0x04005286 RID: 21126
		private List<int> ret = new List<int>();
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLevelSpawnMgr : XSingleton<XLevelSpawnMgr>
	{

		public bool HasRobot
		{
			get
			{
				return this._CachedRobotFromServer != null;
			}
		}

		public XLevelSpawnInfo CurrentSpawner
		{
			get
			{
				return this._curSpawner;
			}
		}

		public XAIGlobal AIGlobal
		{
			get
			{
				return this._aiGlobal;
			}
		}

		public override bool Init()
		{
			XSingleton<XResourceLoaderMgr>.singleton.ReadFile("Table/RandomEntityList", this._RandomBossReader);
			return true;
		}

		public override void Uninit()
		{
		}

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

		public XLevelSpawnInfo GetSpawnerBySceneID(uint sceneID)
		{
			return this._curSpawner;
		}

		public void OnMonsterDie(XEntity entity)
		{
			XPlayer xplayer = entity as XPlayer;
			bool flag = entity != null && this._curSpawner != null;
			if (flag)
			{
				this._curSpawner.OnMonsterDie(entity);
			}
		}

		public void OnMonsterSpawn(int waveid)
		{
		}

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

		public void SetMonster(UnitAppearance monster)
		{
			uint waveID = monster.waveID;
			monster.waveID = waveID - 1U;
			this._CachedMonsterFromServer[monster.waveID] = monster;
		}

		public void CacheServerMonster(List<UnitAppearance> Monsters)
		{
			this._CachedMonsterFromServer.Clear();
			for (int i = 0; i < Monsters.Count; i++)
			{
				this._CachedMonsterFromServer.Add(Monsters[i].waveID, Monsters[i]);
			}
		}

		public void CacheServerRobot(UnitAppearance Robot)
		{
			this._CachedRobotFromServer = Robot;
		}

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

		public bool ExecuteWaveExtraScript(int wave)
		{
			bool flag = this._curSpawner != null;
			return flag && this._curSpawner.ExecuteWaveExtraScript(wave);
		}

		public void SpawnExternalMonster(uint enemyID, Vector3 pos, int rot = 0)
		{
			bool flag = this._curSpawner != null;
			if (flag)
			{
				this._curSpawner.GenerateExternalSpawnTask(enemyID, pos, rot);
			}
		}

		public void KillAllMonster()
		{
			List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(XSingleton<XEntityMgr>.singleton.Player);
			for (int i = 0; i < opponent.Count; i++)
			{
				XSingleton<XDeath>.singleton.DeathDetect(opponent[i], null, true);
			}
		}

		public void CacheServerMonsterID(List<uint> idList)
		{
			this.MonsterIDs.Clear();
			for (int i = 0; i < idList.Count; i++)
			{
				this.MonsterIDs.Add(idList[i]);
			}
		}

		public bool QueryMonsterStaticInfo(uint monsterID, ref Vector3 position, ref float face)
		{
			bool flag = this.CurrentSpawner == null;
			return !flag && this.CurrentSpawner.QueryMonsterStaticInfo(monsterID, ref position, ref face);
		}

		private float _time = 0f;

		private XLevelSpawnInfo _curSpawner;

		private XAIGlobal _aiGlobal;

		private Dictionary<uint, UnitAppearance> _CachedMonsterFromServer = new Dictionary<uint, UnitAppearance>();

		private UnitAppearance _CachedRobotFromServer = null;

		private RandomBossTable _RandomBossReader = new RandomBossTable();

		public XEntity robot;

		public bool BossExtarScriptExecuting = false;

		public List<uint> MonsterIDs = new List<uint>();

		public bool ForcePreloadOneWave = false;

		public int MaxPreloadCount = 6;

		private List<int> ret = new List<int>();
	}
}

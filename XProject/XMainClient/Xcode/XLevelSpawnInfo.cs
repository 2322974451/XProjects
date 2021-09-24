using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLevelSpawnInfo
	{

		public void Clear()
		{
			this._waves.Clear();
			foreach (KeyValuePair<int, XLevelDynamicInfo> keyValuePair in this._wavesDynamicInfo)
			{
				keyValuePair.Value.Reset();
			}
			this._wavesDynamicInfo.Clear();
			this._preloadInfo.Clear();
			this._tasks.Clear();
		}

		public void ResetDynamicInfo()
		{
			foreach (KeyValuePair<int, XLevelDynamicInfo> keyValuePair in this._wavesDynamicInfo)
			{
				keyValuePair.Value.Reset();
			}
		}

		public void KillSpawn(int waveid)
		{
			List<XEntity> list = XSingleton<XEntityMgr>.singleton.GetNeutral();
			for (int i = 0; i < list.Count; i++)
			{
				bool flag = list[i].Wave == waveid;
				if (flag)
				{
					list[i].Attributes.ForceDeath();
				}
			}
			list = XSingleton<XEntityMgr>.singleton.GetOpponent(XSingleton<XEntityMgr>.singleton.Player);
			for (int j = 0; j < list.Count; j++)
			{
				bool flag2 = list[j].Wave == waveid;
				if (flag2)
				{
					list[j].Attributes.ForceDeath();
				}
			}
		}

		public void ShowBubble(int typeid, string text, float exist)
		{
			List<XEntity> all = XSingleton<XEntityMgr>.singleton.GetAll();
			for (int i = 0; i < all.Count; i++)
			{
				bool flag = XEntity.ValideEntity(all[i]) && (ulong)all[i].TypeID == (ulong)((long)typeid);
				if (flag)
				{
					XBubbleComponent xbubbleComponent = all[i].GetXComponent(XBubbleComponent.uuID) as XBubbleComponent;
					bool flag2 = xbubbleComponent == null;
					if (flag2)
					{
						XSingleton<XComponentMgr>.singleton.CreateComponent(all[i], XBubbleComponent.uuID);
					}
					XBubbleEventArgs @event = XEventPool<XBubbleEventArgs>.GetEvent();
					@event.bubbletext = text;
					@event.existtime = exist;
					@event.Firer = all[i];
					@event.speaker = all[i].Name;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
					break;
				}
			}
		}

		public void Update(float time)
		{
			bool flag = !XSingleton<XGame>.singleton.SyncMode;
			if (flag)
			{
				this._SoloUpdate(time);
			}
		}

		protected void _SoloUpdate(float time)
		{
			for (int i = 0; i < this._waves.Count; i++)
			{
				XLevelDynamicInfo waveDynamicInfo = this.GetWaveDynamicInfo(this._waves[i]._id);
				bool flag = waveDynamicInfo == null;
				if (!flag)
				{
					bool flag2 = waveDynamicInfo._TotalCount != 0 && waveDynamicInfo._generateCount == waveDynamicInfo._TotalCount;
					if (!flag2)
					{
						bool pushIntoTask = waveDynamicInfo._pushIntoTask;
						if (!pushIntoTask)
						{
							bool flag3 = true;
							for (int j = 0; j < this._waves[i]._preWave.Count; j++)
							{
								XLevelDynamicInfo xlevelDynamicInfo;
								bool flag4 = this._wavesDynamicInfo.TryGetValue(this._waves[i]._preWave[j], out xlevelDynamicInfo);
								if (flag4)
								{
									bool flag5 = xlevelDynamicInfo._generateCount != xlevelDynamicInfo._TotalCount;
									if (flag5)
									{
										flag3 = false;
										break;
									}
									bool flag6 = xlevelDynamicInfo._enemyIds.Count == 0;
									if (flag6)
									{
										flag3 = true;
									}
									else
									{
										bool flag7 = xlevelDynamicInfo._enemyIds.Count == 1;
										if (flag7)
										{
											XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(xlevelDynamicInfo._enemyIds[0]);
											bool flag8 = entity != null;
											if (flag8)
											{
												double attr = entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total);
												double attr2 = entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
												bool flag9 = attr2 > attr * (double)this._waves[i]._preWavePercent;
												if (flag9)
												{
													flag3 = false;
													break;
												}
											}
										}
										else
										{
											bool flag10 = xlevelDynamicInfo._generateCount != xlevelDynamicInfo._dieCount;
											if (flag10)
											{
												flag3 = false;
												break;
											}
										}
									}
								}
							}
							bool flag11 = !flag3;
							if (!flag11)
							{
								bool flag12 = true;
								bool flag13 = this._waves[i]._exString != null && this._waves[i]._exString.Length > 0;
								if (flag13)
								{
									bool flag14 = !XSingleton<XLevelScriptMgr>.singleton.QueryExternalString(this._waves[i]._exString, false);
									if (flag14)
									{
										flag12 = false;
									}
								}
								bool flag15 = flag12 && waveDynamicInfo._exStringFinishTime == 0f;
								if (flag15)
								{
									waveDynamicInfo._exStringFinishTime = time;
								}
								bool flag16 = flag3 && XSingleton<XCommon>.singleton.IsEqual(waveDynamicInfo._prewaveFinishTime, 0f);
								if (flag16)
								{
									waveDynamicInfo._prewaveFinishTime = time;
								}
								bool flag17 = false;
								bool flag18 = this._waves[i]._exString != null && this._waves[i]._exString.Length > 0;
								if (flag18)
								{
									bool flag19 = time - waveDynamicInfo._exStringFinishTime >= this._waves[i]._time && waveDynamicInfo._exStringFinishTime > 0f;
									if (flag19)
									{
										flag17 = true;
									}
								}
								else
								{
									bool flag20 = this._waves[i].IsScriptWave() || waveDynamicInfo._generateCount < waveDynamicInfo._TotalCount;
									if (flag20)
									{
										bool flag21 = flag3 && time - waveDynamicInfo._prewaveFinishTime >= this._waves[i]._time;
										if (flag21)
										{
											flag17 = true;
										}
									}
								}
								bool flag22 = flag17;
								if (flag22)
								{
									bool flag23 = this._waves[i].IsScriptWave();
									if (flag23)
									{
										this.GenerateScriptTask(this._waves[i]);
									}
									else
									{
										this.GenerateNormalTask(this._waves[i]);
										this.GenerateRoundTask(this._waves[i]);
									}
									bool flag24 = !this._waves[i]._repeat;
									if (flag24)
									{
										waveDynamicInfo._pushIntoTask = true;
									}
									bool flag25 = this._waves[i]._repeat && this._waves[i]._exString != null && this._waves[i]._exString.Length > 0;
									if (flag25)
									{
										XSingleton<XLevelScriptMgr>.singleton.QueryExternalString(this._waves[i]._exString, true);
										waveDynamicInfo._exStringFinishTime = 0f;
									}
								}
							}
						}
					}
				}
			}
			this.ProcessTaskQueue(time);
		}

		public bool ExecuteWaveExtraScript(int wave)
		{
			for (int i = 0; i < this._waves.Count; i++)
			{
				XLevelDynamicInfo waveDynamicInfo = this.GetWaveDynamicInfo(this._waves[i]._id);
				bool flag = waveDynamicInfo == null;
				if (!flag)
				{
					bool pushIntoTask = waveDynamicInfo._pushIntoTask;
					if (!pushIntoTask)
					{
						bool flag2 = this._waves[i]._preWave.Count > 0 && this._waves[i]._preWave[0] == wave && this._waves[i].IsScriptWave();
						if (flag2)
						{
							bool flag3 = XSingleton<XLevelScriptMgr>.singleton.IsTalkScript(this._waves[i]._levelscript);
							if (flag3)
							{
								XSingleton<XLevelSpawnMgr>.singleton.BossExtarScriptExecuting = true;
								XSingleton<XTimerMgr>.singleton.SetTimer(this._waves[i]._time, new XTimerMgr.ElapsedEventHandler(this.RunExtraScript), this._waves[i]._levelscript);
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		protected void RunExtraScript(object o)
		{
			string funcName = (string)o;
			XSingleton<XLevelScriptMgr>.singleton.RunScript(funcName);
		}

		protected void ProcessTaskQueue(float time)
		{
			bool flag = true;
			for (int i = 0; i < 2; i++)
			{
				bool flag2 = flag;
				if (flag2)
				{
					bool flag3 = this._tasks.Count > 0;
					if (flag3)
					{
						XLevelBaseTask xlevelBaseTask = this._tasks.Dequeue();
						flag = xlevelBaseTask.Execute(time);
					}
				}
			}
		}

		public XLevelDynamicInfo GetWaveDynamicInfo(int waveid)
		{
			XLevelDynamicInfo xlevelDynamicInfo;
			bool flag = this._wavesDynamicInfo.TryGetValue(waveid, out xlevelDynamicInfo);
			XLevelDynamicInfo result;
			if (flag)
			{
				result = xlevelDynamicInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		protected XLevelWave GetWaveInfo(int waveid)
		{
			for (int i = 0; i < this._waves.Count; i++)
			{
				bool flag = this._waves[i]._id == waveid;
				if (flag)
				{
					return this._waves[i];
				}
			}
			return null;
		}

		public void OnMonsterDie(XEntity entity)
		{
			XLevelDynamicInfo xlevelDynamicInfo;
			bool flag = this._wavesDynamicInfo.TryGetValue(entity.Wave, out xlevelDynamicInfo);
			if (flag)
			{
				xlevelDynamicInfo._dieCount++;
				xlevelDynamicInfo._enemyIds.Remove(entity.ID);
			}
			XSingleton<XLevelDoodadMgr>.singleton.OnMonsterDie(entity);
		}

		public void GenerateExternalSpawnTask(uint enemyID, Vector3 pos, int rot)
		{
			XLevelSpawnTask xlevelSpawnTask = new XLevelSpawnTask(this);
			xlevelSpawnTask._id = -1;
			xlevelSpawnTask._EnemyID = enemyID;
			xlevelSpawnTask._MonsterRotate = rot;
			xlevelSpawnTask._MonsterIndex = 0;
			xlevelSpawnTask._MonsterPos = pos;
			xlevelSpawnTask._SpawnType = LevelSpawnType.Spawn_Source_Monster;
			xlevelSpawnTask._IsSummonTask = true;
			this._tasks.Enqueue(xlevelSpawnTask);
		}

		protected void GenerateNormalTask(XLevelWave wave)
		{
			XSingleton<XLevelStatistics>.singleton.ls._monster_refresh_time.Add((uint)(Time.time - XSingleton<XLevelStatistics>.singleton.ls._start_time));
			foreach (KeyValuePair<int, Vector3> keyValuePair in wave._monsterPos)
			{
				XLevelSpawnTask xlevelSpawnTask = new XLevelSpawnTask(this);
				xlevelSpawnTask._id = wave._id;
				xlevelSpawnTask._EnemyID = wave._EnemyID;
				xlevelSpawnTask._MonsterRotate = (int)wave._monsterRot[keyValuePair.Key].y;
				xlevelSpawnTask._MonsterIndex = keyValuePair.Key;
				xlevelSpawnTask._MonsterPos = keyValuePair.Value;
				xlevelSpawnTask._SpawnType = wave._spawnType;
				xlevelSpawnTask._IsSummonTask = false;
				this._tasks.Enqueue(xlevelSpawnTask);
			}
		}

		protected void GenerateRoundTask(XLevelWave wave)
		{
			bool flag = wave._roundRidus > 0f && wave._roundCount > 0;
			if (flag)
			{
				XSingleton<XLevelStatistics>.singleton.ls._monster_refresh_time.Add((uint)(Time.time - XSingleton<XLevelStatistics>.singleton.ls._start_time));
				float num = 360f / (float)wave._roundCount;
				Vector3 position = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position;
				for (int i = 0; i < wave._roundCount; i++)
				{
					XLevelSpawnTask xlevelSpawnTask = new XLevelSpawnTask(this);
					xlevelSpawnTask._id = wave._id;
					xlevelSpawnTask._EnemyID = wave._EnemyID;
					xlevelSpawnTask._MonsterIndex = 0;
					xlevelSpawnTask._MonsterPos = position + Quaternion.Euler(0f, num * (float)i, 0f) * new Vector3(0f, 0f, 1f) * wave._roundRidus;
					xlevelSpawnTask._MonsterRotate = (int)num * i + 180;
					xlevelSpawnTask._SpawnType = wave._spawnType;
					xlevelSpawnTask._IsSummonTask = false;
					this._tasks.Enqueue(xlevelSpawnTask);
				}
			}
		}

		protected void GenerateScriptTask(XLevelWave wave)
		{
			XLevelScriptTask xlevelScriptTask = new XLevelScriptTask(this);
			xlevelScriptTask._ScriptName = wave._levelscript;
			this._tasks.Enqueue(xlevelScriptTask);
		}

		public bool QueryMonsterStaticInfo(uint monsterID, ref Vector3 position, ref float face)
		{
			for (int i = 0; i < this._waves.Count; i++)
			{
				bool flag = this._waves[i]._EnemyID == monsterID;
				if (flag)
				{
					using (Dictionary<int, Vector3>.KeyCollection.Enumerator enumerator = this._waves[i]._monsterPos.Keys.GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							int key = enumerator.Current;
							position = this._waves[i]._monsterPos[key];
							face = this._waves[i]._monsterRot[key].y;
							return true;
						}
					}
				}
			}
			return false;
		}

		public List<XLevelWave> _waves = new List<XLevelWave>();

		public Dictionary<int, XLevelDynamicInfo> _wavesDynamicInfo = new Dictionary<int, XLevelDynamicInfo>();

		public Dictionary<int, int> _preloadInfo = new Dictionary<int, int>();

		private Queue<XLevelBaseTask> _tasks = new Queue<XLevelBaseTask>();

		private const int spawn_monster_per_frame = 2;
	}
}

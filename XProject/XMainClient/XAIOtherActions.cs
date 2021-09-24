using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XAIOtherActions : XSingleton<XAIOtherActions>
	{

		public XAIOtherActions()
		{
			this._delayRunScriptCb = new XTimerMgr.ElapsedEventHandler(this.DelayRunScript);
		}

		public bool Shout(XEntity entity)
		{
			return true;
		}

		public string ReceiveAIEvent(XEntity entity, int msgType, bool Deprecate)
		{
			string text = "";
			bool flag = entity.AI.AIEvent == null;
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				bool flag2 = entity.AI.AIEvent.EventType == msgType;
				if (flag2)
				{
					text = string.Format("{0} {1} {2} {3} {4} {5} {6}", new object[]
					{
						entity.AI.AIEvent.EventArg,
						entity.AI.AIEvent.TypeId,
						entity.AI.AIEvent.Pos.x,
						entity.AI.AIEvent.Pos.y,
						entity.AI.AIEvent.Pos.z,
						entity.AI.AIEvent.SkillId,
						entity.AI.AIEvent.SenderUID
					});
				}
				if (Deprecate)
				{
					entity.AI.AIEvent = null;
				}
				result = text;
			}
			return result;
		}

		public bool SendAIEvent(XEntity entity, int msgto, int msgtype, int entitytypeid, string msgarg, Vector3 pos, float delaytime = 0f)
		{
			List<XEntity> list = new List<XEntity>();
			switch (msgto)
			{
			case 0:
				list = XSingleton<XEntityMgr>.singleton.GetAlly(entity);
				break;
			case 1:
				list = XSingleton<XEntityMgr>.singleton.GetAlly(XSingleton<XEntityMgr>.singleton.Player);
				break;
			case 2:
			{
				bool flag = XSingleton<XEntityMgr>.singleton.Boss != null;
				if (flag)
				{
					list.Add(XSingleton<XEntityMgr>.singleton.Boss);
				}
				break;
			}
			case 3:
			{
				bool flag2 = entity != null;
				if (flag2)
				{
					bool flag3 = entity.IsPlayer || entity.IsRole;
					if (flag3)
					{
						list = XSingleton<XEntityMgr>.singleton.GetOpponent(entity);
					}
					else
					{
						list = XSingleton<XEntityMgr>.singleton.GetAlly(entity);
					}
				}
				else
				{
					list = XSingleton<XEntityMgr>.singleton.GetOpponent(XSingleton<XEntityMgr>.singleton.Player);
				}
				break;
			}
			case 4:
				list = XSingleton<XEntityMgr>.singleton.GetOpponent(entity);
				break;
			case 5:
			{
				list = XSingleton<XEntityMgr>.singleton.GetAlly(entity);
				List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(entity);
				for (int i = 0; i < opponent.Count; i++)
				{
					list.Add(opponent[i]);
				}
				break;
			}
			case 6:
			{
				bool flag4 = msgtype == 0;
				if (flag4)
				{
					XSingleton<XLevelScriptMgr>.singleton.SetExternalString(msgarg, false);
				}
				return true;
			}
			case 7:
				list.Add(XSingleton<XLevelSpawnMgr>.singleton.AIGlobal.Host);
				break;
			}
			for (int j = 0; j < list.Count; j++)
			{
				bool flag5 = entitytypeid != 0 && list[j].Attributes != null && (ulong)list[j].Attributes.TypeID != (ulong)((long)entitytypeid);
				if (!flag5)
				{
					XAIEventArgs @event = XEventPool<XAIEventArgs>.GetEvent();
					@event.DepracatedPass = false;
					@event.Firer = list[j];
					@event.TypeId = entitytypeid;
					@event.EventType = msgtype;
					@event.EventArg = msgarg;
					@event.Pos = pos;
					XSingleton<XEventMgr>.singleton.FireEvent(@event, (delaytime > 0f) ? delaytime : 0.05f);
				}
			}
			return true;
		}

		public bool CallMonster(XEntity entity, CallMonsterData data)
		{
			Vector3 vector = Vector3.zero;
			bool flag = data.mAIArgBornType == 0;
			if (flag)
			{
				vector = data.mAIArgPos;
			}
			else
			{
				bool flag2 = data.mAIArgBornType == 2;
				if (flag2)
				{
					vector = data.mAIArgPos1 + data.mAIArgPos;
				}
				else
				{
					Vector3[] array = new Vector3[]
					{
						data.mAIArgPos1,
						data.mAIArgPos2,
						data.mAIArgPos3,
						data.mAIArgPos4
					};
					vector = array[XSingleton<XCommon>.singleton.RandomInt(0, 4)];
				}
			}
			bool flag3 = data.mAIArgDist > 0f;
			if (flag3)
			{
				bool flag4 = false;
				Vector3 vector2 = vector;
				for (int i = 0; i < 10; i++)
				{
					vector.x += data.mAIArgDist * XSingleton<XCommon>.singleton.RandomFloat(-1f, 1f);
					vector.z += data.mAIArgDist * XSingleton<XCommon>.singleton.RandomFloat(-1f, 1f);
					bool flag5 = XSingleton<XScene>.singleton.IsWalkable(vector);
					if (flag5)
					{
						flag4 = true;
						break;
					}
				}
				bool flag6 = !flag4;
				if (flag6)
				{
					bool mAIArgForcePlace = data.mAIArgForcePlace;
					if (mAIArgForcePlace)
					{
						return false;
					}
					bool flag7 = XSingleton<XScene>.singleton.IsWalkable(vector2);
					if (flag7)
					{
						vector = vector2;
					}
					else
					{
						bool flag8 = data.mAIArgFinalPos != Vector3.zero;
						if (!flag8)
						{
							return false;
						}
						vector = data.mAIArgFinalPos;
					}
				}
			}
			bool flag9 = !XSingleton<XScene>.singleton.IsWalkable(vector);
			if (flag9)
			{
				bool mAIArgForcePlace2 = data.mAIArgForcePlace;
				if (mAIArgForcePlace2)
				{
					return false;
				}
				bool flag10 = data.mAIArgFinalPos != Vector3.zero;
				if (!flag10)
				{
					return false;
				}
				vector = data.mAIArgFinalPos;
			}
			bool flag11 = data.mAIArgMaxMonsterNum != 0;
			if (flag11)
			{
				int num = 0;
				List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(XSingleton<XEntityMgr>.singleton.Player);
				for (int j = 0; j < opponent.Count; j++)
				{
					bool flag12 = opponent[j].Attributes.TypeID == (uint)data.mAIArgMonsterId;
					if (flag12)
					{
						num++;
					}
				}
				bool flag13 = num >= data.mAIArgMaxMonsterNum;
				if (flag13)
				{
					return false;
				}
			}
			bool flag14 = data.mAIArgDelayTime > 0f;
			if (flag14)
			{
				CallMonsterArg callMonsterArg = new CallMonsterArg();
				callMonsterArg.MonsterTemplateId = data.mAIArgMonsterId;
				callMonsterArg.CopyMonsterId = data.mAIArgCopyMonsterId;
				callMonsterArg.MonsterPos = vector;
				callMonsterArg.MonsterUnitId = 0UL;
				callMonsterArg.WaveId = 0;
				callMonsterArg.OldMonsterUnitId = 0UL;
				callMonsterArg.FaceDir = data.mAIArgAngle;
				callMonsterArg.HPPercent = data.mAIArgHPPercent;
				callMonsterArg.LifeTime = data.mAIArgLifeTime;
				uint item = XSingleton<XTimerMgr>.singleton.SetTimer(data.mAIArgDelayTime, new XTimerMgr.ElapsedEventHandler(this.LateSpawn), callMonsterArg);
				entity.AI.TimerToken.Add(item);
			}
			else
			{
				XEntity xentity = XSingleton<XEntityMgr>.singleton.CreateEntity((uint)data.mAIArgMonsterId, vector, Quaternion.Euler(new Vector3(0f, data.mAIArgAngle, 0f)), true, 0U);
				bool flag15 = data.mAIArgHPPercent > 0f && data.mAIArgHPPercent < 100f;
				if (flag15)
				{
					double num2 = xentity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total);
					num2 = num2 * (double)data.mAIArgHPPercent / 100.0;
					xentity.Attributes.SetAttr(XAttributeDefine.XAttr_CurrentHP_Basic, num2);
				}
				bool flag16 = data.mAIArgLifeTime > 0f;
				if (flag16)
				{
					uint item2 = XSingleton<XTimerMgr>.singleton.SetTimer(data.mAIArgLifeTime, new XTimerMgr.ElapsedEventHandler(this.KillSpawn), xentity.ID);
					entity.AI.TimerToken.Add(item2);
				}
			}
			bool flag17 = XSingleton<XEntityMgr>.singleton.Boss != null;
			if (flag17)
			{
				XSecurityAIInfo xsecurityAIInfo = XSecurityAIInfo.TryGetStatistics(XSingleton<XEntityMgr>.singleton.Boss);
				bool flag18 = xsecurityAIInfo != null;
				if (flag18)
				{
					xsecurityAIInfo.OnCallMonster(entity);
				}
			}
			return true;
		}

		private void LateSpawn(object obj)
		{
			CallMonsterArg callMonsterArg = (CallMonsterArg)obj;
			XEntity xentity = XSingleton<XEntityMgr>.singleton.CreateEntity((uint)callMonsterArg.MonsterTemplateId, callMonsterArg.MonsterPos, Quaternion.Euler(new Vector3(0f, callMonsterArg.FaceDir, 0f)), true, 0U);
			bool flag = callMonsterArg.HPPercent > 0f && callMonsterArg.HPPercent < 100f;
			if (flag)
			{
				double num = xentity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total);
				num = num * (double)callMonsterArg.HPPercent / 100.0;
				xentity.Attributes.SetAttr(XAttributeDefine.XAttr_CurrentHP_Basic, num);
			}
			bool flag2 = callMonsterArg.LifeTime > 0f;
			if (flag2)
			{
				uint item = XSingleton<XTimerMgr>.singleton.SetTimer(callMonsterArg.LifeTime, new XTimerMgr.ElapsedEventHandler(this.KillSpawn), xentity.ID);
				XSingleton<XDebug>.singleton.AddLog("Will spawn: ", xentity.ID.ToString(), null, null, null, null, XDebugColor.XDebug_None);
				bool flag3 = XSingleton<XLevelSpawnMgr>.singleton.AIGlobal != null && XSingleton<XLevelSpawnMgr>.singleton.AIGlobal.Host != null;
				if (flag3)
				{
					XSingleton<XLevelSpawnMgr>.singleton.AIGlobal.Host.AI.TimerToken.Add(item);
				}
			}
		}

		private void KillSpawn(object obj)
		{
			ulong id = (ulong)obj;
			XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(id);
			XSingleton<XDebug>.singleton.AddLog("Will kill spawn:", id.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			bool flag = entityConsiderDeath != null;
			if (flag)
			{
				entityConsiderDeath.TriggerDeath(null);
			}
		}

		public bool CallScript(string script, float delaytime)
		{
			bool flag = delaytime > 0f;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.SetTimer(delaytime, this._delayRunScriptCb, script);
			}
			else
			{
				XSingleton<XLevelScriptMgr>.singleton.RunScript(script);
			}
			return true;
		}

		private void DelayRunScript(object args)
		{
			XSingleton<XLevelScriptMgr>.singleton.RunScript((string)args);
		}

		public bool AddBuff(int monsterid, int buffid, int buffid2)
		{
			List<XEntity> list = new List<XEntity>();
			bool result = false;
			list = XSingleton<XEntityMgr>.singleton.GetOpponent(XSingleton<XEntityMgr>.singleton.Player);
			for (int i = 0; i < list.Count; i++)
			{
				bool flag = monsterid != -1 && (ulong)list[i].Attributes.TypeID != (ulong)((long)monsterid);
				if (!flag)
				{
					result = true;
					this.AddEntityBuff(list[i], buffid);
					bool flag2 = buffid2 != 0;
					if (flag2)
					{
						this.AddEntityBuff(list[i], buffid2);
					}
				}
			}
			bool flag3 = monsterid == -1;
			if (flag3)
			{
				this.AddEntityBuff(XSingleton<XEntityMgr>.singleton.Player, buffid);
				bool flag4 = buffid2 != 0;
				if (flag4)
				{
					this.AddEntityBuff(XSingleton<XEntityMgr>.singleton.Player, buffid2);
				}
			}
			return result;
		}

		private void AddEntityBuff(XEntity entity, int buffid)
		{
			int num = buffid / 100000;
			bool flag = num == 0;
			if (flag)
			{
				num = 1;
			}
			XBuffAddEventArgs @event = XEventPool<XBuffAddEventArgs>.GetEvent();
			@event.xBuffDesc.BuffID = buffid % 100000;
			@event.xBuffDesc.BuffLevel = num;
			@event.Firer = entity;
			@event.xBuffDesc.CasterID = entity.ID;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		public bool PlayFx(string fxname, Vector3 fxpos, float delaytime)
		{
			return true;
		}

		public bool DetectEnemyInRange(XEntity entity, ref DetectEnemyInRangeArg arg)
		{
			List<XEntity> list = null;
			bool flag = arg.mAIArgFightGroupType == 0;
			if (flag)
			{
				list = XSingleton<XEntityMgr>.singleton.GetOpponent(entity);
			}
			else
			{
				bool flag2 = arg.mAIArgFightGroupType == 1;
				if (flag2)
				{
					list = XSingleton<XEntityMgr>.singleton.GetAlly(entity);
				}
			}
			bool flag3 = list == null;
			bool result;
			if (flag3)
			{
				result = false;
			}
			else
			{
				bool flag4 = arg.mAIArgMonsterType == 0;
				if (flag4)
				{
					arg.mAIArgMonsterType = -1;
				}
				for (int i = 0; i < list.Count; i++)
				{
					XEntity xentity = list[i];
					bool flag5 = xentity == entity || xentity == null;
					if (!flag5)
					{
						bool flag6 = arg.mAIArgMonsterType != -1;
						if (flag6)
						{
							uint num = 0U;
							bool flag7 = xentity.Attributes != null;
							if (flag7)
							{
								num = xentity.Attributes.Tag;
							}
							bool flag8 = ((ulong)num & (ulong)((long)arg.mAIArgMonsterType)) == 0UL;
							if (flag8)
							{
								goto IL_234;
							}
						}
						bool flag9 = arg.mAIArgRangeType == 0;
						if (flag9)
						{
							bool flag10 = (xentity.EngineObject.Position - (entity.EngineObject.Position + entity.EngineObject.Forward.normalized * arg.mAIArgOffsetLength)).magnitude <= arg.mAIArgRadius;
							if (flag10)
							{
								return true;
							}
						}
						else
						{
							bool flag11 = arg.mAIArgRangeType == 1;
							if (flag11)
							{
								float num2 = Vector3.Dot(xentity.EngineObject.Position - entity.EngineObject.Position, entity.EngineObject.Forward.normalized);
								bool flag12 = Mathf.Abs(num2) > arg.mAIArgWidth / 2f;
								if (!flag12)
								{
									Vector3 vector = Quaternion.Euler(new Vector3(0f, 90f, 0f)) * entity.EngineObject.Position.normalized;
									num2 = Vector3.Dot(xentity.EngineObject.Position - entity.EngineObject.Position, vector);
									bool flag13 = Mathf.Abs(num2) > arg.mAIArgLength / 2f;
									if (!flag13)
									{
										return true;
									}
								}
							}
						}
					}
					IL_234:;
				}
				result = false;
			}
			return result;
		}

		public void TickKillAll(object obj)
		{
			bool flag = obj as string == "stop";
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._kill_timer_token);
				this._kill_timer_token = 0U;
			}
			else
			{
				bool flag2 = this._kill_timer_token > 0U;
				if (flag2)
				{
					XSingleton<XTimerMgr>.singleton.KillTimer(this._kill_timer_token);
					this._kill_timer_token = 0U;
				}
				RpcC2G_GMCommand rpcC2G_GMCommand = new RpcC2G_GMCommand();
				rpcC2G_GMCommand.oArg.cmd = "killall";
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GMCommand);
				this._kill_timer_token = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(this.TickKillAll), "continue");
			}
		}

		public bool AIDoodad(int doodadid, int waveid, Vector3 pos, float randompos, float delaytime)
		{
			return true;
		}

		private XTimerMgr.ElapsedEventHandler _delayRunScriptCb = null;

		private uint _kill_timer_token = 0U;
	}
}

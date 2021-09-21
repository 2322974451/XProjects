using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B03 RID: 2819
	internal class XAITarget : XSingleton<XAITarget>
	{
		// Token: 0x0600A636 RID: 42550 RVA: 0x001D27B0 File Offset: 0x001D09B0
		private int SortEnemy(XEntity a, XEntity b)
		{
			bool flag = a == null || b == null;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				bool flag2 = a.Attributes == null || b.Attributes == null;
				if (flag2)
				{
					result = 0;
				}
				else
				{
					int value = 0;
					XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(a.Attributes.TypeID);
					bool flag3 = byID != null;
					if (flag3)
					{
						value = (int)byID.aihit;
					}
					int num = 0;
					XEntityStatistics.RowData byID2 = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(b.Attributes.TypeID);
					bool flag4 = byID2 != null;
					if (flag4)
					{
						num = (int)byID2.aihit;
					}
					result = num.CompareTo(value);
				}
			}
			return result;
		}

		// Token: 0x0600A637 RID: 42551 RVA: 0x001D2860 File Offset: 0x001D0A60
		public bool ResetTargets(XEntity entity)
		{
			List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(entity);
			entity.AI.ClearTargets();
			for (int i = 0; i < opponent.Count; i++)
			{
				bool flag = XEntity.ValideEntity(opponent[i]);
				if (flag)
				{
					entity.AI.AddTarget(opponent[i]);
				}
			}
			bool flag2 = entity.AI.TargetsCount == 0;
			bool result;
			if (flag2)
			{
				entity.AI.IsFighting = false;
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600A638 RID: 42552 RVA: 0x001D28F0 File Offset: 0x001D0AF0
		public bool FindTargetByDistance(XEntity entity, float dist, bool filterImmortal, float angle, float delta, int targettype)
		{
			bool flag = !this.ResetTargets(entity);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = entity.AI.TargetsCount == 0;
				if (flag2)
				{
					entity.AI.IsFighting = false;
					result = false;
				}
				else
				{
					List<XEntity> list = ListPool<XEntity>.Get();
					entity.AI.SortTarget(new Comparison<XEntity>(this.SortEnemy));
					for (int i = 0; i < entity.AI.TargetsCount; i++)
					{
						XEntity target = entity.AI.GetTarget(i);
						bool flag3 = XEntity.ValideEntity(target);
						if (flag3)
						{
							Vector3 position = target.EngineObject.Position;
							Vector3 position2 = entity.EngineObject.Position;
							float magnitude = (position - position2).magnitude;
							bool flag4 = magnitude < dist;
							if (flag4)
							{
								bool flag5 = !filterImmortal || target.Buffs == null || !target.Buffs.IsBuffStateOn(XBuffType.XBuffType_Immortal);
								if (flag5)
								{
									bool flag6 = angle < 180f && angle > 0f;
									if (flag6)
									{
										Vector3 vector = target.EngineObject.Position - entity.EngineObject.Position;
										float num = Vector3.Angle(vector, entity.EngineObject.Forward);
										bool flag7 = num < angle;
										if (flag7)
										{
											bool flag8 = targettype == 0 || targettype == 2;
											if (flag8)
											{
												list.Add(target);
											}
										}
									}
									else
									{
										bool flag9 = targettype == 0 || targettype == 2;
										if (flag9)
										{
											list.Add(target);
										}
									}
								}
							}
						}
					}
					entity.AI.Copy2Target(list);
					ListPool<XEntity>.Release(list);
					bool flag10 = entity.AI.TargetsCount == 0;
					if (flag10)
					{
						entity.AI.IsFighting = false;
						result = false;
					}
					else
					{
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x0600A639 RID: 42553 RVA: 0x001D2AE0 File Offset: 0x001D0CE0
		public bool FindTargetByHitLevel(XEntity entity, bool filterImmortal)
		{
			this.ResetTargets(entity);
			bool flag = entity.AI.TargetsCount == 0;
			bool result;
			if (flag)
			{
				entity.AI.IsFighting = false;
				result = false;
			}
			else
			{
				List<XEntity> list = ListPool<XEntity>.Get();
				entity.AI.SortTarget(new Comparison<XEntity>(this.SortEnemy));
				int num = -1;
				int i = 0;
				while (i < entity.AI.TargetsCount)
				{
					XEntity target = entity.AI.GetTarget(i);
					bool flag2 = XEntity.ValideEntity(target);
					if (flag2)
					{
						bool syncMode = XSingleton<XGame>.singleton.SyncMode;
						bool flag3;
						if (syncMode)
						{
							flag3 = target.IsServerFighting;
						}
						else
						{
							flag3 = (target.IsFighting || !target.HasAI);
						}
						bool flag4 = !flag3;
						if (!flag4)
						{
							bool flag5 = !filterImmortal || target.Buffs == null || !XSingleton<XAIGeneralMgr>.singleton.IsTargetEntityImmortal(target);
							if (flag5)
							{
								XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(target.Attributes.TypeID);
								bool flag6 = byID != null;
								if (flag6)
								{
									num = (int)byID.aihit;
									break;
								}
							}
						}
					}
					IL_117:
					i++;
					continue;
					goto IL_117;
				}
				int j = 0;
				while (j < entity.AI.TargetsCount)
				{
					XEntity target2 = entity.AI.GetTarget(j);
					bool flag7 = XEntity.ValideEntity(target2);
					if (flag7)
					{
						bool syncMode2 = XSingleton<XGame>.singleton.SyncMode;
						bool flag8;
						if (syncMode2)
						{
							flag8 = target2.IsServerFighting;
						}
						else
						{
							flag8 = (target2.IsFighting || !target2.HasAI);
						}
						bool flag9 = !flag8;
						if (!flag9)
						{
							Vector3 position = target2.EngineObject.Position;
							Vector3 position2 = entity.EngineObject.Position;
							float magnitude = (position - position2).magnitude;
							int num2 = -1;
							XEntityStatistics.RowData byID2 = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(target2.Attributes.TypeID);
							bool flag10 = byID2 != null;
							if (flag10)
							{
								num2 = (int)byID2.aihit;
							}
							bool flag11 = num2 == num && num2 >= 0;
							if (flag11)
							{
								bool flag12 = !filterImmortal || target2.Buffs == null || !XSingleton<XAIGeneralMgr>.singleton.IsTargetEntityImmortal(target2);
								if (flag12)
								{
									list.Add(target2);
								}
							}
						}
					}
					IL_250:
					j++;
					continue;
					goto IL_250;
				}
				bool flag13 = list.Count == 0 && filterImmortal;
				if (flag13)
				{
					for (int k = 0; k < entity.AI.TargetsCount; k++)
					{
						XEntity target3 = entity.AI.GetTarget(k);
						XEntityStatistics.RowData byID3 = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(target3.Attributes.TypeID);
						bool flag14 = byID3.aihit >= 0 && XSingleton<XAIGeneralMgr>.singleton.IsTargetEntityImmortal(target3) && (target3.IsFighting || target3.IsServerFighting);
						if (flag14)
						{
							list.Add(target3);
						}
					}
				}
				entity.AI.Copy2Target(list);
				ListPool<XEntity>.Release(list);
				bool flag15 = entity.AI.TargetsCount == 0;
				if (flag15)
				{
					entity.AI.IsFighting = false;
					result = false;
				}
				else
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600A63A RID: 42554 RVA: 0x001D2E40 File Offset: 0x001D1040
		public bool FindTargetByHartedList(XEntity entity, bool filterImmortal)
		{
			List<XEntity> hateEntity = entity.AI.EnmityList.GetHateEntity(filterImmortal);
			bool flag = hateEntity.Count == 0;
			bool result;
			if (flag)
			{
				entity.AI.IsFighting = false;
				result = false;
			}
			else
			{
				entity.AI.Copy2Target(hateEntity);
				result = true;
			}
			return result;
		}

		// Token: 0x0600A63B RID: 42555 RVA: 0x001D2E94 File Offset: 0x001D1094
		public bool FindTargetByNonImmortal(XEntity entity)
		{
			return true;
		}

		// Token: 0x0600A63C RID: 42556 RVA: 0x001D2EA8 File Offset: 0x001D10A8
		public bool DoSelectNearest(XEntity entity)
		{
			bool flag = entity.AI.TargetsCount == 0;
			bool result;
			if (flag)
			{
				entity.AI.SetTarget(null);
				entity.AI.IsFighting = false;
				result = false;
			}
			else
			{
				float num = float.MaxValue;
				XEntity target = entity.AI.GetTarget(0);
				for (int i = 0; i < entity.AI.TargetsCount; i++)
				{
					XEntity target2 = entity.AI.GetTarget(i);
					float magnitude = (target2.EngineObject.Position - entity.EngineObject.Position).magnitude;
					bool flag2 = magnitude < num;
					if (flag2)
					{
						num = magnitude;
						target = target2;
					}
				}
				entity.AI.SetTarget(target);
				bool flag3 = !entity.AI.IsFighting;
				if (flag3)
				{
					XAIEnterFightEventArgs @event = XEventPool<XAIEnterFightEventArgs>.GetEvent();
					@event.Firer = entity;
					@event.Target = target;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
				entity.AI.IsFighting = true;
				result = true;
			}
			return result;
		}

		// Token: 0x0600A63D RID: 42557 RVA: 0x001D2FC4 File Offset: 0x001D11C4
		public bool DoSelectFarthest(XEntity entity)
		{
			bool flag = entity.AI.TargetsCount == 0;
			bool result;
			if (flag)
			{
				entity.AI.SetTarget(null);
				entity.AI.IsFighting = false;
				result = false;
			}
			else
			{
				float num = 0f;
				XEntity target = entity.AI.GetTarget(0);
				for (int i = 0; i < entity.AI.TargetsCount; i++)
				{
					XEntity target2 = entity.AI.GetTarget(i);
					float magnitude = (target2.EngineObject.Position - entity.EngineObject.Position).magnitude;
					bool flag2 = magnitude > num;
					if (flag2)
					{
						num = magnitude;
						target = target2;
					}
				}
				entity.AI.SetTarget(target);
				bool flag3 = !entity.AI.IsFighting;
				if (flag3)
				{
					XAIEnterFightEventArgs @event = XEventPool<XAIEnterFightEventArgs>.GetEvent();
					@event.Firer = entity;
					@event.Target = target;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
				entity.AI.IsFighting = true;
				result = true;
			}
			return result;
		}

		// Token: 0x0600A63E RID: 42558 RVA: 0x001D30E0 File Offset: 0x001D12E0
		public bool DoSelectRandom(XEntity entity)
		{
			bool flag = entity.AI.TargetsCount == 0;
			bool result;
			if (flag)
			{
				entity.AI.SetTarget(null);
				entity.AI.IsFighting = false;
				result = false;
			}
			else
			{
				int index = XSingleton<XCommon>.singleton.RandomInt(0, entity.AI.TargetsCount);
				XEntity target = entity.AI.GetTarget(index);
				entity.AI.SetTarget(target);
				bool flag2 = !entity.AI.IsFighting;
				if (flag2)
				{
					XAIEnterFightEventArgs @event = XEventPool<XAIEnterFightEventArgs>.GetEvent();
					@event.Firer = entity;
					@event.Target = target;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
				entity.AI.IsFighting = true;
				result = true;
			}
			return result;
		}

		// Token: 0x0600A63F RID: 42559 RVA: 0x001D31A0 File Offset: 0x001D13A0
		public XGameObject SelectMoveTargetById(XEntity entity, int objectid)
		{
			List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(XSingleton<XEntityMgr>.singleton.Player);
			float num = float.MaxValue;
			XGameObject result = null;
			for (int i = 0; i < opponent.Count; i++)
			{
				bool flag = (ulong)opponent[i].Attributes.TypeID == (ulong)((long)objectid);
				if (flag)
				{
					XGameObject engineObject = opponent[i].EngineObject;
					float magnitude = (entity.EngineObject.Position - engineObject.Position).magnitude;
					bool flag2 = magnitude < num;
					if (flag2)
					{
						num = magnitude;
						result = engineObject;
					}
				}
			}
			return result;
		}

		// Token: 0x0600A640 RID: 42560 RVA: 0x001D324C File Offset: 0x001D144C
		public Transform SelectDoodaTarget(XEntity entity, XDoodadType type)
		{
			List<GameObject> doodadsInScene = XSingleton<XLevelDoodadMgr>.singleton.GetDoodadsInScene(type);
			bool flag = doodadsInScene.Count == 0;
			Transform result;
			if (flag)
			{
				result = null;
			}
			else
			{
				float num = 999999f;
				int num2 = -1;
				for (int i = 0; i < doodadsInScene.Count; i++)
				{
					bool flag2 = doodadsInScene[i] == null;
					if (!flag2)
					{
						float magnitude = (doodadsInScene[i].transform.position - entity.EngineObject.Position).magnitude;
						bool flag3 = magnitude < num;
						if (flag3)
						{
							num = magnitude;
							num2 = i;
						}
					}
				}
				bool flag4 = num2 == -1;
				if (flag4)
				{
					result = null;
				}
				else
				{
					result = doodadsInScene[num2].transform;
				}
			}
			return result;
		}

		// Token: 0x0600A641 RID: 42561 RVA: 0x001D3318 File Offset: 0x001D1518
		public Transform SelectItemTarget(XEntity entity)
		{
			return XSingleton<XAITarget>.singleton.SelectDoodaTarget(entity, XDoodadType.Item);
		}

		// Token: 0x0600A642 RID: 42562 RVA: 0x001D3338 File Offset: 0x001D1538
		public bool SelectTargetBySkillCircle(XEntity entity)
		{
			bool flag = !entity.IsPlayer;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XPlayer xplayer = entity as XPlayer;
				bool flag2 = xplayer == null || xplayer.TargetLocated == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = xplayer.TargetLocated.Target != null;
					if (flag3)
					{
						entity.AI.ClearTargets();
						entity.AI.AddTarget(xplayer.TargetLocated.Target);
						entity.AI.SetTarget(xplayer.TargetLocated.Target);
						result = true;
					}
					else
					{
						entity.AI.SetTarget(null);
						result = false;
					}
				}
			}
			return result;
		}

		// Token: 0x0600A643 RID: 42563 RVA: 0x001D33E0 File Offset: 0x001D15E0
		public bool ResetHartedList(XEntity entity)
		{
			entity.AI.EnmityList.Reset();
			entity.AI.SetTarget(null);
			return true;
		}
	}
}

using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XAIGeneralMgr : XSingleton<XAIGeneralMgr>, IXAIGeneralMgr, IXInterface
	{

		public bool Deprecated { get; set; }

		public void InitAIMgr()
		{
			bool flag = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXAIGeneralMgr>(XSingleton<XCommon>.singleton.XHash("XAIGeneralMgr")) == null;
			if (flag)
			{
				XSingleton<XInterfaceMgr>.singleton.AttachInterface<IXAIGeneralMgr>(XSingleton<XCommon>.singleton.XHash("XAIGeneralMgr"), this);
			}
		}

		public bool IsAtState(GameObject go, int state)
		{
			return this.IsAtState(ulong.Parse(go.transform.name), state);
		}

		public bool IsAtState(ulong id, int state)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.CurState == (XStateDefine)state;
		}

		public bool IsRotate(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.Rotate.Enabled;
		}

		public bool IsCastSkill(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.AI.IsCastingSkill;
		}

		public bool IsWoozy(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.AI.IsAtWoozyState();
		}

		public bool IsValid(ulong id)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			return XEntity.ValideEntity(entity);
		}

		public bool IsValid(Transform transform)
		{
			bool flag = transform == null;
			return !flag && this.IsValid(ulong.Parse(transform.name));
		}

		public bool IsHPValue(ulong id, int min, int max)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = !XEntity.ValideEntity(entity);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int num = (int)(100.0 * entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic) / entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total));
				bool flag2 = max == 0 || (num >= min && num <= max);
				result = flag2;
			}
			return result;
		}

		public bool IsHPValue(Transform transform, int min, int max)
		{
			return this.IsHPValue(ulong.Parse(transform.name), min, max);
		}

		public bool IsMPValue(ulong id, int min, int max)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = !XEntity.ValideEntity(entity);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int num = (int)(100.0 * entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentMP_Basic) / entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentMP_Total));
				bool flag2 = max == 0 || (num >= min && num <= max);
				result = flag2;
			}
			return result;
		}

		public bool IsMPValue(Transform transform, int min, int max)
		{
			return this.IsMPValue(ulong.Parse(transform.name), min, max);
		}

		public bool IsFPValue(ulong id, int min, int max)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = !XEntity.ValideEntity(entity);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int num = (int)entity.Attributes.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic);
				bool flag2 = max == 0 || (num >= min && num <= max);
				result = flag2;
			}
			return result;
		}

		public bool IsFPValue(Transform transform, int min, int max)
		{
			return this.IsFPValue(ulong.Parse(transform.name), min, max);
		}

		public bool IsFighting(ulong id)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.AI.IsFighting;
		}

		public bool IsFighting(Transform transform)
		{
			return this.IsFighting(ulong.Parse(transform.name));
		}

		public bool IsOppoCastingSkill(ulong id)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.AI.IsOppoCastingSkill;
		}

		public bool IsOppoCastingSkill(Transform transform)
		{
			return this.IsOppoCastingSkill(ulong.Parse(transform.name));
		}

		public bool IsHurtOppo(ulong id)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.AI.IsHurtOppo;
		}

		public bool IsHurtOppo(Transform transform)
		{
			return this.IsHurtOppo(ulong.Parse(transform.name));
		}

		public bool IsFixedInCd(ulong id)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.AI.IsFixedInCd;
		}

		public bool IsFixedInCd(Transform transform)
		{
			return this.IsFixedInCd(ulong.Parse(transform.name));
		}

		public bool IsWander(ulong id)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.AI.IsWander;
		}

		public bool IsWander(Transform transform)
		{
			return this.IsWander(ulong.Parse(transform.name));
		}

		public bool IsSkillChoosed(ulong id)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.AI.CanCastSkillCount == 1;
		}

		public bool IsSkillChoosed(Transform transform)
		{
			return this.IsSkillChoosed(ulong.Parse(transform.name));
		}

		public void ClearTarget(ulong id)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = entity == null || entity.AI == null;
			if (!flag)
			{
				entity.AI.SetTarget(null);
			}
		}

		public void ClearTarget(Transform transform)
		{
			this.ClearTarget(ulong.Parse(transform.name));
		}

		public bool HasQTE(ulong id, int QTEState)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			return this.HasQTE(entity, QTEState);
		}

		public bool HasQTE(GameObject go, int QTEState)
		{
			return this.HasQTE(ulong.Parse(go.transform.name), QTEState);
		}

		private bool HasQTE(XEntity entity, int QTEState)
		{
			bool flag = entity == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = entity.QTE == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = QTEState == 1000;
					if (flag3)
					{
						result = entity.QTE.IsInAnyState();
					}
					else
					{
						result = entity.QTE.IsInState((uint)QTEState);
					}
				}
			}
			return result;
		}

		public bool DetectEnimyInSight(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAIDataRelated>.singleton.DetectEnimyInSight(entity);
		}

		public bool ResetTargets(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.ResetTargets(entity);
		}

		public bool FindTargetByDistance(GameObject go, float distance, bool filterImmortal, float angle, float delta, int targettype)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.FindTargetByDistance(entity, distance, filterImmortal, angle, delta, targettype);
		}

		public bool FindTargetByHitLevel(GameObject go, bool filterImmortal)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.FindTargetByHitLevel(entity, filterImmortal);
		}

		public bool FindTargetByHartedList(GameObject go, bool filterImmortal)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.FindTargetByHartedList(entity, filterImmortal);
		}

		public bool FindTargetByNonImmortal(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.FindTargetByNonImmortal(entity);
		}

		public bool DoSelectNearest(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.DoSelectNearest(entity);
		}

		public bool DoSelectFarthest(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.DoSelectFarthest(entity);
		}

		public bool DoSelectRandomTarget(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.DoSelectRandom(entity);
		}

		public bool SelectTargetBySkillCircle(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.SelectTargetBySkillCircle(entity);
		}

		public bool ResetHartedList(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.ResetHartedList(entity);
		}

		public bool CastQTESkill(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAISkill>.singleton.CastQTESkill(entity);
		}

		public bool CastDashSkill(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAISkill>.singleton.CastQTESkill(entity);
		}

		public bool TryCastPhysicalSkill(GameObject go, GameObject targetgo)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			XEntity entity2 = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(targetgo.transform.name));
			return XSingleton<XAISkill>.singleton.TryCastPhysicalSkill(entity, entity2);
		}

		public bool TryCastInstallSkill(GameObject go, GameObject targetgo)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			XEntity entity2 = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(targetgo.transform.name));
			return XSingleton<XAISkill>.singleton.TryCastInstallSkill(entity, entity2);
		}

		public bool TryCastLearnedSkill(GameObject go, GameObject targetgo)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			XEntity entity2 = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(targetgo.transform.name));
			return XSingleton<XAISkill>.singleton.TryCastLearnedSkill(entity, entity2);
		}

		public bool SelectSkill(GameObject go, FilterSkillArg skillarg)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			XEntity target = null;
			bool flag = skillarg.mAIArgTarget != null;
			if (flag)
			{
				target = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(skillarg.mAIArgTarget.name));
			}
			return XSingleton<XAISkill>.singleton.SelectSkill(entity, target, skillarg);
		}

		public bool DoSelectInOrder(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAISkill>.singleton.DoSelectInOrder(entity);
		}

		public bool DoSelectRandom(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAISkill>.singleton.DoSelectRandom(entity);
		}

		public bool DoCastSkill(GameObject go, GameObject targetgo)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			XEntity target = null;
			bool flag = targetgo != null;
			if (flag)
			{
				target = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(targetgo.transform.name));
			}
			return XSingleton<XAISkill>.singleton.DoCastSkill(entity, target);
		}

		public bool NavToTarget(ulong id, GameObject target)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = entity == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = target != null;
				result = (flag2 && XSingleton<XAIMove>.singleton.NavToTarget(entity, target.transform.position, entity.AI.MoveSpeed));
			}
			return result;
		}

		public bool NavToTarget(GameObject go, GameObject target)
		{
			return this.NavToTarget(ulong.Parse(go.transform.name), target);
		}

		public bool FindNavPath(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAIMove>.singleton.FindNavPath(entity);
		}

		public bool ActionMove(GameObject go, Vector3 dir, Vector3 dest, float speedratio)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAIMove>.singleton.ActionMove(entity, dir, dest, speedratio);
		}

		public bool ActionNav(ulong id, Vector3 dest)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			return XSingleton<XAIMove>.singleton.ActionNav(entity, dest, 1f);
		}

		public bool ActionNav(GameObject go, Vector3 dest)
		{
			return this.ActionNav(ulong.Parse(go.transform.name), dest);
		}

		public bool ActionRotate(GameObject go, float degree, float speed, int type)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAIMove>.singleton.ActionRotate(entity, degree, speed, type);
		}

		public bool RotateToTarget(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAIMove>.singleton.RotateToTarget(entity);
		}

		public bool Shout(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAIOtherActions>.singleton.Shout(entity);
		}

		public string ReceiveAIEvent(GameObject go, int msgType, bool Deprecate)
		{
			XEntity xentity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			bool flag = xentity == null;
			if (flag)
			{
				bool flag2 = XSingleton<XLevelSpawnMgr>.singleton.AIGlobal != null && go.transform.name == XSingleton<XLevelSpawnMgr>.singleton.AIGlobal.Host.EngineObject.Name;
				if (flag2)
				{
					xentity = XSingleton<XLevelSpawnMgr>.singleton.AIGlobal.Host;
				}
			}
			return XSingleton<XAIOtherActions>.singleton.ReceiveAIEvent(xentity, msgType, Deprecate);
		}

		public bool SendAIEvent(GameObject go, int msgto, int msgtype, int entitytypeid, string msgarg, float delaytime, Vector3 pos)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAIOtherActions>.singleton.SendAIEvent(entity, msgto, msgtype, entitytypeid, msgarg, pos, delaytime);
		}

		public bool IsTargetImmortal(ulong id)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			return this.IsTargetEntityImmortal(entity);
		}

		public bool IsTargetEntityImmortal(XEntity theHost)
		{
			bool flag = theHost == null || theHost.Buffs == null;
			return !flag && theHost.Buffs.IsBuffStateOn(XBuffType.XBuffType_Immortal);
		}

		public Transform SelectMoveTargetById(GameObject go, int objectid)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			XGameObject xgameObject = XSingleton<XAITarget>.singleton.SelectMoveTargetById(entity, objectid);
			return xgameObject.Find("");
		}

		public Transform SelectBuffTarget(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.SelectDoodaTarget(entity, XDoodadType.Buff);
		}

		public Transform SelectItemTarget(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.SelectDoodaTarget(entity, XDoodadType.Item);
		}

		public bool CallMonster(GameObject go, CallMonsterData data)
		{
			XEntity xentity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			bool flag = xentity == null;
			if (flag)
			{
				bool flag2 = go.transform.name == "0";
				if (!flag2)
				{
					return false;
				}
				xentity = XSingleton<XLevelSpawnMgr>.singleton.AIGlobal.Host;
			}
			return XSingleton<XAIOtherActions>.singleton.CallMonster(xentity, data);
		}

		public bool CallScript(GameObject go, string script, float delaytime)
		{
			return XSingleton<XAIOtherActions>.singleton.CallScript(script, delaytime);
		}

		public bool AddBuff(int monsterid, int buffid, int buffid2)
		{
			return XSingleton<XAIOtherActions>.singleton.AddBuff(monsterid, buffid, buffid2);
		}

		public void RunSubTree(GameObject go, string treename)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			entity.AI.OnTickSubTree(treename);
		}

		public bool PlayFx(GameObject go, string fxname, Vector3 fxpos, float delaytime)
		{
			return XSingleton<XAIOtherActions>.singleton.PlayFx(fxname, fxpos, delaytime);
		}

		public bool StopCastingSkill(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAISkill>.singleton.StopCastingSkill(entity);
		}

		public bool DetectEnemyInRange(GameObject go, ref DetectEnemyInRangeArg arg)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAIOtherActions>.singleton.DetectEnemyInRange(entity, ref arg);
		}

		public void EnablePlayerAI(bool enable)
		{
			XAIEnableAI @event = XEventPool<XAIEnableAI>.GetEvent();
			@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
			@event.Enable = enable;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		public bool UpdateNavigation(GameObject go, int dir, int oldDir)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAIMove>.singleton.UpdateNavigation(entity, dir, oldDir);
		}

		public int GetPlayerProf()
		{
			return (int)XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.Profession;
		}

		public bool IsPointInMap(Vector3 pos)
		{
			return XSingleton<XAIMove>.singleton.IsPointInMap(pos);
		}

		public bool AIDoodad(GameObject go, int doodadid, int waveid, Vector3 pos, float randompos, float delaytime)
		{
			return XSingleton<XAIOtherActions>.singleton.AIDoodad(doodadid, waveid, pos, randompos, delaytime);
		}
	}
}

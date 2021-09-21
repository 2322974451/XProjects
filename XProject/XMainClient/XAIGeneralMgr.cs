using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B96 RID: 2966
	internal class XAIGeneralMgr : XSingleton<XAIGeneralMgr>, IXAIGeneralMgr, IXInterface
	{
		// Token: 0x1700303B RID: 12347
		// (get) Token: 0x0600A9E6 RID: 43494 RVA: 0x001E4D74 File Offset: 0x001E2F74
		// (set) Token: 0x0600A9E7 RID: 43495 RVA: 0x001E4D7C File Offset: 0x001E2F7C
		public bool Deprecated { get; set; }

		// Token: 0x0600A9E8 RID: 43496 RVA: 0x001E4D88 File Offset: 0x001E2F88
		public void InitAIMgr()
		{
			bool flag = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXAIGeneralMgr>(XSingleton<XCommon>.singleton.XHash("XAIGeneralMgr")) == null;
			if (flag)
			{
				XSingleton<XInterfaceMgr>.singleton.AttachInterface<IXAIGeneralMgr>(XSingleton<XCommon>.singleton.XHash("XAIGeneralMgr"), this);
			}
		}

		// Token: 0x0600A9E9 RID: 43497 RVA: 0x001E4DD4 File Offset: 0x001E2FD4
		public bool IsAtState(GameObject go, int state)
		{
			return this.IsAtState(ulong.Parse(go.transform.name), state);
		}

		// Token: 0x0600A9EA RID: 43498 RVA: 0x001E4E00 File Offset: 0x001E3000
		public bool IsAtState(ulong id, int state)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.CurState == (XStateDefine)state;
		}

		// Token: 0x0600A9EB RID: 43499 RVA: 0x001E4E38 File Offset: 0x001E3038
		public bool IsRotate(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.Rotate.Enabled;
		}

		// Token: 0x0600A9EC RID: 43500 RVA: 0x001E4E84 File Offset: 0x001E3084
		public bool IsCastSkill(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.AI.IsCastingSkill;
		}

		// Token: 0x0600A9ED RID: 43501 RVA: 0x001E4ED0 File Offset: 0x001E30D0
		public bool IsWoozy(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.AI.IsAtWoozyState();
		}

		// Token: 0x0600A9EE RID: 43502 RVA: 0x001E4F1C File Offset: 0x001E311C
		public bool IsValid(ulong id)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			return XEntity.ValideEntity(entity);
		}

		// Token: 0x0600A9EF RID: 43503 RVA: 0x001E4F40 File Offset: 0x001E3140
		public bool IsValid(Transform transform)
		{
			bool flag = transform == null;
			return !flag && this.IsValid(ulong.Parse(transform.name));
		}

		// Token: 0x0600A9F0 RID: 43504 RVA: 0x001E4F74 File Offset: 0x001E3174
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

		// Token: 0x0600A9F1 RID: 43505 RVA: 0x001E4FEC File Offset: 0x001E31EC
		public bool IsHPValue(Transform transform, int min, int max)
		{
			return this.IsHPValue(ulong.Parse(transform.name), min, max);
		}

		// Token: 0x0600A9F2 RID: 43506 RVA: 0x001E5014 File Offset: 0x001E3214
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

		// Token: 0x0600A9F3 RID: 43507 RVA: 0x001E508C File Offset: 0x001E328C
		public bool IsMPValue(Transform transform, int min, int max)
		{
			return this.IsMPValue(ulong.Parse(transform.name), min, max);
		}

		// Token: 0x0600A9F4 RID: 43508 RVA: 0x001E50B4 File Offset: 0x001E32B4
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

		// Token: 0x0600A9F5 RID: 43509 RVA: 0x001E5114 File Offset: 0x001E3314
		public bool IsFPValue(Transform transform, int min, int max)
		{
			return this.IsFPValue(ulong.Parse(transform.name), min, max);
		}

		// Token: 0x0600A9F6 RID: 43510 RVA: 0x001E513C File Offset: 0x001E333C
		public bool IsFighting(ulong id)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.AI.IsFighting;
		}

		// Token: 0x0600A9F7 RID: 43511 RVA: 0x001E5178 File Offset: 0x001E3378
		public bool IsFighting(Transform transform)
		{
			return this.IsFighting(ulong.Parse(transform.name));
		}

		// Token: 0x0600A9F8 RID: 43512 RVA: 0x001E519C File Offset: 0x001E339C
		public bool IsOppoCastingSkill(ulong id)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.AI.IsOppoCastingSkill;
		}

		// Token: 0x0600A9F9 RID: 43513 RVA: 0x001E51D8 File Offset: 0x001E33D8
		public bool IsOppoCastingSkill(Transform transform)
		{
			return this.IsOppoCastingSkill(ulong.Parse(transform.name));
		}

		// Token: 0x0600A9FA RID: 43514 RVA: 0x001E51FC File Offset: 0x001E33FC
		public bool IsHurtOppo(ulong id)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.AI.IsHurtOppo;
		}

		// Token: 0x0600A9FB RID: 43515 RVA: 0x001E5238 File Offset: 0x001E3438
		public bool IsHurtOppo(Transform transform)
		{
			return this.IsHurtOppo(ulong.Parse(transform.name));
		}

		// Token: 0x0600A9FC RID: 43516 RVA: 0x001E525C File Offset: 0x001E345C
		public bool IsFixedInCd(ulong id)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.AI.IsFixedInCd;
		}

		// Token: 0x0600A9FD RID: 43517 RVA: 0x001E5298 File Offset: 0x001E3498
		public bool IsFixedInCd(Transform transform)
		{
			return this.IsFixedInCd(ulong.Parse(transform.name));
		}

		// Token: 0x0600A9FE RID: 43518 RVA: 0x001E52BC File Offset: 0x001E34BC
		public bool IsWander(ulong id)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.AI.IsWander;
		}

		// Token: 0x0600A9FF RID: 43519 RVA: 0x001E52F8 File Offset: 0x001E34F8
		public bool IsWander(Transform transform)
		{
			return this.IsWander(ulong.Parse(transform.name));
		}

		// Token: 0x0600AA00 RID: 43520 RVA: 0x001E531C File Offset: 0x001E351C
		public bool IsSkillChoosed(ulong id)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = !XEntity.ValideEntity(entity);
			return !flag && entity.AI.CanCastSkillCount == 1;
		}

		// Token: 0x0600AA01 RID: 43521 RVA: 0x001E535C File Offset: 0x001E355C
		public bool IsSkillChoosed(Transform transform)
		{
			return this.IsSkillChoosed(ulong.Parse(transform.name));
		}

		// Token: 0x0600AA02 RID: 43522 RVA: 0x001E5380 File Offset: 0x001E3580
		public void ClearTarget(ulong id)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = entity == null || entity.AI == null;
			if (!flag)
			{
				entity.AI.SetTarget(null);
			}
		}

		// Token: 0x0600AA03 RID: 43523 RVA: 0x001E53BC File Offset: 0x001E35BC
		public void ClearTarget(Transform transform)
		{
			this.ClearTarget(ulong.Parse(transform.name));
		}

		// Token: 0x0600AA04 RID: 43524 RVA: 0x001E53D4 File Offset: 0x001E35D4
		public bool HasQTE(ulong id, int QTEState)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			return this.HasQTE(entity, QTEState);
		}

		// Token: 0x0600AA05 RID: 43525 RVA: 0x001E53FC File Offset: 0x001E35FC
		public bool HasQTE(GameObject go, int QTEState)
		{
			return this.HasQTE(ulong.Parse(go.transform.name), QTEState);
		}

		// Token: 0x0600AA06 RID: 43526 RVA: 0x001E5428 File Offset: 0x001E3628
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

		// Token: 0x0600AA07 RID: 43527 RVA: 0x001E5480 File Offset: 0x001E3680
		public bool DetectEnimyInSight(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAIDataRelated>.singleton.DetectEnimyInSight(entity);
		}

		// Token: 0x0600AA08 RID: 43528 RVA: 0x001E54B8 File Offset: 0x001E36B8
		public bool ResetTargets(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.ResetTargets(entity);
		}

		// Token: 0x0600AA09 RID: 43529 RVA: 0x001E54F0 File Offset: 0x001E36F0
		public bool FindTargetByDistance(GameObject go, float distance, bool filterImmortal, float angle, float delta, int targettype)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.FindTargetByDistance(entity, distance, filterImmortal, angle, delta, targettype);
		}

		// Token: 0x0600AA0A RID: 43530 RVA: 0x001E5530 File Offset: 0x001E3730
		public bool FindTargetByHitLevel(GameObject go, bool filterImmortal)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.FindTargetByHitLevel(entity, filterImmortal);
		}

		// Token: 0x0600AA0B RID: 43531 RVA: 0x001E556C File Offset: 0x001E376C
		public bool FindTargetByHartedList(GameObject go, bool filterImmortal)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.FindTargetByHartedList(entity, filterImmortal);
		}

		// Token: 0x0600AA0C RID: 43532 RVA: 0x001E55A8 File Offset: 0x001E37A8
		public bool FindTargetByNonImmortal(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.FindTargetByNonImmortal(entity);
		}

		// Token: 0x0600AA0D RID: 43533 RVA: 0x001E55E0 File Offset: 0x001E37E0
		public bool DoSelectNearest(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.DoSelectNearest(entity);
		}

		// Token: 0x0600AA0E RID: 43534 RVA: 0x001E5618 File Offset: 0x001E3818
		public bool DoSelectFarthest(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.DoSelectFarthest(entity);
		}

		// Token: 0x0600AA0F RID: 43535 RVA: 0x001E5650 File Offset: 0x001E3850
		public bool DoSelectRandomTarget(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.DoSelectRandom(entity);
		}

		// Token: 0x0600AA10 RID: 43536 RVA: 0x001E5688 File Offset: 0x001E3888
		public bool SelectTargetBySkillCircle(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.SelectTargetBySkillCircle(entity);
		}

		// Token: 0x0600AA11 RID: 43537 RVA: 0x001E56C0 File Offset: 0x001E38C0
		public bool ResetHartedList(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.ResetHartedList(entity);
		}

		// Token: 0x0600AA12 RID: 43538 RVA: 0x001E56F8 File Offset: 0x001E38F8
		public bool CastQTESkill(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAISkill>.singleton.CastQTESkill(entity);
		}

		// Token: 0x0600AA13 RID: 43539 RVA: 0x001E5730 File Offset: 0x001E3930
		public bool CastDashSkill(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAISkill>.singleton.CastQTESkill(entity);
		}

		// Token: 0x0600AA14 RID: 43540 RVA: 0x001E5768 File Offset: 0x001E3968
		public bool TryCastPhysicalSkill(GameObject go, GameObject targetgo)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			XEntity entity2 = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(targetgo.transform.name));
			return XSingleton<XAISkill>.singleton.TryCastPhysicalSkill(entity, entity2);
		}

		// Token: 0x0600AA15 RID: 43541 RVA: 0x001E57BC File Offset: 0x001E39BC
		public bool TryCastInstallSkill(GameObject go, GameObject targetgo)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			XEntity entity2 = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(targetgo.transform.name));
			return XSingleton<XAISkill>.singleton.TryCastInstallSkill(entity, entity2);
		}

		// Token: 0x0600AA16 RID: 43542 RVA: 0x001E5810 File Offset: 0x001E3A10
		public bool TryCastLearnedSkill(GameObject go, GameObject targetgo)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			XEntity entity2 = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(targetgo.transform.name));
			return XSingleton<XAISkill>.singleton.TryCastLearnedSkill(entity, entity2);
		}

		// Token: 0x0600AA17 RID: 43543 RVA: 0x001E5864 File Offset: 0x001E3A64
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

		// Token: 0x0600AA18 RID: 43544 RVA: 0x001E58CC File Offset: 0x001E3ACC
		public bool DoSelectInOrder(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAISkill>.singleton.DoSelectInOrder(entity);
		}

		// Token: 0x0600AA19 RID: 43545 RVA: 0x001E5904 File Offset: 0x001E3B04
		public bool DoSelectRandom(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAISkill>.singleton.DoSelectRandom(entity);
		}

		// Token: 0x0600AA1A RID: 43546 RVA: 0x001E593C File Offset: 0x001E3B3C
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

		// Token: 0x0600AA1B RID: 43547 RVA: 0x001E59A0 File Offset: 0x001E3BA0
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

		// Token: 0x0600AA1C RID: 43548 RVA: 0x001E59FC File Offset: 0x001E3BFC
		public bool NavToTarget(GameObject go, GameObject target)
		{
			return this.NavToTarget(ulong.Parse(go.transform.name), target);
		}

		// Token: 0x0600AA1D RID: 43549 RVA: 0x001E5A28 File Offset: 0x001E3C28
		public bool FindNavPath(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAIMove>.singleton.FindNavPath(entity);
		}

		// Token: 0x0600AA1E RID: 43550 RVA: 0x001E5A60 File Offset: 0x001E3C60
		public bool ActionMove(GameObject go, Vector3 dir, Vector3 dest, float speedratio)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAIMove>.singleton.ActionMove(entity, dir, dest, speedratio);
		}

		// Token: 0x0600AA1F RID: 43551 RVA: 0x001E5A9C File Offset: 0x001E3C9C
		public bool ActionNav(ulong id, Vector3 dest)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			return XSingleton<XAIMove>.singleton.ActionNav(entity, dest, 1f);
		}

		// Token: 0x0600AA20 RID: 43552 RVA: 0x001E5ACC File Offset: 0x001E3CCC
		public bool ActionNav(GameObject go, Vector3 dest)
		{
			return this.ActionNav(ulong.Parse(go.transform.name), dest);
		}

		// Token: 0x0600AA21 RID: 43553 RVA: 0x001E5AF8 File Offset: 0x001E3CF8
		public bool ActionRotate(GameObject go, float degree, float speed, int type)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAIMove>.singleton.ActionRotate(entity, degree, speed, type);
		}

		// Token: 0x0600AA22 RID: 43554 RVA: 0x001E5B34 File Offset: 0x001E3D34
		public bool RotateToTarget(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAIMove>.singleton.RotateToTarget(entity);
		}

		// Token: 0x0600AA23 RID: 43555 RVA: 0x001E5B6C File Offset: 0x001E3D6C
		public bool Shout(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAIOtherActions>.singleton.Shout(entity);
		}

		// Token: 0x0600AA24 RID: 43556 RVA: 0x001E5BA4 File Offset: 0x001E3DA4
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

		// Token: 0x0600AA25 RID: 43557 RVA: 0x001E5C34 File Offset: 0x001E3E34
		public bool SendAIEvent(GameObject go, int msgto, int msgtype, int entitytypeid, string msgarg, float delaytime, Vector3 pos)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAIOtherActions>.singleton.SendAIEvent(entity, msgto, msgtype, entitytypeid, msgarg, pos, delaytime);
		}

		// Token: 0x0600AA26 RID: 43558 RVA: 0x001E5C78 File Offset: 0x001E3E78
		public bool IsTargetImmortal(ulong id)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			return this.IsTargetEntityImmortal(entity);
		}

		// Token: 0x0600AA27 RID: 43559 RVA: 0x001E5CA0 File Offset: 0x001E3EA0
		public bool IsTargetEntityImmortal(XEntity theHost)
		{
			bool flag = theHost == null || theHost.Buffs == null;
			return !flag && theHost.Buffs.IsBuffStateOn(XBuffType.XBuffType_Immortal);
		}

		// Token: 0x0600AA28 RID: 43560 RVA: 0x001E5CD8 File Offset: 0x001E3ED8
		public Transform SelectMoveTargetById(GameObject go, int objectid)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			XGameObject xgameObject = XSingleton<XAITarget>.singleton.SelectMoveTargetById(entity, objectid);
			return xgameObject.Find("");
		}

		// Token: 0x0600AA29 RID: 43561 RVA: 0x001E5D20 File Offset: 0x001E3F20
		public Transform SelectBuffTarget(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.SelectDoodaTarget(entity, XDoodadType.Buff);
		}

		// Token: 0x0600AA2A RID: 43562 RVA: 0x001E5D5C File Offset: 0x001E3F5C
		public Transform SelectItemTarget(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAITarget>.singleton.SelectDoodaTarget(entity, XDoodadType.Item);
		}

		// Token: 0x0600AA2B RID: 43563 RVA: 0x001E5D98 File Offset: 0x001E3F98
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

		// Token: 0x0600AA2C RID: 43564 RVA: 0x001E5E0C File Offset: 0x001E400C
		public bool CallScript(GameObject go, string script, float delaytime)
		{
			return XSingleton<XAIOtherActions>.singleton.CallScript(script, delaytime);
		}

		// Token: 0x0600AA2D RID: 43565 RVA: 0x001E5E2C File Offset: 0x001E402C
		public bool AddBuff(int monsterid, int buffid, int buffid2)
		{
			return XSingleton<XAIOtherActions>.singleton.AddBuff(monsterid, buffid, buffid2);
		}

		// Token: 0x0600AA2E RID: 43566 RVA: 0x001E5E4C File Offset: 0x001E404C
		public void RunSubTree(GameObject go, string treename)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			entity.AI.OnTickSubTree(treename);
		}

		// Token: 0x0600AA2F RID: 43567 RVA: 0x001E5E84 File Offset: 0x001E4084
		public bool PlayFx(GameObject go, string fxname, Vector3 fxpos, float delaytime)
		{
			return XSingleton<XAIOtherActions>.singleton.PlayFx(fxname, fxpos, delaytime);
		}

		// Token: 0x0600AA30 RID: 43568 RVA: 0x001E5EA4 File Offset: 0x001E40A4
		public bool StopCastingSkill(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAISkill>.singleton.StopCastingSkill(entity);
		}

		// Token: 0x0600AA31 RID: 43569 RVA: 0x001E5EDC File Offset: 0x001E40DC
		public bool DetectEnemyInRange(GameObject go, ref DetectEnemyInRangeArg arg)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAIOtherActions>.singleton.DetectEnemyInRange(entity, ref arg);
		}

		// Token: 0x0600AA32 RID: 43570 RVA: 0x001E5F18 File Offset: 0x001E4118
		public void EnablePlayerAI(bool enable)
		{
			XAIEnableAI @event = XEventPool<XAIEnableAI>.GetEvent();
			@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
			@event.Enable = enable;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x0600AA33 RID: 43571 RVA: 0x001E5F50 File Offset: 0x001E4150
		public bool UpdateNavigation(GameObject go, int dir, int oldDir)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			return XSingleton<XAIMove>.singleton.UpdateNavigation(entity, dir, oldDir);
		}

		// Token: 0x0600AA34 RID: 43572 RVA: 0x001E5F8C File Offset: 0x001E418C
		public int GetPlayerProf()
		{
			return (int)XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.Profession;
		}

		// Token: 0x0600AA35 RID: 43573 RVA: 0x001E5FB4 File Offset: 0x001E41B4
		public bool IsPointInMap(Vector3 pos)
		{
			return XSingleton<XAIMove>.singleton.IsPointInMap(pos);
		}

		// Token: 0x0600AA36 RID: 43574 RVA: 0x001E5FD4 File Offset: 0x001E41D4
		public bool AIDoodad(GameObject go, int doodadid, int waveid, Vector3 pos, float randompos, float delaytime)
		{
			return XSingleton<XAIOtherActions>.singleton.AIDoodad(doodadid, waveid, pos, randompos, delaytime);
		}
	}
}

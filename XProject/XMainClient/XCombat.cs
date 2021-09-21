using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FF4 RID: 4084
	internal sealed class XCombat : XSingleton<XCombat>
	{
		// Token: 0x0600D461 RID: 54369 RVA: 0x00320070 File Offset: 0x0031E270
		public override bool Init()
		{
			bool flag = this._async_loader == null;
			if (flag)
			{
				this._async_loader = new XTableAsyncLoader();
				this._async_loader.AddTask("Table/CombatParamList", XCombat.oTable, false);
				this._async_loader.Execute(null);
			}
			bool flag2 = !this._async_loader.IsDone;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				XCombat.oAttackApplyStateHandlers = new List<AttackApplyState>();
				XCombat.oAttackApplyStateHandlers.Add(new AttackApplyCritical());
				XCombat.oAttackApplyStateHandlers.Add(new AttackApplyStun());
				this.PhysicalAvoidenceLimit = double.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("PhycialAvoidenceLimit"));
				this.MagicAvoidenceLimit = double.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("MagicAvoidenceLimit"));
				result = true;
			}
			return result;
		}

		// Token: 0x0600D462 RID: 54370 RVA: 0x00320135 File Offset: 0x0031E335
		public override void Uninit()
		{
			XCombat.oAttackApplyStateHandlers.Clear();
			this._async_loader = null;
		}

		// Token: 0x0600D463 RID: 54371 RVA: 0x0032014C File Offset: 0x0031E34C
		public double GetBaseCriticalProb(XAttributes attributes, double value)
		{
			bool flag = attributes == null;
			double result;
			if (flag)
			{
				result = 0.0;
			}
			else
			{
				CombatParamTable.RowData combatParam = XSingleton<XCombat>.singleton.GetCombatParam(attributes.Level);
				result = value / (value + (double)combatParam.CriticalBase);
			}
			return result;
		}

		// Token: 0x0600D464 RID: 54372 RVA: 0x00320190 File Offset: 0x0031E390
		public double GetCombatValue(int combatParam, double value)
		{
			return value / (value + (double)combatParam);
		}

		// Token: 0x0600D465 RID: 54373 RVA: 0x003201A8 File Offset: 0x0031E3A8
		public CombatParamTable.RowData GetCombatParam(uint Level)
		{
			bool flag = Level == 0U || (ulong)Level >= (ulong)((long)XCombat.oTable.Table.Length);
			CombatParamTable.RowData result;
			if (flag)
			{
				result = XCombat.oTable.Table[0];
			}
			else
			{
				result = XCombat.oTable.Table[(int)(Level - 1U)];
			}
			return result;
		}

		// Token: 0x0600D466 RID: 54374 RVA: 0x003201F8 File Offset: 0x0031E3F8
		public XAttributeDefine MapElementToAttrAttack(DamageElement de)
		{
			XAttributeDefine result;
			switch (de)
			{
			case DamageElement.DE_NONE:
				result = XAttributeDefine.XAttr_VoidAtk_Total;
				break;
			case DamageElement.DE_FIRE:
				result = XAttributeDefine.XAttr_FireAtk_Total;
				break;
			case DamageElement.DE_WATER:
				result = XAttributeDefine.XAttr_WaterAtk_Total;
				break;
			case DamageElement.DE_LIGHT:
				result = XAttributeDefine.XAttr_LightAtk_Total;
				break;
			case DamageElement.DE_DARK:
				result = XAttributeDefine.XAttr_DarkAtk_Total;
				break;
			default:
				result = XAttributeDefine.XAttr_VoidAtk_Total;
				break;
			}
			return result;
		}

		// Token: 0x0600D467 RID: 54375 RVA: 0x00320258 File Offset: 0x0031E458
		public XAttributeDefine MapElementToAttrDefense(DamageElement de)
		{
			XAttributeDefine result;
			switch (de)
			{
			case DamageElement.DE_NONE:
				result = XAttributeDefine.XAttr_VoidDef_Total;
				break;
			case DamageElement.DE_FIRE:
				result = XAttributeDefine.XAttr_FireDef_Total;
				break;
			case DamageElement.DE_WATER:
				result = XAttributeDefine.XAttr_WaterDef_Total;
				break;
			case DamageElement.DE_LIGHT:
				result = XAttributeDefine.XAttr_LightDef_Total;
				break;
			case DamageElement.DE_DARK:
				result = XAttributeDefine.XAttr_DarkDef_Total;
				break;
			default:
				result = XAttributeDefine.XAttr_VoidDef_Total;
				break;
			}
			return result;
		}

		// Token: 0x0600D468 RID: 54376 RVA: 0x003202B8 File Offset: 0x0031E4B8
		private void ApplySkillBuff(HurtInfo rawInput, List<BuffDesc> Buffs)
		{
			for (int i = 0; i < Buffs.Count; i++)
			{
				int buffTargetType = XSingleton<XBuffTemplateManager>.singleton.GetBuffTargetType(Buffs[i].BuffID);
				bool flag = buffTargetType == -1;
				if (!flag)
				{
					XSkillExternalBuffArgs @event = XEventPool<XSkillExternalBuffArgs>.GetEvent();
					@event.xBuffDesc = Buffs[i];
					@event.xBuffDesc.CasterID = rawInput.Caster.ID;
					bool flag2 = buffTargetType == 1;
					if (flag2)
					{
						@event.xTarget = rawInput.Target;
					}
					else
					{
						bool flag3 = buffTargetType == 0;
						if (flag3)
						{
							@event.xTarget = rawInput.Caster;
						}
					}
					bool flag4 = Buffs[i].DelayTime == 0f;
					if (flag4)
					{
						this._OnApplyBuff(@event);
						@event.Recycle();
					}
					else
					{
						@event.delay = Buffs[i].DelayTime;
						@event.callback = new SkillExternalCallback(this._OnApplyBuff);
						rawInput.Callback(@event);
					}
				}
			}
		}

		// Token: 0x0600D469 RID: 54377 RVA: 0x003203C4 File Offset: 0x0031E5C4
		private bool _OnApplyBuff(XSkillExternalArgs arg)
		{
			XSkillExternalBuffArgs xskillExternalBuffArgs = arg as XSkillExternalBuffArgs;
			bool flag = xskillExternalBuffArgs.xTarget != null && !xskillExternalBuffArgs.xTarget.Deprecated;
			if (flag)
			{
				XBuffAddEventArgs @event = XEventPool<XBuffAddEventArgs>.GetEvent();
				@event.xBuffDesc = xskillExternalBuffArgs.xBuffDesc;
				@event.Firer = xskillExternalBuffArgs.xTarget;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
			return true;
		}

		// Token: 0x0600D46A RID: 54378 RVA: 0x00320428 File Offset: 0x0031E628
		private void GetBaseDamage(XAttributes casterAttr, XAttributes targetAttr, SkillEffect eff, ref ProjectDamageResult result)
		{
			CombatParamTable.RowData combatParam = this.GetCombatParam(targetAttr.Level);
			double num = this.GetCombatValue(combatParam.PhysicalDef, targetAttr.GetAttr(XAttributeDefine.XAttr_PhysicalDefMod_Total));
			num = Math.Min(num, this.PhysicalAvoidenceLimit);
			double num2 = casterAttr.GetAttr(XAttributeDefine.XAttr_PhysicalAtkMod_Total) * (1.0 - num);
			double num3 = this.GetCombatValue(combatParam.MagicDef, targetAttr.GetAttr(XAttributeDefine.XAttr_MagicDefMod_Total));
			num3 = Math.Min(num3, this.MagicAvoidenceLimit);
			double num4 = casterAttr.GetAttr(XAttributeDefine.XAttr_MagicAtkMod_Total) * (1.0 - num3);
			bool flag = num2 < 0.0;
			if (flag)
			{
				num2 = 0.0;
			}
			bool flag2 = num4 < 0.0;
			if (flag2)
			{
				num4 = 0.0;
			}
			double num5 = 0.0;
			num5 += eff.PhyRatio * num2 + eff.PhyFixed;
			num5 += eff.MagRatio * num4 + eff.MagFixed;
			bool flag3 = num5 > 0.0;
			if (flag3)
			{
				double num6 = 0.0;
				num6 += eff.PhyRatio * num2 / (1.0 - num) + eff.PhyFixed;
				num6 += eff.MagRatio * num4 / (1.0 - num3) + eff.MagFixed;
				result.DefOriginalRatio = num6 / num5;
				CombatParamTable.RowData combatParam2 = this.GetCombatParam(casterAttr.Level);
				double num7 = this.GetCombatValue(combatParam2.ElementAtk, casterAttr.GetAttr(this.MapElementToAttrAttack(eff.DamageElementType)));
				double num8 = this.GetCombatValue(combatParam.ElementDef, targetAttr.GetAttr(this.MapElementToAttrDefense(eff.DamageElementType)));
				bool flag4 = num7 > XSingleton<XGlobalConfig>.singleton.ElemAtkLimit;
				if (flag4)
				{
					num7 = XSingleton<XGlobalConfig>.singleton.ElemAtkLimit;
				}
				bool flag5 = num8 > XSingleton<XGlobalConfig>.singleton.ElemDefLimit;
				if (flag5)
				{
					num8 = XSingleton<XGlobalConfig>.singleton.ElemDefLimit;
				}
				double num9 = this.GetCombatValue(combatParam2.FinalDamageBase, casterAttr.GetAttr(XAttributeDefine.XAttr_FinalDamage_Total));
				bool flag6 = num9 > XSingleton<XGlobalConfig>.singleton.FinalDamageLimit;
				if (flag6)
				{
					num9 = XSingleton<XGlobalConfig>.singleton.FinalDamageLimit;
				}
				double num10 = targetAttr.GetAttr(XAttributeDefine.XAttr_HurtInc_Total) / XSingleton<XGlobalConfig>.singleton.GeneralCombatParam + 1.0;
				bool flag7 = num10 > XSingleton<XGlobalConfig>.singleton.AttrChangeDamageLimit;
				if (flag7)
				{
					num10 = XSingleton<XGlobalConfig>.singleton.AttrChangeDamageLimit;
				}
				result.Value = num10 * num5 * (1.0 + num9) * (1.0 + num7) * (1.0 - num8);
			}
			else
			{
				result.Value = 0.0;
				result.DefOriginalRatio = 1.0;
			}
		}

		// Token: 0x0600D46B RID: 54379 RVA: 0x00320714 File Offset: 0x0031E914
		public double GetCritialRatio(XAttributes casterAttr)
		{
			double attr = casterAttr.GetAttr(XAttributeDefine.XAttr_CritDamage_Total);
			CombatParamTable.RowData combatParam = this.GetCombatParam(casterAttr.Level);
			double num = attr / (attr + (double)combatParam.CritDamageBase) + XSingleton<XGlobalConfig>.singleton.CritDamageBase;
			bool flag = num > XSingleton<XGlobalConfig>.singleton.CritDamageUpperBound;
			if (flag)
			{
				num = XSingleton<XGlobalConfig>.singleton.CritDamageUpperBound;
			}
			bool flag2 = num < XSingleton<XGlobalConfig>.singleton.CritDamageLowerBound;
			if (flag2)
			{
				num = XSingleton<XGlobalConfig>.singleton.CritDamageLowerBound;
			}
			return num;
		}

		// Token: 0x0600D46C RID: 54380 RVA: 0x00320798 File Offset: 0x0031E998
		public void CaculateSkillDamage(HurtInfo rawInput, ProjectDamageResult result, SkillEffect eff)
		{
			XAttributes attributes = rawInput.Caster.Attributes;
			XAttributes attributes2 = rawInput.Target.Attributes;
			float num;
			result.EffectHelper.GetSkillDamage(out num);
			num += XEmblemDocument.GetSkillDamageRatio(attributes.EmblemBag, rawInput.SkillID);
			eff.PhyRatio *= 1.0 + (double)num;
			eff.MagRatio *= 1.0 + (double)num;
			this.GetBaseDamage(attributes, attributes2, eff, ref result);
			for (int i = 0; i < XCombat.oAttackApplyStateHandlers.Count; i++)
			{
				bool flag = XCombat.oAttackApplyStateHandlers[i].GetStateMask() != 0;
				if (flag)
				{
					bool flag2 = XCombat.oAttackApplyStateHandlers[i].IsApplyState(rawInput.Caster) && !XCombat.oAttackApplyStateHandlers[i].IsDefenseState(rawInput.Target);
					if (flag2)
					{
						XCombat.oAttackApplyStateHandlers[i].ApplyState(rawInput.Caster, result);
					}
				}
			}
			bool flag3 = eff.Buffs != null && eff.Buffs.Count > 0;
			if (flag3)
			{
				this.ApplySkillBuff(rawInput, eff.Buffs);
			}
			result.ElementType = eff.DamageElementType;
			double num2 = 1.0;
			double num3 = 1.0;
			double num4 = 1.0;
			bool flag4 = rawInput.Caster.Buffs != null;
			if (flag4)
			{
				num2 += rawInput.Caster.Buffs.ModifySkillDamage();
				num4 += rawInput.Caster.Buffs.ChangeSkillDamage(rawInput.SkillID);
			}
			bool flag5 = rawInput.Target.Buffs != null;
			if (flag5)
			{
				num2 += rawInput.Target.Buffs.IncReceivedDamage();
				num3 += rawInput.Target.Buffs.DecReceivedDamage();
			}
			result.Value *= num2 * num3 * num4;
			double num5 = (double)XSingleton<XCommon>.singleton.RandomFloat(XSingleton<XGlobalConfig>.singleton.DamageRandomLowerBound, XSingleton<XGlobalConfig>.singleton.DamageRandomUpperBound);
			result.Value *= num5;
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
			bool flag6 = sceneData != null;
			if (flag6)
			{
				result.Value *= (double)sceneData.HurtCoef;
			}
			double num6 = attributes.GetAttr(XAttributeDefine.XAttr_TrueDamage_Total);
			bool flag7 = eff.PercentDamage > 1E-05;
			if (flag7)
			{
				num6 += attributes2.GetAttr(XAttributeDefine.XAttr_MaxHP_Total) * eff.PercentDamage;
			}
			result.TrueDamage += num6;
			bool flag8 = result.Value < 1.0;
			if (flag8)
			{
				result.Value = 1.0;
			}
		}

		// Token: 0x0600D46D RID: 54381 RVA: 0x00320A88 File Offset: 0x0031EC88
		public static void CaculateSuperArmorChange(HurtInfo rawInput, ProjectDamageResult result, SkillEffect eff)
		{
			XWoozyComponent xwoozyComponent = rawInput.Target.GetXComponent(XWoozyComponent.uuID) as XWoozyComponent;
			bool flag = xwoozyComponent != null && xwoozyComponent.InTransfer;
			if (flag)
			{
				result.SetResult(ProjectResultType.PJRES_BATI);
			}
			else
			{
				bool flag2 = rawInput.Target.Attributes.GetAttr(XAttributeDefine.XAttr_MaxSuperArmor_Basic) > 0.0 && rawInput.Target.Attributes.IsSuperArmorBroken;
				if (!flag2)
				{
					double attr = rawInput.Caster.Attributes.GetAttr(XAttributeDefine.XAttr_SuperArmorAtk_Total);
					double attr2 = rawInput.Target.Attributes.GetAttr(XAttributeDefine.XAttr_SuperArmorDef_Total);
					double num = attr * (double)eff.DecSuperArmor - attr2;
					bool flag3 = num <= 0.0;
					if (flag3)
					{
						result.SetResult(ProjectResultType.PJRES_BATI);
					}
					else
					{
						bool flag4 = rawInput.Target.Attributes.GetAttr(XAttributeDefine.XAttr_MaxSuperArmor_Basic) <= 0.0;
						if (!flag4)
						{
							bool flag5 = !rawInput.Target.Attributes.IsSuperArmorBroken;
							if (flag5)
							{
								double attr3 = rawInput.Target.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentSuperArmor_Basic);
								XAttrChangeEventArgs @event = XEventPool<XAttrChangeEventArgs>.GetEvent();
								@event.AttrKey = XAttributeDefine.XAttr_CurrentSuperArmor_Basic;
								@event.DeltaValue = -num;
								@event.Firer = rawInput.Target;
								XSingleton<XEventMgr>.singleton.FireEvent(@event);
								bool flag6 = rawInput.Target.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentSuperArmor_Basic) > 0.0;
								if (flag6)
								{
									result.SetResult(ProjectResultType.PJRES_BATI);
								}
								else
								{
									bool flag7 = rawInput.Target.Attributes.HasWoozyStatus && attr3 > 0.0;
									if (flag7)
									{
										result.SetResult(ProjectResultType.PJRES_BATI);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600D46E RID: 54382 RVA: 0x00320C5C File Offset: 0x0031EE5C
		public void ProjectDemonstrationStart(HurtInfo rawInput)
		{
			SkillStartEffect skillStartEffect = XSingleton<XSkillEffectMgr>.singleton.GetSkillStartEffect(rawInput.SkillID, 1U, null, 0U, XSingleton<XScene>.singleton.IsPVPScene);
			bool flag = skillStartEffect.Buffs != null;
			if (flag)
			{
				this.ApplySkillBuff(rawInput, skillStartEffect.Buffs);
			}
		}

		// Token: 0x0600D46F RID: 54383 RVA: 0x00320CA8 File Offset: 0x0031EEA8
		public void ProjectStart(HurtInfo rawInput)
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (!syncMode)
			{
				uint skillLevel = rawInput.Caster.Attributes.SkillLevelInfo.GetSkillLevel(rawInput.SkillID);
				SkillStartEffect skillStartEffect = XSingleton<XSkillEffectMgr>.singleton.GetSkillStartEffect(rawInput.SkillID, skillLevel, rawInput.Caster.Attributes.SkillLevelInfo.Flags, rawInput.Caster.SkillCasterTypeID, XSingleton<XScene>.singleton.IsPVPScene);
				CombatEffectHelper data = XDataPool<CombatEffectHelper>.GetData();
				data.Set(rawInput.SkillID, rawInput.Caster);
				data.GetSkillAddBuff(ref skillStartEffect.Buffs, rawInput.Caster.Attributes.SkillLevelInfo.Flags);
				data.Recycle();
				bool flag = skillStartEffect.IncSuperArmor > 0;
				if (flag)
				{
					XAttrChangeEventArgs @event = XEventPool<XAttrChangeEventArgs>.GetEvent();
					@event.AttrKey = XAttributeDefine.XAttr_CurrentSuperArmor_Basic;
					@event.DeltaValue = (double)skillStartEffect.IncSuperArmor;
					@event.Firer = rawInput.Caster;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
				XAttrChangeEventArgs event2 = XEventPool<XAttrChangeEventArgs>.GetEvent();
				event2.AttrKey = XAttributeDefine.XAttr_CurrentMP_Basic;
				bool flag2 = skillStartEffect.MpCost > 0.0;
				if (flag2)
				{
					event2.DeltaValue = -skillStartEffect.MpCost * (1.0 + rawInput.Caster.Buffs.ModifySkillCost());
				}
				else
				{
					event2.DeltaValue = -skillStartEffect.MpCost;
				}
				event2.Firer = rawInput.Caster;
				XSingleton<XEventMgr>.singleton.FireEvent(event2);
				XAIStartSkillEventArgs event3 = XEventPool<XAIStartSkillEventArgs>.GetEvent();
				event3.Firer = rawInput.Caster;
				event3.SkillId = rawInput.SkillID;
				event3.IsCaster = true;
				XSingleton<XEventMgr>.singleton.FireEvent(event3);
				XAIStartSkillEventArgs event4 = XEventPool<XAIStartSkillEventArgs>.GetEvent();
				event4.Firer = rawInput.Target;
				event4.SkillId = rawInput.SkillID;
				event4.IsCaster = false;
				XSingleton<XEventMgr>.singleton.FireEvent(event4);
				uint skillID = rawInput.SkillID;
				bool flag3 = rawInput.Caster.Buffs != null;
				if (flag3)
				{
					rawInput.Caster.Buffs.OnCastSkill(rawInput);
				}
				bool flag4 = skillID != rawInput.SkillID;
				if (!flag4)
				{
					bool flag5 = skillStartEffect.Buffs != null;
					if (flag5)
					{
						this.ApplySkillBuff(rawInput, skillStartEffect.Buffs);
					}
					bool flag6 = rawInput.SkillToken != 0L;
					if (flag6)
					{
						int num = 0;
						for (int i = 0; i < XCombat.oAttackApplyStateHandlers.Count; i++)
						{
							num |= XCombat.oAttackApplyStateHandlers[i].GetStateMask();
						}
					}
				}
			}
		}

		// Token: 0x0600D470 RID: 54384 RVA: 0x00320F5C File Offset: 0x0031F15C
		public void ProjectEnd(HurtInfo rawInput)
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (!syncMode)
			{
				uint skillLevel = rawInput.Caster.Attributes.SkillLevelInfo.GetSkillLevel(rawInput.SkillID);
				SkillStartEffect skillStartEffect = XSingleton<XSkillEffectMgr>.singleton.GetSkillStartEffect(rawInput.SkillID, skillLevel, rawInput.Caster.Attributes.SkillLevelInfo.Flags, rawInput.Caster.SkillCasterTypeID, XSingleton<XScene>.singleton.IsPVPScene);
				bool flag = skillStartEffect.IncSuperArmor > 0 && rawInput.Caster is XPlayer;
				if (flag)
				{
					XAttrChangeEventArgs @event = XEventPool<XAttrChangeEventArgs>.GetEvent();
					@event.AttrKey = XAttributeDefine.XAttr_CurrentSuperArmor_Basic;
					@event.DeltaValue = (double)(-(double)skillStartEffect.IncSuperArmor);
					@event.Firer = rawInput.Caster;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
				XAIEndSkillEventArgs event2 = XEventPool<XAIEndSkillEventArgs>.GetEvent();
				event2.Firer = rawInput.Caster;
				event2.SkillId = rawInput.SkillID;
				event2.IsCaster = true;
				XSingleton<XEventMgr>.singleton.FireEvent(event2);
				XAIEndSkillEventArgs event3 = XEventPool<XAIEndSkillEventArgs>.GetEvent();
				event3.Firer = rawInput.Target;
				event3.SkillId = rawInput.SkillID;
				event3.IsCaster = false;
				XSingleton<XEventMgr>.singleton.FireEvent(event3);
			}
		}

		// Token: 0x0600D471 RID: 54385 RVA: 0x003210A4 File Offset: 0x0031F2A4
		public ProjectDamageResult ProjectDamage(HurtInfo rawInput)
		{
			ProjectDamageResult data = XDataPool<ProjectDamageResult>.GetData();
			bool flag = rawInput.Caster == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("caster is null!", null, null, null, null, null);
			}
			else
			{
				data.Caster = rawInput.Caster.ID;
			}
			bool flag2 = rawInput.Target == null;
			if (flag2)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("target is null!", null, null, null, null, null);
			}
			else
			{
				XAISkillHurtEventArgs @event = XEventPool<XAISkillHurtEventArgs>.GetEvent();
				@event.Firer = rawInput.Target;
				@event.IsCaster = false;
				@event.SkillId = rawInput.SkillID;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
			data.EffectHelper.Set(rawInput.SkillID, rawInput.Caster);
			bool flag3 = !this.CheckState(rawInput, data);
			ProjectDamageResult result;
			if (flag3)
			{
				bool accept = data.Accept;
				if (accept)
				{
					XCombat.BuffEffect(rawInput, data);
				}
				result = data;
			}
			else
			{
				SkillEffect skillEffect = XSingleton<XSkillEffectMgr>.singleton.GetSkillEffect(rawInput.SkillID, rawInput.HitPoint, rawInput.Caster.Attributes.SkillLevelInfo.GetSkillLevel(rawInput.SkillID), rawInput.Caster.Attributes.SkillLevelInfo.Flags, rawInput.Caster.SkillCasterTypeID, XSingleton<XScene>.singleton.IsPVPScene);
				bool flag4 = (rawInput.Target.Attributes.Tag & skillEffect.ExclusiveMask) > 0U;
				if (flag4)
				{
					data.Accept = false;
					result = data;
				}
				else
				{
					XAISkillHurtEventArgs event2 = XEventPool<XAISkillHurtEventArgs>.GetEvent();
					event2.Firer = rawInput.Caster;
					event2.IsCaster = true;
					event2.SkillId = rawInput.SkillID;
					XSingleton<XEventMgr>.singleton.FireEvent(event2);
					this.CaculateSkillDamage(rawInput, data, skillEffect);
					XCombat.CaculateSuperArmorChange(rawInput, data, skillEffect);
					XCombat.BuffEffect(rawInput, data);
					XCombat.ChangeHPAndFireEvent(rawInput, data, false);
					result = data;
				}
			}
			return result;
		}

		// Token: 0x0600D472 RID: 54386 RVA: 0x00321288 File Offset: 0x0031F488
		public static void BuffEffect(HurtInfo rawInput, ProjectDamageResult result)
		{
			XBuff.EffectEnumeratorPriorityCur = XBuffEffectPrioriy.BEP_START;
			XBuff.EffectEnumeratorPriorityNext = XBuffEffectPrioriy.BEP_END;
			XBuffComponent xbuffComponent = null;
			XBuffComponent xbuffComponent2 = null;
			bool flag = rawInput.Target != null;
			if (flag)
			{
				xbuffComponent = rawInput.Target.Buffs;
			}
			bool flag2 = rawInput.Caster != null;
			if (flag2)
			{
				xbuffComponent2 = rawInput.Caster.Buffs;
			}
			while (XBuff.EffectEnumeratorPriorityCur != XBuffEffectPrioriy.BEP_END)
			{
				bool flag3 = xbuffComponent != null;
				if (flag3)
				{
					xbuffComponent.OnHurt(rawInput, result);
				}
				bool flag4 = xbuffComponent2 != null;
				if (flag4)
				{
					xbuffComponent2.OnCastDamage(rawInput, result);
				}
				XBuff.EffectEnumeratorPriorityCur = XBuff.EffectEnumeratorPriorityNext;
				XBuff.EffectEnumeratorPriorityNext = XBuffEffectPrioriy.BEP_END;
			}
		}

		// Token: 0x0600D473 RID: 54387 RVA: 0x00321328 File Offset: 0x0031F528
		public static double CheckChangeHPLimit(double damage, XEntity entity, bool bIgnoreImmortal, bool bForceCantDie)
		{
			return XCombat._CheckChangeHPLimit(XAttributeDefine.XAttr_CurrentHP_Basic, damage, true, entity, bIgnoreImmortal, bForceCantDie);
		}

		// Token: 0x0600D474 RID: 54388 RVA: 0x00321348 File Offset: 0x0031F548
		public static double CheckChangeHPLimit(XAttributeDefine attr, double value, XEntity entity, bool bIgnoreImmortal, bool bForceCantDie)
		{
			return XCombat._CheckChangeHPLimit(attr, value, false, entity, bIgnoreImmortal, bForceCantDie);
		}

		// Token: 0x0600D475 RID: 54389 RVA: 0x00321368 File Offset: 0x0031F568
		private static double _CheckChangeHPLimit(XAttributeDefine attr, double value, bool bIsDamage, XEntity entity, bool bIgnoreImmortal, bool bForceCantDie)
		{
			double result;
			if (bIsDamage)
			{
				result = -XBuffSpecialState.GetActualChangeAttr(attr, -value, entity, bIgnoreImmortal, bForceCantDie);
			}
			else
			{
				result = XBuffSpecialState.GetActualChangeAttr(attr, value, entity, bIgnoreImmortal, bForceCantDie);
			}
			return result;
		}

		// Token: 0x0600D476 RID: 54390 RVA: 0x0032139C File Offset: 0x0031F59C
		private static void ChangeHPAndFireEvent(HurtInfo rawInput, ProjectDamageResult result, bool bShowHUD)
		{
			bool flag = rawInput == null || result == null || rawInput.Target == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddWarningLog("rawInput == null || result == null || rawInput.Target == null", null, null, null, null, null);
			}
			else
			{
				XEntity caster = rawInput.Caster;
				XEntity target = rawInput.Target;
				bool flag2 = target.Attributes != null;
				if (flag2)
				{
					bool flag3 = target.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentXULI_Basic) > 0.0;
					if (flag3)
					{
						XAttrChangeEventArgs @event = XEventPool<XAttrChangeEventArgs>.GetEvent();
						@event.AttrKey = XAttributeDefine.XAttr_CurrentXULI_Basic;
						@event.DeltaValue = -result.Value;
						@event.Firer = target;
						XSingleton<XEventMgr>.singleton.FireEvent(@event);
						bool flag4 = target.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentXULI_Basic) <= 0.0;
						if (flag4)
						{
							XStrengthPresevationOffArgs event2 = XEventPool<XStrengthPresevationOffArgs>.GetEvent();
							event2.Firer = target;
							XSingleton<XEventMgr>.singleton.FireEvent(event2);
						}
					}
					bool flag5 = result.Value != 0.0;
					if (flag5)
					{
						XAttrChangeEventArgs event3 = XEventPool<XAttrChangeEventArgs>.GetEvent();
						event3.AttrKey = XAttributeDefine.XAttr_CurrentHP_Basic;
						event3.DeltaValue = -result.Value;
						event3.CasterID = result.Caster;
						event3.bShowHUD = bShowHUD;
						event3.Firer = target;
						XSingleton<XEventMgr>.singleton.FireEvent(event3);
					}
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("target.Attributes == null, typeID: ", target.TypeID.ToString(), " name: ", target.Name, null, null);
				}
				result.IsTargetDead = target.IsDead;
				XEnmityEventArgs event4 = XEventPool<XEnmityEventArgs>.GetEvent();
				event4.AttrKey = XAttributeDefine.XAttr_CurrentHP_Basic;
				event4.Firer = target;
				event4.Starter = caster;
				event4.DeltaValue = result.Value;
				event4.SkillId = rawInput.SkillID;
				XSingleton<XEventMgr>.singleton.FireEvent(event4);
				XProjectDamageEventArgs event5 = XEventPool<XProjectDamageEventArgs>.GetEvent();
				event5.Damage = result;
				event5.Hurt = rawInput;
				event5.Firer = rawInput.Caster;
				XSingleton<XEventMgr>.singleton.FireEvent(event5);
				event5 = XEventPool<XProjectDamageEventArgs>.GetEvent();
				event5.Damage = result;
				event5.Hurt = rawInput;
				event5.Firer = rawInput.Target;
				XSingleton<XEventMgr>.singleton.FireEvent(event5);
			}
		}

		// Token: 0x0600D477 RID: 54391 RVA: 0x003215DC File Offset: 0x0031F7DC
		public void ChangeHPAndFireEventByQTE(double Value, XEntity target)
		{
			Value = XCombat.CheckChangeHPLimit(Value, target, false, false);
			XAttrChangeEventArgs @event = XEventPool<XAttrChangeEventArgs>.GetEvent();
			@event.AttrKey = XAttributeDefine.XAttr_CurrentHP_Basic;
			@event.DeltaValue = -Value;
			@event.Firer = target;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x0600D478 RID: 54392 RVA: 0x00321624 File Offset: 0x0031F824
		private bool CheckState(HurtInfo rawInput, ProjectDamageResult result)
		{
			bool flag = !XEntity.ValideEntity(rawInput.Target);
			bool result2;
			if (flag)
			{
				result.Accept = false;
				result2 = false;
			}
			else
			{
				bool flag2 = rawInput.Target.Attributes.BuffState.IsBuffStateOn(XBuffType.XBuffType_Immortal);
				if (flag2)
				{
					result.Accept = true;
					result.SetResult(ProjectResultType.PJRES_IMMORTAL);
					result2 = false;
				}
				else
				{
					bool flag3 = rawInput.Caster.Attributes.BuffState.IsBuffStateOn(XBuffType.XBuffType_Blind);
					if (flag3)
					{
						result.Accept = true;
						result.SetResult(ProjectResultType.PJRES_MISS);
						result2 = false;
					}
					else
					{
						result2 = true;
					}
				}
			}
			return result2;
		}

		// Token: 0x0600D479 RID: 54393 RVA: 0x003216B4 File Offset: 0x0031F8B4
		public static void ProjectExternalDamage(double damage, ulong CasterID, XEntity target, bool bShowHUD, int flag = 0)
		{
			bool flag2 = target == null;
			if (!flag2)
			{
				HurtInfo data = XDataPool<HurtInfo>.GetData();
				data.Caster = XSingleton<XEntityMgr>.singleton.GetEntity(CasterID);
				data.Target = target;
				ProjectDamageResult data2 = XDataPool<ProjectDamageResult>.GetData();
				data2.Value = damage;
				data2.Caster = CasterID;
				data2.Flag |= flag;
				data2.DefOriginalRatio = 1.0;
				XCombat.BuffEffect(data, data2);
				XCombat.ChangeHPAndFireEvent(data, data2, bShowHUD);
				XProjectDamageEventArgs @event = XEventPool<XProjectDamageEventArgs>.GetEvent();
				@event = XEventPool<XProjectDamageEventArgs>.GetEvent();
				@event.Damage = data2;
				@event.Hurt = data;
				@event.Firer = data.Caster;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				@event = XEventPool<XProjectDamageEventArgs>.GetEvent();
				@event.Damage = data2;
				@event.Hurt = data;
				@event.Firer = data.Target;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				data.Recycle();
				data2.Recycle();
			}
		}

		// Token: 0x040060ED RID: 24813
		private XTableAsyncLoader _async_loader = null;

		// Token: 0x040060EE RID: 24814
		private static CombatParamTable oTable = new CombatParamTable();

		// Token: 0x040060EF RID: 24815
		private static List<AttackApplyState> oAttackApplyStateHandlers;

		// Token: 0x040060F0 RID: 24816
		private double PhysicalAvoidenceLimit;

		// Token: 0x040060F1 RID: 24817
		private double MagicAvoidenceLimit;
	}
}

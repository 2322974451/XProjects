using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EA3 RID: 3747
	internal class XSkillEffectMgr : XSingleton<XSkillEffectMgr>
	{
		// Token: 0x0600C798 RID: 51096 RVA: 0x002C9230 File Offset: 0x002C7430
		public void TestSkillTable()
		{
			for (int i = 0; i < this._skillTable.Table.Length; i++)
			{
				SkillList.RowData rowData = this._skillTable.Table[i];
				bool flag = this.GetSkillConfig(XSingleton<XCommon>.singleton.XHash(rowData.SkillScript), 0U, rowData.XEntityStatisticsID) == null;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog2("skill not found:{0}", new object[]
					{
						rowData.SkillScript
					});
				}
			}
		}

		// Token: 0x0600C799 RID: 51097 RVA: 0x002C92B0 File Offset: 0x002C74B0
		public override bool Init()
		{
			bool flag = this._async_loader == null;
			if (flag)
			{
				this._async_loader = new XTableAsyncLoader();
				this._async_loader.AddTask("Table/SkillList", this._skillTable, false);
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
				for (int i = 0; i < this._skillTable.Table.Length; i++)
				{
					SkillList.RowData rowData = this._skillTable.Table[i];
					bool flag3 = !string.IsNullOrEmpty(rowData.SkillScript) && !string.IsNullOrEmpty(rowData.ExSkillScript);
					if (flag3)
					{
						bool flag4 = rowData.XEntityStatisticsID > 0U;
						if (flag4)
						{
							ulong key = (ulong)XSingleton<XCommon>.singleton.XHash(rowData.ExSkillScript) << 32 | (ulong)rowData.XEntityStatisticsID;
							this._specialEnemyPreSkillDict[key] = rowData.SkillScriptHash;
						}
						else
						{
							this.PreSkillDict[XSingleton<XCommon>.singleton.XHash(rowData.ExSkillScript)] = rowData.SkillScriptHash;
						}
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600C79A RID: 51098 RVA: 0x002C93E7 File Offset: 0x002C75E7
		public override void Uninit()
		{
			this._async_loader = null;
		}

		// Token: 0x0600C79B RID: 51099 RVA: 0x002C93F4 File Offset: 0x002C75F4
		public SkillList.RowData GetSkillConfig(uint skillHash, uint skillLevel, uint entityTempID)
		{
			bool flag = entityTempID == 0U;
			SkillList.RowData result;
			if (flag)
			{
				result = this.GetSkillConfig(skillHash, skillLevel);
			}
			else
			{
				result = this.GetEnemySpecialSkillConfig(skillHash, skillLevel, entityTempID);
			}
			return result;
		}

		// Token: 0x0600C79C RID: 51100 RVA: 0x002C9424 File Offset: 0x002C7624
		public SkillList.RowData GetEnemySpecialSkillConfig(uint skillHash, uint skillLevel, uint entityTempID)
		{
			bool flag = this.EmptySkillHash == skillHash;
			SkillList.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				int num = -1;
				int num2 = -1;
				CVSReader.GetRowDataListByField<SkillList.RowData, uint>(this._skillTable.Table, skillHash, out num, out num2, XSkillEffectMgr.comp);
				bool flag2 = num >= 0 && num <= num2;
				if (flag2)
				{
					for (int i = num; i <= num2; i++)
					{
						SkillList.RowData rowData = this._skillTable.Table[i];
						bool flag3 = rowData.XEntityStatisticsID == entityTempID && skillLevel <= (uint)rowData.SkillLevel;
						if (flag3)
						{
							return rowData;
						}
					}
					bool flag4 = num == num2;
					if (flag4)
					{
						result = this._skillTable.Table[num];
					}
					else
					{
						for (int j = num; j <= num2; j++)
						{
							SkillList.RowData rowData2 = this._skillTable.Table[j];
							bool flag5 = rowData2.XEntityStatisticsID == 0U && skillLevel <= (uint)rowData2.SkillLevel;
							if (flag5)
							{
								return rowData2;
							}
						}
						result = this._skillTable.Table[num2];
					}
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x0600C79D RID: 51101 RVA: 0x002C9550 File Offset: 0x002C7750
		private static int SkillDataCompare(SkillList.RowData rowData, uint skillHash)
		{
			return skillHash.CompareTo(rowData.SkillScriptHash);
		}

		// Token: 0x0600C79E RID: 51102 RVA: 0x002C9570 File Offset: 0x002C7770
		public SkillList.RowData GetSkillConfig(uint skillHash, uint skillLevel)
		{
			bool flag = this.EmptySkillHash == skillHash;
			SkillList.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				int num = -1;
				int num2 = -1;
				CVSReader.GetRowDataListByField<SkillList.RowData, uint>(this._skillTable.Table, skillHash, out num, out num2, XSkillEffectMgr.comp);
				bool flag2 = num >= 0 && num <= num2;
				if (flag2)
				{
					bool flag3 = num == num2;
					if (flag3)
					{
						result = this._skillTable.Table[num];
					}
					else
					{
						for (int i = num; i <= num2; i++)
						{
							SkillList.RowData rowData = this._skillTable.Table[i];
							bool flag4 = rowData.XEntityStatisticsID == 0U && skillLevel <= (uint)rowData.SkillLevel;
							if (flag4)
							{
								return rowData;
							}
						}
						result = this._skillTable.Table[num2];
					}
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x0600C79F RID: 51103 RVA: 0x002C964C File Offset: 0x002C784C
		public int GetSkillMaxLevel(uint skillHash, uint entityTempID = 0U)
		{
			bool flag = this.EmptySkillHash == skillHash;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int num = -1;
				int num2 = -1;
				CVSReader.GetRowDataListByField<SkillList.RowData, uint>(this._skillTable.Table, skillHash, out num, out num2, XSkillEffectMgr.comp);
				bool flag2 = num >= 0 && num <= num2;
				if (flag2)
				{
					bool flag3 = entityTempID > 0U;
					SkillList.RowData rowData;
					if (flag3)
					{
						for (int i = num2; i >= num; i--)
						{
							rowData = this._skillTable.Table[i];
							bool flag4 = rowData.XEntityStatisticsID == entityTempID;
							if (flag4)
							{
								return (int)rowData.SkillLevel;
							}
						}
					}
					rowData = this._skillTable.Table[0];
					uint preSkill = this.GetPreSkill(skillHash, 0U);
					bool flag5 = preSkill > 0U;
					if (flag5)
					{
						result = 1;
					}
					else
					{
						for (int j = num2; j >= num; j--)
						{
							rowData = this._skillTable.Table[j];
							bool flag6 = rowData.XEntityStatisticsID == 0U;
							if (flag6)
							{
								return (int)rowData.SkillLevel;
							}
						}
						result = 0;
					}
				}
				else
				{
					result = 0;
				}
			}
			return result;
		}

		// Token: 0x0600C7A0 RID: 51104 RVA: 0x002C9774 File Offset: 0x002C7974
		public int GetSkillHpMaxLimit(string skillName, uint level, uint entityTempID)
		{
			uint skillHash = XSingleton<XCommon>.singleton.XHash(skillName);
			SkillList.RowData skillConfig = this.GetSkillConfig(skillHash, level, entityTempID);
			bool flag = skillConfig == null;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				result = (int)skillConfig.HpMaxLimit;
			}
			return result;
		}

		// Token: 0x0600C7A1 RID: 51105 RVA: 0x002C97B0 File Offset: 0x002C79B0
		public int GetSkillHpMinLimit(string skillName, uint level, uint entityTempID)
		{
			uint skillHash = XSingleton<XCommon>.singleton.XHash(skillName);
			SkillList.RowData skillConfig = this.GetSkillConfig(skillHash, level, entityTempID);
			bool flag = skillConfig == null;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				result = (int)skillConfig.HpMinLimit;
			}
			return result;
		}

		// Token: 0x0600C7A2 RID: 51106 RVA: 0x002C97EC File Offset: 0x002C79EC
		public bool GetSkillDescriptValue(uint skillhash, uint level, XBodyBag EmblemBag, out float Ratio, out float Fixed)
		{
			float num = 0f;
			float num2 = 0f;
			Ratio = 0f;
			Fixed = 0f;
			SkillList.RowData skillConfig = this.GetSkillConfig(skillhash, level);
			bool flag = skillConfig == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < skillConfig.TipsRatio.Count; i++)
				{
					Ratio += skillConfig.TipsRatio[i, 0];
					num += skillConfig.TipsRatio[i, 1];
				}
				Ratio += num * level;
				for (int i = 0; i < skillConfig.TipsFixed.Count; i++)
				{
					Fixed += skillConfig.TipsFixed[i, 0];
					num2 += skillConfig.TipsFixed[i, 1];
				}
				Fixed += num2 * level;
				float num3 = 0f;
				CombatEffectHelper data = XDataPool<CombatEffectHelper>.GetData();
				data.Set(skillhash, XSingleton<XEntityMgr>.singleton.Player);
				data.GetSkillDamage(out num3);
				num3 += XEmblemDocument.GetSkillDamageRatio(EmblemBag, skillhash);
				Ratio *= 1f + num3;
				data.Recycle();
				result = true;
			}
			return result;
		}

		// Token: 0x0600C7A3 RID: 51107 RVA: 0x002C9924 File Offset: 0x002C7B24
		public SkillLevelupRequest GetLevelupRequest(uint skillHash, uint level)
		{
			SkillList.RowData skillConfig = this.GetSkillConfig(skillHash, level);
			bool flag = skillConfig == null;
			SkillLevelupRequest result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = this.req == null;
				if (flag2)
				{
					this.req = new SkillLevelupRequest();
				}
				bool flag3 = skillConfig.UpReqRoleLevel == null || skillConfig.UpReqRoleLevel.Length == 0;
				if (flag3)
				{
					this.req.Level = 0;
				}
				else
				{
					bool flag4 = (ulong)level < (ulong)((long)skillConfig.UpReqRoleLevel.Length);
					if (flag4)
					{
						this.req.Level = (int)skillConfig.UpReqRoleLevel[(int)level];
					}
					else
					{
						this.req.Level = (int)skillConfig.UpReqRoleLevel[skillConfig.UpReqRoleLevel.Length - 1];
					}
				}
				bool flag5 = this.req.Items == null;
				if (flag5)
				{
					this.req.Items = new List<ItemDesc>();
				}
				else
				{
					this.req.Items.Clear();
				}
				ItemDesc item = default(ItemDesc);
				item.ItemID = 5;
				bool flag6 = skillConfig.LevelupCost == null || skillConfig.LevelupCost.Length == 0;
				if (flag6)
				{
					item.ItemCount = 0;
				}
				else
				{
					bool flag7 = (ulong)level < (ulong)((long)skillConfig.LevelupCost.Length);
					if (flag7)
					{
						item.ItemCount = (int)skillConfig.LevelupCost[(int)level];
					}
					else
					{
						item.ItemCount = (int)skillConfig.LevelupCost[skillConfig.LevelupCost.Length - 1];
					}
				}
				this.req.Items.Add(item);
				result = this.req;
			}
			return result;
		}

		// Token: 0x0600C7A4 RID: 51108 RVA: 0x002C9AA8 File Offset: 0x002C7CA8
		public double GetAttackSpeedRatio(XAttributes attr)
		{
			return (double)attr.AttackSpeed;
		}

		// Token: 0x0600C7A5 RID: 51109 RVA: 0x002C9AC4 File Offset: 0x002C7CC4
		public float GetSkillInitCDRatio(uint skillHash, uint level, uint entityTempID, bool IsPVP, XAttributes attr)
		{
			SkillList.RowData skillConfig = this.GetSkillConfig(skillHash, level, entityTempID);
			bool flag = skillConfig == null;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				float num = 0f;
				CombatEffectHelper data = XDataPool<CombatEffectHelper>.GetData();
				data.Set(skillHash, attr.Entity);
				data.GetSkillCD(out num);
				data.Recycle();
				bool isPlayer = attr.Entity.IsPlayer;
				if (isPlayer)
				{
					num += XEmblemDocument.GetSkillCDRatio(attr.EmblemBag, skillHash);
				}
				num += 1f;
				if (IsPVP)
				{
					result = skillConfig.PvPInitCD * num;
				}
				else
				{
					result = skillConfig.InitCD * num;
				}
			}
			return result;
		}

		// Token: 0x0600C7A6 RID: 51110 RVA: 0x002C9B6C File Offset: 0x002C7D6C
		public float GetSkillCDDynamicRatio(XAttributes attr)
		{
			return (float)(attr.GetAttr(XAttributeDefine.XATTR_SKILL_CD_Total) / XSingleton<XGlobalConfig>.singleton.GeneralCombatParam);
		}

		// Token: 0x0600C7A7 RID: 51111 RVA: 0x002C9B98 File Offset: 0x002C7D98
		public float GetSkillCDDynamicRatio(XAttributes attr, uint skillHash)
		{
			return this.CalcDynamicRatio(this.GetSkillCDDynamicRatio(attr), this.GetSkillCDSemiDynamicRatio(attr, skillHash));
		}

		// Token: 0x0600C7A8 RID: 51112 RVA: 0x002C9BC0 File Offset: 0x002C7DC0
		public float GetSkillCDSemiDynamicRatio(XAttributes attr, uint skillHash)
		{
			float num = 0f;
			CombatEffectHelper data = XDataPool<CombatEffectHelper>.GetData();
			data.Set(skillHash, attr.Entity);
			data.GetSkillCD(out num);
			data.Recycle();
			bool isPlayer = attr.Entity.IsPlayer;
			if (isPlayer)
			{
				num += XEmblemDocument.GetSkillCDRatio(attr.EmblemBag, skillHash);
			}
			return num;
		}

		// Token: 0x0600C7A9 RID: 51113 RVA: 0x002C9C20 File Offset: 0x002C7E20
		public double GetXULIPower(XEntity entity)
		{
			bool flag = entity == null || entity.Attributes == null;
			double result;
			if (flag)
			{
				result = 1.0;
			}
			else
			{
				result = entity.Attributes.GetAttr(XAttributeDefine.XAttr_XULI_Total) / XSingleton<XGlobalConfig>.singleton.GeneralCombatParam;
			}
			return result;
		}

		// Token: 0x0600C7AA RID: 51114 RVA: 0x002C9C6C File Offset: 0x002C7E6C
		public float CalcDynamicRatio(float dynamicCDRatio, float semiDynamicCDRatio)
		{
			float num = dynamicCDRatio + semiDynamicCDRatio;
			return Mathf.Clamp(num, XSingleton<XGlobalConfig>.singleton.CDChangeLowerBound, XSingleton<XGlobalConfig>.singleton.CDChangeUpperBound);
		}

		// Token: 0x0600C7AB RID: 51115 RVA: 0x002C9C9C File Offset: 0x002C7E9C
		public float GetSkillCDStaticRatio(uint skillHash, uint level, uint entityTempID, bool IsPVP)
		{
			SkillList.RowData skillConfig = this.GetSkillConfig(skillHash, level, entityTempID);
			bool flag = skillConfig == null;
			float result;
			if (flag)
			{
				result = 1f;
			}
			else if (IsPVP)
			{
				bool flag2 = skillConfig.PvPCDRatio[0] == 0f && skillConfig.PvPCDRatio[1] == 0f;
				if (flag2)
				{
					result = 1f;
				}
				else
				{
					result = skillConfig.PvPCDRatio[0] + skillConfig.PvPCDRatio[1] * level;
				}
			}
			else
			{
				bool flag3 = skillConfig.CDRatio[0] == 0f && skillConfig.CDRatio[1] == 0f;
				if (flag3)
				{
					result = 1f;
				}
				else
				{
					result = skillConfig.CDRatio[0] + skillConfig.CDRatio[1] * level;
				}
			}
			return result;
		}

		// Token: 0x0600C7AC RID: 51116 RVA: 0x002C9D84 File Offset: 0x002C7F84
		public float GetSkillCostMP(uint skillHash, uint level, uint entityTempID)
		{
			SkillList.RowData skillConfig = this.GetSkillConfig(skillHash, level, entityTempID);
			bool flag = skillConfig == null;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				result = skillConfig.CostMP[0] + skillConfig.CostMP[1] * level;
			}
			return result;
		}

		// Token: 0x0600C7AD RID: 51117 RVA: 0x002C9DD0 File Offset: 0x002C7FD0
		public float GetSkillCostMP(string skillName, uint level, uint entityTempID)
		{
			uint skillHash = XSingleton<XCommon>.singleton.XHash(skillName);
			return this.GetSkillCostMP(skillHash, level, entityTempID);
		}

		// Token: 0x0600C7AE RID: 51118 RVA: 0x002C9DF8 File Offset: 0x002C7FF8
		public SkillStartEffect GetSkillStartEffect(uint skillHash, uint level, XSkillFlags skillFlags, uint entityTempID, bool IsPVP)
		{
			SkillStartEffect skillStartEffect = default(SkillStartEffect);
			skillStartEffect.IncSuperArmor = 0;
			skillStartEffect.MpCost = 0.0;
			skillStartEffect.Buffs = null;
			SkillList.RowData skillConfig = this.GetSkillConfig(skillHash, level, entityTempID);
			bool flag = skillConfig == null;
			SkillStartEffect result;
			if (flag)
			{
				result = skillStartEffect;
			}
			else
			{
				if (IsPVP)
				{
					skillStartEffect.IncSuperArmor = skillConfig.PvPIncreaseSuperArmor;
				}
				else
				{
					skillStartEffect.IncSuperArmor = skillConfig.IncreaseSuperArmor;
				}
				for (int i = 0; i < skillConfig.StartBuffID.Count; i++)
				{
					bool flag2 = skillConfig.StartBuffID[i, 0] != 0f && (skillFlags == null || skillFlags.IsFlagSet((uint)skillConfig.StartBuffID[i, 3]));
					if (flag2)
					{
						BuffDesc item;
						item.BuffID = (int)skillConfig.StartBuffID[i, 0];
						item.BuffLevel = (int)(((int)skillConfig.StartBuffID[i, 1] == 0) ? level : ((uint)((int)skillConfig.StartBuffID[i, 1])));
						item.DelayTime = skillConfig.StartBuffID[i, 2];
						item.CasterID = 0UL;
						item.EffectTime = BuffDesc.DEFAULT_TIME;
						bool flag3 = skillStartEffect.Buffs == null;
						if (flag3)
						{
							skillStartEffect.Buffs = new List<BuffDesc>();
						}
						item.SkillID = skillHash;
						skillStartEffect.Buffs.Add(item);
					}
				}
				skillStartEffect.MpCost = (double)(skillConfig.CostMP[0] + skillConfig.CostMP[1] * level);
				result = skillStartEffect;
			}
			return result;
		}

		// Token: 0x0600C7AF RID: 51119 RVA: 0x002C9F9C File Offset: 0x002C819C
		public SkillEffect GetSkillEffect(uint skillHash, int hitpoint, uint level, XSkillFlags skillFlags, uint entityTempID, bool IsPVP)
		{
			SkillEffect skillEffect = this.m_SkillEffect;
			skillEffect.DamageElementType = DamageElement.DE_NONE;
			skillEffect.PhyRatio = 1.0;
			skillEffect.PhyFixed = 0.0;
			skillEffect.MagRatio = 1.0;
			skillEffect.MagFixed = 0.0;
			skillEffect.DecSuperArmor = 0f;
			bool flag = skillEffect.Buffs != null;
			if (flag)
			{
				skillEffect.Buffs.Clear();
			}
			SkillList.RowData skillConfig = this.GetSkillConfig(skillHash, level, entityTempID);
			bool flag2 = skillConfig == null;
			SkillEffect result;
			if (flag2)
			{
				result = skillEffect;
			}
			else
			{
				skillEffect.DamageElementType = (DamageElement)skillConfig.Element;
				if (IsPVP)
				{
					bool flag3 = hitpoint >= skillConfig.PvPRatio.Count || hitpoint >= skillConfig.PvPFixed.Count || hitpoint >= skillConfig.PvPMagicRatio.Count || hitpoint >= skillConfig.PvPMagicFixed.Count || hitpoint >= skillConfig.PercentDamage.Count;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Error: skill ", skillConfig.SkillScript, " hitpoint ", hitpoint.ToString(), " out of range", null);
						return skillEffect;
					}
					skillEffect.PhyRatio = (double)(skillConfig.PvPRatio[hitpoint, 0] + skillConfig.PvPRatio[hitpoint, 1] * level);
					skillEffect.PhyFixed = (double)(skillConfig.PvPFixed[hitpoint, 0] + skillConfig.PvPFixed[hitpoint, 1] * level);
					skillEffect.MagRatio = (double)(skillConfig.PvPMagicRatio[hitpoint, 0] + skillConfig.PvPMagicRatio[hitpoint, 1] * level);
					skillEffect.MagFixed = (double)(skillConfig.PvPMagicFixed[hitpoint, 0] + skillConfig.PvPMagicFixed[hitpoint, 1] * level);
					skillEffect.PercentDamage = (double)(skillConfig.PercentDamage[hitpoint, 0] + skillConfig.PercentDamage[hitpoint, 1] * level);
					bool flag4 = skillConfig.PvPDecreaseSuperArmor != null && hitpoint < skillConfig.PvPDecreaseSuperArmor.Length;
					if (flag4)
					{
						skillEffect.DecSuperArmor = skillConfig.PvPDecreaseSuperArmor[hitpoint];
					}
				}
				else
				{
					bool flag5 = hitpoint >= skillConfig.PhysicalRatio.Count || hitpoint >= skillConfig.PhysicalFixed.Count || hitpoint >= skillConfig.MagicRatio.Count || hitpoint >= skillConfig.MagicFixed.Count || hitpoint >= skillConfig.PercentDamage.Count;
					if (flag5)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Error: skill ", skillConfig.SkillScript, " hitpoint ", hitpoint.ToString(), " out of range", null);
						return skillEffect;
					}
					skillEffect.PhyRatio = (double)(skillConfig.PhysicalRatio[hitpoint, 0] + skillConfig.PhysicalRatio[hitpoint, 1] * level);
					skillEffect.PhyFixed = (double)(skillConfig.PhysicalFixed[hitpoint, 0] + skillConfig.PhysicalFixed[hitpoint, 1] * level);
					skillEffect.MagRatio = (double)(skillConfig.MagicRatio[hitpoint, 0] + skillConfig.MagicRatio[hitpoint, 1] * level);
					skillEffect.MagFixed = (double)(skillConfig.MagicFixed[hitpoint, 0] + skillConfig.MagicFixed[hitpoint, 1] * level);
					skillEffect.PercentDamage = (double)(skillConfig.PercentDamage[hitpoint, 0] + skillConfig.PercentDamage[hitpoint, 1] * level);
					bool flag6 = skillConfig.DecreaseSuperArmor != null && hitpoint < skillConfig.DecreaseSuperArmor.Length;
					if (flag6)
					{
						skillEffect.DecSuperArmor = (float)skillConfig.DecreaseSuperArmor[hitpoint];
					}
				}
				bool flag7 = skillConfig.AddBuffPoint != null;
				if (flag7)
				{
					for (int i = 0; i < skillConfig.AddBuffPoint.Length; i++)
					{
						bool flag8 = (int)skillConfig.AddBuffPoint[i] == hitpoint;
						if (flag8)
						{
							bool flag9 = i < skillConfig.BuffID.Count && (skillFlags == null || skillFlags.IsFlagSet((uint)skillConfig.BuffID[i, 2]));
							if (flag9)
							{
								bool flag10 = skillEffect.Buffs == null;
								if (flag10)
								{
									skillEffect.Buffs = new List<BuffDesc>();
								}
								BuffDesc item;
								item.BuffID = skillConfig.BuffID[i, 0];
								item.BuffLevel = (int)((skillConfig.BuffID[i, 1] == 0) ? level : ((uint)skillConfig.BuffID[i, 1]));
								item.CasterID = 0UL;
								item.DelayTime = 0f;
								item.EffectTime = BuffDesc.DEFAULT_TIME;
								item.SkillID = skillHash;
								skillEffect.Buffs.Add(item);
							}
							else
							{
								XSingleton<XDebug>.singleton.AddLog("Error: skill ", skillConfig.SkillScript, " index ", i.ToString(), " buff out of range ", skillConfig.BuffID.Count.ToString(), XDebugColor.XDebug_None);
							}
						}
					}
				}
				skillEffect.ExclusiveMask = 0U;
				bool flag11 = skillConfig.ExclusiveMask != null;
				if (flag11)
				{
					for (int j = 0; j < skillConfig.ExclusiveMask.Length; j++)
					{
						skillEffect.ExclusiveMask |= 1U << (int)skillConfig.ExclusiveMask[j];
					}
				}
				result = skillEffect;
			}
			return result;
		}

		// Token: 0x0600C7B0 RID: 51120 RVA: 0x002CA4E4 File Offset: 0x002C86E4
		public List<uint> GetProfSkillID(int profID)
		{
			bool flag = this.ret == null;
			if (flag)
			{
				this.ret = new List<uint>();
			}
			bool flag2 = this.repeatHash == null;
			if (flag2)
			{
				this.repeatHash = new HashSet<uint>();
			}
			this.ret.Clear();
			this.repeatHash.Clear();
			for (int i = 0; i < this._skillTable.Table.Length; i++)
			{
				SkillList.RowData rowData = this._skillTable.Table[i];
				bool flag3 = rowData != null && rowData.Profession == profID && rowData.IsBasicSkill == 0;
				if (flag3)
				{
					bool flag4 = !this.repeatHash.Contains(rowData.SkillScriptHash);
					if (flag4)
					{
						this.ret.Add(rowData.SkillScriptHash);
						this.repeatHash.Add(rowData.SkillScriptHash);
					}
				}
			}
			return this.ret;
		}

		// Token: 0x0600C7B1 RID: 51121 RVA: 0x002CA5D8 File Offset: 0x002C87D8
		public int GetSkillType(uint skillID)
		{
			SkillList.RowData skillConfig = this.GetSkillConfig(skillID, 0U);
			bool flag = skillConfig != null;
			int result;
			if (flag)
			{
				result = (int)skillConfig.SkillType;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x0600C7B2 RID: 51122 RVA: 0x002CA608 File Offset: 0x002C8808
		public uint GetSkillID(string skillName, uint statisticsID = 0U)
		{
			uint num = XSingleton<XCommon>.singleton.XHash(skillName);
			SkillList.RowData skillConfig = this.GetSkillConfig(num, 0U, statisticsID);
			bool flag = skillConfig == null;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				result = num;
			}
			return result;
		}

		// Token: 0x0600C7B3 RID: 51123 RVA: 0x002CA640 File Offset: 0x002C8840
		public void SetMobProperty(XEntity mobEntity, XEntity caster, uint skillID)
		{
			bool flag = mobEntity == null || caster == null || mobEntity.Attributes == null || caster.Attributes == null;
			if (!flag)
			{
				XAttributes attributes = mobEntity.Attributes;
				XAttributes attributes2 = caster.Attributes;
				attributes.Level = attributes2.Level;
				attributes.SetAttr(XAttributeDefine.XAttr_MaxHP_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_MaxHP_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_CurrentHP_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_MaxHP_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_PhysicalAtk_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_PhysicalAtk_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_MagicAtk_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_MagicAtk_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_PhysicalAtkMod_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_PhysicalAtkMod_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_MagicAtkMod_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_MagicAtkMod_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_PhysicalDefMod_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_PhysicalDefMod_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_MagicDefMod_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_MagicDefMod_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_Critical_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_Critical_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_CritDamage_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_CritDamage_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_CritResist_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_CritResist_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_FireAtk_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_FireAtk_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_WaterAtk_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_WaterAtk_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_LightAtk_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_LightAtk_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_DarkAtk_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_DarkAtk_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_FireDef_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_FireDef_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_WaterDef_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_WaterDef_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_LightDef_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_LightDef_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_DarkDef_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_DarkDef_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_Strength_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_Strength_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_Agility_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_Agility_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_Intelligence_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_Intelligence_Basic));
				attributes.SetAttr(XAttributeDefine.XAttr_Vitality_Basic, attributes2.GetAttr(XAttributeDefine.XAttr_Vitality_Basic));
				attributes.SetHost(caster);
				uint skillLevel = attributes2.SkillLevelInfo.GetSkillLevel(skillID);
				SkillList.RowData skillConfig = this.GetSkillConfig(skillID, skillLevel, caster.SkillCasterTypeID);
				bool flag2 = skillConfig == null;
				if (!flag2)
				{
					CombatEffectHelper data = XDataPool<CombatEffectHelper>.GetData();
					data.Set(skillID, caster);
					bool flag3 = (skillConfig == null || skillConfig.MobBuffs == null) && !data.bHasEffect(CombatEffectType.CET_Skill_AddMobBuff);
					if (flag3)
					{
						data.Recycle();
					}
					else
					{
						List<BuffDesc> list = ListPool<BuffDesc>.Get();
						bool flag4 = data != null;
						if (flag4)
						{
							data.GetSkillAddMobBuff((int)skillLevel, list);
						}
						bool flag5 = skillConfig.MobBuffs != null;
						if (flag5)
						{
							for (int i = 0; i < skillConfig.MobBuffs.Length; i++)
							{
								list.Add(new BuffDesc
								{
									BuffID = (int)skillConfig.MobBuffs[i],
									BuffLevel = (int)skillLevel,
									EffectTime = BuffDesc.DEFAULT_TIME
								});
							}
						}
						for (int j = 0; j < list.Count; j++)
						{
							XBuffAddEventArgs @event = XEventPool<XBuffAddEventArgs>.GetEvent();
							@event.xBuffDesc = list[j];
							@event.xBuffDesc.CasterID = mobEntity.ID;
							@event.Firer = mobEntity;
							XSingleton<XEventMgr>.singleton.FireEvent(@event);
						}
						ListPool<BuffDesc>.Release(list);
						data.Recycle();
					}
				}
			}
		}

		// Token: 0x0600C7B4 RID: 51124 RVA: 0x002CA978 File Offset: 0x002C8B78
		public uint GetPreSkill(uint skillID, uint entityTempID)
		{
			uint num = 0U;
			bool flag = entityTempID > 0U;
			if (flag)
			{
				ulong key = (ulong)skillID << 32 | (ulong)entityTempID;
				bool flag2 = this._specialEnemyPreSkillDict.TryGetValue(key, out num);
				if (flag2)
				{
					return num;
				}
			}
			bool flag3 = this.PreSkillDict.TryGetValue(skillID, out num);
			uint result;
			if (flag3)
			{
				result = num;
			}
			else
			{
				result = 0U;
			}
			return result;
		}

		// Token: 0x0600C7B5 RID: 51125 RVA: 0x002CA9D4 File Offset: 0x002C8BD4
		public bool CanChangeCD(uint skillHash, uint skillLevel, uint entityTempID)
		{
			SkillList.RowData skillConfig = this.GetSkillConfig(skillHash, skillLevel, entityTempID);
			bool flag = skillConfig == null;
			return !flag && skillConfig.UnchangableCD == 0;
		}

		// Token: 0x0600C7B6 RID: 51126 RVA: 0x002CAA08 File Offset: 0x002C8C08
		public bool AICantCast(uint skillHash, uint skillLevel, uint entityTempID)
		{
			SkillList.RowData skillConfig = this.GetSkillConfig(skillHash, skillLevel, entityTempID);
			bool flag = skillConfig == null;
			return !flag && skillConfig.LinkType == 1;
		}

		// Token: 0x0600C7B7 RID: 51127 RVA: 0x002CAA3C File Offset: 0x002C8C3C
		public float GetRemainingCDNotify(uint skillHash, uint skillLevel, uint entityTempID)
		{
			SkillList.RowData skillConfig = this.GetSkillConfig(skillHash, skillLevel, entityTempID);
			bool flag = skillConfig == null;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				result = skillConfig.RemainingCDNotify;
			}
			return result;
		}

		// Token: 0x0600C7B8 RID: 51128 RVA: 0x002CAA70 File Offset: 0x002C8C70
		public int GetStrengthValue(uint skillHash, uint skillLevel, uint entityTempID)
		{
			SkillList.RowData skillConfig = this.GetSkillConfig(skillHash, skillLevel, entityTempID);
			bool flag = skillConfig == null;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				result = skillConfig.StrengthValue;
			}
			return result;
		}

		// Token: 0x0600C7B9 RID: 51129 RVA: 0x002CAAA0 File Offset: 0x002C8CA0
		public int GetUsageCount(uint skillHash, uint skillLevel, uint entityTempID)
		{
			SkillList.RowData skillConfig = this.GetSkillConfig(skillHash, skillLevel, entityTempID);
			bool flag = skillConfig == null;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				result = (int)skillConfig.UsageCount;
			}
			return result;
		}

		// Token: 0x040057E9 RID: 22505
		private XTableAsyncLoader _async_loader = null;

		// Token: 0x040057EA RID: 22506
		private SkillList _skillTable = new SkillList();

		// Token: 0x040057EB RID: 22507
		public Dictionary<uint, uint> PreSkillDict = new Dictionary<uint, uint>(200);

		// Token: 0x040057EC RID: 22508
		private Dictionary<ulong, uint> _specialEnemyPreSkillDict = new Dictionary<ulong, uint>();

		// Token: 0x040057ED RID: 22509
		public uint EmptySkillHash = XSingleton<XCommon>.singleton.XHash("E");

		// Token: 0x040057EE RID: 22510
		private static CVSReader.RowDataCompare<SkillList.RowData, uint> comp = new CVSReader.RowDataCompare<SkillList.RowData, uint>(XSkillEffectMgr.SkillDataCompare);

		// Token: 0x040057EF RID: 22511
		private SkillLevelupRequest req = null;

		// Token: 0x040057F0 RID: 22512
		private SkillEffect m_SkillEffect = new SkillEffect();

		// Token: 0x040057F1 RID: 22513
		private List<uint> ret = null;

		// Token: 0x040057F2 RID: 22514
		private HashSet<uint> repeatHash = null;
	}
}

using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008A5 RID: 2213
	internal struct XBuffModifyEffect
	{
		// Token: 0x06008623 RID: 34339 RVA: 0x0010DAF8 File Offset: 0x0010BCF8
		public bool TryCreate(CombatEffectHelper pEffectHelper, XBuff buff)
		{
			BuffTable.RowData buffInfo = pEffectHelper.BuffInfo;
			bool flag = buffInfo.CostModify != 0f;
			if (flag)
			{
				this.m_CostModify += (double)buffInfo.CostModify - 1.0;
			}
			double num = 0.0;
			double num2 = 0.0;
			pEffectHelper.GetBuffChangeDamage(out num, out num2);
			num += (double)buffInfo.ChangeDamage[0];
			num2 += (double)buffInfo.ChangeDamage[1];
			bool flag2 = num != 0.0;
			if (flag2)
			{
				this.m_CastDamageModify += num - 1.0;
			}
			bool flag3 = num2 != 0.0;
			if (flag3)
			{
				bool flag4 = num2 > 1.0;
				if (flag4)
				{
					this.m_IncReceivedDamageModify += num2 - 1.0;
				}
				else
				{
					this.m_DecReceivedDamageModify += num2 - 1.0;
				}
			}
			bool flag5 = buffInfo.ChangeSkillDamage.Count > 0;
			if (flag5)
			{
				bool flag6 = this.m_ChangeSkillDamage == null;
				if (flag6)
				{
					this.m_ChangeSkillDamage = DictionaryPool<uint, double>.Get();
				}
				for (int i = 0; i < buffInfo.ChangeSkillDamage.Count; i++)
				{
					uint num3 = XSingleton<XCommon>.singleton.XHash(buffInfo.ChangeSkillDamage[i, 0]);
					double num4 = double.Parse(buffInfo.ChangeSkillDamage[i, 1]) / 100.0;
					bool flag7 = this.m_ChangeSkillDamage.ContainsKey(num3);
					if (flag7)
					{
						Dictionary<uint, double> changeSkillDamage = this.m_ChangeSkillDamage;
						uint key = num3;
						changeSkillDamage[key] += num4;
					}
					else
					{
						this.m_ChangeSkillDamage[num3] = num4;
					}
				}
			}
			bool flag8 = pEffectHelper.bHasEffect(CombatEffectType.CET_Buff_ChangeSkillDamage);
			if (flag8)
			{
				bool flag9 = this.m_ChangeSkillDamage == null;
				if (flag9)
				{
					this.m_ChangeSkillDamage = DictionaryPool<uint, double>.Get();
				}
				SequenceList<uint> sequenceList = CommonObjectPool<SequenceList<uint>>.Get();
				pEffectHelper.GetBuffChangeSkillDamage(sequenceList);
				for (int j = 0; j < sequenceList.Count; j++)
				{
					uint num5 = sequenceList[j, 0];
					double num6 = sequenceList[j, 1] / 100.0;
					bool flag10 = this.m_ChangeSkillDamage.ContainsKey(num5);
					if (flag10)
					{
						Dictionary<uint, double> changeSkillDamage = this.m_ChangeSkillDamage;
						uint key = num5;
						changeSkillDamage[key] += num6;
					}
					else
					{
						this.m_ChangeSkillDamage[num5] = num6;
					}
				}
				CommonObjectPool<SequenceList<uint>>.Release(sequenceList);
			}
			return true;
		}

		// Token: 0x06008624 RID: 34340 RVA: 0x0010DDBC File Offset: 0x0010BFBC
		public void Destroy()
		{
			bool flag = this.m_ChangeSkillDamage != null;
			if (flag)
			{
				DictionaryPool<uint, double>.Release(this.m_ChangeSkillDamage);
				this.m_ChangeSkillDamage = null;
			}
		}

		// Token: 0x06008625 RID: 34341 RVA: 0x0010DDEC File Offset: 0x0010BFEC
		public double ModifySkillDamage()
		{
			return this.m_CastDamageModify;
		}

		// Token: 0x06008626 RID: 34342 RVA: 0x0010DE04 File Offset: 0x0010C004
		public double IncReceivedDamage()
		{
			return this.m_IncReceivedDamageModify;
		}

		// Token: 0x06008627 RID: 34343 RVA: 0x0010DE1C File Offset: 0x0010C01C
		public double DecReceivedDamage()
		{
			return this.m_DecReceivedDamageModify;
		}

		// Token: 0x06008628 RID: 34344 RVA: 0x0010DE34 File Offset: 0x0010C034
		public double ModifySkillCost()
		{
			return this.m_CostModify;
		}

		// Token: 0x06008629 RID: 34345 RVA: 0x0010DE4C File Offset: 0x0010C04C
		public double ChangeSkillDamage(uint skillID)
		{
			double num = default;
			bool flag = this.m_ChangeSkillDamage != null && this.m_ChangeSkillDamage.TryGetValue(skillID, out num);
			double result;
			if (flag)
			{
				result = num;
			}
			else
			{
				result = 0.0;
			}
			return result;
		}

		// Token: 0x0600862A RID: 34346 RVA: 0x0010DE8C File Offset: 0x0010C08C
		private void _RefreshSecuriy(XBuff buff)
		{
			bool flag = buff.BuffComponent == null;
			if (!flag)
			{
				bool flag2 = this.m_DecReceivedDamageModify == 0.0;
				if (!flag2)
				{
					XSecurityBuffInfo xsecurityBuffInfo = XSecurityBuffInfo.TryGetStatistics(buff.BuffComponent.Entity);
					bool flag3 = xsecurityBuffInfo != null;
					if (flag3)
					{
						xsecurityBuffInfo.OnReduceDamage(buff, -this.m_DecReceivedDamageModify);
					}
				}
			}
		}

		// Token: 0x0600862B RID: 34347 RVA: 0x0010DEEA File Offset: 0x0010C0EA
		public void OnRemove(XBuff buff)
		{
			this._RefreshSecuriy(buff);
		}

		// Token: 0x0600862C RID: 34348 RVA: 0x0010DEEA File Offset: 0x0010C0EA
		public void OnBattleEnd(XBuff buff)
		{
			this._RefreshSecuriy(buff);
		}

		// Token: 0x040029CF RID: 10703
		private double m_CostModify;

		// Token: 0x040029D0 RID: 10704
		private double m_CastDamageModify;

		// Token: 0x040029D1 RID: 10705
		private double m_IncReceivedDamageModify;

		// Token: 0x040029D2 RID: 10706
		private double m_DecReceivedDamageModify;

		// Token: 0x040029D3 RID: 10707
		private Dictionary<uint, double> m_ChangeSkillDamage;
	}
}

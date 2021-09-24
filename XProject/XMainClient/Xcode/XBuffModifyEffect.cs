using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal struct XBuffModifyEffect
	{

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

		public void Destroy()
		{
			bool flag = this.m_ChangeSkillDamage != null;
			if (flag)
			{
				DictionaryPool<uint, double>.Release(this.m_ChangeSkillDamage);
				this.m_ChangeSkillDamage = null;
			}
		}

		public double ModifySkillDamage()
		{
			return this.m_CastDamageModify;
		}

		public double IncReceivedDamage()
		{
			return this.m_IncReceivedDamageModify;
		}

		public double DecReceivedDamage()
		{
			return this.m_DecReceivedDamageModify;
		}

		public double ModifySkillCost()
		{
			return this.m_CostModify;
		}

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

		public void OnRemove(XBuff buff)
		{
			this._RefreshSecuriy(buff);
		}

		public void OnBattleEnd(XBuff buff)
		{
			this._RefreshSecuriy(buff);
		}

		private double m_CostModify;

		private double m_CastDamageModify;

		private double m_IncReceivedDamageModify;

		private double m_DecReceivedDamageModify;

		private Dictionary<uint, double> m_ChangeSkillDamage;
	}
}

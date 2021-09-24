using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCombatStatisticsInfo : XDataBase, IComparable<XCombatStatisticsInfo>
	{

		public void CutName()
		{
			bool flag = this.name != null && this.name.Length > 5;
			if (flag)
			{
				this.name = this.name.Substring(0, 4) + "..";
			}
		}

		public bool Set(XSecuritySkillInfo.SkillInfo skillInfo, XEntity entity, XSecuritySkillInfo.SkillInfo resetInfo)
		{
			return this.Set(skillInfo._SkillID, skillInfo._CastCount, (double)skillInfo._AttackTotal, entity, resetInfo);
		}

		public bool Set(uint _id, int _count, double _value, XEntity entity, XSecuritySkillInfo.SkillInfo resetInfo)
		{
			this.id = _id;
			this.value = _value;
			this.count = _count;
			bool flag = resetInfo != null && resetInfo._SkillID == this.id;
			if (flag)
			{
				this.value -= (double)resetInfo._AttackTotal;
				this.count -= resetInfo._CastCount;
			}
			bool flag2 = this.value < 0.0010000000474974513;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				uint preSkill = XSingleton<XSkillEffectMgr>.singleton.GetPreSkill(this.id, entity.SkillCasterTypeID);
				bool flag3 = preSkill > 0U;
				if (flag3)
				{
					this.id = preSkill;
				}
				SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(this.id, 1U, entity.SkillCasterTypeID);
				bool flag4 = skillConfig != null;
				if (flag4)
				{
					this.name = skillConfig.ScriptName;
				}
				this.CutName();
				result = true;
			}
			return result;
		}

		public bool Set(XSecurityMobInfo.MobInfo mobInfo, XEntity entity, XSecurityMobInfo.MobInfo resetInfo)
		{
			return this.Set(mobInfo._TemplateID, mobInfo._CastCount, (double)mobInfo._AttackTotal, entity, resetInfo);
		}

		public bool Set(uint _id, int _count, double _value, XEntity entity, XSecurityMobInfo.MobInfo resetInfo)
		{
			this.id = _id;
			this.value = _value;
			this.count = _count;
			bool flag = resetInfo != null && resetInfo._TemplateID == this.id;
			if (flag)
			{
				this.value -= (double)resetInfo._AttackTotal;
				this.count -= resetInfo._CastCount;
			}
			bool flag2 = this.value < 0.0010000000474974513;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this.id);
				bool flag3 = byID != null;
				if (flag3)
				{
					this.name = byID.Name;
				}
				this.CutName();
				result = true;
			}
			return result;
		}

		public void MergeValue(XCombatStatisticsInfo other)
		{
			this.value += other.value;
		}

		public int CompareTo(XCombatStatisticsInfo other)
		{
			int num = -this.value.CompareTo(other.value);
			bool flag = num == 0;
			if (flag)
			{
				num = -this.count.CompareTo(other.count);
			}
			bool flag2 = num == 0;
			if (flag2)
			{
				num = this.id.CompareTo(other.id);
			}
			return num;
		}

		public override void Init()
		{
			base.Init();
			this.id = 0U;
			this.name = string.Empty;
			this.count = 0;
			this.value = 0.0;
			this.percent = 0f;
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XCombatStatisticsInfo>.Recycle(this);
		}

		public uint id;

		public string name;

		public int count;

		public double value;

		public float percent;
	}
}

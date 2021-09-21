using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008D2 RID: 2258
	internal class XCombatStatisticsInfo : XDataBase, IComparable<XCombatStatisticsInfo>
	{
		// Token: 0x0600889D RID: 34973 RVA: 0x0011B700 File Offset: 0x00119900
		public void CutName()
		{
			bool flag = this.name != null && this.name.Length > 5;
			if (flag)
			{
				this.name = this.name.Substring(0, 4) + "..";
			}
		}

		// Token: 0x0600889E RID: 34974 RVA: 0x0011B74C File Offset: 0x0011994C
		public bool Set(XSecuritySkillInfo.SkillInfo skillInfo, XEntity entity, XSecuritySkillInfo.SkillInfo resetInfo)
		{
			return this.Set(skillInfo._SkillID, skillInfo._CastCount, (double)skillInfo._AttackTotal, entity, resetInfo);
		}

		// Token: 0x0600889F RID: 34975 RVA: 0x0011B77C File Offset: 0x0011997C
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

		// Token: 0x060088A0 RID: 34976 RVA: 0x0011B864 File Offset: 0x00119A64
		public bool Set(XSecurityMobInfo.MobInfo mobInfo, XEntity entity, XSecurityMobInfo.MobInfo resetInfo)
		{
			return this.Set(mobInfo._TemplateID, mobInfo._CastCount, (double)mobInfo._AttackTotal, entity, resetInfo);
		}

		// Token: 0x060088A1 RID: 34977 RVA: 0x0011B894 File Offset: 0x00119A94
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

		// Token: 0x060088A2 RID: 34978 RVA: 0x0011B94D File Offset: 0x00119B4D
		public void MergeValue(XCombatStatisticsInfo other)
		{
			this.value += other.value;
		}

		// Token: 0x060088A3 RID: 34979 RVA: 0x0011B964 File Offset: 0x00119B64
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

		// Token: 0x060088A4 RID: 34980 RVA: 0x0011B9BF File Offset: 0x00119BBF
		public override void Init()
		{
			base.Init();
			this.id = 0U;
			this.name = string.Empty;
			this.count = 0;
			this.value = 0.0;
			this.percent = 0f;
		}

		// Token: 0x060088A5 RID: 34981 RVA: 0x0011B9FC File Offset: 0x00119BFC
		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XCombatStatisticsInfo>.Recycle(this);
		}

		// Token: 0x04002B3A RID: 11066
		public uint id;

		// Token: 0x04002B3B RID: 11067
		public string name;

		// Token: 0x04002B3C RID: 11068
		public int count;

		// Token: 0x04002B3D RID: 11069
		public double value;

		// Token: 0x04002B3E RID: 11070
		public float percent;
	}
}

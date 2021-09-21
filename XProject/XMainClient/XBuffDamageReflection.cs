using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200089B RID: 2203
	internal class XBuffDamageReflection : BuffEffect
	{
		// Token: 0x060085F4 RID: 34292 RVA: 0x0010CBBC File Offset: 0x0010ADBC
		public static bool TryCreate(BuffTable.RowData rowData, XBuff buff)
		{
			bool flag = rowData.DamageReflection == 0f;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffDamageReflection(rowData.DamageReflection, buff));
				result = true;
			}
			return result;
		}

		// Token: 0x060085F5 RID: 34293 RVA: 0x0010CBF7 File Offset: 0x0010ADF7
		public XBuffDamageReflection(float ratio, XBuff _Buff)
		{
			this.m_Ratio = ratio;
			this.m_Buff = _Buff;
		}

		// Token: 0x17002A2C RID: 10796
		// (get) Token: 0x060085F6 RID: 34294 RVA: 0x0010CC10 File Offset: 0x0010AE10
		public override XBuffEffectPrioriy Priority
		{
			get
			{
				return XBuffEffectPrioriy.BEP_DamageReflection;
			}
		}

		// Token: 0x060085F7 RID: 34295 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
		}

		// Token: 0x060085F8 RID: 34296 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
		}

		// Token: 0x060085F9 RID: 34297 RVA: 0x0010CC24 File Offset: 0x0010AE24
		public override void OnBuffEffect(HurtInfo rawInput, ProjectDamageResult result)
		{
			double num = (result.BasicDamage * result.DefOriginalRatio + result.TrueDamage) * (double)this.m_Ratio;
			bool flag = num <= 0.0 || (result.Flag & XFastEnumIntEqualityComparer<DamageFlag>.ToInt(DamageFlag.DMGFLAG_REFLECTION)) != 0;
			if (!flag)
			{
				XCombat.ProjectExternalDamage(num, rawInput.Target.ID, rawInput.Caster, !this.m_Buff.BuffInfo.DontShowText, XFastEnumIntEqualityComparer<DamageFlag>.ToInt(DamageFlag.DMGFLAG_REFLECTION));
			}
		}

		// Token: 0x040029B3 RID: 10675
		private float m_Ratio;

		// Token: 0x040029B4 RID: 10676
		private XBuff m_Buff;
	}
}

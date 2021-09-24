using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffDamageReflection : BuffEffect
	{

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

		public XBuffDamageReflection(float ratio, XBuff _Buff)
		{
			this.m_Ratio = ratio;
			this.m_Buff = _Buff;
		}

		public override XBuffEffectPrioriy Priority
		{
			get
			{
				return XBuffEffectPrioriy.BEP_DamageReflection;
			}
		}

		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
		}

		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
		}

		public override void OnBuffEffect(HurtInfo rawInput, ProjectDamageResult result)
		{
			double num = (result.BasicDamage * result.DefOriginalRatio + result.TrueDamage) * (double)this.m_Ratio;
			bool flag = num <= 0.0 || (result.Flag & XFastEnumIntEqualityComparer<DamageFlag>.ToInt(DamageFlag.DMGFLAG_REFLECTION)) != 0;
			if (!flag)
			{
				XCombat.ProjectExternalDamage(num, rawInput.Target.ID, rawInput.Caster, !this.m_Buff.BuffInfo.DontShowText, XFastEnumIntEqualityComparer<DamageFlag>.ToInt(DamageFlag.DMGFLAG_REFLECTION));
			}
		}

		private float m_Ratio;

		private XBuff m_Buff;
	}
}

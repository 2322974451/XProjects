using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D4B RID: 3403
	internal class AttackApplyCritical : AttackApplyState
	{
		// Token: 0x0600BC32 RID: 48178 RVA: 0x0026C958 File Offset: 0x0026AB58
		public override int GetStateMask()
		{
			return XFastEnumIntEqualityComparer<DamageFlag>.ToInt(DamageFlag.DMGFLAG_CRITICAL);
		}

		// Token: 0x0600BC33 RID: 48179 RVA: 0x0026C970 File Offset: 0x0026AB70
		public override bool IsApplyState(XEntity entity)
		{
			double num = XSingleton<XCombat>.singleton.GetBaseCriticalProb(entity.Attributes, entity.Attributes.GetAttr(XAttributeDefine.XAttr_Critical_Total));
			bool flag = num > XSingleton<XGlobalConfig>.singleton.CriticalLimit;
			if (flag)
			{
				num = XSingleton<XGlobalConfig>.singleton.CriticalLimit;
			}
			float num2 = XSingleton<XCommon>.singleton.RandomFloat(0f, 1f);
			return (double)num2 < num;
		}

		// Token: 0x0600BC34 RID: 48180 RVA: 0x0026C9DC File Offset: 0x0026ABDC
		public override bool IsDefenseState(XEntity entity)
		{
			XAttributes attributes = entity.Attributes;
			double attr = attributes.GetAttr(XAttributeDefine.XAttr_CritResist_Total);
			CombatParamTable.RowData combatParam = XSingleton<XCombat>.singleton.GetCombatParam(attributes.Level);
			double num = attr / (attr + (double)combatParam.CritResistBase);
			bool flag = num > XSingleton<XGlobalConfig>.singleton.CritResistLimit;
			if (flag)
			{
				num = XSingleton<XGlobalConfig>.singleton.CritResistLimit;
			}
			float num2 = XSingleton<XCommon>.singleton.RandomFloat(0f, 1f);
			return (double)num2 < num;
		}

		// Token: 0x0600BC35 RID: 48181 RVA: 0x0026CA5C File Offset: 0x0026AC5C
		public override void ApplyState(XEntity caster, ProjectDamageResult result)
		{
			base.ApplyState(caster, result);
			result.Value *= XSingleton<XCombat>.singleton.GetCritialRatio(caster.Attributes);
		}
	}
}

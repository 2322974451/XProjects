using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D4C RID: 3404
	internal class AttackApplyStun : AttackApplyState
	{
		// Token: 0x0600BC37 RID: 48183 RVA: 0x0026CA90 File Offset: 0x0026AC90
		public override int GetStateMask()
		{
			return XFastEnumIntEqualityComparer<DamageFlag>.ToInt(DamageFlag.DMGFLAG_STUN);
		}

		// Token: 0x0600BC38 RID: 48184 RVA: 0x0026CAA8 File Offset: 0x0026ACA8
		public override bool IsApplyState(XEntity entity)
		{
			XAttributes attributes = entity.Attributes;
			double attr = attributes.GetAttr(XAttributeDefine.XAttr_Stun_Total);
			CombatParamTable.RowData combatParam = XSingleton<XCombat>.singleton.GetCombatParam(attributes.Level);
			double num = attr / (attr + (double)combatParam.StunBase);
			bool flag = num > XSingleton<XGlobalConfig>.singleton.StunLimit;
			if (flag)
			{
				num = XSingleton<XGlobalConfig>.singleton.StunLimit;
			}
			float num2 = XSingleton<XCommon>.singleton.RandomFloat(0f, 1f);
			return (double)num2 < num;
		}

		// Token: 0x0600BC39 RID: 48185 RVA: 0x0026CB28 File Offset: 0x0026AD28
		public override bool IsDefenseState(XEntity entity)
		{
			XAttributes attributes = entity.Attributes;
			double attr = attributes.GetAttr(XAttributeDefine.XAttr_StunResist_Total);
			CombatParamTable.RowData combatParam = XSingleton<XCombat>.singleton.GetCombatParam(attributes.Level);
			double num = attr / (attr + (double)combatParam.StunResistBase);
			bool flag = num > XSingleton<XGlobalConfig>.singleton.StunResistLimit;
			if (flag)
			{
				num = XSingleton<XGlobalConfig>.singleton.StunResistLimit;
			}
			float num2 = XSingleton<XCommon>.singleton.RandomFloat(0f, 1f);
			return (double)num2 < num;
		}

		// Token: 0x0600BC3A RID: 48186 RVA: 0x0026CBA8 File Offset: 0x0026ADA8
		public override void ApplyState(XEntity caster, ProjectDamageResult result)
		{
			result.SetResult(ProjectResultType.PJRES_STUN);
		}
	}
}

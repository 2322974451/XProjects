using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AttackApplyCritical : AttackApplyState
	{

		public override int GetStateMask()
		{
			return XFastEnumIntEqualityComparer<DamageFlag>.ToInt(DamageFlag.DMGFLAG_CRITICAL);
		}

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

		public override void ApplyState(XEntity caster, ProjectDamageResult result)
		{
			base.ApplyState(caster, result);
			result.Value *= XSingleton<XCombat>.singleton.GetCritialRatio(caster.Attributes);
		}
	}
}

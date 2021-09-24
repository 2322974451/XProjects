using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AttackApplyStun : AttackApplyState
	{

		public override int GetStateMask()
		{
			return XFastEnumIntEqualityComparer<DamageFlag>.ToInt(DamageFlag.DMGFLAG_STUN);
		}

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

		public override void ApplyState(XEntity caster, ProjectDamageResult result)
		{
			result.SetResult(ProjectResultType.PJRES_STUN);
		}
	}
}

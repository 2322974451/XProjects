using System;

namespace XMainClient
{

	internal enum XAttributeDefine
	{

		XAttr_Invalid = -1,

		XAttr_Strength_Basic = 1,

		XAttr_Strength_Percent = 1001,

		XAttr_Strength_Total = 2001,

		XAttr_Agility_Basic = 2,

		XAttr_Agility_Percent = 1002,

		XAttr_Agility_Total = 2002,

		XAttr_Intelligence_Basic = 3,

		XAttr_Intelligence_Percent = 1003,

		XAttr_Intelligence_Total = 2003,

		XAttr_Vitality_Basic = 4,

		XAttr_Vitality_Percent = 1004,

		XAttr_Vitality_Total = 2004,

		XAttr_CombatScore_Basic = 5,

		XAttr_CombatScore_Percent = 1005,

		XAttr_CombatScore_Total = 2005,

		XAttr_PhysicalAtk_Basic = 11,

		XAttr_PhysicalAtk_Percent = 1011,

		XAttr_PhysicalAtk_Total = 2011,

		XAttr_PhysicalDef_Basic = 12,

		XAttr_PhysicalDef_Percent = 1012,

		XAttr_PhysicalDef_Total = 2012,

		XAttr_MaxHP_Basic = 13,

		XAttr_MaxHP_Percent = 1013,

		XAttr_MaxHP_Total = 2013,

		XAttr_CurrentHP_Basic = 14,

		XAttr_CurrentHP_Percent = 1014,

		XAttr_CurrentHP_Total = 2014,

		XAttr_HPRecovery_Basic = 15,

		XAttr_HPRecovery_Percent = 1015,

		XAttr_HPRecovery_Total = 2015,

		XAttr_PhysicalAtkMod_Basic = 16,

		XAttr_PhysicalAtkMod_Percent = 1016,

		XAttr_PhysicalAtkMod_Total = 2016,

		XAttr_PhysicalDefMod_Basic = 17,

		XAttr_PhysicalDefMod_Percent = 1017,

		XAttr_PhysicalDefMod_Total = 2017,

		XAttr_MaxSuperArmor_Basic = 18,

		XAttr_MaxSuperArmor_Percent = 1018,

		XAttr_MaxSuperArmor_Total = 2018,

		XAttr_CurrentSuperArmor_Basic = 19,

		XAttr_CurrentSuperArmor_Percent = 1019,

		XAttr_CurrentSuperArmor_Total = 2019,

		XAttr_SuperArmorRecovery_Basic = 20,

		XAttr_SuperArmorRecovery_Percent = 1020,

		XAttr_SuperArmorRecovery_Total = 2020,

		XAttr_SuperArmorAtk_Basic = 52,

		XAttr_SuperArmorAtk_Percent = 1052,

		XAttr_SuperArmorAtk_Total = 2052,

		XAttr_SuperArmorDef_Basic = 53,

		XAttr_SuperArmorDef_Percent = 1053,

		XAttr_SuperArmorDef_Total = 2053,

		XAttr_SuperArmorReg_Basic = 54,

		XAttr_SuperArmorReg_Percent = 1054,

		XAttr_SuperArmorReg_Total = 2054,

		XAttr_MagicAtk_Basic = 21,

		XAttr_MagicAtk_Percent = 1021,

		XAttr_MagicAtk_Total = 2021,

		XAttr_MagicDef_Basic = 22,

		XAttr_MagicDef_Percent = 1022,

		XAttr_MagicDef_Total = 2022,

		XAttr_MaxMP_Basic = 23,

		XAttr_MaxMP_Percent = 1023,

		XAttr_MaxMP_Total = 2023,

		XAttr_CurrentMP_Basic = 24,

		XAttr_CurrentMP_Percent = 1024,

		XAttr_CurrentMP_Total = 2024,

		XAttr_MPRecovery_Basic = 25,

		XAttr_MPRecovery_Percent = 1025,

		XAttr_MPRecovery_Total = 2025,

		XAttr_MagicAtkMod_Basic = 26,

		XAttr_MagicAtkMod_Percent = 1026,

		XAttr_MagicAtkMod_Total = 2026,

		XAttr_MagicDefMod_Basic = 27,

		XAttr_MagicDefMod_Percent = 1027,

		XAttr_MagicDefMod_Total = 2027,

		XAttr_Critical_Basic = 31,

		XAttr_Critical_Percent = 1031,

		XAttr_Critical_Total = 2031,

		XAttr_CritResist_Basic = 32,

		XAttr_CritResist_Percent = 1032,

		XAttr_CritResist_Total = 2032,

		XAttr_Paralyze_Basic = 33,

		XAttr_Paralyze_Percent = 1033,

		XAttr_Paralyze_Total = 2033,

		XAttr_ParaResist_Basic = 34,

		XAttr_ParaResist_Percent = 1034,

		XAttr_ParaResist_Total = 2034,

		XAttr_Stun_Basic = 35,

		XAttr_Stun_Percent = 1035,

		XAttr_Stun_Total = 2035,

		XAttr_StunResist_Basic = 36,

		XAttr_StunResist_Percent = 1036,

		XAttr_StunResist_Total = 2036,

		XAttr_HurtInc_Basic = 50,

		XAttr_HurtInc_Percent = 1050,

		XAttr_HurtInc_Total = 2050,

		XAttr_CurrentXULI_Basic = 51,

		XAttr_CurrentXULI_Percent = 1051,

		XAttr_CurrentXULI_Total = 2051,

		XAttr_CurrentEnergy_Basic = 55,

		XAttr_CurrentEnergy_Percent = 1055,

		XAttr_CurrentEnergy_Total = 2055,

		XAttr_XULI_Basic = 61,

		XAttr_XULI_Percent = 1061,

		XAttr_XULI_Total = 2061,

		XAttr_CritDamage_Basic = 111,

		XAttr_CritDamage_Percent = 1111,

		XAttr_CritDamage_Total = 2111,

		XAttr_FinalDamage_Basic = 112,

		XAttr_FinalDamage_Percent = 1112,

		XAttr_FinalDamage_Total = 2112,

		XAttr_TrueDamage_Basic = 113,

		XAttr_TrueDamage_Percent = 1113,

		XAttr_TrueDamage_Total = 2113,

		XAttr_FireAtk_Basic = 121,

		XAttr_FireAtk_Percent = 1121,

		XAttr_FireAtk_Total = 2121,

		XAttr_FireDef_Basic = 122,

		XAttr_FireDef_Percent = 1122,

		XAttr_FireDef_Total = 2122,

		XAttr_WaterAtk_Basic = 123,

		XAttr_WaterAtk_Percent = 1123,

		XAttr_WaterAtk_Total = 2123,

		XAttr_WaterDef_Basic = 124,

		XAttr_WaterDef_Percent = 1124,

		XAttr_WaterDef_Total = 2124,

		XAttr_LightAtk_Basic = 125,

		XAttr_LightAtk_Percent = 1125,

		XAttr_LightAtk_Total = 2125,

		XAttr_LightDef_Basic = 126,

		XAttr_LightDef_Percent = 1126,

		XAttr_LightDef_Total = 2126,

		XAttr_DarkAtk_Basic = 127,

		XAttr_DarkAtk_Percent = 1127,

		XAttr_DarkAtk_Total = 2127,

		XAttr_DarkDef_Basic = 128,

		XAttr_DarkDef_Percent = 1128,

		XAttr_DarkDef_Total = 2128,

		XAttr_VoidAtk_Basic = 129,

		XAttr_VoidAtk_Percent = 1129,

		XAttr_VoidAtk_Total = 2129,

		XAttr_VoidDef_Basic = 130,

		XAttr_VoidDef_Percent = 1130,

		XAttr_VoidDef_Total = 2130,

		XAttr_RUN_SPEED_Basic = 201,

		XAttr_RUN_SPEED_Percent = 1201,

		XAttr_RUN_SPEED_Total = 2201,

		XAttr_WALK_SPEED_Basic = 202,

		XAttr_WALK_SPEED_Percent = 1202,

		XAttr_WALK_SPEED_Total = 2202,

		XAttr_DASH_SPEED_Basic = 203,

		XAttr_DASH_SPEED_Percent = 1203,

		XAttr_DASH_SPEED_Total = 2203,

		XAttr_ROTATION_SPEED_Basic = 204,

		XAttr_ROTATION_SPEED_Percent = 1204,

		XAttr_ROTATION_SPEED_Total = 2204,

		XAttr_AUTOROTATION_SPEED_Basic = 205,

		XAttr_AUTOROTATION_SPEED_Percent = 1205,

		XAttr_AUTOROTATION_SPEED_Total = 2205,

		XATTR_ATTACK_SPEED_Basic = 206,

		XATTR_ATTACK_SPEED_Percent = 1206,

		XATTR_ATTACK_SPEED_Total = 2206,

		XATTR_SKILL_CD_Basic = 207,

		XATTR_SKILL_CD_Percent = 1207,

		XATTR_SKILL_CD_Total = 2207,

		XATTR_ENMITY_Basic = 208,

		XATTR_ENMITY_Percent = 1208,

		XATTR_ENMITY_Total = 2208,

		XAttr_POWER_POINT_Basic = 300,

		XAttr_POWER_POINT_Percent = 1300,

		XAttr_POWER_POINT_Total = 2300
	}
}

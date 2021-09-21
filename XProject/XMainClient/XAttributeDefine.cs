using System;

namespace XMainClient
{
	// Token: 0x02000F37 RID: 3895
	internal enum XAttributeDefine
	{
		// Token: 0x04005C59 RID: 23641
		XAttr_Invalid = -1,
		// Token: 0x04005C5A RID: 23642
		XAttr_Strength_Basic = 1,
		// Token: 0x04005C5B RID: 23643
		XAttr_Strength_Percent = 1001,
		// Token: 0x04005C5C RID: 23644
		XAttr_Strength_Total = 2001,
		// Token: 0x04005C5D RID: 23645
		XAttr_Agility_Basic = 2,
		// Token: 0x04005C5E RID: 23646
		XAttr_Agility_Percent = 1002,
		// Token: 0x04005C5F RID: 23647
		XAttr_Agility_Total = 2002,
		// Token: 0x04005C60 RID: 23648
		XAttr_Intelligence_Basic = 3,
		// Token: 0x04005C61 RID: 23649
		XAttr_Intelligence_Percent = 1003,
		// Token: 0x04005C62 RID: 23650
		XAttr_Intelligence_Total = 2003,
		// Token: 0x04005C63 RID: 23651
		XAttr_Vitality_Basic = 4,
		// Token: 0x04005C64 RID: 23652
		XAttr_Vitality_Percent = 1004,
		// Token: 0x04005C65 RID: 23653
		XAttr_Vitality_Total = 2004,
		// Token: 0x04005C66 RID: 23654
		XAttr_CombatScore_Basic = 5,
		// Token: 0x04005C67 RID: 23655
		XAttr_CombatScore_Percent = 1005,
		// Token: 0x04005C68 RID: 23656
		XAttr_CombatScore_Total = 2005,
		// Token: 0x04005C69 RID: 23657
		XAttr_PhysicalAtk_Basic = 11,
		// Token: 0x04005C6A RID: 23658
		XAttr_PhysicalAtk_Percent = 1011,
		// Token: 0x04005C6B RID: 23659
		XAttr_PhysicalAtk_Total = 2011,
		// Token: 0x04005C6C RID: 23660
		XAttr_PhysicalDef_Basic = 12,
		// Token: 0x04005C6D RID: 23661
		XAttr_PhysicalDef_Percent = 1012,
		// Token: 0x04005C6E RID: 23662
		XAttr_PhysicalDef_Total = 2012,
		// Token: 0x04005C6F RID: 23663
		XAttr_MaxHP_Basic = 13,
		// Token: 0x04005C70 RID: 23664
		XAttr_MaxHP_Percent = 1013,
		// Token: 0x04005C71 RID: 23665
		XAttr_MaxHP_Total = 2013,
		// Token: 0x04005C72 RID: 23666
		XAttr_CurrentHP_Basic = 14,
		// Token: 0x04005C73 RID: 23667
		XAttr_CurrentHP_Percent = 1014,
		// Token: 0x04005C74 RID: 23668
		XAttr_CurrentHP_Total = 2014,
		// Token: 0x04005C75 RID: 23669
		XAttr_HPRecovery_Basic = 15,
		// Token: 0x04005C76 RID: 23670
		XAttr_HPRecovery_Percent = 1015,
		// Token: 0x04005C77 RID: 23671
		XAttr_HPRecovery_Total = 2015,
		// Token: 0x04005C78 RID: 23672
		XAttr_PhysicalAtkMod_Basic = 16,
		// Token: 0x04005C79 RID: 23673
		XAttr_PhysicalAtkMod_Percent = 1016,
		// Token: 0x04005C7A RID: 23674
		XAttr_PhysicalAtkMod_Total = 2016,
		// Token: 0x04005C7B RID: 23675
		XAttr_PhysicalDefMod_Basic = 17,
		// Token: 0x04005C7C RID: 23676
		XAttr_PhysicalDefMod_Percent = 1017,
		// Token: 0x04005C7D RID: 23677
		XAttr_PhysicalDefMod_Total = 2017,
		// Token: 0x04005C7E RID: 23678
		XAttr_MaxSuperArmor_Basic = 18,
		// Token: 0x04005C7F RID: 23679
		XAttr_MaxSuperArmor_Percent = 1018,
		// Token: 0x04005C80 RID: 23680
		XAttr_MaxSuperArmor_Total = 2018,
		// Token: 0x04005C81 RID: 23681
		XAttr_CurrentSuperArmor_Basic = 19,
		// Token: 0x04005C82 RID: 23682
		XAttr_CurrentSuperArmor_Percent = 1019,
		// Token: 0x04005C83 RID: 23683
		XAttr_CurrentSuperArmor_Total = 2019,
		// Token: 0x04005C84 RID: 23684
		XAttr_SuperArmorRecovery_Basic = 20,
		// Token: 0x04005C85 RID: 23685
		XAttr_SuperArmorRecovery_Percent = 1020,
		// Token: 0x04005C86 RID: 23686
		XAttr_SuperArmorRecovery_Total = 2020,
		// Token: 0x04005C87 RID: 23687
		XAttr_SuperArmorAtk_Basic = 52,
		// Token: 0x04005C88 RID: 23688
		XAttr_SuperArmorAtk_Percent = 1052,
		// Token: 0x04005C89 RID: 23689
		XAttr_SuperArmorAtk_Total = 2052,
		// Token: 0x04005C8A RID: 23690
		XAttr_SuperArmorDef_Basic = 53,
		// Token: 0x04005C8B RID: 23691
		XAttr_SuperArmorDef_Percent = 1053,
		// Token: 0x04005C8C RID: 23692
		XAttr_SuperArmorDef_Total = 2053,
		// Token: 0x04005C8D RID: 23693
		XAttr_SuperArmorReg_Basic = 54,
		// Token: 0x04005C8E RID: 23694
		XAttr_SuperArmorReg_Percent = 1054,
		// Token: 0x04005C8F RID: 23695
		XAttr_SuperArmorReg_Total = 2054,
		// Token: 0x04005C90 RID: 23696
		XAttr_MagicAtk_Basic = 21,
		// Token: 0x04005C91 RID: 23697
		XAttr_MagicAtk_Percent = 1021,
		// Token: 0x04005C92 RID: 23698
		XAttr_MagicAtk_Total = 2021,
		// Token: 0x04005C93 RID: 23699
		XAttr_MagicDef_Basic = 22,
		// Token: 0x04005C94 RID: 23700
		XAttr_MagicDef_Percent = 1022,
		// Token: 0x04005C95 RID: 23701
		XAttr_MagicDef_Total = 2022,
		// Token: 0x04005C96 RID: 23702
		XAttr_MaxMP_Basic = 23,
		// Token: 0x04005C97 RID: 23703
		XAttr_MaxMP_Percent = 1023,
		// Token: 0x04005C98 RID: 23704
		XAttr_MaxMP_Total = 2023,
		// Token: 0x04005C99 RID: 23705
		XAttr_CurrentMP_Basic = 24,
		// Token: 0x04005C9A RID: 23706
		XAttr_CurrentMP_Percent = 1024,
		// Token: 0x04005C9B RID: 23707
		XAttr_CurrentMP_Total = 2024,
		// Token: 0x04005C9C RID: 23708
		XAttr_MPRecovery_Basic = 25,
		// Token: 0x04005C9D RID: 23709
		XAttr_MPRecovery_Percent = 1025,
		// Token: 0x04005C9E RID: 23710
		XAttr_MPRecovery_Total = 2025,
		// Token: 0x04005C9F RID: 23711
		XAttr_MagicAtkMod_Basic = 26,
		// Token: 0x04005CA0 RID: 23712
		XAttr_MagicAtkMod_Percent = 1026,
		// Token: 0x04005CA1 RID: 23713
		XAttr_MagicAtkMod_Total = 2026,
		// Token: 0x04005CA2 RID: 23714
		XAttr_MagicDefMod_Basic = 27,
		// Token: 0x04005CA3 RID: 23715
		XAttr_MagicDefMod_Percent = 1027,
		// Token: 0x04005CA4 RID: 23716
		XAttr_MagicDefMod_Total = 2027,
		// Token: 0x04005CA5 RID: 23717
		XAttr_Critical_Basic = 31,
		// Token: 0x04005CA6 RID: 23718
		XAttr_Critical_Percent = 1031,
		// Token: 0x04005CA7 RID: 23719
		XAttr_Critical_Total = 2031,
		// Token: 0x04005CA8 RID: 23720
		XAttr_CritResist_Basic = 32,
		// Token: 0x04005CA9 RID: 23721
		XAttr_CritResist_Percent = 1032,
		// Token: 0x04005CAA RID: 23722
		XAttr_CritResist_Total = 2032,
		// Token: 0x04005CAB RID: 23723
		XAttr_Paralyze_Basic = 33,
		// Token: 0x04005CAC RID: 23724
		XAttr_Paralyze_Percent = 1033,
		// Token: 0x04005CAD RID: 23725
		XAttr_Paralyze_Total = 2033,
		// Token: 0x04005CAE RID: 23726
		XAttr_ParaResist_Basic = 34,
		// Token: 0x04005CAF RID: 23727
		XAttr_ParaResist_Percent = 1034,
		// Token: 0x04005CB0 RID: 23728
		XAttr_ParaResist_Total = 2034,
		// Token: 0x04005CB1 RID: 23729
		XAttr_Stun_Basic = 35,
		// Token: 0x04005CB2 RID: 23730
		XAttr_Stun_Percent = 1035,
		// Token: 0x04005CB3 RID: 23731
		XAttr_Stun_Total = 2035,
		// Token: 0x04005CB4 RID: 23732
		XAttr_StunResist_Basic = 36,
		// Token: 0x04005CB5 RID: 23733
		XAttr_StunResist_Percent = 1036,
		// Token: 0x04005CB6 RID: 23734
		XAttr_StunResist_Total = 2036,
		// Token: 0x04005CB7 RID: 23735
		XAttr_HurtInc_Basic = 50,
		// Token: 0x04005CB8 RID: 23736
		XAttr_HurtInc_Percent = 1050,
		// Token: 0x04005CB9 RID: 23737
		XAttr_HurtInc_Total = 2050,
		// Token: 0x04005CBA RID: 23738
		XAttr_CurrentXULI_Basic = 51,
		// Token: 0x04005CBB RID: 23739
		XAttr_CurrentXULI_Percent = 1051,
		// Token: 0x04005CBC RID: 23740
		XAttr_CurrentXULI_Total = 2051,
		// Token: 0x04005CBD RID: 23741
		XAttr_CurrentEnergy_Basic = 55,
		// Token: 0x04005CBE RID: 23742
		XAttr_CurrentEnergy_Percent = 1055,
		// Token: 0x04005CBF RID: 23743
		XAttr_CurrentEnergy_Total = 2055,
		// Token: 0x04005CC0 RID: 23744
		XAttr_XULI_Basic = 61,
		// Token: 0x04005CC1 RID: 23745
		XAttr_XULI_Percent = 1061,
		// Token: 0x04005CC2 RID: 23746
		XAttr_XULI_Total = 2061,
		// Token: 0x04005CC3 RID: 23747
		XAttr_CritDamage_Basic = 111,
		// Token: 0x04005CC4 RID: 23748
		XAttr_CritDamage_Percent = 1111,
		// Token: 0x04005CC5 RID: 23749
		XAttr_CritDamage_Total = 2111,
		// Token: 0x04005CC6 RID: 23750
		XAttr_FinalDamage_Basic = 112,
		// Token: 0x04005CC7 RID: 23751
		XAttr_FinalDamage_Percent = 1112,
		// Token: 0x04005CC8 RID: 23752
		XAttr_FinalDamage_Total = 2112,
		// Token: 0x04005CC9 RID: 23753
		XAttr_TrueDamage_Basic = 113,
		// Token: 0x04005CCA RID: 23754
		XAttr_TrueDamage_Percent = 1113,
		// Token: 0x04005CCB RID: 23755
		XAttr_TrueDamage_Total = 2113,
		// Token: 0x04005CCC RID: 23756
		XAttr_FireAtk_Basic = 121,
		// Token: 0x04005CCD RID: 23757
		XAttr_FireAtk_Percent = 1121,
		// Token: 0x04005CCE RID: 23758
		XAttr_FireAtk_Total = 2121,
		// Token: 0x04005CCF RID: 23759
		XAttr_FireDef_Basic = 122,
		// Token: 0x04005CD0 RID: 23760
		XAttr_FireDef_Percent = 1122,
		// Token: 0x04005CD1 RID: 23761
		XAttr_FireDef_Total = 2122,
		// Token: 0x04005CD2 RID: 23762
		XAttr_WaterAtk_Basic = 123,
		// Token: 0x04005CD3 RID: 23763
		XAttr_WaterAtk_Percent = 1123,
		// Token: 0x04005CD4 RID: 23764
		XAttr_WaterAtk_Total = 2123,
		// Token: 0x04005CD5 RID: 23765
		XAttr_WaterDef_Basic = 124,
		// Token: 0x04005CD6 RID: 23766
		XAttr_WaterDef_Percent = 1124,
		// Token: 0x04005CD7 RID: 23767
		XAttr_WaterDef_Total = 2124,
		// Token: 0x04005CD8 RID: 23768
		XAttr_LightAtk_Basic = 125,
		// Token: 0x04005CD9 RID: 23769
		XAttr_LightAtk_Percent = 1125,
		// Token: 0x04005CDA RID: 23770
		XAttr_LightAtk_Total = 2125,
		// Token: 0x04005CDB RID: 23771
		XAttr_LightDef_Basic = 126,
		// Token: 0x04005CDC RID: 23772
		XAttr_LightDef_Percent = 1126,
		// Token: 0x04005CDD RID: 23773
		XAttr_LightDef_Total = 2126,
		// Token: 0x04005CDE RID: 23774
		XAttr_DarkAtk_Basic = 127,
		// Token: 0x04005CDF RID: 23775
		XAttr_DarkAtk_Percent = 1127,
		// Token: 0x04005CE0 RID: 23776
		XAttr_DarkAtk_Total = 2127,
		// Token: 0x04005CE1 RID: 23777
		XAttr_DarkDef_Basic = 128,
		// Token: 0x04005CE2 RID: 23778
		XAttr_DarkDef_Percent = 1128,
		// Token: 0x04005CE3 RID: 23779
		XAttr_DarkDef_Total = 2128,
		// Token: 0x04005CE4 RID: 23780
		XAttr_VoidAtk_Basic = 129,
		// Token: 0x04005CE5 RID: 23781
		XAttr_VoidAtk_Percent = 1129,
		// Token: 0x04005CE6 RID: 23782
		XAttr_VoidAtk_Total = 2129,
		// Token: 0x04005CE7 RID: 23783
		XAttr_VoidDef_Basic = 130,
		// Token: 0x04005CE8 RID: 23784
		XAttr_VoidDef_Percent = 1130,
		// Token: 0x04005CE9 RID: 23785
		XAttr_VoidDef_Total = 2130,
		// Token: 0x04005CEA RID: 23786
		XAttr_RUN_SPEED_Basic = 201,
		// Token: 0x04005CEB RID: 23787
		XAttr_RUN_SPEED_Percent = 1201,
		// Token: 0x04005CEC RID: 23788
		XAttr_RUN_SPEED_Total = 2201,
		// Token: 0x04005CED RID: 23789
		XAttr_WALK_SPEED_Basic = 202,
		// Token: 0x04005CEE RID: 23790
		XAttr_WALK_SPEED_Percent = 1202,
		// Token: 0x04005CEF RID: 23791
		XAttr_WALK_SPEED_Total = 2202,
		// Token: 0x04005CF0 RID: 23792
		XAttr_DASH_SPEED_Basic = 203,
		// Token: 0x04005CF1 RID: 23793
		XAttr_DASH_SPEED_Percent = 1203,
		// Token: 0x04005CF2 RID: 23794
		XAttr_DASH_SPEED_Total = 2203,
		// Token: 0x04005CF3 RID: 23795
		XAttr_ROTATION_SPEED_Basic = 204,
		// Token: 0x04005CF4 RID: 23796
		XAttr_ROTATION_SPEED_Percent = 1204,
		// Token: 0x04005CF5 RID: 23797
		XAttr_ROTATION_SPEED_Total = 2204,
		// Token: 0x04005CF6 RID: 23798
		XAttr_AUTOROTATION_SPEED_Basic = 205,
		// Token: 0x04005CF7 RID: 23799
		XAttr_AUTOROTATION_SPEED_Percent = 1205,
		// Token: 0x04005CF8 RID: 23800
		XAttr_AUTOROTATION_SPEED_Total = 2205,
		// Token: 0x04005CF9 RID: 23801
		XATTR_ATTACK_SPEED_Basic = 206,
		// Token: 0x04005CFA RID: 23802
		XATTR_ATTACK_SPEED_Percent = 1206,
		// Token: 0x04005CFB RID: 23803
		XATTR_ATTACK_SPEED_Total = 2206,
		// Token: 0x04005CFC RID: 23804
		XATTR_SKILL_CD_Basic = 207,
		// Token: 0x04005CFD RID: 23805
		XATTR_SKILL_CD_Percent = 1207,
		// Token: 0x04005CFE RID: 23806
		XATTR_SKILL_CD_Total = 2207,
		// Token: 0x04005CFF RID: 23807
		XATTR_ENMITY_Basic = 208,
		// Token: 0x04005D00 RID: 23808
		XATTR_ENMITY_Percent = 1208,
		// Token: 0x04005D01 RID: 23809
		XATTR_ENMITY_Total = 2208,
		// Token: 0x04005D02 RID: 23810
		XAttr_POWER_POINT_Basic = 300,
		// Token: 0x04005D03 RID: 23811
		XAttr_POWER_POINT_Percent = 1300,
		// Token: 0x04005D04 RID: 23812
		XAttr_POWER_POINT_Total = 2300
	}
}

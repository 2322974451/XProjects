using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200074A RID: 1866
	[ProtoContract(Name = "RoleType")]
	public enum RoleType
	{
		// Token: 0x040021C4 RID: 8644
		[ProtoEnum(Name = "Role_INVALID", Value = 0)]
		Role_INVALID,
		// Token: 0x040021C5 RID: 8645
		[ProtoEnum(Name = "Role_Warrior", Value = 1)]
		Role_Warrior,
		// Token: 0x040021C6 RID: 8646
		[ProtoEnum(Name = "Role_Archer", Value = 2)]
		Role_Archer,
		// Token: 0x040021C7 RID: 8647
		[ProtoEnum(Name = "Role_Sorceress", Value = 3)]
		Role_Sorceress,
		// Token: 0x040021C8 RID: 8648
		[ProtoEnum(Name = "Role_Cleric", Value = 4)]
		Role_Cleric,
		// Token: 0x040021C9 RID: 8649
		[ProtoEnum(Name = "Role_Academic", Value = 5)]
		Role_Academic,
		// Token: 0x040021CA RID: 8650
		[ProtoEnum(Name = "Role_Swordsman", Value = 11)]
		Role_Swordsman = 11,
		// Token: 0x040021CB RID: 8651
		[ProtoEnum(Name = "Role_Mercenary", Value = 21)]
		Role_Mercenary = 21,
		// Token: 0x040021CC RID: 8652
		[ProtoEnum(Name = "Role_Sharpshooter", Value = 12)]
		Role_Sharpshooter = 12,
		// Token: 0x040021CD RID: 8653
		[ProtoEnum(Name = "Role_Acrobat", Value = 22)]
		Role_Acrobat = 22,
		// Token: 0x040021CE RID: 8654
		[ProtoEnum(Name = "Role_Elementalist", Value = 13)]
		Role_Elementalist = 13,
		// Token: 0x040021CF RID: 8655
		[ProtoEnum(Name = "Role_Mystic", Value = 23)]
		Role_Mystic = 23,
		// Token: 0x040021D0 RID: 8656
		[ProtoEnum(Name = "Role_Paladin", Value = 14)]
		Role_Paladin = 14,
		// Token: 0x040021D1 RID: 8657
		[ProtoEnum(Name = "Role_Priest", Value = 24)]
		Role_Priest = 24,
		// Token: 0x040021D2 RID: 8658
		[ProtoEnum(Name = "Role_Engineer", Value = 15)]
		Role_Engineer = 15,
		// Token: 0x040021D3 RID: 8659
		[ProtoEnum(Name = "Role_Alchemist", Value = 25)]
		Role_Alchemist = 25,
		// Token: 0x040021D4 RID: 8660
		[ProtoEnum(Name = "Role_Gladiator", Value = 111)]
		Role_Gladiator = 111,
		// Token: 0x040021D5 RID: 8661
		[ProtoEnum(Name = "Role_Moonlord", Value = 211)]
		Role_Moonlord = 211,
		// Token: 0x040021D6 RID: 8662
		[ProtoEnum(Name = "Role_Destroyer", Value = 121)]
		Role_Destroyer = 121,
		// Token: 0x040021D7 RID: 8663
		[ProtoEnum(Name = "Role_Barbarian", Value = 221)]
		Role_Barbarian = 221,
		// Token: 0x040021D8 RID: 8664
		[ProtoEnum(Name = "Role_Sniper", Value = 112)]
		Role_Sniper = 112,
		// Token: 0x040021D9 RID: 8665
		[ProtoEnum(Name = "Role_Artillery", Value = 212)]
		Role_Artillery = 212,
		// Token: 0x040021DA RID: 8666
		[ProtoEnum(Name = "Role_Tempest", Value = 122)]
		Role_Tempest = 122,
		// Token: 0x040021DB RID: 8667
		[ProtoEnum(Name = "Role_Windwalker", Value = 222)]
		Role_Windwalker = 222,
		// Token: 0x040021DC RID: 8668
		[ProtoEnum(Name = "Role_Saleana", Value = 113)]
		Role_Saleana = 113,
		// Token: 0x040021DD RID: 8669
		[ProtoEnum(Name = "Role_Elestra", Value = 213)]
		Role_Elestra = 213,
		// Token: 0x040021DE RID: 8670
		[ProtoEnum(Name = "Role_Smasher", Value = 123)]
		Role_Smasher = 123,
		// Token: 0x040021DF RID: 8671
		[ProtoEnum(Name = "Role_Majesty", Value = 223)]
		Role_Majesty = 223,
		// Token: 0x040021E0 RID: 8672
		[ProtoEnum(Name = "Role_Guardian", Value = 114)]
		Role_Guardian = 114,
		// Token: 0x040021E1 RID: 8673
		[ProtoEnum(Name = "Role_Crusader", Value = 214)]
		Role_Crusader = 214,
		// Token: 0x040021E2 RID: 8674
		[ProtoEnum(Name = "Role_Saint", Value = 124)]
		Role_Saint = 124,
		// Token: 0x040021E3 RID: 8675
		[ProtoEnum(Name = "Role_Inquistior", Value = 224)]
		Role_Inquistior = 224,
		// Token: 0x040021E4 RID: 8676
		[ProtoEnum(Name = "Role_Shootingstar", Value = 115)]
		Role_Shootingstar = 115,
		// Token: 0x040021E5 RID: 8677
		[ProtoEnum(Name = "Role_Gearmaster", Value = 215)]
		Role_Gearmaster = 215,
		// Token: 0x040021E6 RID: 8678
		[ProtoEnum(Name = "Role_Adept", Value = 125)]
		Role_Adept = 125,
		// Token: 0x040021E7 RID: 8679
		[ProtoEnum(Name = "Role_Physician", Value = 225)]
		Role_Physician = 225,
		// Token: 0x040021E8 RID: 8680
		[ProtoEnum(Name = "Role_Assassin", Value = 6)]
		Role_Assassin = 6,
		// Token: 0x040021E9 RID: 8681
		[ProtoEnum(Name = "Role_Shinobi", Value = 16)]
		Role_Shinobi = 16,
		// Token: 0x040021EA RID: 8682
		[ProtoEnum(Name = "Role_Taoist", Value = 26)]
		Role_Taoist = 26,
		// Token: 0x040021EB RID: 8683
		[ProtoEnum(Name = "Role_Reaper", Value = 116)]
		Role_Reaper = 116,
		// Token: 0x040021EC RID: 8684
		[ProtoEnum(Name = "Role_Raven", Value = 216)]
		Role_Raven = 216,
		// Token: 0x040021ED RID: 8685
		[ProtoEnum(Name = "Role_LightBringer", Value = 126)]
		Role_LightBringer = 126,
		// Token: 0x040021EE RID: 8686
		[ProtoEnum(Name = "Role_AbyssWalker", Value = 226)]
		Role_AbyssWalker = 226,
		// Token: 0x040021EF RID: 8687
		[ProtoEnum(Name = "Role_Kali", Value = 7)]
		Role_Kali = 7,
		// Token: 0x040021F0 RID: 8688
		[ProtoEnum(Name = "Role_Screamer", Value = 17)]
		Role_Screamer = 17,
		// Token: 0x040021F1 RID: 8689
		[ProtoEnum(Name = "Role_Dancer", Value = 27)]
		Role_Dancer = 27,
		// Token: 0x040021F2 RID: 8690
		[ProtoEnum(Name = "Role_SoulEater", Value = 117)]
		Role_SoulEater = 117,
		// Token: 0x040021F3 RID: 8691
		[ProtoEnum(Name = "Role_DarkSummoner", Value = 217)]
		Role_DarkSummoner = 217,
		// Token: 0x040021F4 RID: 8692
		[ProtoEnum(Name = "Role_SpiritDancer", Value = 127)]
		Role_SpiritDancer = 127,
		// Token: 0x040021F5 RID: 8693
		[ProtoEnum(Name = "Role_BladeDancer", Value = 227)]
		Role_BladeDancer = 227,
		// Token: 0x040021F6 RID: 8694
		[ProtoEnum(Name = "Role_AwakeGladiator", Value = 1111)]
		Role_AwakeGladiator = 1111,
		// Token: 0x040021F7 RID: 8695
		[ProtoEnum(Name = "Role_AwakeMoonLord", Value = 1211)]
		Role_AwakeMoonLord = 1211,
		// Token: 0x040021F8 RID: 8696
		[ProtoEnum(Name = "Role_AwakeDestroyer", Value = 1121)]
		Role_AwakeDestroyer = 1121,
		// Token: 0x040021F9 RID: 8697
		[ProtoEnum(Name = "Role_AwakeBarbarian", Value = 1221)]
		Role_AwakeBarbarian = 1221,
		// Token: 0x040021FA RID: 8698
		[ProtoEnum(Name = "Role_AwakeSniper", Value = 1112)]
		Role_AwakeSniper = 1112,
		// Token: 0x040021FB RID: 8699
		[ProtoEnum(Name = "Role_AwakeArtillery", Value = 1212)]
		Role_AwakeArtillery = 1212,
		// Token: 0x040021FC RID: 8700
		[ProtoEnum(Name = "Role_AwakeTempest", Value = 1122)]
		Role_AwakeTempest = 1122,
		// Token: 0x040021FD RID: 8701
		[ProtoEnum(Name = "Role_AwakeWindwalker", Value = 1222)]
		Role_AwakeWindwalker = 1222,
		// Token: 0x040021FE RID: 8702
		[ProtoEnum(Name = "Role_AwakeSaleana", Value = 1113)]
		Role_AwakeSaleana = 1113,
		// Token: 0x040021FF RID: 8703
		[ProtoEnum(Name = "Role_AwakeElestra", Value = 1213)]
		Role_AwakeElestra = 1213,
		// Token: 0x04002200 RID: 8704
		[ProtoEnum(Name = "Role_AwakeSmasher", Value = 1123)]
		Role_AwakeSmasher = 1123,
		// Token: 0x04002201 RID: 8705
		[ProtoEnum(Name = "Role_AwakeMajesty", Value = 1223)]
		Role_AwakeMajesty = 1223,
		// Token: 0x04002202 RID: 8706
		[ProtoEnum(Name = "Role_AwakeGuardian", Value = 1114)]
		Role_AwakeGuardian = 1114,
		// Token: 0x04002203 RID: 8707
		[ProtoEnum(Name = "Role_AwakeCrusader", Value = 1214)]
		Role_AwakeCrusader = 1214,
		// Token: 0x04002204 RID: 8708
		[ProtoEnum(Name = "Role_AwakeSaint", Value = 1124)]
		Role_AwakeSaint = 1124,
		// Token: 0x04002205 RID: 8709
		[ProtoEnum(Name = "Role_AwakeInquistior", Value = 1224)]
		Role_AwakeInquistior = 1224,
		// Token: 0x04002206 RID: 8710
		[ProtoEnum(Name = "Role_AwakeShootingstar", Value = 1115)]
		Role_AwakeShootingstar = 1115,
		// Token: 0x04002207 RID: 8711
		[ProtoEnum(Name = "Role_AwakeGearmaster", Value = 1215)]
		Role_AwakeGearmaster = 1215,
		// Token: 0x04002208 RID: 8712
		[ProtoEnum(Name = "Role_AwakeAdept", Value = 1125)]
		Role_AwakeAdept = 1125,
		// Token: 0x04002209 RID: 8713
		[ProtoEnum(Name = "Role_AwakePhysician", Value = 1225)]
		Role_AwakePhysician = 1225,
		// Token: 0x0400220A RID: 8714
		[ProtoEnum(Name = "Role_AwakeReaper", Value = 1116)]
		Role_AwakeReaper = 1116,
		// Token: 0x0400220B RID: 8715
		[ProtoEnum(Name = "Role_AwakeRaven", Value = 1216)]
		Role_AwakeRaven = 1216,
		// Token: 0x0400220C RID: 8716
		[ProtoEnum(Name = "Role_AwakeLightBringer", Value = 1126)]
		Role_AwakeLightBringer = 1126,
		// Token: 0x0400220D RID: 8717
		[ProtoEnum(Name = "Role_AwakeAbyssWalker", Value = 1226)]
		Role_AwakeAbyssWalker = 1226,
		// Token: 0x0400220E RID: 8718
		[ProtoEnum(Name = "Role_AwakeSoulEater", Value = 1117)]
		Role_AwakeSoulEater = 1117,
		// Token: 0x0400220F RID: 8719
		[ProtoEnum(Name = "Role_AwakeDarkSummoner", Value = 1217)]
		Role_AwakeDarkSummoner = 1217,
		// Token: 0x04002210 RID: 8720
		[ProtoEnum(Name = "Role_AwakeSpiritDancer", Value = 1127)]
		Role_AwakeSpiritDancer = 1127,
		// Token: 0x04002211 RID: 8721
		[ProtoEnum(Name = "Role_AwakeBladeDancer", Value = 1227)]
		Role_AwakeBladeDancer = 1227,
		// Token: 0x04002212 RID: 8722
		[ProtoEnum(Name = "Role_Avenger", Value = 31)]
		Role_Avenger = 31,
		// Token: 0x04002213 RID: 8723
		[ProtoEnum(Name = "Role_DarkAvenger", Value = 131)]
		Role_DarkAvenger = 131,
		// Token: 0x04002214 RID: 8724
		[ProtoEnum(Name = "Role_AwakeDarkAvenger", Value = 1131)]
		Role_AwakeDarkAvenger = 1131
	}
}

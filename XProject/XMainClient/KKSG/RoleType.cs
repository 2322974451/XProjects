using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleType")]
	public enum RoleType
	{

		[ProtoEnum(Name = "Role_INVALID", Value = 0)]
		Role_INVALID,

		[ProtoEnum(Name = "Role_Warrior", Value = 1)]
		Role_Warrior,

		[ProtoEnum(Name = "Role_Archer", Value = 2)]
		Role_Archer,

		[ProtoEnum(Name = "Role_Sorceress", Value = 3)]
		Role_Sorceress,

		[ProtoEnum(Name = "Role_Cleric", Value = 4)]
		Role_Cleric,

		[ProtoEnum(Name = "Role_Academic", Value = 5)]
		Role_Academic,

		[ProtoEnum(Name = "Role_Swordsman", Value = 11)]
		Role_Swordsman = 11,

		[ProtoEnum(Name = "Role_Mercenary", Value = 21)]
		Role_Mercenary = 21,

		[ProtoEnum(Name = "Role_Sharpshooter", Value = 12)]
		Role_Sharpshooter = 12,

		[ProtoEnum(Name = "Role_Acrobat", Value = 22)]
		Role_Acrobat = 22,

		[ProtoEnum(Name = "Role_Elementalist", Value = 13)]
		Role_Elementalist = 13,

		[ProtoEnum(Name = "Role_Mystic", Value = 23)]
		Role_Mystic = 23,

		[ProtoEnum(Name = "Role_Paladin", Value = 14)]
		Role_Paladin = 14,

		[ProtoEnum(Name = "Role_Priest", Value = 24)]
		Role_Priest = 24,

		[ProtoEnum(Name = "Role_Engineer", Value = 15)]
		Role_Engineer = 15,

		[ProtoEnum(Name = "Role_Alchemist", Value = 25)]
		Role_Alchemist = 25,

		[ProtoEnum(Name = "Role_Gladiator", Value = 111)]
		Role_Gladiator = 111,

		[ProtoEnum(Name = "Role_Moonlord", Value = 211)]
		Role_Moonlord = 211,

		[ProtoEnum(Name = "Role_Destroyer", Value = 121)]
		Role_Destroyer = 121,

		[ProtoEnum(Name = "Role_Barbarian", Value = 221)]
		Role_Barbarian = 221,

		[ProtoEnum(Name = "Role_Sniper", Value = 112)]
		Role_Sniper = 112,

		[ProtoEnum(Name = "Role_Artillery", Value = 212)]
		Role_Artillery = 212,

		[ProtoEnum(Name = "Role_Tempest", Value = 122)]
		Role_Tempest = 122,

		[ProtoEnum(Name = "Role_Windwalker", Value = 222)]
		Role_Windwalker = 222,

		[ProtoEnum(Name = "Role_Saleana", Value = 113)]
		Role_Saleana = 113,

		[ProtoEnum(Name = "Role_Elestra", Value = 213)]
		Role_Elestra = 213,

		[ProtoEnum(Name = "Role_Smasher", Value = 123)]
		Role_Smasher = 123,

		[ProtoEnum(Name = "Role_Majesty", Value = 223)]
		Role_Majesty = 223,

		[ProtoEnum(Name = "Role_Guardian", Value = 114)]
		Role_Guardian = 114,

		[ProtoEnum(Name = "Role_Crusader", Value = 214)]
		Role_Crusader = 214,

		[ProtoEnum(Name = "Role_Saint", Value = 124)]
		Role_Saint = 124,

		[ProtoEnum(Name = "Role_Inquistior", Value = 224)]
		Role_Inquistior = 224,

		[ProtoEnum(Name = "Role_Shootingstar", Value = 115)]
		Role_Shootingstar = 115,

		[ProtoEnum(Name = "Role_Gearmaster", Value = 215)]
		Role_Gearmaster = 215,

		[ProtoEnum(Name = "Role_Adept", Value = 125)]
		Role_Adept = 125,

		[ProtoEnum(Name = "Role_Physician", Value = 225)]
		Role_Physician = 225,

		[ProtoEnum(Name = "Role_Assassin", Value = 6)]
		Role_Assassin = 6,

		[ProtoEnum(Name = "Role_Shinobi", Value = 16)]
		Role_Shinobi = 16,

		[ProtoEnum(Name = "Role_Taoist", Value = 26)]
		Role_Taoist = 26,

		[ProtoEnum(Name = "Role_Reaper", Value = 116)]
		Role_Reaper = 116,

		[ProtoEnum(Name = "Role_Raven", Value = 216)]
		Role_Raven = 216,

		[ProtoEnum(Name = "Role_LightBringer", Value = 126)]
		Role_LightBringer = 126,

		[ProtoEnum(Name = "Role_AbyssWalker", Value = 226)]
		Role_AbyssWalker = 226,

		[ProtoEnum(Name = "Role_Kali", Value = 7)]
		Role_Kali = 7,

		[ProtoEnum(Name = "Role_Screamer", Value = 17)]
		Role_Screamer = 17,

		[ProtoEnum(Name = "Role_Dancer", Value = 27)]
		Role_Dancer = 27,

		[ProtoEnum(Name = "Role_SoulEater", Value = 117)]
		Role_SoulEater = 117,

		[ProtoEnum(Name = "Role_DarkSummoner", Value = 217)]
		Role_DarkSummoner = 217,

		[ProtoEnum(Name = "Role_SpiritDancer", Value = 127)]
		Role_SpiritDancer = 127,

		[ProtoEnum(Name = "Role_BladeDancer", Value = 227)]
		Role_BladeDancer = 227,

		[ProtoEnum(Name = "Role_AwakeGladiator", Value = 1111)]
		Role_AwakeGladiator = 1111,

		[ProtoEnum(Name = "Role_AwakeMoonLord", Value = 1211)]
		Role_AwakeMoonLord = 1211,

		[ProtoEnum(Name = "Role_AwakeDestroyer", Value = 1121)]
		Role_AwakeDestroyer = 1121,

		[ProtoEnum(Name = "Role_AwakeBarbarian", Value = 1221)]
		Role_AwakeBarbarian = 1221,

		[ProtoEnum(Name = "Role_AwakeSniper", Value = 1112)]
		Role_AwakeSniper = 1112,

		[ProtoEnum(Name = "Role_AwakeArtillery", Value = 1212)]
		Role_AwakeArtillery = 1212,

		[ProtoEnum(Name = "Role_AwakeTempest", Value = 1122)]
		Role_AwakeTempest = 1122,

		[ProtoEnum(Name = "Role_AwakeWindwalker", Value = 1222)]
		Role_AwakeWindwalker = 1222,

		[ProtoEnum(Name = "Role_AwakeSaleana", Value = 1113)]
		Role_AwakeSaleana = 1113,

		[ProtoEnum(Name = "Role_AwakeElestra", Value = 1213)]
		Role_AwakeElestra = 1213,

		[ProtoEnum(Name = "Role_AwakeSmasher", Value = 1123)]
		Role_AwakeSmasher = 1123,

		[ProtoEnum(Name = "Role_AwakeMajesty", Value = 1223)]
		Role_AwakeMajesty = 1223,

		[ProtoEnum(Name = "Role_AwakeGuardian", Value = 1114)]
		Role_AwakeGuardian = 1114,

		[ProtoEnum(Name = "Role_AwakeCrusader", Value = 1214)]
		Role_AwakeCrusader = 1214,

		[ProtoEnum(Name = "Role_AwakeSaint", Value = 1124)]
		Role_AwakeSaint = 1124,

		[ProtoEnum(Name = "Role_AwakeInquistior", Value = 1224)]
		Role_AwakeInquistior = 1224,

		[ProtoEnum(Name = "Role_AwakeShootingstar", Value = 1115)]
		Role_AwakeShootingstar = 1115,

		[ProtoEnum(Name = "Role_AwakeGearmaster", Value = 1215)]
		Role_AwakeGearmaster = 1215,

		[ProtoEnum(Name = "Role_AwakeAdept", Value = 1125)]
		Role_AwakeAdept = 1125,

		[ProtoEnum(Name = "Role_AwakePhysician", Value = 1225)]
		Role_AwakePhysician = 1225,

		[ProtoEnum(Name = "Role_AwakeReaper", Value = 1116)]
		Role_AwakeReaper = 1116,

		[ProtoEnum(Name = "Role_AwakeRaven", Value = 1216)]
		Role_AwakeRaven = 1216,

		[ProtoEnum(Name = "Role_AwakeLightBringer", Value = 1126)]
		Role_AwakeLightBringer = 1126,

		[ProtoEnum(Name = "Role_AwakeAbyssWalker", Value = 1226)]
		Role_AwakeAbyssWalker = 1226,

		[ProtoEnum(Name = "Role_AwakeSoulEater", Value = 1117)]
		Role_AwakeSoulEater = 1117,

		[ProtoEnum(Name = "Role_AwakeDarkSummoner", Value = 1217)]
		Role_AwakeDarkSummoner = 1217,

		[ProtoEnum(Name = "Role_AwakeSpiritDancer", Value = 1127)]
		Role_AwakeSpiritDancer = 1127,

		[ProtoEnum(Name = "Role_AwakeBladeDancer", Value = 1227)]
		Role_AwakeBladeDancer = 1227,

		[ProtoEnum(Name = "Role_Avenger", Value = 31)]
		Role_Avenger = 31,

		[ProtoEnum(Name = "Role_DarkAvenger", Value = 131)]
		Role_DarkAvenger = 131,

		[ProtoEnum(Name = "Role_AwakeDarkAvenger", Value = 1131)]
		Role_AwakeDarkAvenger = 1131
	}
}

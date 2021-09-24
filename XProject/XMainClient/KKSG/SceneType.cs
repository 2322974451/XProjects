using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SceneType")]
	public enum SceneType
	{

		[ProtoEnum(Name = "SCENE_HALL", Value = 1)]
		SCENE_HALL = 1,

		[ProtoEnum(Name = "SCENE_BATTLE", Value = 2)]
		SCENE_BATTLE,

		[ProtoEnum(Name = "SCENE_NEST", Value = 3)]
		SCENE_NEST,

		[ProtoEnum(Name = "SCENE_ARENA", Value = 5)]
		SCENE_ARENA = 5,

		[ProtoEnum(Name = "SCENE_WORLDBOSS", Value = 7)]
		SCENE_WORLDBOSS = 7,

		[ProtoEnum(Name = "SCENE_BOSSRUSH", Value = 9)]
		SCENE_BOSSRUSH = 9,

		[ProtoEnum(Name = "SCENE_GUILD_HALL", Value = 10)]
		SCENE_GUILD_HALL,

		[ProtoEnum(Name = "SCENE_GUILD_BOSS", Value = 11)]
		SCENE_GUILD_BOSS,

		[ProtoEnum(Name = "SCENE_PK", Value = 12)]
		SCENE_PK,

		[ProtoEnum(Name = "SCENE_ABYSSS", Value = 13)]
		SCENE_ABYSSS,

		[ProtoEnum(Name = "SCENE_FAMILYGARDEN", Value = 15)]
		SCENE_FAMILYGARDEN = 15,

		[ProtoEnum(Name = "SCENE_TOWER", Value = 16)]
		SCENE_TOWER,

		[ProtoEnum(Name = "SCENE_PVP", Value = 17)]
		SCENE_PVP,

		[ProtoEnum(Name = "SCENE_DRAGON", Value = 18)]
		SCENE_DRAGON,

		[ProtoEnum(Name = "SCENE_GMF", Value = 19)]
		SCENE_GMF,

		[ProtoEnum(Name = "SCENE_GODDESS", Value = 20)]
		SCENE_GODDESS,

		[ProtoEnum(Name = "SCENE_DRAGON_EXP", Value = 21)]
		SCENE_DRAGON_EXP,

		[ProtoEnum(Name = "SCENE_RISK", Value = 22)]
		SCENE_RISK,

		[ProtoEnum(Name = "SCENE_ENDLESSABYSS", Value = 23)]
		SCENE_ENDLESSABYSS,

		[ProtoEnum(Name = "SKYCITY_WAITING", Value = 24)]
		SKYCITY_WAITING,

		[ProtoEnum(Name = "SKYCITY_FIGHTING", Value = 25)]
		SKYCITY_FIGHTING,

		[ProtoEnum(Name = "SCENE_PROF_TRIALS", Value = 26)]
		SCENE_PROF_TRIALS,

		[ProtoEnum(Name = "SCENE_GPR", Value = 27)]
		SCENE_GPR,

		[ProtoEnum(Name = "SCENE_RESWAR_PVP", Value = 28)]
		SCENE_RESWAR_PVP,

		[ProtoEnum(Name = "SCENE_RESWAR_PVE", Value = 29)]
		SCENE_RESWAR_PVE,

		[ProtoEnum(Name = "SCENE_GUILD_CAMP", Value = 30)]
		SCENE_GUILD_CAMP,

		[ProtoEnum(Name = "SCENE_AIRSHIP", Value = 31)]
		SCENE_AIRSHIP,

		[ProtoEnum(Name = "SCENE_WEEK_NEST", Value = 32)]
		SCENE_WEEK_NEST,

		[ProtoEnum(Name = "SCENE_VS_CHALLENGE", Value = 33)]
		SCENE_VS_CHALLENGE,

		[ProtoEnum(Name = "SCENE_HORSE", Value = 34)]
		SCENE_HORSE,

		[ProtoEnum(Name = "SCENE_HORSE_RACE", Value = 35)]
		SCENE_HORSE_RACE,

		[ProtoEnum(Name = "SCENE_HEROBATTLE", Value = 36)]
		SCENE_HEROBATTLE,

		[ProtoEnum(Name = "SCENE_INVFIGHT", Value = 37)]
		SCENE_INVFIGHT,

		[ProtoEnum(Name = "SCENE_CASTLE_WAIT", Value = 38)]
		SCENE_CASTLE_WAIT,

		[ProtoEnum(Name = "SCENE_CASTLE_FIGHT", Value = 39)]
		SCENE_CASTLE_FIGHT,

		[ProtoEnum(Name = "SCENE_LEAGUE_BATTLE", Value = 40)]
		SCENE_LEAGUE_BATTLE,

		[ProtoEnum(Name = "SCENE_ACTIVITY_ONE", Value = 41)]
		SCENE_ACTIVITY_ONE,

		[ProtoEnum(Name = "SCENE_ACTIVITY_TWO", Value = 42)]
		SCENE_ACTIVITY_TWO,

		[ProtoEnum(Name = "SCENE_ACTIVITY_THREE", Value = 43)]
		SCENE_ACTIVITY_THREE,

		[ProtoEnum(Name = "SCENE_ABYSS_PARTY", Value = 44)]
		SCENE_ABYSS_PARTY,

		[ProtoEnum(Name = "SCENE_CUSTOMPK", Value = 45)]
		SCENE_CUSTOMPK,

		[ProtoEnum(Name = "SCENE_PKTWO", Value = 46)]
		SCENE_PKTWO,

		[ProtoEnum(Name = "SCENE_MOBA", Value = 47)]
		SCENE_MOBA,

		[ProtoEnum(Name = "SCENE_WEEKEND4V4_MONSTERFIGHT", Value = 48)]
		SCENE_WEEKEND4V4_MONSTERFIGHT,

		[ProtoEnum(Name = "SCENE_WEEKEND4V4_GHOSTACTION", Value = 49)]
		SCENE_WEEKEND4V4_GHOSTACTION,

		[ProtoEnum(Name = "SCENE_WEEKEND4V4_LIVECHALLENGE", Value = 50)]
		SCENE_WEEKEND4V4_LIVECHALLENGE,

		[ProtoEnum(Name = "SCENE_WEEKEND4V4_CRAZYBOMB", Value = 51)]
		SCENE_WEEKEND4V4_CRAZYBOMB,

		[ProtoEnum(Name = "SCENE_WEEKEND4V4_HORSERACING", Value = 52)]
		SCENE_WEEKEND4V4_HORSERACING,

		[ProtoEnum(Name = "SCENE_CUSTOMPKTWO", Value = 53)]
		SCENE_CUSTOMPKTWO,

		[ProtoEnum(Name = "SCENE_WEEKEND4V4_DUCK", Value = 54)]
		SCENE_WEEKEND4V4_DUCK,

		[ProtoEnum(Name = "SCENE_BIGMELEE_READY", Value = 60)]
		SCENE_BIGMELEE_READY = 60,

		[ProtoEnum(Name = "SCENE_BIGMELEE_FIGHT", Value = 61)]
		SCENE_BIGMELEE_FIGHT,

		[ProtoEnum(Name = "SCENE_CALLBACK", Value = 62)]
		SCENE_CALLBACK,

		[ProtoEnum(Name = "SCENE_WEDDING", Value = 63)]
		SCENE_WEDDING,

		[ProtoEnum(Name = "SCENE_BIOHELL", Value = 64)]
		SCENE_BIOHELL,

		[ProtoEnum(Name = "SCENE_DUCK", Value = 65)]
		SCENE_DUCK,

		[ProtoEnum(Name = "SCENE_COUPLE", Value = 66)]
		SCENE_COUPLE,

		[ProtoEnum(Name = "SCENE_BATTLEFIELD_READY", Value = 67)]
		SCENE_BATTLEFIELD_READY,

		[ProtoEnum(Name = "SCENE_BATTLEFIELD_FIGHT", Value = 68)]
		SCENE_BATTLEFIELD_FIGHT,

		[ProtoEnum(Name = "SCENE_COMPETEDRAGON", Value = 69)]
		SCENE_COMPETEDRAGON,

		[ProtoEnum(Name = "SCENE_SURVIVE", Value = 70)]
		SCENE_SURVIVE,

		[ProtoEnum(Name = "SCENE_LEISURE", Value = 71)]
		SCENE_LEISURE,

		[ProtoEnum(Name = "SCENE_GCF", Value = 72)]
		SCENE_GCF,

		[ProtoEnum(Name = "SCENE_RIFT", Value = 73)]
		SCENE_RIFT,

		[ProtoEnum(Name = "SCENE_GUILD_WILD_HUNT", Value = 74)]
		SCENE_GUILD_WILD_HUNT,

		[ProtoEnum(Name = "SCENE_AWAKE", Value = 75)]
		SCENE_AWAKE,

		[ProtoEnum(Name = "SCENE_LOGIN", Value = 100)]
		SCENE_LOGIN = 100
	}
}

using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200074B RID: 1867
	[ProtoContract(Name = "SceneType")]
	public enum SceneType
	{
		// Token: 0x04002216 RID: 8726
		[ProtoEnum(Name = "SCENE_HALL", Value = 1)]
		SCENE_HALL = 1,
		// Token: 0x04002217 RID: 8727
		[ProtoEnum(Name = "SCENE_BATTLE", Value = 2)]
		SCENE_BATTLE,
		// Token: 0x04002218 RID: 8728
		[ProtoEnum(Name = "SCENE_NEST", Value = 3)]
		SCENE_NEST,
		// Token: 0x04002219 RID: 8729
		[ProtoEnum(Name = "SCENE_ARENA", Value = 5)]
		SCENE_ARENA = 5,
		// Token: 0x0400221A RID: 8730
		[ProtoEnum(Name = "SCENE_WORLDBOSS", Value = 7)]
		SCENE_WORLDBOSS = 7,
		// Token: 0x0400221B RID: 8731
		[ProtoEnum(Name = "SCENE_BOSSRUSH", Value = 9)]
		SCENE_BOSSRUSH = 9,
		// Token: 0x0400221C RID: 8732
		[ProtoEnum(Name = "SCENE_GUILD_HALL", Value = 10)]
		SCENE_GUILD_HALL,
		// Token: 0x0400221D RID: 8733
		[ProtoEnum(Name = "SCENE_GUILD_BOSS", Value = 11)]
		SCENE_GUILD_BOSS,
		// Token: 0x0400221E RID: 8734
		[ProtoEnum(Name = "SCENE_PK", Value = 12)]
		SCENE_PK,
		// Token: 0x0400221F RID: 8735
		[ProtoEnum(Name = "SCENE_ABYSSS", Value = 13)]
		SCENE_ABYSSS,
		// Token: 0x04002220 RID: 8736
		[ProtoEnum(Name = "SCENE_FAMILYGARDEN", Value = 15)]
		SCENE_FAMILYGARDEN = 15,
		// Token: 0x04002221 RID: 8737
		[ProtoEnum(Name = "SCENE_TOWER", Value = 16)]
		SCENE_TOWER,
		// Token: 0x04002222 RID: 8738
		[ProtoEnum(Name = "SCENE_PVP", Value = 17)]
		SCENE_PVP,
		// Token: 0x04002223 RID: 8739
		[ProtoEnum(Name = "SCENE_DRAGON", Value = 18)]
		SCENE_DRAGON,
		// Token: 0x04002224 RID: 8740
		[ProtoEnum(Name = "SCENE_GMF", Value = 19)]
		SCENE_GMF,
		// Token: 0x04002225 RID: 8741
		[ProtoEnum(Name = "SCENE_GODDESS", Value = 20)]
		SCENE_GODDESS,
		// Token: 0x04002226 RID: 8742
		[ProtoEnum(Name = "SCENE_DRAGON_EXP", Value = 21)]
		SCENE_DRAGON_EXP,
		// Token: 0x04002227 RID: 8743
		[ProtoEnum(Name = "SCENE_RISK", Value = 22)]
		SCENE_RISK,
		// Token: 0x04002228 RID: 8744
		[ProtoEnum(Name = "SCENE_ENDLESSABYSS", Value = 23)]
		SCENE_ENDLESSABYSS,
		// Token: 0x04002229 RID: 8745
		[ProtoEnum(Name = "SKYCITY_WAITING", Value = 24)]
		SKYCITY_WAITING,
		// Token: 0x0400222A RID: 8746
		[ProtoEnum(Name = "SKYCITY_FIGHTING", Value = 25)]
		SKYCITY_FIGHTING,
		// Token: 0x0400222B RID: 8747
		[ProtoEnum(Name = "SCENE_PROF_TRIALS", Value = 26)]
		SCENE_PROF_TRIALS,
		// Token: 0x0400222C RID: 8748
		[ProtoEnum(Name = "SCENE_GPR", Value = 27)]
		SCENE_GPR,
		// Token: 0x0400222D RID: 8749
		[ProtoEnum(Name = "SCENE_RESWAR_PVP", Value = 28)]
		SCENE_RESWAR_PVP,
		// Token: 0x0400222E RID: 8750
		[ProtoEnum(Name = "SCENE_RESWAR_PVE", Value = 29)]
		SCENE_RESWAR_PVE,
		// Token: 0x0400222F RID: 8751
		[ProtoEnum(Name = "SCENE_GUILD_CAMP", Value = 30)]
		SCENE_GUILD_CAMP,
		// Token: 0x04002230 RID: 8752
		[ProtoEnum(Name = "SCENE_AIRSHIP", Value = 31)]
		SCENE_AIRSHIP,
		// Token: 0x04002231 RID: 8753
		[ProtoEnum(Name = "SCENE_WEEK_NEST", Value = 32)]
		SCENE_WEEK_NEST,
		// Token: 0x04002232 RID: 8754
		[ProtoEnum(Name = "SCENE_VS_CHALLENGE", Value = 33)]
		SCENE_VS_CHALLENGE,
		// Token: 0x04002233 RID: 8755
		[ProtoEnum(Name = "SCENE_HORSE", Value = 34)]
		SCENE_HORSE,
		// Token: 0x04002234 RID: 8756
		[ProtoEnum(Name = "SCENE_HORSE_RACE", Value = 35)]
		SCENE_HORSE_RACE,
		// Token: 0x04002235 RID: 8757
		[ProtoEnum(Name = "SCENE_HEROBATTLE", Value = 36)]
		SCENE_HEROBATTLE,
		// Token: 0x04002236 RID: 8758
		[ProtoEnum(Name = "SCENE_INVFIGHT", Value = 37)]
		SCENE_INVFIGHT,
		// Token: 0x04002237 RID: 8759
		[ProtoEnum(Name = "SCENE_CASTLE_WAIT", Value = 38)]
		SCENE_CASTLE_WAIT,
		// Token: 0x04002238 RID: 8760
		[ProtoEnum(Name = "SCENE_CASTLE_FIGHT", Value = 39)]
		SCENE_CASTLE_FIGHT,
		// Token: 0x04002239 RID: 8761
		[ProtoEnum(Name = "SCENE_LEAGUE_BATTLE", Value = 40)]
		SCENE_LEAGUE_BATTLE,
		// Token: 0x0400223A RID: 8762
		[ProtoEnum(Name = "SCENE_ACTIVITY_ONE", Value = 41)]
		SCENE_ACTIVITY_ONE,
		// Token: 0x0400223B RID: 8763
		[ProtoEnum(Name = "SCENE_ACTIVITY_TWO", Value = 42)]
		SCENE_ACTIVITY_TWO,
		// Token: 0x0400223C RID: 8764
		[ProtoEnum(Name = "SCENE_ACTIVITY_THREE", Value = 43)]
		SCENE_ACTIVITY_THREE,
		// Token: 0x0400223D RID: 8765
		[ProtoEnum(Name = "SCENE_ABYSS_PARTY", Value = 44)]
		SCENE_ABYSS_PARTY,
		// Token: 0x0400223E RID: 8766
		[ProtoEnum(Name = "SCENE_CUSTOMPK", Value = 45)]
		SCENE_CUSTOMPK,
		// Token: 0x0400223F RID: 8767
		[ProtoEnum(Name = "SCENE_PKTWO", Value = 46)]
		SCENE_PKTWO,
		// Token: 0x04002240 RID: 8768
		[ProtoEnum(Name = "SCENE_MOBA", Value = 47)]
		SCENE_MOBA,
		// Token: 0x04002241 RID: 8769
		[ProtoEnum(Name = "SCENE_WEEKEND4V4_MONSTERFIGHT", Value = 48)]
		SCENE_WEEKEND4V4_MONSTERFIGHT,
		// Token: 0x04002242 RID: 8770
		[ProtoEnum(Name = "SCENE_WEEKEND4V4_GHOSTACTION", Value = 49)]
		SCENE_WEEKEND4V4_GHOSTACTION,
		// Token: 0x04002243 RID: 8771
		[ProtoEnum(Name = "SCENE_WEEKEND4V4_LIVECHALLENGE", Value = 50)]
		SCENE_WEEKEND4V4_LIVECHALLENGE,
		// Token: 0x04002244 RID: 8772
		[ProtoEnum(Name = "SCENE_WEEKEND4V4_CRAZYBOMB", Value = 51)]
		SCENE_WEEKEND4V4_CRAZYBOMB,
		// Token: 0x04002245 RID: 8773
		[ProtoEnum(Name = "SCENE_WEEKEND4V4_HORSERACING", Value = 52)]
		SCENE_WEEKEND4V4_HORSERACING,
		// Token: 0x04002246 RID: 8774
		[ProtoEnum(Name = "SCENE_CUSTOMPKTWO", Value = 53)]
		SCENE_CUSTOMPKTWO,
		// Token: 0x04002247 RID: 8775
		[ProtoEnum(Name = "SCENE_WEEKEND4V4_DUCK", Value = 54)]
		SCENE_WEEKEND4V4_DUCK,
		// Token: 0x04002248 RID: 8776
		[ProtoEnum(Name = "SCENE_BIGMELEE_READY", Value = 60)]
		SCENE_BIGMELEE_READY = 60,
		// Token: 0x04002249 RID: 8777
		[ProtoEnum(Name = "SCENE_BIGMELEE_FIGHT", Value = 61)]
		SCENE_BIGMELEE_FIGHT,
		// Token: 0x0400224A RID: 8778
		[ProtoEnum(Name = "SCENE_CALLBACK", Value = 62)]
		SCENE_CALLBACK,
		// Token: 0x0400224B RID: 8779
		[ProtoEnum(Name = "SCENE_WEDDING", Value = 63)]
		SCENE_WEDDING,
		// Token: 0x0400224C RID: 8780
		[ProtoEnum(Name = "SCENE_BIOHELL", Value = 64)]
		SCENE_BIOHELL,
		// Token: 0x0400224D RID: 8781
		[ProtoEnum(Name = "SCENE_DUCK", Value = 65)]
		SCENE_DUCK,
		// Token: 0x0400224E RID: 8782
		[ProtoEnum(Name = "SCENE_COUPLE", Value = 66)]
		SCENE_COUPLE,
		// Token: 0x0400224F RID: 8783
		[ProtoEnum(Name = "SCENE_BATTLEFIELD_READY", Value = 67)]
		SCENE_BATTLEFIELD_READY,
		// Token: 0x04002250 RID: 8784
		[ProtoEnum(Name = "SCENE_BATTLEFIELD_FIGHT", Value = 68)]
		SCENE_BATTLEFIELD_FIGHT,
		// Token: 0x04002251 RID: 8785
		[ProtoEnum(Name = "SCENE_COMPETEDRAGON", Value = 69)]
		SCENE_COMPETEDRAGON,
		// Token: 0x04002252 RID: 8786
		[ProtoEnum(Name = "SCENE_SURVIVE", Value = 70)]
		SCENE_SURVIVE,
		// Token: 0x04002253 RID: 8787
		[ProtoEnum(Name = "SCENE_LEISURE", Value = 71)]
		SCENE_LEISURE,
		// Token: 0x04002254 RID: 8788
		[ProtoEnum(Name = "SCENE_GCF", Value = 72)]
		SCENE_GCF,
		// Token: 0x04002255 RID: 8789
		[ProtoEnum(Name = "SCENE_RIFT", Value = 73)]
		SCENE_RIFT,
		// Token: 0x04002256 RID: 8790
		[ProtoEnum(Name = "SCENE_GUILD_WILD_HUNT", Value = 74)]
		SCENE_GUILD_WILD_HUNT,
		// Token: 0x04002257 RID: 8791
		[ProtoEnum(Name = "SCENE_AWAKE", Value = 75)]
		SCENE_AWAKE,
		// Token: 0x04002258 RID: 8792
		[ProtoEnum(Name = "SCENE_LOGIN", Value = 100)]
		SCENE_LOGIN = 100
	}
}

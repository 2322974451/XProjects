using System;

namespace XMainClient
{
	// Token: 0x02000DC8 RID: 3528
	public enum XSysDefine
	{
		// Token: 0x04004E77 RID: 20087
		XSys_Invalid = -1,
		// Token: 0x04004E78 RID: 20088
		XSys_None,
		// Token: 0x04004E79 RID: 20089
		XSys_Character = 10,
		// Token: 0x04004E7A RID: 20090
		XSys_Level,
		// Token: 0x04004E7B RID: 20091
		XSys_Item,
		// Token: 0x04004E7C RID: 20092
		XSys_Skill,
		// Token: 0x04004E7D RID: 20093
		XSys_Char,
		// Token: 0x04004E7E RID: 20094
		XSys_Horse,
		// Token: 0x04004E7F RID: 20095
		XSys_Fashion,
		// Token: 0x04004E80 RID: 20096
		XSys_Guild,
		// Token: 0x04004E81 RID: 20097
		XSys_Recycle,
		// Token: 0x04004E82 RID: 20098
		XSys_Bag,
		// Token: 0x04004E83 RID: 20099
		XSys_TShow,
		// Token: 0x04004E84 RID: 20100
		XSys_Confession,
		// Token: 0x04004E85 RID: 20101
		XSys_Auction,
		// Token: 0x04004E86 RID: 20102
		XSys_TShowRule,
		// Token: 0x04004E87 RID: 20103
		XSys_FlowerRank,
		// Token: 0x04004E88 RID: 20104
		XSys_CardCollect,
		// Token: 0x04004E89 RID: 20105
		XSys_Camp,
		// Token: 0x04004E8A RID: 20106
		XSys_Mail,
		// Token: 0x04004E8B RID: 20107
		XSys_Wifi,
		// Token: 0x04004E8C RID: 20108
		XSys_Design,
		// Token: 0x04004E8D RID: 20109
		XSys_SuperReward,
		// Token: 0x04004E8E RID: 20110
		XSys_Draw,
		// Token: 0x04004E8F RID: 20111
		XSys_Mall,
		// Token: 0x04004E90 RID: 20112
		XSys_Strong,
		// Token: 0x04004E91 RID: 20113
		XSys_Target,
		// Token: 0x04004E92 RID: 20114
		XSys_Reward,
		// Token: 0x04004E93 RID: 20115
		XSys_ServerActivity = 37,
		// Token: 0x04004E94 RID: 20116
		XSys_OnlineReward = 39,
		// Token: 0x04004E95 RID: 20117
		XSys_Setting,
		// Token: 0x04004E96 RID: 20118
		XSys_Rank,
		// Token: 0x04004E97 RID: 20119
		XSys_LevelReward,
		// Token: 0x04004E98 RID: 20120
		XSys_ReceiveEnergy = 44,
		// Token: 0x04004E99 RID: 20121
		XSys_EquipCreate,
		// Token: 0x04004E9A RID: 20122
		XSys_SystemActivity,
		// Token: 0x04004E9B RID: 20123
		XSys_LevelSeal,
		// Token: 0x04004E9C RID: 20124
		XSys_BossRush,
		// Token: 0x04004E9D RID: 20125
		XSys_SuperRisk,
		// Token: 0x04004E9E RID: 20126
		XSys_DragonCrusade,
		// Token: 0x04004E9F RID: 20127
		XSys_Arena,
		// Token: 0x04004EA0 RID: 20128
		XSys_Activity,
		// Token: 0x04004EA1 RID: 20129
		XSys_Qualifying = 54,
		// Token: 0x04004EA2 RID: 20130
		XSys_MulActivity,
		// Token: 0x04004EA3 RID: 20131
		XSys_Spectate,
		// Token: 0x04004EA4 RID: 20132
		XSys_DailyAcitivity,
		// Token: 0x04004EA5 RID: 20133
		XSys_PVPAcitivity,
		// Token: 0x04004EA6 RID: 20134
		XSys_ExcellentLive,
		// Token: 0x04004EA7 RID: 20135
		XSys_MobaAcitivity,
		// Token: 0x04004EA8 RID: 20136
		XSys_Money,
		// Token: 0x04004EA9 RID: 20137
		XSys_Coin,
		// Token: 0x04004EAA RID: 20138
		XSys_Power,
		// Token: 0x04004EAB RID: 20139
		XSys_DragonCoin,
		// Token: 0x04004EAC RID: 20140
		XSys_GameMall,
		// Token: 0x04004EAD RID: 20141
		XSys_Carnival = 67,
		// Token: 0x04004EAE RID: 20142
		XSys_WeekShareReward,
		// Token: 0x04004EAF RID: 20143
		XSys_DungeonShareReward,
		// Token: 0x04004EB0 RID: 20144
		XSys_OtherPlayerInfo,
		// Token: 0x04004EB1 RID: 20145
		XSys_Chat,
		// Token: 0x04004EB2 RID: 20146
		XSys_Friends,
		// Token: 0x04004EB3 RID: 20147
		XSys_Maquee,
		// Token: 0x04004EB4 RID: 20148
		XSys_SendFlower,
		// Token: 0x04004EB5 RID: 20149
		XSys_Mentorship,
		// Token: 0x04004EB6 RID: 20150
		XSys_PK,
		// Token: 0x04004EB7 RID: 20151
		XSys_3GFree,
		// Token: 0x04004EB8 RID: 20152
		XSys_ChatGroup,
		// Token: 0x04004EB9 RID: 20153
		XSys_Broadcast = 80,
		// Token: 0x04004EBA RID: 20154
		XSys_GuildHall,
		// Token: 0x04004EBB RID: 20155
		XSys_GuildRelax,
		// Token: 0x04004EBC RID: 20156
		XSys_GuildDragon = 85,
		// Token: 0x04004EBD RID: 20157
		XSys_GuildPvp,
		// Token: 0x04004EBE RID: 20158
		XSys_GuildRedPacket,
		// Token: 0x04004EBF RID: 20159
		XSys_GuildMine,
		// Token: 0x04004EC0 RID: 20160
		XSys_CrossGVG,
		// Token: 0x04004EC1 RID: 20161
		XSys_Team,
		// Token: 0x04004EC2 RID: 20162
		XSys_GayValley,
		// Token: 0x04004EC3 RID: 20163
		XSys_GayValleyManager,
		// Token: 0x04004EC4 RID: 20164
		XSys_SevenActivity,
		// Token: 0x04004EC5 RID: 20165
		XSys_Title,
		// Token: 0x04004EC6 RID: 20166
		XSys_Task,
		// Token: 0x04004EC7 RID: 20167
		XSys_Pandora,
		// Token: 0x04004EC8 RID: 20168
		XSys_Personal_Career,
		// Token: 0x04004EC9 RID: 20169
		XSys_MilitaryRank,
		// Token: 0x04004ECA RID: 20170
		XSys_Recharge = 100,
		// Token: 0x04004ECB RID: 20171
		XSys_VIP,
		// Token: 0x04004ECC RID: 20172
		XSys_Random_Gift,
		// Token: 0x04004ECD RID: 20173
		XSys_HallFame,
		// Token: 0x04004ECE RID: 20174
		XSys_Level_Normal = 110,
		// Token: 0x04004ECF RID: 20175
		XSys_Level_Elite,
		// Token: 0x04004ED0 RID: 20176
		XSys_Level_Swap,
		// Token: 0x04004ED1 RID: 20177
		XSys_Item_Equip = 120,
		// Token: 0x04004ED2 RID: 20178
		XSys_Item_Enhance,
		// Token: 0x04004ED3 RID: 20179
		XSys_Item_Jade,
		// Token: 0x04004ED4 RID: 20180
		XSys_Item_SlotAttr,
		// Token: 0x04004ED5 RID: 20181
		XSys_Item_Smelting,
		// Token: 0x04004ED6 RID: 20182
		XSys_Item_Reinforce,
		// Token: 0x04004ED7 RID: 20183
		XSys_Emblem_Smelting,
		// Token: 0x04004ED8 RID: 20184
		XSys_Item_Enchant,
		// Token: 0x04004ED9 RID: 20185
		XSys_Item_Forge,
		// Token: 0x04004EDA RID: 20186
		XSys_Skill_Levelup = 130,
		// Token: 0x04004EDB RID: 20187
		XSys_Skill_Promote,
		// Token: 0x04004EDC RID: 20188
		XSys_Char_Attr = 140,
		// Token: 0x04004EDD RID: 20189
		XSys_Char_Emblem,
		// Token: 0x04004EDE RID: 20190
		XSys_Home = 150,
		// Token: 0x04004EDF RID: 20191
		XSys_Home_Cooking,
		// Token: 0x04004EE0 RID: 20192
		XSys_Home_Fishing,
		// Token: 0x04004EE1 RID: 20193
		XSys_Home_Plant,
		// Token: 0x04004EE2 RID: 20194
		XSys_Home_Feast,
		// Token: 0x04004EE3 RID: 20195
		XSys_Home_MyHome,
		// Token: 0x04004EE4 RID: 20196
		XSys_Home_HomeFriends,
		// Token: 0x04004EE5 RID: 20197
		XSys_Horse_LearnSkill = 159,
		// Token: 0x04004EE6 RID: 20198
		XSys_Fashion_Fashion,
		// Token: 0x04004EE7 RID: 20199
		XSys_Fashion_Wearing = 162,
		// Token: 0x04004EE8 RID: 20200
		XSys_Fashion_OutLook = 161,
		// Token: 0x04004EE9 RID: 20201
		XSys_Item_Compose = 170,
		// Token: 0x04004EEA RID: 20202
		XSys_Pet_Pairs,
		// Token: 0x04004EEB RID: 20203
		XSys_Recycle_Equip = 180,
		// Token: 0x04004EEC RID: 20204
		XSys_Recycle_Jade,
		// Token: 0x04004EED RID: 20205
		XSys_Bag_Item = 190,
		// Token: 0x04004EEE RID: 20206
		XSys_TShow_Vote = 200,
		// Token: 0x04004EEF RID: 20207
		XSys_TShow_Main,
		// Token: 0x04004EF0 RID: 20208
		XSys_CustomBattle = 220,
		// Token: 0x04004EF1 RID: 20209
		XSys_CustomBattle_BountyMode,
		// Token: 0x04004EF2 RID: 20210
		XSys_CustomBattle_CustomMode,
		// Token: 0x04004EF3 RID: 20211
		XSys_WeekEndNest = 230,
		// Token: 0x04004EF4 RID: 20212
		XSys_Camp_CampHall = 260,
		// Token: 0x04004EF5 RID: 20213
		XSys_Camp_MemberHall,
		// Token: 0x04004EF6 RID: 20214
		XSys_Camp_Mission = 269,
		// Token: 0x04004EF7 RID: 20215
		XSys_DragonNest_Sweep,
		// Token: 0x04004EF8 RID: 20216
		XSys_Mail_System,
		// Token: 0x04004EF9 RID: 20217
		XSys_Mail_Player,
		// Token: 0x04004EFA RID: 20218
		XSys_Mail_Content,
		// Token: 0x04004EFB RID: 20219
		XSys_Design_Designation = 290,
		// Token: 0x04004EFC RID: 20220
		XSys_Design_Achieve,
		// Token: 0x04004EFD RID: 20221
		XSys_Mall_Happy = 294,
		// Token: 0x04004EFE RID: 20222
		XSys_Mall_New_One,
		// Token: 0x04004EFF RID: 20223
		XSys_Mall_New_Two,
		// Token: 0x04004F00 RID: 20224
		XSys_Mall_New_Three,
		// Token: 0x04004F01 RID: 20225
		XSys_Mall_New_Four,
		// Token: 0x04004F02 RID: 20226
		XSys_Mall_MystShop = 320,
		// Token: 0x04004F03 RID: 20227
		XSys_Mall_Mall,
		// Token: 0x04004F04 RID: 20228
		XSys_Mall_Fasion,
		// Token: 0x04004F05 RID: 20229
		XSys_Mall_Honer,
		// Token: 0x04004F06 RID: 20230
		XSys_Mall_Guild,
		// Token: 0x04004F07 RID: 20231
		XSys_Mall_Tear,
		// Token: 0x04004F08 RID: 20232
		XSys_Mall_Card1,
		// Token: 0x04004F09 RID: 20233
		XSys_Mall_Card2,
		// Token: 0x04004F0A RID: 20234
		XSys_Mall_Card3,
		// Token: 0x04004F0B RID: 20235
		XSys_Mall_Card4,
		// Token: 0x04004F0C RID: 20236
		XSys_Mall_32A,
		// Token: 0x04004F0D RID: 20237
		XSys_Mall_40A,
		// Token: 0x04004F0E RID: 20238
		XSys_Mall_50A,
		// Token: 0x04004F0F RID: 20239
		XSys_Mall_60A,
		// Token: 0x04004F10 RID: 20240
		XSys_Mall_Home,
		// Token: 0x04004F11 RID: 20241
		XSys_LevelElite_Shop1,
		// Token: 0x04004F12 RID: 20242
		XSys_LevelElite_Shop2,
		// Token: 0x04004F13 RID: 20243
		XSys_LevelElite_Shop3,
		// Token: 0x04004F14 RID: 20244
		XSys_LevelElite_Shop4,
		// Token: 0x04004F15 RID: 20245
		XSys_Mall_Mentorship,
		// Token: 0x04004F16 RID: 20246
		XSys_Mall_Partner,
		// Token: 0x04004F17 RID: 20247
		XSys_Mall_Medal,
		// Token: 0x04004F18 RID: 20248
		XSys_Mall_SkillMark,
		// Token: 0x04004F19 RID: 20249
		XSys_Mall_Tattoo,
		// Token: 0x04004F1A RID: 20250
		XSys_Mall_Mounts,
		// Token: 0x04004F1B RID: 20251
		XSys_Mall_AllPkMatch,
		// Token: 0x04004F1C RID: 20252
		XSys_Mall_ShopMax,
		// Token: 0x04004F1D RID: 20253
		XSys_Mall_WeddingLover,
		// Token: 0x04004F1E RID: 20254
		XSys_Mall_BackFlowShop,
		// Token: 0x04004F1F RID: 20255
		XSys_Strong_Brief,
		// Token: 0x04004F20 RID: 20256
		XSys_Reward_Achivement,
		// Token: 0x04004F21 RID: 20257
		XSys_Reward_Activity,
		// Token: 0x04004F22 RID: 20258
		XSys_Reward_Login = 353,
		// Token: 0x04004F23 RID: 20259
		XSys_Reward_Dragon = 355,
		// Token: 0x04004F24 RID: 20260
		XSys_Prerogative,
		// Token: 0x04004F25 RID: 20261
		XSys_Reward_Target,
		// Token: 0x04004F26 RID: 20262
		XSys_PrerogativeShop,
		// Token: 0x04004F27 RID: 20263
		XSys_AbyssParty = 360,
		// Token: 0x04004F28 RID: 20264
		XSys_Mall_Rift = 366,
		// Token: 0x04004F29 RID: 20265
		XSys_Artifact = 370,
		// Token: 0x04004F2A RID: 20266
		XSys_Artifact_Comepose,
		// Token: 0x04004F2B RID: 20267
		XSys_Artifact_Atlas,
		// Token: 0x04004F2C RID: 20268
		XSys_Artifact_DeityStove,
		// Token: 0x04004F2D RID: 20269
		XSys_Artifact_Recast,
		// Token: 0x04004F2E RID: 20270
		XSys_Artifact_Fuse,
		// Token: 0x04004F2F RID: 20271
		XSys_Artifact_Inscription,
		// Token: 0x04004F30 RID: 20272
		XSys_Artifact_Refined,
		// Token: 0x04004F31 RID: 20273
		XSys_SmeltReturn = 380,
		// Token: 0x04004F32 RID: 20274
		XSys_EquipFusion,
		// Token: 0x04004F33 RID: 20275
		XSys_EquipUpgrade,
		// Token: 0x04004F34 RID: 20276
		XSys_H5ObligateSysOne = 390,
		// Token: 0x04004F35 RID: 20277
		XSys_H5ObligateSysTwo,
		// Token: 0x04004F36 RID: 20278
		XSys_H5ObligateSysThree,
		// Token: 0x04004F37 RID: 20279
		XSys_QQWallet,
		// Token: 0x04004F38 RID: 20280
		XSys_Rank_Rift = 408,
		// Token: 0x04004F39 RID: 20281
		XSys_Rank_WorldBoss,
		// Token: 0x04004F3A RID: 20282
		XSys_Rank_PPT,
		// Token: 0x04004F3B RID: 20283
		XSys_Rank_Level,
		// Token: 0x04004F3C RID: 20284
		XSys_Rank_Guild,
		// Token: 0x04004F3D RID: 20285
		XSys_Rank_Fashion,
		// Token: 0x04004F3E RID: 20286
		XSys_Rank_TeamTower,
		// Token: 0x04004F3F RID: 20287
		XSys_Rank_GuildBoss,
		// Token: 0x04004F40 RID: 20288
		XSys_Rank_Pet,
		// Token: 0x04004F41 RID: 20289
		XSys_Rank_Sprite,
		// Token: 0x04004F42 RID: 20290
		XSys_Rank_Qualifying,
		// Token: 0x04004F43 RID: 20291
		XSys_Rank_BigMelee,
		// Token: 0x04004F44 RID: 20292
		XSys_Flower_Rank_Today,
		// Token: 0x04004F45 RID: 20293
		XSys_Flower_Rank_Yesterday,
		// Token: 0x04004F46 RID: 20294
		XSys_Flower_Rank_History,
		// Token: 0x04004F47 RID: 20295
		XSys_Flower_Rank_Week,
		// Token: 0x04004F48 RID: 20296
		XSys_Flower_Log,
		// Token: 0x04004F49 RID: 20297
		XSys_Flower_Log_Send,
		// Token: 0x04004F4A RID: 20298
		XSys_Flower_Log_Receive,
		// Token: 0x04004F4B RID: 20299
		XSys_Flower_Rank_Activity,
		// Token: 0x04004F4C RID: 20300
		XSys_Rank_DragonGuild = 430,
		// Token: 0x04004F4D RID: 20301
		XSys_Rank_SkyArena,
		// Token: 0x04004F4E RID: 20302
		XSys_Rank_CampDuel,
		// Token: 0x04004F4F RID: 20303
		XSys_Yorozuya = 440,
		// Token: 0x04004F50 RID: 20304
		XSys_EquipCreate_EquipSet = 450,
		// Token: 0x04004F51 RID: 20305
		XSys_EquipCreate_EmblemSet,
		// Token: 0x04004F52 RID: 20306
		XSys_EquipCreate_ArtifactSet,
		// Token: 0x04004F53 RID: 20307
		XSys_SystemActivity_Other = 460,
		// Token: 0x04004F54 RID: 20308
		XSys_LevelSeal_Tip = 470,
		// Token: 0x04004F55 RID: 20309
		XSys_MentorshipMsg_Tip,
		// Token: 0x04004F56 RID: 20310
		XSys_Nest_QuanMin = 510,
		// Token: 0x04004F57 RID: 20311
		XSys_DragonNest_QuanMin,
		// Token: 0x04004F58 RID: 20312
		XSys_Activity_Nest = 520,
		// Token: 0x04004F59 RID: 20313
		XSys_Activity_SmallMonster,
		// Token: 0x04004F5A RID: 20314
		XSys_Activity_BossRush,
		// Token: 0x04004F5B RID: 20315
		XSys_Activity_Fashion,
		// Token: 0x04004F5C RID: 20316
		XSys_Activity_WorldBoss,
		// Token: 0x04004F5D RID: 20317
		XSys_Activity_ExpeditionFrame,
		// Token: 0x04004F5E RID: 20318
		XSys_Activity_DragonNest,
		// Token: 0x04004F5F RID: 20319
		XSys_Activity_TeamTower,
		// Token: 0x04004F60 RID: 20320
		XSys_Activity_CaptainPVP,
		// Token: 0x04004F61 RID: 20321
		XSys_Activity_GoddessTrial,
		// Token: 0x04004F62 RID: 20322
		XSys_Activity_TeamTowerSingle,
		// Token: 0x04004F63 RID: 20323
		XSys_BigMelee,
		// Token: 0x04004F64 RID: 20324
		XSys_BigMeleeEnd,
		// Token: 0x04004F65 RID: 20325
		XSys_Battlefield,
		// Token: 0x04004F66 RID: 20326
		XSys_EndlessAbyss = 540,
		// Token: 0x04004F67 RID: 20327
		XSys_Shanggu,
		// Token: 0x04004F68 RID: 20328
		XSys_Activity_WeekDragonNest,
		// Token: 0x04004F69 RID: 20329
		XSys_MulActivity_MulVoiceQA = 551,
		// Token: 0x04004F6A RID: 20330
		XSys_MulActivity_SkyArena,
		// Token: 0x04004F6B RID: 20331
		XSys_MulActivity_Race,
		// Token: 0x04004F6C RID: 20332
		XSys_MulActivity_WeekendParty,
		// Token: 0x04004F6D RID: 20333
		XSys_MulActivity_SkyArenaEnd,
		// Token: 0x04004F6E RID: 20334
		XSys_Welfare = 560,
		// Token: 0x04004F6F RID: 20335
		XSys_Welfare_GiftBag = 562,
		// Token: 0x04004F70 RID: 20336
		XSys_Welfare_StarFund,
		// Token: 0x04004F71 RID: 20337
		XSys_Welfare_FirstRechange,
		// Token: 0x04004F72 RID: 20338
		XSyS_Welfare_RewardBack,
		// Token: 0x04004F73 RID: 20339
		XSys_Welfare_MoneyTree,
		// Token: 0x04004F74 RID: 20340
		XSys_Welfare_KingdomPrivilege,
		// Token: 0x04004F75 RID: 20341
		XSys_Welfare_KingdomPrivilege_Court,
		// Token: 0x04004F76 RID: 20342
		XSys_Welfare_KingdomPrivilege_Adventurer,
		// Token: 0x04004F77 RID: 20343
		XSys_Welfare_KingdomPrivilege_Commerce,
		// Token: 0x04004F78 RID: 20344
		XSys_Welfare_NiceGirl,
		// Token: 0x04004F79 RID: 20345
		XSys_Welfare_YyMall,
		// Token: 0x04004F7A RID: 20346
		Xsys_Backflow = 580,
		// Token: 0x04004F7B RID: 20347
		Xsys_Backflow_LavishGift,
		// Token: 0x04004F7C RID: 20348
		Xsys_Backflow_Dailylogin,
		// Token: 0x04004F7D RID: 20349
		Xsys_Backflow_GiftBag,
		// Token: 0x04004F7E RID: 20350
		Xsys_Backflow_NewServerReward,
		// Token: 0x04004F7F RID: 20351
		Xsys_Server_Two,
		// Token: 0x04004F80 RID: 20352
		Xsys_Backflow_LevelUp,
		// Token: 0x04004F81 RID: 20353
		Xsys_Backflow_Task,
		// Token: 0x04004F82 RID: 20354
		Xsys_Backflow_Target,
		// Token: 0x04004F83 RID: 20355
		Xsys_Backflow_Privilege,
		// Token: 0x04004F84 RID: 20356
		Xsys_TaJieHelp,
		// Token: 0x04004F85 RID: 20357
		XSys_InGameAD = 599,
		// Token: 0x04004F86 RID: 20358
		XSys_OperatingActivity,
		// Token: 0x04004F87 RID: 20359
		XSys_FirstPass,
		// Token: 0x04004F88 RID: 20360
		XSys_MWCX,
		// Token: 0x04004F89 RID: 20361
		XSys_GHJC,
		// Token: 0x04004F8A RID: 20362
		XSys_GuildRank,
		// Token: 0x04004F8B RID: 20363
		XSys_Flower_Activity,
		// Token: 0x04004F8C RID: 20364
		XSys_CrushingSeal,
		// Token: 0x04004F8D RID: 20365
		XSys_WeekNest,
		// Token: 0x04004F8E RID: 20366
		XSys_Holiday = 609,
		// Token: 0x04004F8F RID: 20367
		XSys_Announcement,
		// Token: 0x04004F90 RID: 20368
		XSys_Patface,
		// Token: 0x04004F91 RID: 20369
		XSys_PandoraSDK,
		// Token: 0x04004F92 RID: 20370
		XSys_OldFriendsBack,
		// Token: 0x04004F93 RID: 20371
		XSys_CampDuel,
		// Token: 0x04004F94 RID: 20372
		XSys_Dance1,
		// Token: 0x04004F95 RID: 20373
		XSys_Dance2,
		// Token: 0x04004F96 RID: 20374
		XSys_Dance3,
		// Token: 0x04004F97 RID: 20375
		XSys_Dance4,
		// Token: 0x04004F98 RID: 20376
		XSys_Dance5,
		// Token: 0x04004F99 RID: 20377
		XSys_Dance6,
		// Token: 0x04004F9A RID: 20378
		XSys_Dance7,
		// Token: 0x04004F9B RID: 20379
		XSys_Dance8,
		// Token: 0x04004F9C RID: 20380
		XSys_Dance9,
		// Token: 0x04004F9D RID: 20381
		XSys_Dance10,
		// Token: 0x04004F9E RID: 20382
		XSys_Dance11,
		// Token: 0x04004F9F RID: 20383
		XSys_Dance12,
		// Token: 0x04004FA0 RID: 20384
		XSys_Dance13,
		// Token: 0x04004FA1 RID: 20385
		XSys_Dance14,
		// Token: 0x04004FA2 RID: 20386
		XSys_Dance15,
		// Token: 0x04004FA3 RID: 20387
		XSys_Dance16,
		// Token: 0x04004FA4 RID: 20388
		XSys_Dance17,
		// Token: 0x04004FA5 RID: 20389
		XSys_Dance18,
		// Token: 0x04004FA6 RID: 20390
		XSys_LuckyTurntable,
		// Token: 0x04004FA7 RID: 20391
		XSys_GameMall_Diamond = 650,
		// Token: 0x04004FA8 RID: 20392
		XSys_GameMall_Dragon,
		// Token: 0x04004FA9 RID: 20393
		XSys_GameMall_Pay,
		// Token: 0x04004FAA RID: 20394
		XSys_GameMall_DWeek,
		// Token: 0x04004FAB RID: 20395
		XSys_GameMall_DCost,
		// Token: 0x04004FAC RID: 20396
		XSys_GameMall_DLongyu,
		// Token: 0x04004FAD RID: 20397
		XSys_GameMall_DFashion,
		// Token: 0x04004FAE RID: 20398
		XSys_GameMall_DRide,
		// Token: 0x04004FAF RID: 20399
		XSys_GameMall_DGift,
		// Token: 0x04004FB0 RID: 20400
		XSys_GameMall_DVip,
		// Token: 0x04004FB1 RID: 20401
		XSys_GameMall_GWeek,
		// Token: 0x04004FB2 RID: 20402
		XSys_GameMall_GCost,
		// Token: 0x04004FB3 RID: 20403
		XSys_GameMall_GLongyu,
		// Token: 0x04004FB4 RID: 20404
		XSys_GameMall_GRide,
		// Token: 0x04004FB5 RID: 20405
		XSys_GameMall_GGift,
		// Token: 0x04004FB6 RID: 20406
		XSys_GameMall_GEquip,
		// Token: 0x04004FB7 RID: 20407
		Xsys_GameMall_DEquip,
		// Token: 0x04004FB8 RID: 20408
		XSys_Carnival_Tabs = 670,
		// Token: 0x04004FB9 RID: 20409
		XSys_Carnival_Rwd,
		// Token: 0x04004FBA RID: 20410
		XSys_Carnival_Content,
		// Token: 0x04004FBB RID: 20411
		XSys_Partner = 700,
		// Token: 0x04004FBC RID: 20412
		XSys_Parner_Liveness,
		// Token: 0x04004FBD RID: 20413
		XSys_Wedding,
		// Token: 0x04004FBE RID: 20414
		XSys_NPCFavor,
		// Token: 0x04004FBF RID: 20415
		XSys_GC_XinYueVIP = 710,
		// Token: 0x04004FC0 RID: 20416
		XSys_GC_CustomService,
		// Token: 0x04004FC1 RID: 20417
		XSys_GC_GameWebsite,
		// Token: 0x04004FC2 RID: 20418
		XSys_GC_Forum,
		// Token: 0x04004FC3 RID: 20419
		XSys_GC_Privilege,
		// Token: 0x04004FC4 RID: 20420
		XSys_GC_OfficialAccounts,
		// Token: 0x04004FC5 RID: 20421
		XSys_GC_DeepLink,
		// Token: 0x04004FC6 RID: 20422
		XSys_GC_MiniCommunity = 718,
		// Token: 0x04004FC7 RID: 20423
		XSys_GC_IOSLive = 721,
		// Token: 0x04004FC8 RID: 20424
		XSys_GC_TVStation,
		// Token: 0x04004FC9 RID: 20425
		XSys_GC_XiaoYueGuanJia,
		// Token: 0x04004FCA RID: 20426
		XSys_GC_Libaozhongxin,
		// Token: 0x04004FCB RID: 20427
		XSys_GC_Reserve17,
		// Token: 0x04004FCC RID: 20428
		XSys_GC_Reserve18,
		// Token: 0x04004FCD RID: 20429
		XSys_GC_Reserve19,
		// Token: 0x04004FCE RID: 20430
		XSys_GC_Reserve20,
		// Token: 0x04004FCF RID: 20431
		XSys_GC_Reserve21,
		// Token: 0x04004FD0 RID: 20432
		XSys_Pandora730,
		// Token: 0x04004FD1 RID: 20433
		XSys_Pandora731,
		// Token: 0x04004FD2 RID: 20434
		XSys_Pandora732,
		// Token: 0x04004FD3 RID: 20435
		XSys_Pandora733,
		// Token: 0x04004FD4 RID: 20436
		XSys_Pandora734,
		// Token: 0x04004FD5 RID: 20437
		XSys_Pandora735,
		// Token: 0x04004FD6 RID: 20438
		XSys_Pandora736,
		// Token: 0x04004FD7 RID: 20439
		XSys_Pandora737,
		// Token: 0x04004FD8 RID: 20440
		XSys_Pandora738,
		// Token: 0x04004FD9 RID: 20441
		XSys_Pandora739,
		// Token: 0x04004FDA RID: 20442
		XSys_Pandora740,
		// Token: 0x04004FDB RID: 20443
		XSys_Pandora741,
		// Token: 0x04004FDC RID: 20444
		XSys_Pandora742,
		// Token: 0x04004FDD RID: 20445
		XSys_Pandora743,
		// Token: 0x04004FDE RID: 20446
		XSys_Pandora744,
		// Token: 0x04004FDF RID: 20447
		XSys_Pandora745,
		// Token: 0x04004FE0 RID: 20448
		XSys_Pandora746,
		// Token: 0x04004FE1 RID: 20449
		XSys_Pandora747,
		// Token: 0x04004FE2 RID: 20450
		XSys_Pandora748,
		// Token: 0x04004FE3 RID: 20451
		XSys_Pandora749,
		// Token: 0x04004FE4 RID: 20452
		XSys_PandoraTest,
		// Token: 0x04004FE5 RID: 20453
		XSys_GroupRecruit = 760,
		// Token: 0x04004FE6 RID: 20454
		XSys_GroupRecruitAuthorize,
		// Token: 0x04004FE7 RID: 20455
		XSys_ThemeActivity = 770,
		// Token: 0x04004FE8 RID: 20456
		XSys_ThemeActivity_HellDog,
		// Token: 0x04004FE9 RID: 20457
		XSys_ThemeActivity_MadDuck,
		// Token: 0x04004FEA RID: 20458
		XSys_GuildHall_SignIn = 810,
		// Token: 0x04004FEB RID: 20459
		XSys_GuildHall_Approve,
		// Token: 0x04004FEC RID: 20460
		XSys_GuildHall_Skill,
		// Token: 0x04004FED RID: 20461
		XSys_GuildHall_Member,
		// Token: 0x04004FEE RID: 20462
		XSys_GuildRelax_Joker = 820,
		// Token: 0x04004FEF RID: 20463
		XSys_GuildRelax_VoiceQA,
		// Token: 0x04004FF0 RID: 20464
		XSys_GuildRelax_JokerMatch,
		// Token: 0x04004FF1 RID: 20465
		XSys_GuildLab_Consider,
		// Token: 0x04004FF2 RID: 20466
		XSys_GuildLab_Build,
		// Token: 0x04004FF3 RID: 20467
		XSys_GuildGrowthHunting,
		// Token: 0x04004FF4 RID: 20468
		XSys_GuildGrowthDonate,
		// Token: 0x04004FF5 RID: 20469
		XSys_GuildGrowthBuff,
		// Token: 0x04004FF6 RID: 20470
		XSys_GuildGrowthLab,
		// Token: 0x04004FF7 RID: 20471
		XSys_GuildBoon_RedPacket = 830,
		// Token: 0x04004FF8 RID: 20472
		XSys_GuildBoon_FixedRedPacket = 834,
		// Token: 0x04004FF9 RID: 20473
		XSys_GuildBoon_Shop = 831,
		// Token: 0x04004FFA RID: 20474
		XSys_GuildBoon_DailyActivity,
		// Token: 0x04004FFB RID: 20475
		XSys_GuildBoon_Salay,
		// Token: 0x04004FFC RID: 20476
		XSys_GuildDungeon_SmallMonter = 840,
		// Token: 0x04004FFD RID: 20477
		XSys_GuildChallenge = 850,
		// Token: 0x04004FFE RID: 20478
		XSys_GuildChallenge_MemberRank,
		// Token: 0x04004FFF RID: 20479
		XSys_GuildChallenge_GuildRank,
		// Token: 0x04005000 RID: 20480
		XSys_WorldBoss_EndRank = 855,
		// Token: 0x04005001 RID: 20481
		XSys_GuildQualifier = 860,
		// Token: 0x04005002 RID: 20482
		XSys_GuildMineMain = 880,
		// Token: 0x04005003 RID: 20483
		XSys_GuildDailyTask = 886,
		// Token: 0x04005004 RID: 20484
		XSys_GuildDialyDonate,
		// Token: 0x04005005 RID: 20485
		XSys_GuildWeeklyDonate,
		// Token: 0x04005006 RID: 20486
		XSys_GuildInherit = 890,
		// Token: 0x04005007 RID: 20487
		XSys_JockerKing = 900,
		// Token: 0x04005008 RID: 20488
		XSys_Team_TeamList,
		// Token: 0x04005009 RID: 20489
		XSys_Team_MyTeam,
		// Token: 0x0400500A RID: 20490
		XSys_Team_Invited,
		// Token: 0x0400500B RID: 20491
		XSys_GuildWeeklyBountyTask,
		// Token: 0x0400500C RID: 20492
		XSys_GuildDailyRefresh,
		// Token: 0x0400500D RID: 20493
		XSys_GuildDailyRequest,
		// Token: 0x0400500E RID: 20494
		XSys_GayValley_Fashion = 910,
		// Token: 0x0400500F RID: 20495
		XSys_GayValley_Fishing,
		// Token: 0x04005010 RID: 20496
		XSys_GayValleyManager_Return = 920,
		// Token: 0x04005011 RID: 20497
		XSys_Qualifying2,
		// Token: 0x04005012 RID: 20498
		XSys_IDIP_ZeroReward = 925,
		// Token: 0x04005013 RID: 20499
		XSys_Photo,
		// Token: 0x04005014 RID: 20500
		xSys_Mysterious,
		// Token: 0x04005015 RID: 20501
		XSys_SpriteSystem = 930,
		// Token: 0x04005016 RID: 20502
		XSys_SpriteSystem_Main,
		// Token: 0x04005017 RID: 20503
		XSys_SpriteSystem_Lottery,
		// Token: 0x04005018 RID: 20504
		XSys_SpriteSystem_Fight,
		// Token: 0x04005019 RID: 20505
		XSys_SpriteSystem_Resolve,
		// Token: 0x0400501A RID: 20506
		XSys_SpriteSystem_Detail,
		// Token: 0x0400501B RID: 20507
		XSys_SpriteSystem_Shop,
		// Token: 0x0400501C RID: 20508
		XSys_Title_Share = 941,
		// Token: 0x0400501D RID: 20509
		XSys_Link_Share,
		// Token: 0x0400501E RID: 20510
		XSys_QuickRide,
		// Token: 0x0400501F RID: 20511
		XSys_AppStore_Praise,
		// Token: 0x04005020 RID: 20512
		XSys_Transform,
		// Token: 0x04005021 RID: 20513
		XSys_WebView = 949,
		// Token: 0x04005022 RID: 20514
		XSys_GameCommunity,
		// Token: 0x04005023 RID: 20515
		XSys_GameHorde,
		// Token: 0x04005024 RID: 20516
		XSys_FriendCircle,
		// Token: 0x04005025 RID: 20517
		XSys_QQVIP,
		// Token: 0x04005026 RID: 20518
		XSys_SystemAnnounce,
		// Token: 0x04005027 RID: 20519
		XSys_HeroBattle = 956,
		// Token: 0x04005028 RID: 20520
		XSys_GuildBossMainInterface,
		// Token: 0x04005029 RID: 20521
		XSys_GuildMineMainInterface,
		// Token: 0x0400502A RID: 20522
		XSys_GuildPvpMainInterface,
		// Token: 0x0400502B RID: 20523
		XSys_TeamLeague,
		// Token: 0x0400502C RID: 20524
		XSys_ProfessionChange,
		// Token: 0x0400502D RID: 20525
		XSys_Questionnaire,
		// Token: 0x0400502E RID: 20526
		XSys_GuildMineEnd,
		// Token: 0x0400502F RID: 20527
		XSys_GuildTerritory = 970,
		// Token: 0x04005030 RID: 20528
		XSys_GuildTerritoryAllianceInterface = 972,
		// Token: 0x04005031 RID: 20529
		XSys_GuildTerritoryIconInterface = 971,
		// Token: 0x04005032 RID: 20530
		XSys_GuildTerritoryMessageInterface = 973,
		// Token: 0x04005033 RID: 20531
		XSys_Moba = 979,
		// Token: 0x04005034 RID: 20532
		XSys_Friends_Gift_Share,
		// Token: 0x04005035 RID: 20533
		XSys_Guild_Bind_Group,
		// Token: 0x04005036 RID: 20534
		XSys_Platform_StartPrivilege,
		// Token: 0x04005037 RID: 20535
		XSys_Photo_Share,
		// Token: 0x04005038 RID: 20536
		XSys_Friends_Pk,
		// Token: 0x04005039 RID: 20537
		SYS_IBSHOP_GIFT,
		// Token: 0x0400503A RID: 20538
		XSys_Cross_Server_Invite,
		// Token: 0x0400503B RID: 20539
		XSys_Rename_Player = 988,
		// Token: 0x0400503C RID: 20540
		XSys_Rename_Guild,
		// Token: 0x0400503D RID: 20541
		XSys_Rename_DragonGuild = 1001,
		// Token: 0x0400503E RID: 20542
		XSys_Exchange = 990,
		// Token: 0x0400503F RID: 20543
		XSys_GuildCollectMainInterface,
		// Token: 0x04005040 RID: 20544
		XSys_GuildCollect,
		// Token: 0x04005041 RID: 20545
		XSys_BackFlowMall,
		// Token: 0x04005042 RID: 20546
		XSys_BackFlowWelfare,
		// Token: 0x04005043 RID: 20547
		XSys_GuildCollectSummon = 996,
		// Token: 0x04005044 RID: 20548
		XSys_DragonGuild = 996,
		// Token: 0x04005045 RID: 20549
		XSys_DragonGuildShop,
		// Token: 0x04005046 RID: 20550
		XSys_DragonGuildLiveness,
		// Token: 0x04005047 RID: 20551
		XSys_DragonGuildTask,
		// Token: 0x04005048 RID: 20552
		XSys_DragonGuild_Bind_Group,
		// Token: 0x04005049 RID: 20553
		XSys_Num = 1024
	}
}

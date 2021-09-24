using System;

namespace XMainClient
{

	public enum XSysDefine
	{

		XSys_Invalid = -1,

		XSys_None,

		XSys_Character = 10,

		XSys_Level,

		XSys_Item,

		XSys_Skill,

		XSys_Char,

		XSys_Horse,

		XSys_Fashion,

		XSys_Guild,

		XSys_Recycle,

		XSys_Bag,

		XSys_TShow,

		XSys_Confession,

		XSys_Auction,

		XSys_TShowRule,

		XSys_FlowerRank,

		XSys_CardCollect,

		XSys_Camp,

		XSys_Mail,

		XSys_Wifi,

		XSys_Design,

		XSys_SuperReward,

		XSys_Draw,

		XSys_Mall,

		XSys_Strong,

		XSys_Target,

		XSys_Reward,

		XSys_ServerActivity = 37,

		XSys_OnlineReward = 39,

		XSys_Setting,

		XSys_Rank,

		XSys_LevelReward,

		XSys_ReceiveEnergy = 44,

		XSys_EquipCreate,

		XSys_SystemActivity,

		XSys_LevelSeal,

		XSys_BossRush,

		XSys_SuperRisk,

		XSys_DragonCrusade,

		XSys_Arena,

		XSys_Activity,

		XSys_Qualifying = 54,

		XSys_MulActivity,

		XSys_Spectate,

		XSys_DailyAcitivity,

		XSys_PVPAcitivity,

		XSys_ExcellentLive,

		XSys_MobaAcitivity,

		XSys_Money,

		XSys_Coin,

		XSys_Power,

		XSys_DragonCoin,

		XSys_GameMall,

		XSys_Carnival = 67,

		XSys_WeekShareReward,

		XSys_DungeonShareReward,

		XSys_OtherPlayerInfo,

		XSys_Chat,

		XSys_Friends,

		XSys_Maquee,

		XSys_SendFlower,

		XSys_Mentorship,

		XSys_PK,

		XSys_3GFree,

		XSys_ChatGroup,

		XSys_Broadcast = 80,

		XSys_GuildHall,

		XSys_GuildRelax,

		XSys_GuildDragon = 85,

		XSys_GuildPvp,

		XSys_GuildRedPacket,

		XSys_GuildMine,

		XSys_CrossGVG,

		XSys_Team,

		XSys_GayValley,

		XSys_GayValleyManager,

		XSys_SevenActivity,

		XSys_Title,

		XSys_Task,

		XSys_Pandora,

		XSys_Personal_Career,

		XSys_MilitaryRank,

		XSys_Recharge = 100,

		XSys_VIP,

		XSys_Random_Gift,

		XSys_HallFame,

		XSys_Level_Normal = 110,

		XSys_Level_Elite,

		XSys_Level_Swap,

		XSys_Item_Equip = 120,

		XSys_Item_Enhance,

		XSys_Item_Jade,

		XSys_Item_SlotAttr,

		XSys_Item_Smelting,

		XSys_Item_Reinforce,

		XSys_Emblem_Smelting,

		XSys_Item_Enchant,

		XSys_Item_Forge,

		XSys_Skill_Levelup = 130,

		XSys_Skill_Promote,

		XSys_Char_Attr = 140,

		XSys_Char_Emblem,

		XSys_Home = 150,

		XSys_Home_Cooking,

		XSys_Home_Fishing,

		XSys_Home_Plant,

		XSys_Home_Feast,

		XSys_Home_MyHome,

		XSys_Home_HomeFriends,

		XSys_Horse_LearnSkill = 159,

		XSys_Fashion_Fashion,

		XSys_Fashion_Wearing = 162,

		XSys_Fashion_OutLook = 161,

		XSys_Item_Compose = 170,

		XSys_Pet_Pairs,

		XSys_Recycle_Equip = 180,

		XSys_Recycle_Jade,

		XSys_Bag_Item = 190,

		XSys_TShow_Vote = 200,

		XSys_TShow_Main,

		XSys_CustomBattle = 220,

		XSys_CustomBattle_BountyMode,

		XSys_CustomBattle_CustomMode,

		XSys_WeekEndNest = 230,

		XSys_Camp_CampHall = 260,

		XSys_Camp_MemberHall,

		XSys_Camp_Mission = 269,

		XSys_DragonNest_Sweep,

		XSys_Mail_System,

		XSys_Mail_Player,

		XSys_Mail_Content,

		XSys_Design_Designation = 290,

		XSys_Design_Achieve,

		XSys_Mall_Happy = 294,

		XSys_Mall_New_One,

		XSys_Mall_New_Two,

		XSys_Mall_New_Three,

		XSys_Mall_New_Four,

		XSys_Mall_MystShop = 320,

		XSys_Mall_Mall,

		XSys_Mall_Fasion,

		XSys_Mall_Honer,

		XSys_Mall_Guild,

		XSys_Mall_Tear,

		XSys_Mall_Card1,

		XSys_Mall_Card2,

		XSys_Mall_Card3,

		XSys_Mall_Card4,

		XSys_Mall_32A,

		XSys_Mall_40A,

		XSys_Mall_50A,

		XSys_Mall_60A,

		XSys_Mall_Home,

		XSys_LevelElite_Shop1,

		XSys_LevelElite_Shop2,

		XSys_LevelElite_Shop3,

		XSys_LevelElite_Shop4,

		XSys_Mall_Mentorship,

		XSys_Mall_Partner,

		XSys_Mall_Medal,

		XSys_Mall_SkillMark,

		XSys_Mall_Tattoo,

		XSys_Mall_Mounts,

		XSys_Mall_AllPkMatch,

		XSys_Mall_ShopMax,

		XSys_Mall_WeddingLover,

		XSys_Mall_BackFlowShop,

		XSys_Strong_Brief,

		XSys_Reward_Achivement,

		XSys_Reward_Activity,

		XSys_Reward_Login = 353,

		XSys_Reward_Dragon = 355,

		XSys_Prerogative,

		XSys_Reward_Target,

		XSys_PrerogativeShop,

		XSys_AbyssParty = 360,

		XSys_Mall_Rift = 366,

		XSys_Artifact = 370,

		XSys_Artifact_Comepose,

		XSys_Artifact_Atlas,

		XSys_Artifact_DeityStove,

		XSys_Artifact_Recast,

		XSys_Artifact_Fuse,

		XSys_Artifact_Inscription,

		XSys_Artifact_Refined,

		XSys_SmeltReturn = 380,

		XSys_EquipFusion,

		XSys_EquipUpgrade,

		XSys_H5ObligateSysOne = 390,

		XSys_H5ObligateSysTwo,

		XSys_H5ObligateSysThree,

		XSys_QQWallet,

		XSys_Rank_Rift = 408,

		XSys_Rank_WorldBoss,

		XSys_Rank_PPT,

		XSys_Rank_Level,

		XSys_Rank_Guild,

		XSys_Rank_Fashion,

		XSys_Rank_TeamTower,

		XSys_Rank_GuildBoss,

		XSys_Rank_Pet,

		XSys_Rank_Sprite,

		XSys_Rank_Qualifying,

		XSys_Rank_BigMelee,

		XSys_Flower_Rank_Today,

		XSys_Flower_Rank_Yesterday,

		XSys_Flower_Rank_History,

		XSys_Flower_Rank_Week,

		XSys_Flower_Log,

		XSys_Flower_Log_Send,

		XSys_Flower_Log_Receive,

		XSys_Flower_Rank_Activity,

		XSys_Rank_DragonGuild = 430,

		XSys_Rank_SkyArena,

		XSys_Rank_CampDuel,

		XSys_Yorozuya = 440,

		XSys_EquipCreate_EquipSet = 450,

		XSys_EquipCreate_EmblemSet,

		XSys_EquipCreate_ArtifactSet,

		XSys_SystemActivity_Other = 460,

		XSys_LevelSeal_Tip = 470,

		XSys_MentorshipMsg_Tip,

		XSys_Nest_QuanMin = 510,

		XSys_DragonNest_QuanMin,

		XSys_Activity_Nest = 520,

		XSys_Activity_SmallMonster,

		XSys_Activity_BossRush,

		XSys_Activity_Fashion,

		XSys_Activity_WorldBoss,

		XSys_Activity_ExpeditionFrame,

		XSys_Activity_DragonNest,

		XSys_Activity_TeamTower,

		XSys_Activity_CaptainPVP,

		XSys_Activity_GoddessTrial,

		XSys_Activity_TeamTowerSingle,

		XSys_BigMelee,

		XSys_BigMeleeEnd,

		XSys_Battlefield,

		XSys_EndlessAbyss = 540,

		XSys_Shanggu,

		XSys_Activity_WeekDragonNest,

		XSys_MulActivity_MulVoiceQA = 551,

		XSys_MulActivity_SkyArena,

		XSys_MulActivity_Race,

		XSys_MulActivity_WeekendParty,

		XSys_MulActivity_SkyArenaEnd,

		XSys_Welfare = 560,

		XSys_Welfare_GiftBag = 562,

		XSys_Welfare_StarFund,

		XSys_Welfare_FirstRechange,

		XSyS_Welfare_RewardBack,

		XSys_Welfare_MoneyTree,

		XSys_Welfare_KingdomPrivilege,

		XSys_Welfare_KingdomPrivilege_Court,

		XSys_Welfare_KingdomPrivilege_Adventurer,

		XSys_Welfare_KingdomPrivilege_Commerce,

		XSys_Welfare_NiceGirl,

		XSys_Welfare_YyMall,

		Xsys_Backflow = 580,

		Xsys_Backflow_LavishGift,

		Xsys_Backflow_Dailylogin,

		Xsys_Backflow_GiftBag,

		Xsys_Backflow_NewServerReward,

		Xsys_Server_Two,

		Xsys_Backflow_LevelUp,

		Xsys_Backflow_Task,

		Xsys_Backflow_Target,

		Xsys_Backflow_Privilege,

		Xsys_TaJieHelp,

		XSys_InGameAD = 599,

		XSys_OperatingActivity,

		XSys_FirstPass,

		XSys_MWCX,

		XSys_GHJC,

		XSys_GuildRank,

		XSys_Flower_Activity,

		XSys_CrushingSeal,

		XSys_WeekNest,

		XSys_Holiday = 609,

		XSys_Announcement,

		XSys_Patface,

		XSys_PandoraSDK,

		XSys_OldFriendsBack,

		XSys_CampDuel,

		XSys_Dance1,

		XSys_Dance2,

		XSys_Dance3,

		XSys_Dance4,

		XSys_Dance5,

		XSys_Dance6,

		XSys_Dance7,

		XSys_Dance8,

		XSys_Dance9,

		XSys_Dance10,

		XSys_Dance11,

		XSys_Dance12,

		XSys_Dance13,

		XSys_Dance14,

		XSys_Dance15,

		XSys_Dance16,

		XSys_Dance17,

		XSys_Dance18,

		XSys_LuckyTurntable,

		XSys_GameMall_Diamond = 650,

		XSys_GameMall_Dragon,

		XSys_GameMall_Pay,

		XSys_GameMall_DWeek,

		XSys_GameMall_DCost,

		XSys_GameMall_DLongyu,

		XSys_GameMall_DFashion,

		XSys_GameMall_DRide,

		XSys_GameMall_DGift,

		XSys_GameMall_DVip,

		XSys_GameMall_GWeek,

		XSys_GameMall_GCost,

		XSys_GameMall_GLongyu,

		XSys_GameMall_GRide,

		XSys_GameMall_GGift,

		XSys_GameMall_GEquip,

		Xsys_GameMall_DEquip,

		XSys_Carnival_Tabs = 670,

		XSys_Carnival_Rwd,

		XSys_Carnival_Content,

		XSys_Partner = 700,

		XSys_Parner_Liveness,

		XSys_Wedding,

		XSys_NPCFavor,

		XSys_GC_XinYueVIP = 710,

		XSys_GC_CustomService,

		XSys_GC_GameWebsite,

		XSys_GC_Forum,

		XSys_GC_Privilege,

		XSys_GC_OfficialAccounts,

		XSys_GC_DeepLink,

		XSys_GC_MiniCommunity = 718,

		XSys_GC_IOSLive = 721,

		XSys_GC_TVStation,

		XSys_GC_XiaoYueGuanJia,

		XSys_GC_Libaozhongxin,

		XSys_GC_Reserve17,

		XSys_GC_Reserve18,

		XSys_GC_Reserve19,

		XSys_GC_Reserve20,

		XSys_GC_Reserve21,

		XSys_Pandora730,

		XSys_Pandora731,

		XSys_Pandora732,

		XSys_Pandora733,

		XSys_Pandora734,

		XSys_Pandora735,

		XSys_Pandora736,

		XSys_Pandora737,

		XSys_Pandora738,

		XSys_Pandora739,

		XSys_Pandora740,

		XSys_Pandora741,

		XSys_Pandora742,

		XSys_Pandora743,

		XSys_Pandora744,

		XSys_Pandora745,

		XSys_Pandora746,

		XSys_Pandora747,

		XSys_Pandora748,

		XSys_Pandora749,

		XSys_PandoraTest,

		XSys_GroupRecruit = 760,

		XSys_GroupRecruitAuthorize,

		XSys_ThemeActivity = 770,

		XSys_ThemeActivity_HellDog,

		XSys_ThemeActivity_MadDuck,

		XSys_GuildHall_SignIn = 810,

		XSys_GuildHall_Approve,

		XSys_GuildHall_Skill,

		XSys_GuildHall_Member,

		XSys_GuildRelax_Joker = 820,

		XSys_GuildRelax_VoiceQA,

		XSys_GuildRelax_JokerMatch,

		XSys_GuildLab_Consider,

		XSys_GuildLab_Build,

		XSys_GuildGrowthHunting,

		XSys_GuildGrowthDonate,

		XSys_GuildGrowthBuff,

		XSys_GuildGrowthLab,

		XSys_GuildBoon_RedPacket = 830,

		XSys_GuildBoon_FixedRedPacket = 834,

		XSys_GuildBoon_Shop = 831,

		XSys_GuildBoon_DailyActivity,

		XSys_GuildBoon_Salay,

		XSys_GuildDungeon_SmallMonter = 840,

		XSys_GuildChallenge = 850,

		XSys_GuildChallenge_MemberRank,

		XSys_GuildChallenge_GuildRank,

		XSys_WorldBoss_EndRank = 855,

		XSys_GuildQualifier = 860,

		XSys_GuildMineMain = 880,

		XSys_GuildDailyTask = 886,

		XSys_GuildDialyDonate,

		XSys_GuildWeeklyDonate,

		XSys_GuildInherit = 890,

		XSys_JockerKing = 900,

		XSys_Team_TeamList,

		XSys_Team_MyTeam,

		XSys_Team_Invited,

		XSys_GuildWeeklyBountyTask,

		XSys_GuildDailyRefresh,

		XSys_GuildDailyRequest,

		XSys_GayValley_Fashion = 910,

		XSys_GayValley_Fishing,

		XSys_GayValleyManager_Return = 920,

		XSys_Qualifying2,

		XSys_IDIP_ZeroReward = 925,

		XSys_Photo,

		xSys_Mysterious,

		XSys_SpriteSystem = 930,

		XSys_SpriteSystem_Main,

		XSys_SpriteSystem_Lottery,

		XSys_SpriteSystem_Fight,

		XSys_SpriteSystem_Resolve,

		XSys_SpriteSystem_Detail,

		XSys_SpriteSystem_Shop,

		XSys_Title_Share = 941,

		XSys_Link_Share,

		XSys_QuickRide,

		XSys_AppStore_Praise,

		XSys_Transform,

		XSys_WebView = 949,

		XSys_GameCommunity,

		XSys_GameHorde,

		XSys_FriendCircle,

		XSys_QQVIP,

		XSys_SystemAnnounce,

		XSys_HeroBattle = 956,

		XSys_GuildBossMainInterface,

		XSys_GuildMineMainInterface,

		XSys_GuildPvpMainInterface,

		XSys_TeamLeague,

		XSys_ProfessionChange,

		XSys_Questionnaire,

		XSys_GuildMineEnd,

		XSys_GuildTerritory = 970,

		XSys_GuildTerritoryAllianceInterface = 972,

		XSys_GuildTerritoryIconInterface = 971,

		XSys_GuildTerritoryMessageInterface = 973,

		XSys_Moba = 979,

		XSys_Friends_Gift_Share,

		XSys_Guild_Bind_Group,

		XSys_Platform_StartPrivilege,

		XSys_Photo_Share,

		XSys_Friends_Pk,

		SYS_IBSHOP_GIFT,

		XSys_Cross_Server_Invite,

		XSys_Rename_Player = 988,

		XSys_Rename_Guild,

		XSys_Rename_DragonGuild = 1001,

		XSys_Exchange = 990,

		XSys_GuildCollectMainInterface,

		XSys_GuildCollect,

		XSys_BackFlowMall,

		XSys_BackFlowWelfare,

		XSys_GuildCollectSummon = 996,

		XSys_DragonGuild = 996,

		XSys_DragonGuildShop,

		XSys_DragonGuildLiveness,

		XSys_DragonGuildTask,

		XSys_DragonGuild_Bind_Group,

		XSys_Num = 1024
	}
}

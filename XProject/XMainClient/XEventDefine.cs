using System;

namespace XMainClient
{
	// Token: 0x02000F40 RID: 3904
	internal enum XEventDefine
	{
		// Token: 0x04005D68 RID: 23912
		XEvent_Invalid = -1,
		// Token: 0x04005D69 RID: 23913
		XEvent_Idle,
		// Token: 0x04005D6A RID: 23914
		XEvent_Move,
		// Token: 0x04005D6B RID: 23915
		XEvent_Jump,
		// Token: 0x04005D6C RID: 23916
		XEvent_Fall,
		// Token: 0x04005D6D RID: 23917
		XEvent_Charge,
		// Token: 0x04005D6E RID: 23918
		XEvent_Freeze,
		// Token: 0x04005D6F RID: 23919
		XEvent_BeHit,
		// Token: 0x04005D70 RID: 23920
		XEvent_Attack,
		// Token: 0x04005D71 RID: 23921
		XEvent_Hit,
		// Token: 0x04005D72 RID: 23922
		XEvent_QTE,
		// Token: 0x04005D73 RID: 23923
		XEvent_OnSkillFired,
		// Token: 0x04005D74 RID: 23924
		XEvent_OnJAPassed,
		// Token: 0x04005D75 RID: 23925
		XEvent_Rotation,
		// Token: 0x04005D76 RID: 23926
		XEvent_Endure,
		// Token: 0x04005D77 RID: 23927
		XEvent_CameraShake,
		// Token: 0x04005D78 RID: 23928
		XEvent_CameraSolo,
		// Token: 0x04005D79 RID: 23929
		XEvent_CameraMotion,
		// Token: 0x04005D7A RID: 23930
		XEvent_CameraMotionEnd,
		// Token: 0x04005D7B RID: 23931
		XEvent_CameraAction,
		// Token: 0x04005D7C RID: 23932
		XEvent_CameraCloseUp,
		// Token: 0x04005D7D RID: 23933
		XEvent_CameraCloseUpEnd,
		// Token: 0x04005D7E RID: 23934
		XEvent_AttackShowBegin,
		// Token: 0x04005D7F RID: 23935
		XEvent_AttackShow,
		// Token: 0x04005D80 RID: 23936
		XEvent_AttackShowEnd,
		// Token: 0x04005D81 RID: 23937
		XEvent_EquipChange,
		// Token: 0x04005D82 RID: 23938
		XEvent_PlaySound,
		// Token: 0x04005D83 RID: 23939
		XEvent_NaviMove,
		// Token: 0x04005D84 RID: 23940
		XEvent_OnEntityCreated,
		// Token: 0x04005D85 RID: 23941
		XEvent_OnEntityDeleted,
		// Token: 0x04005D86 RID: 23942
		XEvent_FadeIn,
		// Token: 0x04005D87 RID: 23943
		XEvent_FadeOut,
		// Token: 0x04005D88 RID: 23944
		XEvent_LoadEquip,
		// Token: 0x04005D89 RID: 23945
		XEvent_UnloadEquip,
		// Token: 0x04005D8A RID: 23946
		XEvent_AddItem,
		// Token: 0x04005D8B RID: 23947
		XEvent_RemoveItem,
		// Token: 0x04005D8C RID: 23948
		XEvent_ItemNumChanged,
		// Token: 0x04005D8D RID: 23949
		XEvent_SwapItem,
		// Token: 0x04005D8E RID: 23950
		XEvent_UpdateItem,
		// Token: 0x04005D8F RID: 23951
		XEvent_VirtualItemChanged,
		// Token: 0x04005D90 RID: 23952
		XEvent_ItemChangeFinished,
		// Token: 0x04005D91 RID: 23953
		XEvent_AIAutoFight,
		// Token: 0x04005D92 RID: 23954
		XEvent_SkillExternal,
		// Token: 0x04005D93 RID: 23955
		XEvent_OnRevived,
		// Token: 0x04005D94 RID: 23956
		XEvent_AIEnterFight,
		// Token: 0x04005D95 RID: 23957
		XEvent_AIRestart,
		// Token: 0x04005D96 RID: 23958
		XEvent_AIStartSkill = 46,
		// Token: 0x04005D97 RID: 23959
		XEvent_AISkillHurt,
		// Token: 0x04005D98 RID: 23960
		XEvent_AIEndSkill,
		// Token: 0x04005D99 RID: 23961
		XEvent_AIStop,
		// Token: 0x04005D9A RID: 23962
		XEvent_AIEvent,
		// Token: 0x04005D9B RID: 23963
		XEvent_GuildPositionChanged = 60,
		// Token: 0x04005D9C RID: 23964
		XEvent_GuildLevelChanged,
		// Token: 0x04005D9D RID: 23965
		XEvent_InGuildStateChanged,
		// Token: 0x04005D9E RID: 23966
		XEvent_GuildInfoChange,
		// Token: 0x04005D9F RID: 23967
		XEvent_FriendInfoChange = 70,
		// Token: 0x04005DA0 RID: 23968
		XEvent_BuffAdd = 100,
		// Token: 0x04005DA1 RID: 23969
		XEvent_BuffRemove,
		// Token: 0x04005DA2 RID: 23970
		XEvent_AttributeChange,
		// Token: 0x04005DA3 RID: 23971
		XEvent_HUDAdd,
		// Token: 0x04005DA4 RID: 23972
		XEvent_RealDead,
		// Token: 0x04005DA5 RID: 23973
		XEvent_LeaveScene,
		// Token: 0x04005DA6 RID: 23974
		XEvent_HUDDoodad,
		// Token: 0x04005DA7 RID: 23975
		XEvent_BuffBillboardAdd,
		// Token: 0x04005DA8 RID: 23976
		XEvent_BuffBillboardRemove,
		// Token: 0x04005DA9 RID: 23977
		XEvent_Bubble,
		// Token: 0x04005DAA RID: 23978
		XEvent_BillboardHide,
		// Token: 0x04005DAB RID: 23979
		XEvent_BillboardShowCtrl,
		// Token: 0x04005DAC RID: 23980
		XEvent_TeamMemberCountChanged = 119,
		// Token: 0x04005DAD RID: 23981
		XEvent_JoinTeam,
		// Token: 0x04005DAE RID: 23982
		XEvent_LeaveTeam,
		// Token: 0x04005DAF RID: 23983
		XEvent_OnReconnected = 123,
		// Token: 0x04005DB0 RID: 23984
		XEvent_SpotOn,
		// Token: 0x04005DB1 RID: 23985
		XEvent_Highlight,
		// Token: 0x04005DB2 RID: 23986
		XEvent_FriendList,
		// Token: 0x04005DB3 RID: 23987
		XEvent_GuildMemberList,
		// Token: 0x04005DB4 RID: 23988
		XEvent_Enmity,
		// Token: 0x04005DB5 RID: 23989
		XEvent_OnEntityTransfer,
		// Token: 0x04005DB6 RID: 23990
		XEvent_ArmorBroken,
		// Token: 0x04005DB7 RID: 23991
		XEvent_ArmorRecover,
		// Token: 0x04005DB8 RID: 23992
		XEvent_WoozyOn,
		// Token: 0x04005DB9 RID: 23993
		XEvent_WoozyOff,
		// Token: 0x04005DBA RID: 23994
		XEvent_StrengthPresevedOn,
		// Token: 0x04005DBB RID: 23995
		XEvent_StrengthPresevedOff,
		// Token: 0x04005DBC RID: 23996
		XEvent_AudioOperation,
		// Token: 0x04005DBD RID: 23997
		XEvent_CoolDownAllSkills,
		// Token: 0x04005DBE RID: 23998
		XEvent_InitCoolDownAllSkills,
		// Token: 0x04005DBF RID: 23999
		XEvent_DesignationInfoChange = 140,
		// Token: 0x04005DC0 RID: 24000
		XEvent_ProjectDamage,
		// Token: 0x04005DC1 RID: 24001
		XEvent_EnableAI,
		// Token: 0x04005DC2 RID: 24002
		XEvent_OnMounted,
		// Token: 0x04005DC3 RID: 24003
		XEvent_OnUnMounted,
		// Token: 0x04005DC4 RID: 24004
		XEvent_TitleChange,
		// Token: 0x04005DC5 RID: 24005
		XEvent_BuffChange,
		// Token: 0x04005DC6 RID: 24006
		XEvent_ComboChange,
		// Token: 0x04005DC7 RID: 24007
		XEvent_Manipulation_On,
		// Token: 0x04005DC8 RID: 24008
		XEvent_Manipulation_Off,
		// Token: 0x04005DC9 RID: 24009
		XEvent_TaskStateChange,
		// Token: 0x04005DCA RID: 24010
		XEvent_DoodadCreate,
		// Token: 0x04005DCB RID: 24011
		XEvent_DoodadDelete,
		// Token: 0x04005DCC RID: 24012
		XEvent_ActivityTaskUpdate,
		// Token: 0x04005DCD RID: 24013
		XEvent_FightGroupChanged,
		// Token: 0x04005DCE RID: 24014
		XEvent_HomeFeasting,
		// Token: 0x04005DCF RID: 24015
		XEvent_BattleEnd,
		// Token: 0x04005DD0 RID: 24016
		XEvent_PlayerLevelChange,
		// Token: 0x04005DD1 RID: 24017
		XEvent_MentorshipRelationOperation,
		// Token: 0x04005DD2 RID: 24018
		XEvent_Prerogative,
		// Token: 0x04005DD3 RID: 24019
		XEvent_NpcFavorFxChange,
		// Token: 0x04005DD4 RID: 24020
		XEvent_DragonGuildInfoChange,
		// Token: 0x04005DD5 RID: 24021
		XEvent_BigMeleePointChange,
		// Token: 0x04005DD6 RID: 24022
		XEvent_BigMeleeEnemyChange,
		// Token: 0x04005DD7 RID: 24023
		XEvent_EntityAttributeChange,
		// Token: 0x04005DD8 RID: 24024
		XEvent_Move_Mob,
		// Token: 0x04005DD9 RID: 24025
		XEvent_Num
	}
}
